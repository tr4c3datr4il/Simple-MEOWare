using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Server_side.UserControls
{
    public partial class UC_Config : UserControl
    {
        public UC_Config()
        {
            InitializeComponent();
            LoadServerConfig();
        }

        private void LoadServerConfig()
        {
            string listenIP = ConfigurationManager.AppSettings["ListeningAddress"];
            string downloadFolder = ConfigurationManager.AppSettings["DownloadFolder"];
            int port = int.Parse(ConfigurationManager.AppSettings["Port"]);

            addressBox.Text = listenIP;
            downloadFolderBox.Text = downloadFolder;
            portBox.Text = port.ToString();
        }

        private void SaveConfig_btn_Click(object sender, EventArgs e)
        {
            Program.myConfigs.AppSettings.Settings["ListeningAddress"].Value = addressBox.Text;
            Program.myConfigs.AppSettings.Settings["DownloadFolder"].Value = downloadFolderBox.Text;
            Program.myConfigs.AppSettings.Settings["Port"].Value = portBox.Text;
            Program.myConfigs.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show("Config saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void folderBrowserBtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            downloadFolderBox.Text = folderBrowserDialog1.SelectedPath;
        }
    }
}
