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

namespace Simple_Database_App
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-792E309U\\SQLEXPRESS2014;Initial Catalog=dbFamily;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                
                    if (tbFamno.Text == "")
                    {
                        MessageBox.Show("Input Required!");
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("Delete Family where famno=@famno", con);
                        cmd.Parameters.AddWithValue("@famno", int.Parse(tbFamno.Text));
                        int checker = cmd.ExecuteNonQuery();
                        if (checker == 0)
                        {

                            tbFamno.Text = "";
                            MessageBox.Show("Family Number Doesn't Exist!");
                        }
                        else
                        {
                            tbFamno.Text = "";
                            MessageBox.Show("Successfully Deleted!");
                        }
                    }
                
                con.Close();
            }
            catch(FormatException)
            {
                MessageBox.Show("Invalid Input!");
            }

        }
    }
}
