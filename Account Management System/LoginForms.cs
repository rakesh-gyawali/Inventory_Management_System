using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Account_Management_System
{
    public partial class LoginForms : Form
    {
        public LoginForms()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            String username, password;
            username = tbUsername.Text;
            password = tbPassword.Text;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-A5SMSRH;Initial Catalog=store_management_system;Integrated Security=True");

            try
            {
                String sql = "SELECT username, password FROM users WHERE username = @username AND password = @password";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = tbUsername.Text;
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = tbPassword.Text;

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {

                        Dashboard_form dashboard_Form = new Dashboard_form();
                        dashboard_Form.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Username or Password is incorrect ...", "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();
            userForm.ShowDialog();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
