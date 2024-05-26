using static Guna.UI2.WinForms.Suite.Descriptions;
using System.Xml.Linq;

namespace Server_side.UserControls
{
    partial class UC_Config
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            downloadFolderBox = new TextBox();
            portBox = new TextBox();
            DowloadFolder_lbl = new Label();
            Port_lbl = new Label();
            SaveConfig_btn = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserBtn = new Button();
            label1 = new Label();
            addressBox = new TextBox();
            SuspendLayout();
            // 
            // downloadFolderBox
            // 
            downloadFolderBox.Location = new Point(291, 255);
            downloadFolderBox.Name = "downloadFolderBox";
            downloadFolderBox.Size = new Size(609, 27);
            downloadFolderBox.TabIndex = 0;
            // 
            // portBox
            // 
            portBox.Location = new Point(291, 330);
            portBox.Name = "portBox";
            portBox.Size = new Size(609, 27);
            portBox.TabIndex = 1;
            // 
            // DowloadFolder_lbl
            // 
            DowloadFolder_lbl.AutoSize = true;
            DowloadFolder_lbl.Location = new Point(96, 255);
            DowloadFolder_lbl.Name = "DowloadFolder_lbl";
            DowloadFolder_lbl.Size = new Size(151, 20);
            DowloadFolder_lbl.TabIndex = 4;
            DowloadFolder_lbl.Text = "DOWNLOAD FOLDER";
            // 
            // Port_lbl
            // 
            Port_lbl.AutoSize = true;
            Port_lbl.Location = new Point(96, 337);
            Port_lbl.Name = "Port_lbl";
            Port_lbl.Size = new Size(44, 20);
            Port_lbl.TabIndex = 5;
            Port_lbl.Text = "PORT";
            // 
            // SaveConfig_btn
            // 
            SaveConfig_btn.Location = new Point(1173, 430);
            SaveConfig_btn.Name = "SaveConfig_btn";
            SaveConfig_btn.Size = new Size(157, 83);
            SaveConfig_btn.TabIndex = 8;
            SaveConfig_btn.Text = "Save";
            SaveConfig_btn.UseVisualStyleBackColor = true;
            SaveConfig_btn.Click += SaveConfig_btn_Click;
            // 
            // folderBrowserBtn
            // 
            folderBrowserBtn.Location = new Point(915, 254);
            folderBrowserBtn.Name = "folderBrowserBtn";
            folderBrowserBtn.Size = new Size(42, 29);
            folderBrowserBtn.TabIndex = 9;
            folderBrowserBtn.Text = "...";
            folderBrowserBtn.UseVisualStyleBackColor = true;
            folderBrowserBtn.Click += folderBrowserBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(98, 162);
            label1.Name = "label1";
            label1.Size = new Size(149, 20);
            label1.TabIndex = 10;
            label1.Text = "LISTENING ADDRESS";
            // 
            // addressBox
            // 
            addressBox.Location = new Point(291, 162);
            addressBox.Name = "addressBox";
            addressBox.Size = new Size(609, 27);
            addressBox.TabIndex = 11;
            // 
            // UC_Config
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(addressBox);
            Controls.Add(label1);
            Controls.Add(folderBrowserBtn);
            Controls.Add(SaveConfig_btn);
            Controls.Add(Port_lbl);
            Controls.Add(DowloadFolder_lbl);
            Controls.Add(portBox);
            Controls.Add(downloadFolderBox);
            Name = "UC_Config";
            Size = new Size(1600, 900);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox downloadFolderBox;
        private TextBox portBox;
        private Label DowloadFolder_lbl;
        private Label Port_lbl;
        private Button SaveConfig_btn;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button folderBrowserBtn;
        private Label label1;
        private TextBox addressBox;
    }
}
