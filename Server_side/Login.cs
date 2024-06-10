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
using System.Data.SqlClient;

namespace Server_side
{
    public partial class Login : Form
    {
        String connectionstring = System.IO.Directory.GetCurrentDirectory();
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tranminhprvt01\OneDrive\Documents\LoginData.mdf;Integrated Security=True;Connect Timeout=30");
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
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();

                        String selectData = "SELECT * from admin WHERE username = @username AND password = @password";
                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            cmd.Parameters.AddWithValue("@username", loguser_txtbox.Text);
                            cmd.Parameters.AddWithValue("@password", logpass_txtbox.Text);

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count > 0)
                            {
                                MessageBox.Show("Logged in successfully", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Redirect to main form


                            }
                            else
                            {
                                MessageBox.Show("Incorrect username/password", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error connecting database: " + ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }
    }
}
