﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Server_side.UserControls
{
    public partial class UC_Server : UserControl
    {
        public UC_Server()
        {
            InitializeComponent();
            NetworkLayer.OnClientConnected += AddClientToListView;
        }

        private void StartListen(object sender, EventArgs e)
        {
            NetworkLayer.StartUnsafeThread();
        }

        private void Listen_Click(object sender, EventArgs e)
        {
            StartListen(sender, e);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (clientListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = clientListView.SelectedItems[0];
                string clientIP = selectedItem.SubItems[1].Text;
                string clientHostname = selectedItem.SubItems[2].Text;
                string connectTime = selectedItem.SubItems[3].Text;
                string clientOS = selectedItem.SubItems[4].Text;

                ClientInfo clientInfoForm = new ClientInfo(clientIP, clientHostname, connectTime, clientOS);
                clientInfoForm.Show();
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            NetworkLayer.StopUnsafeThread();
        }

        private void AddClientToListView(string clientIP, string clientHostname, string connectTime, string clientOS)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string, string, string, string>(AddClientToListView), clientIP, clientHostname, connectTime, clientOS);
                return;
            }

            ListViewItem item = new ListViewItem(new[] { "Click", clientIP, clientHostname, connectTime, clientOS });
            clientListView.Items.Add(item);
        }
    }

}
