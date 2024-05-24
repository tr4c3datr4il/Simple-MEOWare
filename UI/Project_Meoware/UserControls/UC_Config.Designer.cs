namespace Project_Meoware.UserControls
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
            txtDownloadFolder = new TextBox();
            txtPort = new TextBox();
            txtDatabaseServer = new TextBox();
            txtDatabaseName = new TextBox();
            DowloadFolder_lbl = new Label();
            Port_lbl = new Label();
            DBServer_lbl = new Label();
            DBServerName_lbl = new Label();
            SaveConfig_btn = new Button();
            SuspendLayout();
            // 
            // txtDownloadFolder
            // 
            txtDownloadFolder.Location = new Point(283, 119);
            txtDownloadFolder.Name = "txtDownloadFolder";
            txtDownloadFolder.Size = new Size(609, 27);
            txtDownloadFolder.TabIndex = 0;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(283, 194);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(609, 27);
            txtPort.TabIndex = 1;
            // 
            // txtDatabaseServer
            // 
            txtDatabaseServer.Location = new Point(283, 274);
            txtDatabaseServer.Name = "txtDatabaseServer";
            txtDatabaseServer.Size = new Size(609, 27);
            txtDatabaseServer.TabIndex = 2;
            // 
            // txtDatabaseName
            // 
            txtDatabaseName.Location = new Point(283, 356);
            txtDatabaseName.Name = "txtDatabaseName";
            txtDatabaseName.Size = new Size(609, 27);
            txtDatabaseName.TabIndex = 3;
            // 
            // DowloadFolder_lbl
            // 
            DowloadFolder_lbl.AutoSize = true;
            DowloadFolder_lbl.Location = new Point(88, 119);
            DowloadFolder_lbl.Name = "DowloadFolder_lbl";
            DowloadFolder_lbl.Size = new Size(114, 20);
            DowloadFolder_lbl.TabIndex = 4;
            DowloadFolder_lbl.Text = "Dowload folder";
            // 
            // Port_lbl
            // 
            Port_lbl.AutoSize = true;
            Port_lbl.Location = new Point(88, 201);
            Port_lbl.Name = "Port_lbl";
            Port_lbl.Size = new Size(35, 20);
            Port_lbl.TabIndex = 5;
            Port_lbl.Text = "Port";
            // 
            // DBServer_lbl
            // 
            DBServer_lbl.AutoSize = true;
            DBServer_lbl.Location = new Point(88, 281);
            DBServer_lbl.Name = "DBServer_lbl";
            DBServer_lbl.Size = new Size(117, 20);
            DBServer_lbl.TabIndex = 6;
            DBServer_lbl.Text = "Database Server";
            // 
            // DBServerName_lbl
            // 
            DBServerName_lbl.AutoSize = true;
            DBServerName_lbl.Location = new Point(88, 359);
            DBServerName_lbl.Name = "DBServerName_lbl";
            DBServerName_lbl.Size = new Size(161, 20);
            DBServerName_lbl.TabIndex = 7;
            DBServerName_lbl.Text = "Database Server Name";
            // 
            // SaveConfig_btn
            // 
            SaveConfig_btn.Location = new Point(1023, 201);
            SaveConfig_btn.Name = "SaveConfig_btn";
            SaveConfig_btn.Size = new Size(231, 110);
            SaveConfig_btn.TabIndex = 8;
            SaveConfig_btn.Text = "Save";
            SaveConfig_btn.UseVisualStyleBackColor = true;
            SaveConfig_btn.Click += SaveConfig_btn_Click;
            // 
            // UC_Config
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(SaveConfig_btn);
            Controls.Add(DBServerName_lbl);
            Controls.Add(DBServer_lbl);
            Controls.Add(Port_lbl);
            Controls.Add(DowloadFolder_lbl);
            Controls.Add(txtDatabaseName);
            Controls.Add(txtDatabaseServer);
            Controls.Add(txtPort);
            Controls.Add(txtDownloadFolder);
            Name = "UC_Config";
            Size = new Size(1839, 861);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDownloadFolder;
        private TextBox txtPort;
        private TextBox txtDatabaseServer;
        private TextBox txtDatabaseName;
        private Label DowloadFolder_lbl;
        private Label Port_lbl;
        private Label DBServer_lbl;
        private Label DBServerName_lbl;
        private Button SaveConfig_btn;
    }
}
