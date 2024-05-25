namespace Server_side
{
    partial class DisplayScreenshot
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
            screenshotBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)screenshotBox).BeginInit();
            SuspendLayout();
            // 
            // screenshotBox
            // 
            screenshotBox.Location = new Point(0, 0);
            screenshotBox.Name = "screenshotBox";
            screenshotBox.Size = new Size(820, 574);
            screenshotBox.TabIndex = 0;
            screenshotBox.TabStop = false;
            // 
            // DisplayScreenshot
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 574);
            Controls.Add(screenshotBox);
            Name = "DisplayScreenshot";
            Text = "DisplayScreenshot";
            ((System.ComponentModel.ISupportInitialize)screenshotBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox screenshotBox;
    }
}