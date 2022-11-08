using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Pharmacy_Management_System
{
    public partial class View_Staff_Details : Form
    {
        SqlConnection con;
        SqlCommand com;
        string sql;
        public View_Staff_Details()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\User\Desktop\Pharmacy Mangement System\Pharmacy_Management_System\Pharmacy_Management_System\staffDetails.mdf;Integrated Security=True;User Instance=True");

        }

        private void View_Staff_Details_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login_Admin la = new Login_Admin();
            la.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "select * from details";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                con.Open();
                DataTable di = new DataTable();
                da.Fill(di);
                dataGridView1.DataSource = di;
                con.Close();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("Sorry there are some went to wrong, Please try again..!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

     
    }
}
