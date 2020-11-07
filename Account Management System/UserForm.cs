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
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
            cbRole.Text = "Select role ...";
            cbRole.Items.Add("Normal");
            cbRole.Items.Add("Admin");
            cbRole.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            int normal = 0;
            int admin = 1;
            String username, password;
            username = tbUsername.Text;
            password = tbPassword.Text;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-A5SMSRH;Initial Catalog=store_management_system;Integrated Security=True");

            try
            {
                String sql = "INSERT into users ([username], [password], [is_admin]) VALUES (@username, @password, @role)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = tbUsername.Text;
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = tbPassword.Text;

                    if (cbRole.SelectedIndex == normal)
                    {
                        cmd.Parameters.Add("@role", SqlDbType.Bit).Value = 0;
                    }

                    else if (cbRole.SelectedIndex == admin)
                    {
                        cmd.Parameters.Add("@role", SqlDbType.Bit).Value = 1;
                    }

                    else
                    {
                        MessageBox.Show("Error", "Please select role ...");
                        return;
                    }
                      
                    int rowsAdded = cmd.ExecuteNonQuery();
                    if (rowsAdded > 0)
                        MessageBox.Show("User added succesfuly!!");

                    else
                    {
                        MessageBox.Show("Error!!!");
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
