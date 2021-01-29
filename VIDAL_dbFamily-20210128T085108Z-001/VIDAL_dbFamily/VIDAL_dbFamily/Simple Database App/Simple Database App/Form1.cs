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
    public partial class Form1 : Form
    {
        Form4 f = new Form4();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Form5 objForm = new Form5();
            objForm.TopLevel = false;
            panel1.Controls.Add(objForm);
            objForm.Dock = DockStyle.Fill;
            objForm.Show();
        }

        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Form3 myForm = new Form3();
            myForm.TopLevel = false;
            panel1.Controls.Add(myForm);
            myForm.Dock = DockStyle.Fill;
            myForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Form4 myForm = new Form4();
            myForm.TopLevel = false;
            panel1.Controls.Add(myForm);
            myForm.Dock = DockStyle.Fill;
            myForm.Show();
           
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Form2 objForm = new Form2();
            objForm.TopLevel = false;
            panel1.Controls.Add(objForm);
            objForm.Dock = DockStyle.Fill;
            objForm.Show();
        }
    }
}