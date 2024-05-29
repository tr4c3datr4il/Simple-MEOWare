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
    public partial class DisplayCreds : Form
    {
        public DisplayCreds(string creds)
        {
            InitializeComponent();

            // Display the credentials in the ListView
            string[] lines = creds.Split("\n");
            foreach (string line in lines)
            {
                string[] parts = line.Split("--");
                if (parts.Length >= 3)
                {
                    ListViewItem item = new ListViewItem(parts[0]);
                    item.SubItems.Add(parts[1]);
                    item.SubItems.Add(parts[2]);
                    credListView.Items.Add(item);
                }
            }
        }
    }
}
