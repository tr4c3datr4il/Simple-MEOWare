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
            // Lấy thông tin cấu hình từ file app.config
            string downloadFolder = ConfigurationManager.AppSettings["DownloadFolder"];
            int port = int.Parse(ConfigurationManager.AppSettings["Port"]);
            string databaseServer = ConfigurationManager.AppSettings["DatabaseServer"];
            string databaseName = ConfigurationManager.AppSettings["DatabaseName"];

            // Hiển thị các thông tin cấu hình lên form
            txtDownloadFolder.Text = downloadFolder;
            txtPort.Text = port.ToString();
            txtDatabaseServer.Text = databaseServer;
            txtDatabaseName.Text = databaseName;
        }

        private void SaveConfig_btn_Click(object sender, EventArgs e)
        {
            // Lưu lại các thay đổi cấu hình
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["DownloadFolder"].Value = txtDownloadFolder.Text;
            config.AppSettings.Settings["Port"].Value = txtPort.Text;
            config.AppSettings.Settings["DatabaseServer"].Value = txtDatabaseServer.Text;
            config.AppSettings.Settings["DatabaseName"].Value = txtDatabaseName.Text;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
