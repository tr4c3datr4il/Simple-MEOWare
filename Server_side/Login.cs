using System;
using System.Data;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Server_side
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void log_showpass_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (log_showpass_checkbox.Checked == true)
            {
                logpass_txtbox.PasswordChar = '\0';
            }
            else
            {
                logpass_txtbox.PasswordChar = '*';
            }
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            if (loguser_txtbox.Text == "" || logpass_txtbox.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Program.SQLConnector.State != ConnectionState.Open)
                {
                    try
                    {
                        Program.SQLConnector.Open();

                        string selectData = "SELECT * FROM user WHERE username = @username AND password = @password";
                        using (SQLiteCommand cmd = new SQLiteCommand(selectData, Program.SQLConnector))
                        {
                            byte[] hashedPassword = MD5.HashData(Encoding.UTF8.GetBytes(logpass_txtbox.Text.Trim()));
                            cmd.Parameters.AddWithValue("@username", loguser_txtbox.Text);
                            cmd.Parameters.AddWithValue("@password", Encryptor.ConvertStr(hashedPassword));

                            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count > 0)
                            {
                                MessageBox.Show("Logged in successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Menu menu = new Menu();
                                menu.Show();
                                Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error connecting to database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Program.SQLConnector.Close();
                    }
                }
            }
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            _ = new DarkModeCS(register);
            register.Show();
            Hide();
        }
    }
}
