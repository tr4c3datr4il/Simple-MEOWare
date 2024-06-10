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
            label1 = new Label();
            label2 = new Label();
            loguser_txtbox = new TextBox();
            logpass_txtbox = new TextBox();
            Login_btn = new Button();
            log_showpass_checkbox = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(112, 105);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 0;
            label1.Text = "Username: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(112, 163);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 1;
            label2.Text = "Password:";
            // 
            // loguser_txtbox
            // 
            loguser_txtbox.Location = new Point(223, 105);
            loguser_txtbox.Name = "loguser_txtbox";
            loguser_txtbox.Size = new Size(293, 27);
            loguser_txtbox.TabIndex = 2;
            // 
            // logpass_txtbox
            // 
            logpass_txtbox.Location = new Point(223, 163);
            logpass_txtbox.Name = "logpass_txtbox";
            logpass_txtbox.PasswordChar = '*';
            logpass_txtbox.Size = new Size(175, 27);
            logpass_txtbox.TabIndex = 3;
            // 
            // Login_btn
            // 
            Login_btn.Location = new Point(223, 286);
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
            log_showpass_checkbox.Location = new Point(223, 211);
            log_showpass_checkbox.Name = "log_showpass_checkbox";
            log_showpass_checkbox.Size = new Size(132, 24);
            log_showpass_checkbox.TabIndex = 5;
            log_showpass_checkbox.Text = "Show Password";
            log_showpass_checkbox.UseVisualStyleBackColor = true;
            log_showpass_checkbox.CheckedChanged += log_showpass_checkbox_CheckedChanged;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(log_showpass_checkbox);
            Controls.Add(Login_btn);
            Controls.Add(logpass_txtbox);
            Controls.Add(loguser_txtbox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Login";
            Text = "Login";
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
    }
}