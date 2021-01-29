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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-792E309U\\SQLEXPRESS2014;Initial Catalog=dbFamily;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            
               try
                {
        
                    if (tbFamno.Text == "" || tblname.Text == "" || tbfname.Text == "" || tbbdate.Text == "" || tbRelationship.Text == "" || tbHometown.Text == "" || tbAge.Text == "" )
                    {
                        MessageBox.Show("Each field is required!");
                    }
                    else
                    {
                        
                        SqlCommand cmd = new SqlCommand("UPDATE Family set lname=@lname, fname=@fname, bdate=@bdate, relationship=@relationship, hometown=@hometown, age=@age where famno=@famno", con);
                        cmd.Parameters.AddWithValue("@famno", int.Parse(tbFamno.Text));
                        cmd.Parameters.AddWithValue("@lname", tblname.Text);
                        cmd.Parameters.AddWithValue("@fname", tbfname.Text);
                        cmd.Parameters.AddWithValue("@bdate", DateTime.Parse(tbbdate.Text));
                        cmd.Parameters.AddWithValue("@relationship", tbRelationship.Text);
                        cmd.Parameters.AddWithValue("@hometown", tbHometown.Text);
                        cmd.Parameters.AddWithValue("@age", int.Parse(tbAge.Text));
                        int checker = cmd.ExecuteNonQuery();
                        if (checker == 0)
                        {

                            MessageBox.Show("Family Number Doesn't Exist!");
                        }
                        else
                        {
                            tbFamno.Text = "";
                            tblname.Text = "";
                            tbfname.Text = "";
                            tbbdate.Text = "";
                            tbRelationship.Text = "";
                            tbHometown.Text = "";
                            tbAge.Text = "";
                            MessageBox.Show("Successfully Updated!");
                        }
                        con.Close();
                      
                    }
                
               }
               catch (FormatException)
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbFamno.Text == "")
            {
                MessageBox.Show("Family Number Required!");
            }
            else
            {
                SqlConnection connection = new SqlConnection("Data Source=LAPTOP-792E309U\\SQLEXPRESS2014;Initial Catalog=dbFamily;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                connection.Open();
                try
                {

                    SqlCommand c = new SqlCommand("Update Family set famno=@famno where famno=@famno", connection);
                    c.Parameters.AddWithValue("@famno", int.Parse(tbFamno.Text));
                    int checker = c.ExecuteNonQuery();
                    if (checker == 0)
                    {
                        tblname.Text = "";
                        tbfname.Text = "";
                        tbbdate.Text = "";
                        tbRelationship.Text = "";
                        tbHometown.Text = "";
                        tbAge.Text = "";
                        tblname.Enabled = false;
                        tbfname.Enabled = false;
                        tbbdate.Enabled = false;
                        tbRelationship.Enabled = false;
                        tbHometown.Enabled = false;
                        tbAge.Enabled = false;
                        btnUpdate.Enabled = false;
                        MessageBox.Show("Family Number Doesn't Exist");
                    }
                    else
                    {

                        tblname.Enabled = true;
                        tbfname.Enabled = true;
                        tbbdate.Enabled = true;
                        tbRelationship.Enabled = true;
                        tbHometown.Enabled = true;
                        tbAge.Enabled = true;
                        btnUpdate.Enabled = true;

                        SqlCommand command = new SqlCommand("SELECT * from Family where famno=@famno", connection);
                        command.Parameters.AddWithValue("@famno", int.Parse(tbFamno.Text));
                        SqlDataReader read = command.ExecuteReader();
                        while (read.Read())
                        {
                            tblname.Text = (read["lname"].ToString());
                            tbfname.Text = (read["fname"].ToString());
                            tbbdate.Text = (read["bdate"].ToString().Substring(0, 10));
                            tbRelationship.Text = (read["relationship"].ToString());
                            tbHometown.Text = (read["hometown"].ToString());
                            tbAge.Text = (read["age"].ToString());
                        }
                        read.Close();

                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Input");
                }
            }

            


        }
    }
}
