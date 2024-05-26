using Server_side.UserControls;

namespace Server_side
{
    public partial class Menu : Form
    {
        // This should fix the issue when the tab's content is not displayed correctly

        private UC_Server ucServer;
        private UC_BuildAgent ucBuildAgent;
        private UC_Config ucConfig;

        public Menu()
        {
            InitializeComponent();

            ucServer = new UC_Server();
            ucBuildAgent = new UC_BuildAgent();
            ucConfig = new UC_Config();

            addUserControl(ucServer);
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
            addUserControl(ucServer);
        }

        private void BuildAgent_btn_Click(object sender, EventArgs e)
        {
            addUserControl(ucBuildAgent);
        }

        private void Config_btn_Click(object sender, EventArgs e)
        {
            addUserControl(ucConfig);
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        // for moving panel
        bool mousedown = false;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                int mousex = MousePosition.X - (panel1.Width/2);
                int mousey = MousePosition.Y - (panel1.Height/2);
                this.SetDesktopLocation(mousex, mousey);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }
    }
}

