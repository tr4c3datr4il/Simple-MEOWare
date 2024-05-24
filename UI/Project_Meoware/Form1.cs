using Project_Meoware.UserControls;

namespace Project_Meoware
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UC_Server uc = new UC_Server();
            addUserControl(uc);
        }


        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void Server_btn_Click(object sender, EventArgs e)
        {
            UC_Server uc = new UC_Server();
            addUserControl(uc);
        }

        private void BuildAgent_btn_Click(object sender, EventArgs e)
        {
            UC_BuildAgent uc = new UC_BuildAgent();
            addUserControl(uc);
        }

        private void Config_btn_Click(object sender, EventArgs e)
        {
            UC_Config uc = new UC_Config();
            addUserControl(uc);
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

