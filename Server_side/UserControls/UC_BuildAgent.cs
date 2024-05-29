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
            this.Load += new EventHandler(UC_BuildAgent_Load);
        }

        private void UC_BuildAgent_Load(object sender, EventArgs e)
        {
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
            string utilFile = $"{path}\\Utils.cs";

            // Replace IP address and port in Utils.cs
            string[] lines = System.IO.File.ReadAllLines(utilFile);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("IP"))
                {
                    lines[i] = $"        public static string IP = \"{addressBox.Text}\";";
                }
                else if (lines[i].Contains("PORT"))
                {
                    lines[i] = $"        public static int PORT = {portBox.Text};";
                }
            }

            System.IO.File.WriteAllLines(utilFile, lines);


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
