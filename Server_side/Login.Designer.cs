namespace Server_side
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            label1 = new Label();
            label2 = new Label();
            loguser_txtbox = new TextBox();
            logpass_txtbox = new TextBox();
            Login_btn = new Button();
            log_showpass_checkbox = new CheckBox();
            linkLabel = new LinkLabel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(446, 61);
            label1.Name = "label1";
            label1.Size = new Size(87, 23);
            label1.TabIndex = 0;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(446, 155);
            label2.Name = "label2";
            label2.Size = new Size(80, 23);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // loguser_txtbox
            // 
            loguser_txtbox.Location = new Point(446, 84);
            loguser_txtbox.Name = "loguser_txtbox";
            loguser_txtbox.Size = new Size(434, 27);
            loguser_txtbox.TabIndex = 2;
            // 
            // logpass_txtbox
            // 
            logpass_txtbox.Location = new Point(446, 181);
            logpass_txtbox.Name = "logpass_txtbox";
            logpass_txtbox.PasswordChar = '*';
            logpass_txtbox.Size = new Size(434, 27);
            logpass_txtbox.TabIndex = 3;
            // 
            // Login_btn
            // 
            Login_btn.Location = new Point(446, 439);
            Login_btn.Name = "Login_btn";
            Login_btn.Size = new Size(163, 65);
            Login_btn.TabIndex = 4;
            Login_btn.Text = "Login";
            Login_btn.UseVisualStyleBackColor = true;
            Login_btn.Click += Login_btn_Click;
            // 
            // log_showpass_checkbox
            // 
            log_showpass_checkbox.AutoSize = true;
            log_showpass_checkbox.Location = new Point(446, 254);
            log_showpass_checkbox.Name = "log_showpass_checkbox";
            log_showpass_checkbox.Size = new Size(132, 24);
            log_showpass_checkbox.TabIndex = 5;
            log_showpass_checkbox.Text = "Show Password";
            log_showpass_checkbox.UseVisualStyleBackColor = true;
            log_showpass_checkbox.CheckedChanged += log_showpass_checkbox_CheckedChanged;
            // 
            // linkLabel
            // 
            linkLabel.AutoSize = true;
            linkLabel.Location = new Point(684, 461);
            linkLabel.Name = "linkLabel";
            linkLabel.Size = new Size(225, 20);
            linkLabel.TabIndex = 6;
            linkLabel.TabStop = true;
            linkLabel.Text = "Don't have an account? Register!";
            linkLabel.LinkClicked += linkLabel_LinkClicked;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.ActiveCaption;
            flowLayoutPanel1.Controls.Add(pictureBox1);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.ForeColor = SystemColors.ActiveCaption;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(405, 565);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(402, 275);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(3, 281);
            label3.Name = "label3";
            label3.Size = new Size(364, 62);
            label3.TabIndex = 12;
            label3.Text = "Welcome Back!";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 564);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(linkLabel);
            Controls.Add(log_showpass_checkbox);
            Controls.Add(Login_btn);
            Controls.Add(logpass_txtbox);
            Controls.Add(loguser_txtbox);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Login";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox loguser_txtbox;
        private TextBox logpass_txtbox;
        private Button Login_btn;
        private CheckBox log_showpass_checkbox;
        private LinkLabel linkLabel;
        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox pictureBox1;
        private Label label3;
    }
}