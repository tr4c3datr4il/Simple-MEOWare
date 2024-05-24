namespace Project_Meoware.UserControls
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
            listView1 = new ListView();
            columnHeader5 = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            Stop = new Button();
            Create_connection_btn = new Button();
            SuspendLayout();
            // 
            // Listen
            // 
            Listen.Location = new Point(1468, 37);
            Listen.Name = "Listen";
            Listen.Size = new Size(193, 89);
            Listen.TabIndex = 0;
            Listen.Text = "Listen";
            Listen.UseVisualStyleBackColor = true;
            Listen.Click += Listen_Click;
            // 
            // listView1
            // 
            listView1.BackColor = SystemColors.Info;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader5, columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            listView1.Location = new Point(19, 37);
            listView1.Name = "listView1";
            listView1.Size = new Size(1325, 637);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.DoubleClick += listView1_DoubleClick;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Clickme";
            columnHeader5.Width = 200;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "IP";
            columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Hostname";
            columnHeader2.Width = 300;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Connect_time";
            columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "OS";
            columnHeader4.Width = 400;
            // 
            // Stop
            // 
            Stop.Location = new Point(1468, 132);
            Stop.Name = "Stop";
            Stop.Size = new Size(193, 89);
            Stop.TabIndex = 2;
            Stop.Text = "Stop";
            Stop.UseVisualStyleBackColor = true;
            Stop.Click += Stop_Click;
            // 
            // Create_connection_btn
            // 
            Create_connection_btn.Location = new Point(1468, 336);
            Create_connection_btn.Name = "Create_connection_btn";
            Create_connection_btn.Size = new Size(193, 88);
            Create_connection_btn.TabIndex = 3;
            Create_connection_btn.Text = "make connection";
            Create_connection_btn.UseVisualStyleBackColor = true;
            Create_connection_btn.Click += Create_connection_btn_Click;
            // 
            // UC_Server
            // 
            AutoScaleDimensions = new SizeF(13F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(Create_connection_btn);
            Controls.Add(Stop);
            Controls.Add(listView1);
            Controls.Add(Listen);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(5);
            Name = "UC_Server";
            Size = new Size(1839, 861);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button Listen;
        private System.Windows.Forms.ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Button Stop;
        private Button Create_connection_btn;
        private ColumnHeader columnHeader5;
    }
}
