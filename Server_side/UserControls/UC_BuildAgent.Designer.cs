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
            richTextBox1 = new RichTextBox();
            groupBox1 = new GroupBox();
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
            buildBtn.Location = new Point(1585, 705);
            buildBtn.Name = "buildBtn";
            buildBtn.Size = new Size(137, 65);
            buildBtn.TabIndex = 2;
            buildBtn.Text = "Build";
            buildBtn.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(672, 135);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(427, 298);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(windowsBuildBtn);
            groupBox1.Controls.Add(linuxBuildBtn);
            groupBox1.Location = new Point(71, 76);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(194, 117);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Operating System";
            // 
            // UC_BuildAgent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(richTextBox1);
            Controls.Add(buildBtn);
            Controls.Add(groupBox1);
            Name = "UC_BuildAgent";
            Size = new Size(1839, 861);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RadioButton linuxBuildBtn;
        private RadioButton windowsBuildBtn;
        private Button buildBtn;
        private RichTextBox richTextBox1;
        private GroupBox groupBox1;
    }
}
