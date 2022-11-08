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
    public partial class View_Stock2 : Form
    {
        SqlConnection con;
        SqlCommand com;
        string sql;
        public View_Stock2()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\Pharmacy_Management_System\Pharmacy_Management_System\Medicine.mdf;Integrated Security=True;User Instance=True");
        }

        private void View_Stock2_Load(object sender, EventArgs e)
        {
            con.Open();
            com = new SqlCommand("select * from details_M", con);

            SqlDataReader dr;
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["mName"].ToString());

            }
            dr.Close();
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login_User la = new Login_User();
            la.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((comboBox1.Text == ""))
                {
                    MessageBox.Show("Sorry,please add the full details", "Warning");
                }

                sql = "select * from details_M where CONVERT(VARCHAR,mName) ='" + comboBox1.Text + "'";

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
            con.Open();
            SqlCommand cmd = new SqlCommand("Select mName from details_M where category = '" + comboBox1.Text + "'", con);

            SqlDataReader reader = cmd.ExecuteReader();
            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            while (reader.Read())
            {
                MyCollection.Add(reader.GetString(0));
            }
            textBox1.AutoCompleteCustomSource = MyCollection;
            con.Close();
        }
    }
}
