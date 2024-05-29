using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_side.UserControls
{
    public partial class UC_BuildAgent : UserControl
    {
        public UC_BuildAgent()
        {
            InitializeComponent();
            addressBox.Text = Program.myConfigs.AppSettings.Settings["ListeningAddress"].Value;
            portBox.Text = Program.myConfigs.AppSettings.Settings["Port"].Value;
        }

        private void BuildAgent()
        {
            bool selfcontained = selfcontainCheckBox.Checked;
            bool singlefile = singlefileCheckBox.Checked;
            bool trimmed = trimmedCheckBox.Checked;
            bool readytorun = r2rCheckBox.Checked;
            string path = folderBox.Text;

            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Please choose a folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string solutionFile = $"{path}\\Client_side.sln";

            string cmd = $"dotnet publish {solutionFile} -c Release -r win-x86 --self-contained {selfcontained.ToString().ToLower()} -p:PublishSingleFile={singlefile.ToString().ToLower()} -p:PublishTrimmed={trimmed.ToString().ToLower()} -p:PublishReadyToRun={readytorun.ToString().ToLower()} -o {path}\\bin\\Release\\net6.0\\publish\\win-x86\\";

            // Configure and start the process
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/C {cmd}";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            string output;
            try
            {
                process.Start();
                output = process.StandardOutput.ReadToEnd();
                string errorOutput = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    output += "\nERROR:\n" + errorOutput;
                }

                process.Close();
            }
            catch (Exception ex)
            {
                output = "Exception occurred: " + ex.Message;
            }

            logBox.Text = output;
        }

        private void chooseFolderBtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            folderBox.Text = folderBrowserDialog1.SelectedPath;
        }

        private void buildBtn_Click(object sender, EventArgs e)
        {
            logBox.Clear();  
            BuildAgent();
        }
    }
}
