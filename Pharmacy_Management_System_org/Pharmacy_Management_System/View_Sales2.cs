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
    public partial class View_Sales2 : Form
    {
        SqlConnection con;
        SqlCommand com;
        String sql, sql1;
        public View_Sales2()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\Pharmacy_Management_System\Pharmacy_Management_System\Medicine.mdf;Integrated Security=True;User Instance=True");
        }

        private void View_Purchase2_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT billNo FROM purchase", con);

            SqlDataReader reader = cmd.ExecuteReader();
            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            while (reader.Read())
            {
                MyCollection.Add(reader.GetString(0));
            }
            textBox2.AutoCompleteCustomSource = MyCollection;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                if ((textBox2.Text == ""))
                {
                    MessageBox.Show("Sorry,please add the full details", "Warning");
                }

                sql = "select * from retail where billNo ='" + textBox2.Text + "'";

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
                if ((textBox2.Text == ""))
                {
                    MessageBox.Show("Sorry,please add the full details", "Warning");
                }

                sql = "select * from purchase where billNo ='" + textBox2.Text + "'";

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

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
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
                MessageBox.Show("sorry there are something went wrong, Please try again..!!");
            }
        }
    }
}
