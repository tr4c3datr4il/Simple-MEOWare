namespace Server_side
{
    partial class Intro
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Intro));
            startBtn = new Button();
            label1 = new Label();
            logoPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // startBtn
            // 
            startBtn.FlatStyle = FlatStyle.System;
            startBtn.Location = new Point(342, 482);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(131, 61);
            startBtn.TabIndex = 0;
            startBtn.Text = "Start";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += startBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(307, 365);
            label1.Name = "label1";
            label1.Size = new Size(204, 38);
            label1.TabIndex = 1;
            label1.Text = "CommandRAT";
            // 
            // logoPictureBox
            // 
            logoPictureBox.Image = (Image)resources.GetObject("logoPictureBox.Image");
            logoPictureBox.Location = new Point(236, 45);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(348, 286);
            logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoPictureBox.TabIndex = 2;
            logoPictureBox.TabStop = false;
            // 
            // Intro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(824, 589);
            Controls.Add(logoPictureBox);
            Controls.Add(label1);
            Controls.Add(startBtn);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Intro";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Simple Meoware C2";
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startBtn;
        private Label label1;
        private PictureBox logoPictureBox;
    }
}
