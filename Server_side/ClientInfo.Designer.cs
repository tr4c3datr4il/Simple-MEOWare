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
            sendCommandBtn = new Button();
            ClientIP = new Label();
            ClientHostname = new Label();
            ConnectTime = new Label();
            ClientOS = new Label();
            agentLogBox = new RichTextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            passLabel = new Label();
            ivLabel = new Label();
            keyLabel = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            osLabel = new Label();
            contimeLabel = new Label();
            hostnameLabel = new Label();
            ipLabel = new Label();
            commandBox = new TextBox();
            cmdComboBox = new ComboBox();
            textBox1 = new TextBox();
            label5 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // sendCommandBtn
            // 
            sendCommandBtn.Location = new Point(1137, 579);
            sendCommandBtn.Name = "sendCommandBtn";
            sendCommandBtn.Size = new Size(148, 56);
            sendCommandBtn.TabIndex = 0;
            sendCommandBtn.Text = "Send";
            sendCommandBtn.UseVisualStyleBackColor = true;
            sendCommandBtn.Click += sendCommandBtn_Click;
            // 
            // ClientIP
            // 
            ClientIP.AutoSize = true;
            ClientIP.Location = new Point(6, 27);
            ClientIP.Name = "ClientIP";
            ClientIP.Size = new Size(21, 20);
            ClientIP.TabIndex = 1;
            ClientIP.Text = "IP";
            // 
            // ClientHostname
            // 
            ClientHostname.AutoSize = true;
            ClientHostname.Location = new Point(6, 63);
            ClientHostname.Name = "ClientHostname";
            ClientHostname.Size = new Size(77, 20);
            ClientHostname.TabIndex = 2;
            ClientHostname.Text = "Hostname";
            // 
            // ConnectTime
            // 
            ConnectTime.AutoSize = true;
            ConnectTime.Location = new Point(6, 99);
            ConnectTime.Name = "ConnectTime";
            ConnectTime.Size = new Size(100, 20);
            ConnectTime.TabIndex = 3;
            ConnectTime.Text = "Connect Time";
            // 
            // ClientOS
            // 
            ClientOS.AutoSize = true;
            ClientOS.Location = new Point(6, 141);
            ClientOS.Name = "ClientOS";
            ClientOS.Size = new Size(28, 20);
            ClientOS.TabIndex = 4;
            ClientOS.Text = "OS";
            // 
            // agentLogBox
            // 
            agentLogBox.Location = new Point(584, 16);
            agentLogBox.Name = "agentLogBox";
            agentLogBox.ReadOnly = true;
            agentLogBox.Size = new Size(701, 418);
            agentLogBox.TabIndex = 5;
            agentLogBox.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 585);
            label1.Name = "label1";
            label1.Size = new Size(131, 20);
            label1.TabIndex = 6;
            label1.Text = "Command Prompt";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(passLabel);
            groupBox1.Controls.Add(ivLabel);
            groupBox1.Controls.Add(keyLabel);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(osLabel);
            groupBox1.Controls.Add(contimeLabel);
            groupBox1.Controls.Add(hostnameLabel);
            groupBox1.Controls.Add(ipLabel);
            groupBox1.Controls.Add(ClientIP);
            groupBox1.Controls.Add(ClientHostname);
            groupBox1.Controls.Add(ClientOS);
            groupBox1.Controls.Add(ConnectTime);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(566, 294);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Agent Infomation";
            // 
            // passLabel
            // 
            passLabel.AutoSize = true;
            passLabel.Location = new Point(100, 256);
            passLabel.Name = "passLabel";
            passLabel.Size = new Size(45, 20);
            passLabel.TabIndex = 18;
            passLabel.Text = "None";
            // 
            // ivLabel
            // 
            ivLabel.AutoSize = true;
            ivLabel.Location = new Point(100, 224);
            ivLabel.Name = "ivLabel";
            ivLabel.Size = new Size(45, 20);
            ivLabel.TabIndex = 17;
            ivLabel.Text = "None";
            // 
            // keyLabel
            // 
            keyLabel.AutoSize = true;
            keyLabel.Location = new Point(100, 191);
            keyLabel.Name = "keyLabel";
            keyLabel.Size = new Size(45, 20);
            keyLabel.TabIndex = 16;
            keyLabel.Text = "None";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 256);
            label4.Name = "label4";
            label4.Size = new Size(36, 20);
            label4.TabIndex = 15;
            label4.Text = "Pass";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 224);
            label3.Name = "label3";
            label3.Size = new Size(22, 20);
            label3.TabIndex = 14;
            label3.Text = "IV";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 191);
            label2.Name = "label2";
            label2.Size = new Size(33, 20);
            label2.TabIndex = 13;
            label2.Text = "Key";
            // 
            // osLabel
            // 
            osLabel.AutoSize = true;
            osLabel.Location = new Point(178, 141);
            osLabel.Name = "osLabel";
            osLabel.Size = new Size(45, 20);
            osLabel.TabIndex = 12;
            osLabel.Text = "None";
            // 
            // contimeLabel
            // 
            contimeLabel.AutoSize = true;
            contimeLabel.Location = new Point(178, 99);
            contimeLabel.Name = "contimeLabel";
            contimeLabel.Size = new Size(45, 20);
            contimeLabel.TabIndex = 11;
            contimeLabel.Text = "None";
            // 
            // hostnameLabel
            // 
            hostnameLabel.AutoSize = true;
            hostnameLabel.Location = new Point(178, 63);
            hostnameLabel.Name = "hostnameLabel";
            hostnameLabel.Size = new Size(45, 20);
            hostnameLabel.TabIndex = 10;
            hostnameLabel.Text = "None";
            // 
            // ipLabel
            // 
            ipLabel.AutoSize = true;
            ipLabel.Location = new Point(178, 27);
            ipLabel.Name = "ipLabel";
            ipLabel.Size = new Size(45, 20);
            ipLabel.TabIndex = 9;
            ipLabel.Text = "None";
            // 
            // commandBox
            // 
            commandBox.Location = new Point(11, 608);
            commandBox.Name = "commandBox";
            commandBox.Size = new Size(845, 27);
            commandBox.TabIndex = 8;
            // 
            // cmdComboBox
            // 
            cmdComboBox.FormattingEnabled = true;
            cmdComboBox.Location = new Point(11, 444);
            cmdComboBox.Name = "cmdComboBox";
            cmdComboBox.Size = new Size(151, 28);
            cmdComboBox.TabIndex = 9;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(11, 478);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(845, 27);
            textBox1.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 421);
            label5.Name = "label5";
            label5.Size = new Size(136, 20);
            label5.TabIndex = 11;
            label5.Text = "Built-in Commands";
            // 
            // ClientInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1297, 659);
            Controls.Add(label5);
            Controls.Add(textBox1);
            Controls.Add(cmdComboBox);
            Controls.Add(commandBox);
            Controls.Add(label1);
            Controls.Add(agentLogBox);
            Controls.Add(sendCommandBtn);
            Controls.Add(groupBox1);
            Name = "ClientInfo";
            Text = "ClientInfo";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button sendCommandBtn;
        private Label ClientIP;
        private Label ClientHostname;
        private Label ConnectTime;
        private Label ClientOS;
        private RichTextBox agentLogBox;
        private Label label1;
        private GroupBox groupBox1;
        private TextBox commandBox;
        private Label osLabel;
        private Label contimeLabel;
        private Label hostnameLabel;
        private Label ipLabel;
        private Label passLabel;
        private Label ivLabel;
        private Label keyLabel;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox cmdComboBox;
        private TextBox textBox1;
        private Label label5;
    }
}