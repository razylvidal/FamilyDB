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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-792E309U\\SQLEXPRESS2014;Initial Catalog=dbFamily;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            try
            {

                if (tbFamno.Text == "" || tblname.Text == "" || tbfname.Text == "" || tbbdate.Text == "" || tbRelationship.Text == "" || tbHometown.Text == "" || tbAge.Text == "")
                {
                    MessageBox.Show("Each field is required!");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("insert into Family values(@famno,@lname,@fname,@bdate,@relationship,@hometown,@age)", con);
                    cmd.Parameters.AddWithValue("@famno", int.Parse(tbFamno.Text));
                    cmd.Parameters.AddWithValue("@lname", tblname.Text);
                    cmd.Parameters.AddWithValue("@fname", tbfname.Text);
                    cmd.Parameters.AddWithValue("@bdate", tbbdate.Text);
                    cmd.Parameters.AddWithValue("@relationship", tbRelationship.Text);
                    cmd.Parameters.AddWithValue("@hometown", tbHometown.Text);
                    cmd.Parameters.AddWithValue("@age", int.Parse(tbAge.Text));
                    cmd.ExecuteNonQuery();

                    con.Close();
                    tbFamno.Text = "";
                    tblname.Text = "";
                    tbfname.Text = "";
                    tbbdate.Text = "";
                    tbRelationship.Text = "";
                    tbHometown.Text = "";
                    tbAge.Text = "";
                    MessageBox.Show("Successfully Created!");
                }
            }
            catch (SqlException)
            {
                tbFamno.Text = "";
                MessageBox.Show("Family Number Already Existed!");

            }
            catch (Exception)
            {
                tbFamno.Text = "";
                tblname.Text = "";
                tbfname.Text = "";
                tbbdate.Text = "";
                tbRelationship.Text = "";
                tbHometown.Text = "";
                tbAge.Text = "";
                MessageBox.Show("Invalid Input!");
            }
            

        }
    }
}
