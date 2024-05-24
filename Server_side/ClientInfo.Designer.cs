using static Guna.UI2.WinForms.Suite.Descriptions;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Server_side
{
    partial class ClientInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            check = new Button();
            ClientIP = new Label();
            ClientHostname = new Label();
            ConnectTime = new Label();
            ClientOS = new Label();
            richTextBox1 = new RichTextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // check
            // 
            check.Location = new Point(691, 12);
            check.Name = "check";
            check.Size = new Size(189, 95);
            check.TabIndex = 0;
            check.Text = "check";
            check.UseVisualStyleBackColor = true;
            // 
            // ClientIP
            // 
            ClientIP.AutoSize = true;
            ClientIP.Location = new Point(79, 181);
            ClientIP.Name = "ClientIP";
            ClientIP.Size = new Size(21, 20);
            ClientIP.TabIndex = 1;
            ClientIP.Text = "IP";
            // 
            // ClientHostname
            // 
            ClientHostname.AutoSize = true;
            ClientHostname.Location = new Point(79, 255);
            ClientHostname.Name = "ClientHostname";
            ClientHostname.Size = new Size(77, 20);
            ClientHostname.TabIndex = 2;
            ClientHostname.Text = "Hostname";
            // 
            // ConnectTime
            // 
            ConnectTime.AutoSize = true;
            ConnectTime.Location = new Point(79, 336);
            ConnectTime.Name = "ConnectTime";
            ConnectTime.Size = new Size(97, 20);
            ConnectTime.TabIndex = 3;
            ConnectTime.Text = "connect_time";
            // 
            // ClientOS
            // 
            ClientOS.AutoSize = true;
            ClientOS.Location = new Point(91, 385);
            ClientOS.Name = "ClientOS";
            ClientOS.Size = new Size(28, 20);
            ClientOS.TabIndex = 4;
            ClientOS.Text = "OS";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(584, 162);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(614, 418);
            richTextBox1.TabIndex = 5;
            richTextBox1.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(393, 87);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 6;
            label1.Text = "not done yet";
            // 
            // ClientInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1297, 649);
            Controls.Add(label1);
            Controls.Add(richTextBox1);
            Controls.Add(ClientOS);
            Controls.Add(ConnectTime);
            Controls.Add(ClientHostname);
            Controls.Add(ClientIP);
            Controls.Add(check);
            Name = "ClientInfo";
            Text = "ClientInfo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button check;
        private Label ClientIP;
        private Label ClientHostname;
        private Label ConnectTime;
        private Label ClientOS;
        private RichTextBox richTextBox1;
        private Label label1;
    }
}