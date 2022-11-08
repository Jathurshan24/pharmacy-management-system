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
    public partial class Delete_Medicine_Details : Form
    {
        SqlConnection con;
        SqlCommand com;
        string sql;
        public Delete_Medicine_Details()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\Pharmacy_Management_System\Pharmacy_Management_System\Medicine.mdf;Integrated Security=True;User Instance=True");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Delete_Medicine_Details_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
           try
            {
                if ((textBox1.Text == "") || (comboBox1.Text == ""))
                {
                    MessageBox.Show("sorry,please add the full details", "Warning");
                }
                con.Open();

                //com = new SqlCommand("select * from details where CONVERT (varchar,expiryDate) ='" + dateTimePicker1.Text + "'", con);
                sql = "select * from details_M where  CONVERT(varchar,mID) = '" + comboBox2.Text + "'";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);

                DataTable di = new DataTable();
                da.Fill(di);
                dataGridView1.DataSource = di;
                con.Close();
            }

            catch (Exception ex1)
            {
                MessageBox.Show("sorry there are something went wrong..!!");
            }
    }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
           // con.Open();
            if ((textBox1.Text == "") || (comboBox1.Text == ""))
            {
                MessageBox.Show("sorry,please add the full details", "Warning");
            }
            else
            {

                con.Open();

                DialogResult result = MessageBox.Show("Do you want to Remove the Member ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    sql = ("delete from details_M where CONVERT(VARCHAR,mID) ='" + comboBox2.Text + "'" );

                    com = new SqlCommand(sql, con);

                    com.ExecuteNonQuery();

                    MessageBox.Show("successfully deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    textBox1.Text = "";
                    comboBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("not deleted", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                    comboBox2.Text = "";

                }
                con.Close();
            }
            //con.Close();
        }
            catch (Exception ex1)
            {
                MessageBox.Show("sorry there are something went wrong..!!");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login_Admin la = new Login_Admin();
            la.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                com = new SqlCommand("select * from details_M where mName = '" + textBox1.Text + "'", con);
                SqlDataReader dr;
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    comboBox2.Items.Add(dr["mID"].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("sorry there are something went wrong, please try again..!!");
            }
        }
    }
}
