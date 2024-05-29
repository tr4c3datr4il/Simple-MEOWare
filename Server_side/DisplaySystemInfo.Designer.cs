namespace Server_side
{
    partial class DisplaySystemInfo
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
            systeminfoListView = new ListView();
            keyCollumn = new ColumnHeader();
            valueCollumn = new ColumnHeader();
            SuspendLayout();
            // 
            // systeminfoListView
            // 
            systeminfoListView.Columns.AddRange(new ColumnHeader[] { keyCollumn, valueCollumn });
            systeminfoListView.Location = new Point(12, 12);
            systeminfoListView.Name = "systeminfoListView";
            systeminfoListView.Size = new Size(873, 525);
            systeminfoListView.TabIndex = 0;
            systeminfoListView.UseCompatibleStateImageBehavior = false;
            systeminfoListView.View = View.Details;
            // 
            // keyCollumn
            // 
            keyCollumn.Text = "Key";
            keyCollumn.Width = 440;
            // 
            // valueCollumn
            // 
            valueCollumn.Text = "Value";
            valueCollumn.Width = 440;
            // 
            // DisplaySystemInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(897, 549);
            Controls.Add(systeminfoListView);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DisplaySystemInfo";
            ShowIcon = false;
            Text = "DisplaySystemInfo";
            ResumeLayout(false);
        }

        #endregion

        private ListView systeminfoListView;
        private ColumnHeader keyCollumn;
        private ColumnHeader valueCollumn;
    }
}