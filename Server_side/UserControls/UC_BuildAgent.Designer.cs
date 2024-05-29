using static Guna.UI2.WinForms.Suite.Descriptions;
using System.Xml.Linq;

namespace Server_side.UserControls
{
    partial class UC_BuildAgent
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
            linuxBuildBtn = new RadioButton();
            windowsBuildBtn = new RadioButton();
            buildBtn = new Button();
            groupBox1 = new GroupBox();
            addressBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            portBox = new TextBox();
            selfcontainCheckBox = new CheckBox();
            singlefileCheckBox = new CheckBox();
            trimmedCheckBox = new CheckBox();
            r2rCheckBox = new CheckBox();
            groupBox2 = new GroupBox();
            logBox = new RichTextBox();
            folderBox = new TextBox();
            chooseFolderBtn = new Button();
            label3 = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // linuxBuildBtn
            // 
            linuxBuildBtn.AutoSize = true;
            linuxBuildBtn.Location = new Point(34, 30);
            linuxBuildBtn.Name = "linuxBuildBtn";
            linuxBuildBtn.Size = new Size(64, 24);
            linuxBuildBtn.TabIndex = 0;
            linuxBuildBtn.TabStop = true;
            linuxBuildBtn.Text = "Linux";
            linuxBuildBtn.UseVisualStyleBackColor = true;
            // 
            // windowsBuildBtn
            // 
            windowsBuildBtn.AutoSize = true;
            windowsBuildBtn.Location = new Point(34, 71);
            windowsBuildBtn.Name = "windowsBuildBtn";
            windowsBuildBtn.Size = new Size(91, 24);
            windowsBuildBtn.TabIndex = 1;
            windowsBuildBtn.TabStop = true;
            windowsBuildBtn.Text = "Windows";
            windowsBuildBtn.UseVisualStyleBackColor = true;
            // 
            // buildBtn
            // 
            buildBtn.Location = new Point(1317, 762);
            buildBtn.Name = "buildBtn";
            buildBtn.Size = new Size(137, 65);
            buildBtn.TabIndex = 2;
            buildBtn.Text = "Build";
            buildBtn.UseVisualStyleBackColor = true;
            buildBtn.Click += buildBtn_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(windowsBuildBtn);
            groupBox1.Controls.Add(linuxBuildBtn);
            groupBox1.Location = new Point(99, 68);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(194, 117);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Operating System";
            // 
            // addressBox
            // 
            addressBox.Location = new Point(410, 91);
            addressBox.Name = "addressBox";
            addressBox.Size = new Size(125, 27);
            addressBox.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(410, 68);
            label1.Name = "label1";
            label1.Size = new Size(120, 20);
            label1.TabIndex = 6;
            label1.Text = "Connect Address";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(410, 141);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 8;
            label2.Text = "Connect Port";
            // 
            // portBox
            // 
            portBox.Location = new Point(410, 164);
            portBox.Name = "portBox";
            portBox.ReadOnly = true;
            portBox.Size = new Size(125, 27);
            portBox.TabIndex = 7;
            // 
            // selfcontainCheckBox
            // 
            selfcontainCheckBox.AutoSize = true;
            selfcontainCheckBox.Location = new Point(119, 286);
            selfcontainCheckBox.Name = "selfcontainCheckBox";
            selfcontainCheckBox.Size = new Size(128, 24);
            selfcontainCheckBox.TabIndex = 9;
            selfcontainCheckBox.Text = "Self Contained";
            selfcontainCheckBox.UseVisualStyleBackColor = true;
            // 
            // singlefileCheckBox
            // 
            singlefileCheckBox.AutoSize = true;
            singlefileCheckBox.Location = new Point(119, 328);
            singlefileCheckBox.Name = "singlefileCheckBox";
            singlefileCheckBox.Size = new Size(150, 24);
            singlefileCheckBox.TabIndex = 10;
            singlefileCheckBox.Text = "Publish Single File";
            singlefileCheckBox.UseVisualStyleBackColor = true;
            // 
            // trimmedCheckBox
            // 
            trimmedCheckBox.AutoSize = true;
            trimmedCheckBox.Location = new Point(119, 370);
            trimmedCheckBox.Name = "trimmedCheckBox";
            trimmedCheckBox.Size = new Size(141, 24);
            trimmedCheckBox.TabIndex = 11;
            trimmedCheckBox.Text = "Publish Trimmed";
            trimmedCheckBox.UseVisualStyleBackColor = true;
            // 
            // r2rCheckBox
            // 
            r2rCheckBox.AutoSize = true;
            r2rCheckBox.Location = new Point(119, 416);
            r2rCheckBox.Name = "r2rCheckBox";
            r2rCheckBox.Size = new Size(164, 24);
            r2rCheckBox.TabIndex = 12;
            r2rCheckBox.Text = "Publish ReadyToRun";
            r2rCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Location = new Point(99, 251);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(194, 210);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            groupBox2.Text = "Build Options";
            // 
            // logBox
            // 
            logBox.Location = new Point(642, 23);
            logBox.Name = "logBox";
            logBox.ReadOnly = true;
            logBox.Size = new Size(940, 498);
            logBox.TabIndex = 14;
            logBox.Text = "";
            // 
            // folderBox
            // 
            folderBox.Location = new Point(90, 648);
            folderBox.Name = "folderBox";
            folderBox.Size = new Size(864, 27);
            folderBox.TabIndex = 15;
            // 
            // chooseFolderBtn
            // 
            chooseFolderBtn.Location = new Point(960, 646);
            chooseFolderBtn.Name = "chooseFolderBtn";
            chooseFolderBtn.Size = new Size(49, 29);
            chooseFolderBtn.TabIndex = 16;
            chooseFolderBtn.Text = "...";
            chooseFolderBtn.UseVisualStyleBackColor = true;
            chooseFolderBtn.Click += chooseFolderBtn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(90, 615);
            label3.Name = "label3";
            label3.Size = new Size(240, 20);
            label3.TabIndex = 17;
            label3.Text = "Choose Client Solution Folder (.sln)";
            // 
            // UC_BuildAgent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label3);
            Controls.Add(chooseFolderBtn);
            Controls.Add(folderBox);
            Controls.Add(logBox);
            Controls.Add(r2rCheckBox);
            Controls.Add(trimmedCheckBox);
            Controls.Add(singlefileCheckBox);
            Controls.Add(selfcontainCheckBox);
            Controls.Add(label2);
            Controls.Add(portBox);
            Controls.Add(label1);
            Controls.Add(addressBox);
            Controls.Add(buildBtn);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "UC_BuildAgent";
            Size = new Size(1600, 900);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton linuxBuildBtn;
        private RadioButton windowsBuildBtn;
        private Button buildBtn;
        private GroupBox groupBox1;
        private TextBox addressBox;
        private Label label1;
        private Label label2;
        private TextBox portBox;
        private CheckBox selfcontainCheckBox;
        private CheckBox singlefileCheckBox;
        private CheckBox trimmedCheckBox;
        private CheckBox r2rCheckBox;
        private GroupBox groupBox2;
        private RichTextBox logBox;
        private TextBox folderBox;
        private Button chooseFolderBtn;
        private Label label3;
        private FolderBrowserDialog folderBrowserDialog1;
    }
}
