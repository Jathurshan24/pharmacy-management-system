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
    public partial class View_Purchase2 : Form

    {
        SqlConnection con;
        SqlCommand com;
        String sql;
        public View_Purchase2()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\Pharmacy_Management_System\Pharmacy_Management_System\Medicine.mdf;Integrated Security=True;User Instance=True");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login_User lu= new Login_User();
            lu.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            com = new SqlCommand("select * from details_M where mID = '" + comboBox1.Text + "'", con);

            SqlDataReader dr;
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["supplierID"].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void View_Purchase2_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT mName FROM details_M", con);

            SqlDataReader reader = cmd.ExecuteReader();
            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            while (reader.Read())
            {
                MyCollection.Add(reader.GetString(0));
            }
            textBox1.AutoCompleteCustomSource = MyCollection;
            con.Close();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            com = new SqlCommand("select * from details_M where mName = '" + textBox1.Text + "'", con);

            SqlDataReader dr;
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["mID"].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((comboBox2.Text == ""))
                {
                    MessageBox.Show("Sorry,please add the full details", "Warning");
                }

                sql = "select * from details_M  d,sDetails s where d.supplierID ='" + comboBox2.Text + "' and s.supplierID=d.supplierID";

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

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            com = new SqlCommand("select * from details_M where mName = '" + textBox1.Text + "'", con);

            SqlDataReader dr;
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["mID"].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            con.Open();
            com = new SqlCommand("select * from details_M where mID = '" + comboBox1.Text + "'", con);

            SqlDataReader dr;
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["supplierID"].ToString());
            }
            dr.Close();
            con.Close();
        }
    }
}
