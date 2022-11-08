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
    public partial class View_Purchase : Form
    {
        SqlConnection con;
        SqlCommand com;
        String sql;

        public View_Purchase()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\Pharmacy_Management_System\Pharmacy_Management_System\Medicine.mdf;Integrated Security=True;User Instance=True");
        }


        private void button1_Click(object sender, EventArgs e)
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

        private void View_Purchase_Load(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            Login_Admin lu = new Login_Admin();
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

       
    }
}
