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
    public partial class Modify_Supplier_Details : Form
    {
        SqlConnection con;
        SqlCommand com;
        string sql;
        public Modify_Supplier_Details()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Jathurshan Sumaniran\Desktop\karna\Pharmacy_Management_System\Pharmacy_Management_System\Medicine.mdf;Integrated Security=True;User Instance=True");

        }

        private void Modify_Supplier_Details_Load(object sender, EventArgs e)
        {
            con.Open();
            com = new SqlCommand("select * from sDetails", con);

            SqlDataReader dr;
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["supplierID"].ToString());

            }
            dr.Close();
            con.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32 || e.KeyChar == 46 ? false : true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (RegExp.checkForEmail(textBox4.Text.ToString()))
            {
                label10.Text = "Valid mail Id";
                label10.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label10.Text = "InValid mail Id";
                label10.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
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
                if ((textBox1.Text == "") || (comboBox1.Text == ""))
                {
                    MessageBox.Show("Sorry,please add the full details", "Warning");
                }

                con.Open();
                com = new SqlCommand("select * from sDetails where supplierID ='" + comboBox1.Text + "'", con);
                sql = "select * from sDetails where supplierID ='" + comboBox1.Text + "'";
                SqlDataReader dr;
                dr = com.ExecuteReader();
                while (dr.Read())
                {

                    textBox7.Text = dr[0].ToString();
                    textBox6.Text = dr[1].ToString();
                    textBox3.Text = dr[2].ToString();
                    textBox2.Text = dr[3].ToString();
                    textBox4.Text = dr[4].ToString();
                    textBox5.Text = dr[5].ToString();
                    richTextBox1.Text = dr[6].ToString();


                }
                dr.Close();

                SqlDataAdapter da = new SqlDataAdapter(sql, con);

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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox5.Text == "") || (textBox7.Text == "") || (richTextBox1.Text == "") || (textBox4.Text == "") || (textBox5.Text == "") || (textBox2.Text == "") || (textBox6.Text == ""))
                {
                    label10.Text = string.Empty;
                    MessageBox.Show("Sorry,please add the full details", "Warning");
                }
                else if (RegExp.checkForEmail(textBox4.Text.ToString()))
                {
                    label10.Text = string.Empty;
                    con.Open();
                    String ab, cd, ef, gh, ij, kl, mn;

                    ab = textBox7.Text;
                    cd = textBox6.Text;
                    ef = textBox3.Text;
                    gh = textBox2.Text;
                    ij = textBox4.Text;
                    kl = textBox5.Text;
                    mn = richTextBox1.Text;


                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    //string sql = "UPDATE details SET name = '" + ab + "', dob = '" + cd + "', gender = '" + ef + "', address = '" + gh + "', contactNum = '" + ij + "', age = '" + mn + "' , salary = '" + op + "' , joiningDate = '" + qr + "' , email = '" + st + "' , username = '" + uv + "' , password = '" + xy + "' , role = '" + mk + "' where NICno = '" +hs + "'";
                    string sql = "UPDATE sDetails SET supplierID = '" + ab + "',supplierName = '" + cd + "', companyName = '" + ef + "' ,licenceNo = '" + gh + "' ,contactNum = '" + ij + "', address = '" + mn + "' where supplierID = '" + comboBox1.Text + "'";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    //com = new OleDbCommand(sql,con);
                    // com.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Succesfully Updated", "Update");


                    textBox7.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox3.Text = "";
                    textBox2.Text = "";
                    richTextBox1.Text = "";

                }

                else
                {
                    label10.Text = string.Empty;
                    textBox7.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox3.Text = "";
                    textBox2.Text = "";
                    richTextBox1.Text = "";
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show("Sorry there are some went to wrong, Please try again..!!");
            }
        }


       
    }
}
