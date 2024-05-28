using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Server_side
{
    internal class NetworkLayer
    {
        private static readonly RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
        private static Task listeningTask;
        private static bool isListening = false;
        public static List<Dictionary<Socket, string>> clientList = new List<Dictionary<Socket, string>>();
        public static event Action<string, string, string, string> OnClientConnected;

        public static void StartUnsafeThread()
        {
            listeningTask = Task.Run(() =>
            {
                try
                {
                    StartListening();
                }
                catch (Exception e)
                {
                    // Temporary fix for the disposed object error
                    if (e.Message.Contains("cannot access a disposed object"))
                    {
                        Program.listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        StartListening();
                    }
                }
            });
        }

        public static void StopUnsafeThread()
        {
            if (isListening)
            {
                Program.listenerSocket?.Close();
                isListening = false;
                MessageBox.Show("Server stopped", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static void StartListening()
        {
            if (isListening)
            {
                MessageBox.Show("Server is already running", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IPAddress ipAddress = IPAddress.Parse(Program.myConfigs.AppSettings.Settings["ListeningAddress"].Value);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, int.Parse(Program.myConfigs.AppSettings.Settings["Port"].Value));
            Program.listenerSocket.Bind(localEndPoint);
            Program.listenerSocket.Listen(100);
            MessageBox.Show("Server started", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            isListening = true;

            while (true)
            {
                try
                {
                    Socket clientSocket = Program.listenerSocket.Accept();
                    ReceivePublicKey(clientSocket);
                    SendPassPhrase(clientSocket);

                    string clientIP = ((IPEndPoint)clientSocket.RemoteEndPoint).Address.ToString();
                    string port = ((IPEndPoint)clientSocket.RemoteEndPoint).Port.ToString();
                    string clientIPPort = $"{clientIP}:{port}";
                    string clientHostname = Dns.GetHostEntry(clientIP).HostName;
                    string connectTime = DateTime.Now.ToString();
                    string clientOS = "";

                    OnClientConnected?.Invoke(clientIPPort, clientHostname, connectTime, clientOS);
                }
                catch (ObjectDisposedException)
                {
                    break;
                }
                catch (Exception e)
                {
                    if (isListening)
                    {
                        MessageBox.Show("Error in StartListening loop: " + e.Message);
                    }
                }
                
            }
        }

        public static void Send(Socket socket, byte[] data)
        {
            socket.Send(data);
        }

        public static void Receive(Socket socket, byte[] data)
        {
            int bytesRead = socket.Receive(data);
            Array.Resize(ref data, bytesRead);
        }

        public static byte[] ReceiveResult(Socket socket)
        {
            byte[] buffer = new byte[Program.listenerSocket.ReceiveBufferSize];
            int bytesRead = socket.Receive(buffer);
            byte[] data = new byte[bytesRead];
            for (int i = 0; i < bytesRead; i++)
            {
                data[i] = buffer[i];
            }

            return data;
        }

        public static bool SocketConnected(Socket socket)
        {
            bool part1 = socket.Poll(1000, SelectMode.SelectRead);
            bool part2 = (socket.Available == 0);
            if (part1 && part2)
                return false;
            else
                return true;
        }

        // Initialize the connection with the client
        public static void ReceivePublicKey(Socket socket)
        {
            try
            {
                byte[] data = new byte[4096];
                Receive(socket, data);
                rsa.ImportSubjectPublicKeyInfo(data, out _);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error in ReceivePublicKey: " + e.Message);
                throw;
            }
        }

        public static void SendPassPhrase(Socket socket)
        {
            try
            {
                string passPhrase = RandomString(32);
                byte[] data = Encoding.UTF8.GetBytes(passPhrase);
                byte[] encryptedData = rsa.Encrypt(data, true);
                Send(socket, encryptedData);

                Dictionary<Socket, string> client = new Dictionary<Socket, string>
                {
                    { socket, passPhrase }
                };
                clientList.Add(client);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error in SendPassPhrase: " + e.Message);
                throw;
            }
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[new Random().Next(s.Length)]).ToArray());
        }
    }

}
