using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Configuration;



namespace Pharmacy_Management_System
{
    public partial class Modify_Medicine_Details : Form
    {
        SqlConnection con;
        SqlCommand com;
        string sql;
        public Modify_Medicine_Details()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Jathurshan Sumaniran\Desktop\Pharmacy_Management_System\Pharmacy_Management_System\Medicine.mdf;Integrated Security=True;User Instance=True");
        }

        private void Modify_Medicine_Details_Load(object sender, EventArgs e)
        {


           

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 109 || e.KeyChar == 103 || e.KeyChar == 107 ? false : true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login_Admin la = new Login_Admin();
            la.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if ((comboBox1.Text == ""))
                {
                    MessageBox.Show("sorry,please add the full details", "Warning");
                }
                con.Open();

                com = new SqlCommand("select * from details_M where CONVERT (varchar,mID) ='" + comboBox1.Text + "'", con);
                sql = "select * from details_M where CONVERT (varchar,mID) ='" + comboBox1.Text + "'";
                SqlDataReader dr;
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    comboBox2.Text = dr[0].ToString();
                    textBox8.Text = dr[1].ToString();
                    textBox7.Text = dr[2].ToString();
                    textBox3.Text = dr[3].ToString();
                    textBox4.Text = dr[4].ToString();
                    textBox5.Text = dr[5].ToString();
                    textBox2.Text = dr[6].ToString();
                    textBox1.Text = dr[7].ToString();
                    textBox11.Text = dr[8].ToString();
                    textBox6.Text = dr[9].ToString();
                    dateTimePicker1.Text = dr[10].ToString();
                    dateTimePicker2.Text = dr[11].ToString();
                    dateTimePicker3.Text = dr[12].ToString();
                    textBox10.Text = dr[13].ToString();
                    textBox9.Text = dr[14].ToString();
                    textBox14.Text = dr[15].ToString();

                }
                dr.Close();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);

                DataTable di = new DataTable();
                da.Fill(di);
                dataGridView1.DataSource = di;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String ax, ab, cd, ef, gh, ij, kl, mn, pq, qr, st, uv, kn, lo, po,cv;
            try
            {
                con.Open();
                ax = comboBox2.Text;
                ab = textBox8.Text;
                cd = textBox7.Text;
                ef = textBox3.Text;
                gh = textBox4.Text;
                ij = textBox5.Text;
                kn = textBox2.Text;
                lo = textBox1.Text;
                po = textBox11.Text;
                kl = textBox6.Text;
                mn = dateTimePicker1.Text;
                pq = dateTimePicker2.Text;
                qr = dateTimePicker3.Text;
                st = textBox10.Text;
                uv = textBox9.Text;
                cv = textBox14.Text;

                SqlCommand cmd = new SqlCommand("UPDATE details_M SET category= '" + ax + "',mName ='" + cd + "', batchNo='" + ef + "',dosage ='" + gh + "', manufacturer ='" + ij + "', importBy ='" + kn + "', brandName ='" + lo + "', genericName ='" + po + "', quantity ='" + kl + "',entryDate ='" + mn + "',  manufactureDate ='" + pq + "', expiryDate ='" + qr + "', buyingPrice ='" + st + "',sellingPrice ='" + uv + "',supplierID ='" + cv + "' WHERE CONVERT(VARCHAR,mID) ='" + comboBox1.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("details are modified");

                SqlDataAdapter da = new SqlDataAdapter(sql, con);

                DataTable di = new DataTable();
                da.Fill(di);
                dataGridView1.DataSource = di;
                con.Close();
                


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Login_Admin la = new Login_Admin();
            la.Show();
            this.Hide();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select mName from details_M where category = '" + comboBox3.Text + "'", con);

            SqlDataReader reader = cmd.ExecuteReader();
            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            while (reader.Read())
            {
                MyCollection.Add(reader.GetString(0));
            }
            textBox12.AutoCompleteCustomSource = MyCollection;
            con.Close();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            com = new SqlCommand("select distinct * from details_M where mName = '" + textBox12.Text + "'", con);

            SqlDataReader dr1;
            dr1 = com.ExecuteReader();
            while (dr1.Read())
            {
                comboBox1.Items.Add(dr1["mID"].ToString());
            }
            dr1.Close();
            con.Close();
        }

    }
}
