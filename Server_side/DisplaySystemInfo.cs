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
    public partial class DisplaySystemInfo : Form
    {
        public DisplaySystemInfo(string systeminfo)
        {
            InitializeComponent();

            // Display the system information to List view
            string[] systeminfoArray = systeminfo.Split("\n");
            foreach (string info in systeminfoArray)
            {
                int colonIndex = info.IndexOf(':');
                if (colonIndex != -1)
                {
                    string key = info.Substring(0, colonIndex).Trim();
                    string value = info.Substring(colonIndex + 1).Trim();
                    ListViewItem item = new ListViewItem(key);
                    item.SubItems.Add(value);
                    systeminfoListView.Items.Add(item);
                }
            }
        }
    }
}
