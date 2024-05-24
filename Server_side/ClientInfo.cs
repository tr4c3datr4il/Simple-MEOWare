using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            ClientIP.Text = clientIP;
            ClientHostname.Text = clientHostname;
            ConnectTime.Text = connectTime;
            ClientOS.Text = clientOS;
        }

    }
}
