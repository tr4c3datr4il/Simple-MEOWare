namespace Server_side
{
    partial class DisplayPSList
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
            pslistListView = new ListView();
            procnameCollumn = new ColumnHeader();
            idCollumn = new ColumnHeader();
            threadsCollumn = new ColumnHeader();
            memCollumn = new ColumnHeader();
            SuspendLayout();
            // 
            // pslistListView
            // 
            pslistListView.Columns.AddRange(new ColumnHeader[] { procnameCollumn, idCollumn, threadsCollumn, memCollumn });
            pslistListView.Location = new Point(12, 12);
            pslistListView.Name = "pslistListView";
            pslistListView.Size = new Size(776, 484);
            pslistListView.TabIndex = 0;
            pslistListView.UseCompatibleStateImageBehavior = false;
            pslistListView.View = View.Details;
            // 
            // procnameCollumn
            // 
            procnameCollumn.Text = "Process Name";
            procnameCollumn.Width = 220;
            // 
            // idCollumn
            // 
            idCollumn.Text = "ID";
            idCollumn.Width = 110;
            // 
            // threadsCollumn
            // 
            threadsCollumn.Text = "Number of Threads";
            threadsCollumn.Width = 220;
            // 
            // memCollumn
            // 
            memCollumn.Text = "Memory Usage (Bytes)";
            memCollumn.Width = 220;
            // 
            // DisplayPSList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 508);
            Controls.Add(pslistListView);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DisplayPSList";
            ShowIcon = false;
            Text = "DisplayPSList";
            ResumeLayout(false);
        }

        #endregion

        private ListView pslistListView;
        private ColumnHeader procnameCollumn;
        private ColumnHeader idCollumn;
        private ColumnHeader threadsCollumn;
        private ColumnHeader memCollumn;
    }
}