using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Client_side
{
    internal class NetworkLayer
    {
        private static readonly RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
        private static Encryptor stageEncryptor = new();

        public static void Connect(string ip, int port)
        {
            Program.clientSocket.Connect(ip, port);
        }

        public static void SendResult(byte[] msg)
        {
            Program.clientSocket.Send(msg, 0, msg.Length, SocketFlags.None);
        }

        public static void SendResult(string msg)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            Program.clientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        public static byte[] ReceiveCommand()
        {
            byte[] buffer = new byte[Program.clientSocket.ReceiveBufferSize];
            int bytesRead = Program.clientSocket.Receive(buffer);
            byte[] data = new byte[bytesRead];
            for (int i = 0; i < bytesRead; i++)
            {
                data[i] = buffer[i];
            }
            
            return data;
        }


        // Initialize the connection by sending the public key
        public static void SendPublicKey()
        {
            byte[] publicKey = rsa.ExportSubjectPublicKeyInfo();
            string publicKey64 = Encryptor.ConvertStr(publicKey);
            byte[] encryptedData = stageEncryptor.Encrypt(publicKey64);

            Program.clientSocket.Send(encryptedData);
        }

        public static string ReceivePassPhrase()
        {
            byte[] recvBuffer = new byte[4096];
            int bytesRead = Program.clientSocket.Receive(recvBuffer);
            byte[] encryptedData = new byte[bytesRead];
            Array.Copy(recvBuffer, encryptedData, bytesRead);
            string encryptedData64 = stageEncryptor.Decrypt(encryptedData);
            byte[] encryptedPassPhrase = Encryptor.InvertStr(encryptedData64);
            string passPhrase = Encoding.UTF8.GetString(rsa.Decrypt(encryptedPassPhrase, true));

            return passPhrase;
        }
    }

}
