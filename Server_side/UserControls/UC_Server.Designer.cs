namespace Server_side.UserControls
{
    partial class UC_Server
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
            Listen = new Button();
            clientListView = new ListView();
            interactCollumn = new ColumnHeader();
            ipCollumn = new ColumnHeader();
            hostnameCollumn = new ColumnHeader();
            conTimeCollumn = new ColumnHeader();
            osCollumn = new ColumnHeader();
            Stop = new Button();
            SuspendLayout();
            // 
            // Listen
            // 
            Listen.Location = new Point(1393, 37);
            Listen.Name = "Listen";
            Listen.Size = new Size(193, 89);
            Listen.TabIndex = 0;
            Listen.Text = "Listen";
            Listen.UseVisualStyleBackColor = true;
            Listen.Click += Listen_Click;
            // 
            // clientListView
            // 
            clientListView.BackColor = SystemColors.Info;
            clientListView.Columns.AddRange(new ColumnHeader[] { interactCollumn, ipCollumn, hostnameCollumn, conTimeCollumn, osCollumn });
            clientListView.Location = new Point(19, 37);
            clientListView.Name = "clientListView";
            clientListView.Size = new Size(1325, 637);
            clientListView.TabIndex = 1;
            clientListView.UseCompatibleStateImageBehavior = false;
            clientListView.View = View.Details;
            clientListView.DoubleClick += listView1_DoubleClick;
            // 
            // interactCollumn
            // 
            interactCollumn.Text = "Interact";
            interactCollumn.Width = 200;
            // 
            // ipCollumn
            // 
            ipCollumn.Text = "IP";
            ipCollumn.Width = 160;
            // 
            // hostnameCollumn
            // 
            hostnameCollumn.Text = "Host Name";
            hostnameCollumn.Width = 300;
            // 
            // conTimeCollumn
            // 
            conTimeCollumn.Text = "Connect Time";
            conTimeCollumn.Width = 200;
            // 
            // osCollumn
            // 
            osCollumn.Text = "OS";
            osCollumn.Width = 400;
            // 
            // Stop
            // 
            Stop.Location = new Point(1393, 132);
            Stop.Name = "Stop";
            Stop.Size = new Size(193, 89);
            Stop.TabIndex = 2;
            Stop.Text = "Stop";
            Stop.UseVisualStyleBackColor = true;
            Stop.Click += Stop_Click;
            // 
            // UC_Server
            // 
            AutoScaleDimensions = new SizeF(13F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(Stop);
            Controls.Add(clientListView);
            Controls.Add(Listen);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Margin = new Padding(5);
            Name = "UC_Server";
            Size = new Size(1600, 900);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button Listen;
        private System.Windows.Forms.ListView clientListView;
        private ColumnHeader ipCollumn;
        private ColumnHeader hostnameCollumn;
        private ColumnHeader conTimeCollumn;
        private ColumnHeader osCollumn;
        private Button Stop;
        private ColumnHeader interactCollumn;
    }
}
