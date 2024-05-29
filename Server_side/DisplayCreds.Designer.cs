namespace Server_side
{
    partial class DisplayCreds
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
            credListView = new ListView();
            siteCollumn = new ColumnHeader();
            usernameCollumn = new ColumnHeader();
            passwdCollumn = new ColumnHeader();
            SuspendLayout();
            // 
            // credListView
            // 
            credListView.Columns.AddRange(new ColumnHeader[] { siteCollumn, usernameCollumn, passwdCollumn });
            credListView.Location = new Point(12, 12);
            credListView.Name = "credListView";
            credListView.Size = new Size(813, 466);
            credListView.TabIndex = 0;
            credListView.UseCompatibleStateImageBehavior = false;
            credListView.View = View.Details;
            // 
            // siteCollumn
            // 
            siteCollumn.Text = "Website";
            siteCollumn.Width = 220;
            // 
            // usernameCollumn
            // 
            usernameCollumn.Text = "Username";
            usernameCollumn.Width = 270;
            // 
            // passwdCollumn
            // 
            passwdCollumn.Text = "Password";
            passwdCollumn.Width = 300;
            // 
            // DisplayCreds
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(837, 490);
            Controls.Add(credListView);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DisplayCreds";
            ShowIcon = false;
            Text = "DisplayCreds";
            ResumeLayout(false);
        }

        #endregion

        private ListView credListView;
        private ColumnHeader siteCollumn;
        private ColumnHeader usernameCollumn;
        private ColumnHeader passwdCollumn;
    }
}