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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            reguser_txtbox = new TextBox();
            regpass_txtbox = new TextBox();
            cpass_txtbox = new TextBox();
            Register_btn = new Button();
            reg_showpass_checkbox = new CheckBox();
            linkLabel1 = new LinkLabel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
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
            label1.TabIndex = 1;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(446, 152);
            label2.Name = "label2";
            label2.Size = new Size(80, 23);
            label2.TabIndex = 2;
            label2.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(446, 233);
            label3.Name = "label3";
            label3.Size = new Size(146, 23);
            label3.TabIndex = 3;
            label3.Text = "Confirm Password";
            // 
            // reguser_txtbox
            // 
            reguser_txtbox.Location = new Point(446, 84);
            reguser_txtbox.Name = "reguser_txtbox";
            reguser_txtbox.Size = new Size(434, 27);
            reguser_txtbox.TabIndex = 4;
            // 
            // regpass_txtbox
            // 
            regpass_txtbox.Location = new Point(446, 178);
            regpass_txtbox.Name = "regpass_txtbox";
            regpass_txtbox.PasswordChar = '*';
            regpass_txtbox.Size = new Size(434, 27);
            regpass_txtbox.TabIndex = 5;
            // 
            // cpass_txtbox
            // 
            cpass_txtbox.Location = new Point(446, 259);
            cpass_txtbox.Name = "cpass_txtbox";
            cpass_txtbox.PasswordChar = '*';
            cpass_txtbox.Size = new Size(434, 27);
            cpass_txtbox.TabIndex = 6;
            // 
            // Register_btn
            // 
            Register_btn.Location = new Point(446, 439);
            Register_btn.Name = "Register_btn";
            Register_btn.Size = new Size(163, 65);
            Register_btn.TabIndex = 7;
            Register_btn.Text = "Register";
            Register_btn.UseVisualStyleBackColor = true;
            Register_btn.Click += Register_btn_Click;
            // 
            // reg_showpass_checkbox
            // 
            reg_showpass_checkbox.AutoSize = true;
            reg_showpass_checkbox.Location = new Point(446, 319);
            reg_showpass_checkbox.Name = "reg_showpass_checkbox";
            reg_showpass_checkbox.Size = new Size(132, 24);
            reg_showpass_checkbox.TabIndex = 8;
            reg_showpass_checkbox.Text = "Show Password";
            reg_showpass_checkbox.UseVisualStyleBackColor = true;
            reg_showpass_checkbox.CheckedChanged += reg_showpass_checkbox_CheckedChanged;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(684, 461);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(223, 20);
            linkLabel1.TabIndex = 9;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Already have an account? Login!";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.ActiveCaption;
            flowLayoutPanel1.Controls.Add(pictureBox1);
            flowLayoutPanel1.ForeColor = SystemColors.ActiveCaption;
            flowLayoutPanel1.Location = new Point(1, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(406, 566);
            flowLayoutPanel1.TabIndex = 10;
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
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 564);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(linkLabel1);
            Controls.Add(reg_showpass_checkbox);
            Controls.Add(Register_btn);
            Controls.Add(cpass_txtbox);
            Controls.Add(regpass_txtbox);
            Controls.Add(reguser_txtbox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Register";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private LinkLabel linkLabel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox pictureBox1;
    }
}