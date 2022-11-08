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
    public partial class View_Sales : Form
    {
        SqlConnection con;
        SqlCommand com;
        String sql, sql1;
        public View_Sales()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\Pharmacy_Management_System\Pharmacy_Management_System\Medicine.mdf;Integrated Security=True;User Instance=True");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void View_Purchase_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT billNo FROM purchase", con);

            SqlDataReader reader = cmd.ExecuteReader();
            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            while (reader.Read())
            {
                MyCollection.Add(reader.GetString(0));
            }
            textBox1.AutoCompleteCustomSource = MyCollection;
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
                if ((textBox1.Text == ""))
                {
                    MessageBox.Show("Sorry,please add the full details", "Warning");
                }

                sql = "select * from retails where billNo ='" + textBox1.Text + "'";

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
            try
            {
                if ((textBox1.Text == ""))
                {
                    MessageBox.Show("Sorry,please add the full details", "Warning");
                }

                sql = "select * from purchase where billNo ='" + textBox1.Text + "'";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                con.Open();
                DataTable di = new DataTable();
                da.Fill(di);
                dataGridView2.DataSource = di;
                con.Close();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("Sorry there are some went to wrong, Please try again..!!");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if ((dateTimePicker1.Text == ""))
                {
                    MessageBox.Show("Sorry,please add the full details", "Warning");
                }

                sql = "select * from purchase where date ='" + dateTimePicker1.Text + "'";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                con.Open();
                DataTable di = new DataTable();
                da.Fill(di);
                dataGridView2.DataSource = di;
                con.Close();

                sql1 = "select * from retails where date ='" + dateTimePicker1.Text + "'";

                SqlDataAdapter da1 = new SqlDataAdapter(sql, con);
                con.Open();
                DataTable di1 = new DataTable();
                da.Fill(di1);
                dataGridView1.DataSource = di1;
                con.Close();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("sorry there are something went  wrong, Please try again..!!");
            }

        }


    }
}
