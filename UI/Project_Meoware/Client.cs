using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project_Meoware
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            string ipText = "127.0.0.1";
            string portText = "8080";

            client = new TcpClient();
            try
            {
                client.Connect(ipText, int.Parse(portText));
                stream = client.GetStream();
                connected = true;
                MessageBox.Show("Connected to the server!");

                // Start receiving messages in a separate thread
                Task.Run(() => ReceiveMessages());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to the server: " + ex.Message);
            }
        }
        private TcpClient client;
        private NetworkStream stream;
        private bool connected = false;
        private void ReceiveMessages()
        {
            while (connected)
            {
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                richTextBox1.Invoke((MethodInvoker)delegate {
                    richTextBox1.AppendText(receivedMessage);
                    richTextBox1.ScrollToCaret();
                });
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                MessageBox.Show("Not connected to the server!");
                return;
            }

            string ipText = "127.0.0.1";
            string portText = "8080";
            string text = nameText.Text + ": " + mesText.Text;
            text = text.Trim();
            if (text[text.Length - 1] != '\n')
                text += '\n';
            richTextBox1.AppendText(text);
            byte[] data = Encoding.UTF8.GetBytes(text);
            stream.Write(data, 0, data.Length);
        }
    }
}
