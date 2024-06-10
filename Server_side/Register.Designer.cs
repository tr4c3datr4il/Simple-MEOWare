namespace Server_side
{
    partial class Register
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
            label3 = new Label();
            reguser_txtbox = new TextBox();
            regpass_txtbox = new TextBox();
            cpass_txtbox = new TextBox();
            Register_btn = new Button();
            reg_showpass_checkbox = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(138, 65);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 1;
            label1.Text = "username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(139, 108);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 2;
            label2.Text = "password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(84, 159);
            label3.Name = "label3";
            label3.Size = new Size(130, 20);
            label3.TabIndex = 3;
            label3.Text = "confirm password:";
            // 
            // reguser_txtbox
            // 
            reguser_txtbox.Location = new Point(248, 58);
            reguser_txtbox.Name = "reguser_txtbox";
            reguser_txtbox.Size = new Size(311, 27);
            reguser_txtbox.TabIndex = 4;
            // 
            // regpass_txtbox
            // 
            regpass_txtbox.Location = new Point(248, 105);
            regpass_txtbox.Name = "regpass_txtbox";
            regpass_txtbox.PasswordChar = '*';
            regpass_txtbox.Size = new Size(166, 27);
            regpass_txtbox.TabIndex = 5;
            // 
            // cpass_txtbox
            // 
            cpass_txtbox.Location = new Point(248, 156);
            cpass_txtbox.Name = "cpass_txtbox";
            cpass_txtbox.PasswordChar = '*';
            cpass_txtbox.Size = new Size(166, 27);
            cpass_txtbox.TabIndex = 6;
            // 
            // Register_btn
            // 
            Register_btn.Location = new Point(248, 279);
            Register_btn.Name = "Register_btn";
            Register_btn.Size = new Size(227, 77);
            Register_btn.TabIndex = 7;
            Register_btn.Text = "Register";
            Register_btn.UseVisualStyleBackColor = true;
            Register_btn.Click += Register_btn_Click;
            // 
            // reg_showpass_checkbox
            // 
            reg_showpass_checkbox.AutoSize = true;
            reg_showpass_checkbox.Location = new Point(248, 201);
            reg_showpass_checkbox.Name = "reg_showpass_checkbox";
            reg_showpass_checkbox.Size = new Size(132, 24);
            reg_showpass_checkbox.TabIndex = 8;
            reg_showpass_checkbox.Text = "Show Password";
            reg_showpass_checkbox.UseVisualStyleBackColor = true;
            reg_showpass_checkbox.CheckedChanged += reg_showpass_checkbox_CheckedChanged;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(reg_showpass_checkbox);
            Controls.Add(Register_btn);
            Controls.Add(cpass_txtbox);
            Controls.Add(regpass_txtbox);
            Controls.Add(reguser_txtbox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Register";
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox reguser_txtbox;
        private TextBox regpass_txtbox;
        private TextBox cpass_txtbox;
        private Button Register_btn;
        private CheckBox reg_showpass_checkbox;
    }
}