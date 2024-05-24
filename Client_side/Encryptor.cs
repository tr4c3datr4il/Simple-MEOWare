using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Client_side
{
    internal class Encryptor
    {
        private byte[] Key;
        private byte[] IV;

        public static string ConvertStr(string s)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
        }

        public static string InvertStr(string s)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(s));
        }

        public Encryptor()
        {
        }

        public Encryptor(string passwd)
        {
            byte[] salt = Hasher(passwd);
            using (Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(passwd, salt, 13337))
            {
                this.Key = rfc.GetBytes(32);
                this.IV = rfc.GetBytes(16);
            }
        }

        public byte[] Encrypt(string msg)
        {
            using (AesManaged aes = new AesManaged())
            {
                aes.Key = this.Key;
                aes.IV = this.IV;
                aes.BlockSize = 128;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(msg);
                        cryptoStream.Write(bytes, 0, bytes.Length);
                    }
                    return memoryStream.ToArray();
                }
            }
        }

        public byte[] Encrypt(byte[] msg)
        {
            using (AesManaged aes = new AesManaged())
            {
                aes.Key = this.Key;
                aes.IV = this.IV;
                aes.BlockSize = 128;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(msg, 0, msg.Length);
                    }
                    return memoryStream.ToArray();
                }
            }
        }

        public string Decrypt(string msg)
        {
            using (AesManaged aes = new AesManaged())
            {
                aes.Key = this.Key;
                aes.IV = this.IV;
                aes.BlockSize = 128;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(msg)))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        byte[] array = new byte[msg.Length];
                        cryptoStream.Read(array, 0, array.Length);
                        return Encoding.UTF8.GetString(array);
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
                aes.BlockSize = 128;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                using (MemoryStream memoryStream = new MemoryStream(msg))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        byte[] array = new byte[msg.Length];
                        cryptoStream.Read(array, 0, array.Length);
                        return Encoding.UTF8.GetString(array);
                    }
                }
            }
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
