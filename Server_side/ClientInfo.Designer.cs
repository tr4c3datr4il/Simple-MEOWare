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
            sendCommandBtn2 = new Button();
            ClientIP = new Label();
            ClientHostname = new Label();
            ConnectTime = new Label();
            ClientOS = new Label();
            agentLogBox = new RichTextBox();
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
            agentfileBox = new TextBox();
            label5 = new Label();
            groupBox2 = new GroupBox();
            sendCommandBtn1 = new Button();
            pidBox = new TextBox();
            label1 = new Label();
            groupBox3 = new GroupBox();
            clearLogBtn = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // sendCommandBtn2
            // 
            sendCommandBtn2.Location = new Point(1120, 26);
            sendCommandBtn2.Name = "sendCommandBtn2";
            sendCommandBtn2.Size = new Size(148, 56);
            sendCommandBtn2.TabIndex = 0;
            sendCommandBtn2.Text = "Send";
            sendCommandBtn2.UseVisualStyleBackColor = true;
            sendCommandBtn2.Click += sendCommandBtn_Click;
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
            commandBox.Location = new Point(6, 55);
            commandBox.Name = "commandBox";
            commandBox.Size = new Size(905, 27);
            commandBox.TabIndex = 8;
            // 
            // cmdComboBox
            // 
            cmdComboBox.AllowDrop = true;
            cmdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cmdComboBox.FormattingEnabled = true;
            cmdComboBox.Location = new Point(7, 37);
            cmdComboBox.Name = "cmdComboBox";
            cmdComboBox.Size = new Size(222, 28);
            cmdComboBox.TabIndex = 9;
            // 
            // agentfileBox
            // 
            agentfileBox.Location = new Point(6, 113);
            agentfileBox.Name = "agentfileBox";
            agentfileBox.Size = new Size(905, 27);
            agentfileBox.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(0, 90);
            label5.Name = "label5";
            label5.Size = new Size(118, 20);
            label5.TabIndex = 11;
            label5.Text = "File Path (Agent)";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(commandBox);
            groupBox2.Controls.Add(sendCommandBtn2);
            groupBox2.Location = new Point(11, 766);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1274, 99);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Command Prompt CMD";
            // 
            // sendCommandBtn1
            // 
            sendCommandBtn1.Location = new Point(1120, 154);
            sendCommandBtn1.Name = "sendCommandBtn1";
            sendCommandBtn1.Size = new Size(148, 56);
            sendCommandBtn1.TabIndex = 9;
            sendCommandBtn1.Text = "Send";
            sendCommandBtn1.UseVisualStyleBackColor = true;
            sendCommandBtn1.Click += sendCommandBtn1_Click;
            // 
            // pidBox
            // 
            pidBox.Location = new Point(6, 183);
            pidBox.Name = "pidBox";
            pidBox.Size = new Size(125, 27);
            pidBox.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1, 160);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 14;
            label1.Text = "Process ID";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cmdComboBox);
            groupBox3.Controls.Add(sendCommandBtn1);
            groupBox3.Controls.Add(pidBox);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(agentfileBox);
            groupBox3.Location = new Point(11, 464);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1274, 225);
            groupBox3.TabIndex = 15;
            groupBox3.TabStop = false;
            groupBox3.Text = "Built-in Commands";
            // 
            // clearLogBtn
            // 
            clearLogBtn.Location = new Point(506, 405);
            clearLogBtn.Name = "clearLogBtn";
            clearLogBtn.Size = new Size(72, 29);
            clearLogBtn.TabIndex = 15;
            clearLogBtn.Text = "Clear";
            clearLogBtn.UseVisualStyleBackColor = true;
            clearLogBtn.Click += clearLogBtn_Click;
            // 
            // ClientInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1297, 877);
            Controls.Add(clearLogBtn);
            Controls.Add(agentLogBox);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            Name = "ClientInfo";
            Text = "Client Interact";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button sendCommandBtn2;
        private Label ClientIP;
        private Label ClientHostname;
        private Label ConnectTime;
        private Label ClientOS;
        private RichTextBox agentLogBox;
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
        private TextBox agentfileBox;
        private Label label5;
        private GroupBox groupBox2;
        private Button sendCommandBtn1;
        private TextBox pidBox;
        private Label label1;
        private GroupBox groupBox3;
        private Button clearLogBtn;
    }
}