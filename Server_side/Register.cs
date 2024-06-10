using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using System.Security.Cryptography;


namespace Server_side
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_btn_Click(object sender, EventArgs e)
        {

            if (reguser_txtbox.Text == "" || regpass_txtbox.Text == "")
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
                        String checkUsername = "SELECT * FROM user WHERE username = '" + reguser_txtbox.Text.Trim() + "'";

                        using (SQLiteCommand checkUser = new SQLiteCommand(checkUsername, Program.SQLConnector))
                        {
                            SQLiteDataAdapter adapter = new SQLiteDataAdapter(checkUser);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count > 0)
                            {
                                MessageBox.Show(reguser_txtbox.Text + " is already exist", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertData = "INSERT INTO user (username, password) VALUES(@username, @password)";

                                using (SQLiteCommand cmd = new SQLiteCommand(insertData, Program.SQLConnector))
                                {
                                    byte[] hashedPassword = MD5.HashData(Encoding.UTF8.GetBytes(regpass_txtbox.Text.Trim()));
                                    cmd.Parameters.AddWithValue("@username", reguser_txtbox.Text.Trim());
                                    cmd.Parameters.AddWithValue("@password", Convert.ToBase64String(hashedPassword));
                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Registered successfully", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    Login login = new Login();
                                    _ = new DarkModeCS(login);
                                    login.Show();
                                    this.Hide();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error connecting database: " + ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Program.SQLConnector.Close();
                    }
                }
            }
        }

        private void reg_showpass_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (reg_showpass_checkbox.Checked == true)
            {
                regpass_txtbox.PasswordChar = '\0';
            }
            else
            {
                regpass_txtbox.PasswordChar = '*';
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            _ = new DarkModeCS(login);
            login.Show();
            this.Hide();
        }
    }
}
