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
    public partial class Register : Form
    {
        String connectionstring = System.IO.Directory.GetCurrentDirectory();
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tranminhprvt01\OneDrive\Documents\LoginData.mdf;Integrated Security=True;Connect Timeout=30");
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
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();
                        String checkUsername = "SELECT * FROM admin WHERE username = '" + reguser_txtbox.Text.Trim() + "'";

                        using (SqlCommand checkUser = new SqlCommand(checkUsername, connect))
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter(checkUser);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count > 0)
                            {
                                MessageBox.Show(reguser_txtbox.Text + " is already exist", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertData = "INSERT INTO admin (username, password) VALUES(@username, @password)";

                                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@username", reguser_txtbox.Text.Trim());
                                    cmd.Parameters.AddWithValue("@password", regpass_txtbox.Text.Trim());

                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Registered successfully", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                    //Switch form??
                                    Login lform = new Login();
                                    lform.Show();
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
                        connect.Close();
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
    }
}
