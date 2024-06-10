namespace Server_side
{
    public partial class Intro : Form
    {
        public Intro()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            _ = new DarkModeCS(login);
            login.Show();
            Hide();
        }
    }
}
