using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project_Meoware
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }
        private List<Socket> clientSockets = new List<Socket>();
        private void StartListen(object sender, EventArgs e)
        {
            //Xử lý lỗi InvalidOperationException
            CheckForIllegalCrossThreadCalls = false;
            Thread serverThread = new Thread(new ThreadStart(StartUnsafeThread));
            serverThread.Start();
        }

        private string GetClientOS(Socket socket)
        {
            OperatingSystem os;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                os = Environment.OSVersion;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                var p = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "uname",
                        Arguments = "-s",
                        UseShellExecute = false,
                        RedirectStandardOutput = true
                    }
                };
                p.Start();
                os = new OperatingSystem(PlatformID.Unix, new Version(p.StandardOutput.ReadToEnd().Trim()));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                var p = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "uname",
                        Arguments = "-s",
                        UseShellExecute = false,
                        RedirectStandardOutput = true
                    }
                };
                p.Start();
                os = new OperatingSystem(PlatformID.MacOSX, new Version(p.StandardOutput.ReadToEnd().Trim()));
            }
            else
            {
                os = new OperatingSystem(PlatformID.Other, new Version());
            }
            return os.VersionString;
        }
        void StartUnsafeThread()
        {
            byte[] recv = new byte[1];


            Socket listenerSocket = new Socket(
                       AddressFamily.InterNetwork,
                       SocketType.Stream,
                       ProtocolType.Tcp);

            IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);

            listenerSocket.Bind(ipepServer);

            listenerSocket.Listen(-1);

            while (true)
            {
                Socket clientSocket = listenerSocket.Accept();
                clientSockets.Add(clientSocket); // Add new client to the list

                IPEndPoint clientEndPoint = (IPEndPoint)clientSocket.RemoteEndPoint;
                string clientIP = clientEndPoint.Address.ToString();
                int clientPort = clientEndPoint.Port;

                string clientHostname = Dns.GetHostEntry(clientIP).HostName;


                DateTime connectTime = DateTime.Now;
                string clientOS = GetClientOS(clientSocket);


                listView1.Items.Add(new ListViewItem(new string[] { clientIP, clientHostname, connectTime.ToString("HH:mm:ss"), clientOS }));

                Thread clientThread = new Thread(() => ReceiveMessages(clientSocket, clientIP, clientHostname, connectTime, clientOS));
                clientThread.Start();
            }

        }

        void ReceiveMessages(Socket clientSocket, string clientIP, string clientHostname, DateTime connectTime, string clientOS)
        {
            byte[] dataToSend;
            while (clientSocket.Connected)
            {
                string text = "";
                byte[] recv = new byte[1024];
                do
                {
                    int bytesReceived = clientSocket.Receive(recv);
                    text += Encoding.UTF8.GetString(recv, 0, bytesReceived);
                    if (text == "")
                        break;
                } while (text[text.Length - 1] != '\n');
                if (text == "")
                    break;
                listView1.Text += text;
                // Send message to every client
                dataToSend = Encoding.UTF8.GetBytes(text);
                foreach (Socket socket in clientSockets)
                {
                    if (socket != clientSocket && socket.Connected)
                    {
                        socket.Send(dataToSend);
                    }
                }
            }
            clientSocket.Close();
            clientSockets.Remove(clientSocket); // Remove client from the list when disconnected

            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[0].Text == clientIP)
                {
                    listView1.Items.Remove(item);
                    break;
                }
            }
        }

        private void Listen_Click(object sender, EventArgs e)
        {
            StartListen(sender, e);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string clientIP = selectedItem.SubItems[0].Text;
                string clientHostname = selectedItem.SubItems[1].Text;
                string connectTime = selectedItem.SubItems[2].Text;
                string clientOS = selectedItem.SubItems[3].Text;

                ClientInfo clientInfoForm = new ClientInfo(clientIP, clientHostname, connectTime, clientOS);
                clientInfoForm.Show();
            }
        }
    }
}