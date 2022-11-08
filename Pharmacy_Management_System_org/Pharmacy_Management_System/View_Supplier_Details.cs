using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pharmacy_Management_System
{
    public partial class View_Supplier_Details : Form
    {
        SqlConnection con;
        SqlCommand com;
        string sql;
        public View_Supplier_Details()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\Pharmacy_Management_System\Pharmacy_Management_System\Medicine.mdf;Integrated Security=True;User Instance=True");
        }

        private void View_Supplier_Details_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd0 = new SqlCommand("SELECT supplierName FROM sDetails", con);

            SqlDataReader reader0 = cmd0.ExecuteReader();
            AutoCompleteStringCollection MyCollection0 = new AutoCompleteStringCollection();
            while (reader0.Read())
            {
                MyCollection0.Add(reader0.GetString(0));
            }
            textBox1.AutoCompleteCustomSource = MyCollection0;
            con.Close();
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
                sql = "select * from sDetails where supplierID ='" + comboBox1.Text + "'";

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            com = new SqlCommand("select distinct * from sDetails where supplierName = '" + textBox1.Text + "'", con);

            SqlDataReader dr1;
            dr1 = com.ExecuteReader();
            while (dr1.Read())
            {
                comboBox1.Items.Add(dr1["supplierID"].ToString());
            }
            dr1.Close();
            con.Close();
        }
    }
}
