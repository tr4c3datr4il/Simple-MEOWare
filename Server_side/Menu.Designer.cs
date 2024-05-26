using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Server_side
{
    partial class Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        /// 

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            Exit_btn = new Guna.UI2.WinForms.Guna2Button();
            Config_btn = new Guna.UI2.WinForms.Guna2Button();
            BuildAgent_btn = new Guna.UI2.WinForms.Guna2Button();
            Server_btn = new Guna.UI2.WinForms.Guna2Button();
            notifyIcon1 = new NotifyIcon(components);
            PanelContainer = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(Exit_btn);
            panel1.Controls.Add(Config_btn);
            panel1.Controls.Add(BuildAgent_btn);
            panel1.Controls.Add(Server_btn);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1600, 72);
            panel1.TabIndex = 0;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            panel1.MouseUp += panel1_MouseUp;
            // 
            // Exit_btn
            // 
            Exit_btn.CustomizableEdges = customizableEdges17;
            Exit_btn.DisabledState.BorderColor = Color.DarkGray;
            Exit_btn.DisabledState.CustomBorderColor = Color.DarkGray;
            Exit_btn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Exit_btn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Exit_btn.FillColor = SystemColors.ActiveCaption;
            Exit_btn.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            Exit_btn.ForeColor = Color.White;
            Exit_btn.Location = new Point(799, 5);
            Exit_btn.Name = "Exit_btn";
            Exit_btn.ShadowDecoration.CustomizableEdges = customizableEdges18;
            Exit_btn.Size = new Size(241, 63);
            Exit_btn.TabIndex = 3;
            Exit_btn.Text = "Exit";
            Exit_btn.Click += Exit_btn_Click;
            // 
            // Config_btn
            // 
            Config_btn.CustomizableEdges = customizableEdges19;
            Config_btn.DisabledState.BorderColor = Color.DarkGray;
            Config_btn.DisabledState.CustomBorderColor = Color.DarkGray;
            Config_btn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Config_btn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Config_btn.FillColor = SystemColors.ActiveCaption;
            Config_btn.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            Config_btn.ForeColor = Color.White;
            Config_btn.Location = new Point(494, 0);
            Config_btn.Name = "Config_btn";
            Config_btn.ShadowDecoration.CustomizableEdges = customizableEdges20;
            Config_btn.Size = new Size(241, 63);
            Config_btn.TabIndex = 2;
            Config_btn.Text = "Config";
            Config_btn.Click += Config_btn_Click;
            // 
            // BuildAgent_btn
            // 
            BuildAgent_btn.CustomizableEdges = customizableEdges21;
            BuildAgent_btn.DisabledState.BorderColor = Color.DarkGray;
            BuildAgent_btn.DisabledState.CustomBorderColor = Color.DarkGray;
            BuildAgent_btn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            BuildAgent_btn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            BuildAgent_btn.FillColor = SystemColors.ActiveCaption;
            BuildAgent_btn.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            BuildAgent_btn.ForeColor = Color.White;
            BuildAgent_btn.Location = new Point(247, 0);
            BuildAgent_btn.Name = "BuildAgent_btn";
            BuildAgent_btn.ShadowDecoration.CustomizableEdges = customizableEdges22;
            BuildAgent_btn.Size = new Size(241, 63);
            BuildAgent_btn.TabIndex = 1;
            BuildAgent_btn.Text = "Build Agent";
            BuildAgent_btn.Click += BuildAgent_btn_Click;
            // 
            // Server_btn
            // 
            Server_btn.CustomizableEdges = customizableEdges23;
            Server_btn.DisabledState.BorderColor = Color.DarkGray;
            Server_btn.DisabledState.CustomBorderColor = Color.DarkGray;
            Server_btn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Server_btn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Server_btn.FillColor = SystemColors.ActiveCaption;
            Server_btn.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            Server_btn.ForeColor = Color.White;
            Server_btn.Location = new Point(0, 0);
            Server_btn.Name = "Server_btn";
            Server_btn.ShadowDecoration.CustomizableEdges = customizableEdges24;
            Server_btn.Size = new Size(241, 63);
            Server_btn.TabIndex = 0;
            Server_btn.Text = "Server";
            Server_btn.Click += Server_btn_Click;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // PanelContainer
            // 
            PanelContainer.Dock = DockStyle.Fill;
            PanelContainer.Location = new Point(0, 72);
            PanelContainer.Name = "PanelContainer";
            PanelContainer.Size = new Size(1600, 828);
            PanelContainer.TabIndex = 1;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1600, 900);
            Controls.Add(PanelContainer);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Menu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private NotifyIcon notifyIcon1;
        private Guna.UI2.WinForms.Guna2Button Server_btn;
        private Guna.UI2.WinForms.Guna2Button BuildAgent_btn;
        private Guna.UI2.WinForms.Guna2Button Config_btn;
        private Panel PanelContainer;
        private Guna.UI2.WinForms.Guna2Button Exit_btn;
    }
}
