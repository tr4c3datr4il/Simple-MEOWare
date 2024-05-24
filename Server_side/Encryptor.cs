using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Server_side
{
    internal class Encryptor
    {
        private byte[] Key;
        private byte[] IV;

        public static string ConvertStr(string s)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
        }

        public static string ConvertStr(byte[] s)
        {
            return Convert.ToBase64String(s);
        }

        public static string InvertStr(string s)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(s));
        }

        public static byte[] InvertStr(byte[] s)
        {
            return Convert.FromBase64String(Encoding.UTF8.GetString(s));
        }

        public Encryptor(string passwd)
        {
            byte[] salt = Hasher(passwd);
            using (Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(passwd, salt, 13337))
            {
                this.Key = rfc.GetBytes(32);
                this.IV = rfc.GetBytes(16);

                Console.WriteLine("Key: " + Convert.ToBase64String(this.Key));
                Console.WriteLine("IV: " + Convert.ToBase64String(this.IV));
            }
        }

        public byte[] Encrypt(string msg)
        {
            using (AesManaged aes = new AesManaged())
            {
                aes.Key = this.Key;
                aes.IV = this.IV;

                ICryptoTransform enc = aes.CreateEncryptor();
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, enc, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(msg);
                        }
                    }
                    return ms.ToArray();
                }
            }
        }

        public byte[] Encrypt(byte[] msg)
        {
            using (AesManaged aes = new AesManaged())
            {
                aes.Key = this.Key;
                aes.IV = this.IV;

                ICryptoTransform enc = aes.CreateEncryptor();
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, enc, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(msg);
                        }
                    }
                    return ms.ToArray();
                }
            }
        }

        public string Decrypt(string msg)
        {
            using (AesManaged aes = new AesManaged())
            {
                aes.Key = this.Key;
                aes.IV = this.IV;

                ICryptoTransform dec = aes.CreateDecryptor();
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(msg)))
                {
                    using (CryptoStream cs = new CryptoStream(ms, dec, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }

        public string Decrypt(byte[] msg)
        {
            using (AesManaged aes = new AesManaged())
            {
                aes.Key = this.Key;
                aes.IV = this.IV;

                ICryptoTransform dec = aes.CreateDecryptor();
                using (MemoryStream ms = new MemoryStream(msg))
                {
                    using (CryptoStream cs = new CryptoStream(ms, dec, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }

        public string GetKey()
        {
            return Convert.ToBase64String(this.Key);
        }

        public string GetIV()
        {
            return Convert.ToBase64String(this.IV);
        }

        private byte[] Hasher(string s)
        {
            using (SHA256Managed sha256Managed = new SHA256Managed())
            {
                return sha256Managed.ComputeHash(Encoding.UTF8.GetBytes(s));
            }
        }
    }
}
