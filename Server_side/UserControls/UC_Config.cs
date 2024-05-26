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
            string downloadFolder = ConfigurationManager.AppSettings["DownloadFolder"];
            int port = int.Parse(ConfigurationManager.AppSettings["Port"]);

            txtDownloadFolder.Text = downloadFolder;
            txtPort.Text = port.ToString();
        }

        private void SaveConfig_btn_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["DownloadFolder"].Value = txtDownloadFolder.Text;
            config.AppSettings.Settings["Port"].Value = txtPort.Text;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
