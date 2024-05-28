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
    public partial class DisplayPSList : Form
    {
        public DisplayPSList(string pslist)
        {
            InitializeComponent();

            // Display the system information to List view
            string[] pslistArray = pslist.Split("\n");
            foreach (string info in pslistArray)
            {
                string[] process = info.Split("--");
                if (process.Length >= 4)
                {
                    ListViewItem item = new ListViewItem(process[0]);
                    item.SubItems.Add(process[1]);
                    item.SubItems.Add(process[2]);
                    item.SubItems.Add(process[3]);
                    pslistListView.Items.Add(item);
                }
            }
        }
    }
}
