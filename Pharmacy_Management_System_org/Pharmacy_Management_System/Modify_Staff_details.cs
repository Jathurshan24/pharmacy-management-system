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
    public partial class Modify_Staff_details : Form
    {
        SqlConnection con;
        SqlCommand com;
        string sql;
        public Modify_Staff_details()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Jathurshan Sumaniran\Desktop\karna\Pharmacy_Management_System\Pharmacy_Management_System\staffDetails.mdf;Integrated Security=True;User Instance=True");
        }

        private void Modify_Staff_details_Load(object sender, EventArgs e)
        {
            con.Open();
            com = new SqlCommand("select * from details",con);
  
            SqlDataReader dr;
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr["NICno"].ToString());

            }
            dr.Close();
            con.Close();

        }


        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 32 ? false : true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 86 || e.KeyChar == 88 ? false : true;
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 32 ? false : true;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (RegExp.checkForEmail(textBox11.Text.ToString()))
            {
                label11.Text = "Valid mail Id";
                label11.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label11.Text = "InValid mail Id";
                label11.ForeColor = System.Drawing.Color.Red;
            }
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
                if ((textBox1.Text == "") || (comboBox3.Text == ""))
                {
                    MessageBox.Show("Sorry,please add the full details", "Warning");
                }

                con.Open();
                com = new SqlCommand("select * from details where NICno ='" + comboBox3.Text + "'", con);
                sql = "select * from details where NICno ='" + comboBox3.Text + "'";
                SqlDataReader dr;
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    textBox8.Text = dr[0].ToString();
                    dateTimePicker1.Text = dr[1].ToString();
                    comboBox2.Text = dr[2].ToString();
                    textBox4.Text = dr[3].ToString();
                    textBox5.Text = dr[4].ToString();
                    textBox6.Text = dr[5].ToString();
                    textBox10.Text = dr[6].ToString();
                    textBox9.Text = dr[7].ToString();
                    dateTimePicker2.Text = dr[8].ToString();
                    textBox11.Text = dr[9].ToString();
                    textBox15.Text = dr[10].ToString();
                    textBox14.Text = dr[11].ToString();
                    textBox13.Text = dr[12].ToString();
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
                if ((textBox8.Text == "") || (dateTimePicker1.Text == "") || (comboBox2.Text == "") || (textBox4.Text == "") || (textBox5.Text == "") || (textBox6.Text == "") || (textBox10.Text == "") || (textBox9.Text == "") || (dateTimePicker2.Text == "") || (textBox11.Text == "") || (textBox15.Text == "") || (textBox14.Text == "") || (textBox13.Text == ""))
                {
                    label11.Text = string.Empty;
                    MessageBox.Show("Sorry,please add the full details", "Warning");
                }
                else if (RegExp.checkForEmail(textBox11.Text.ToString()))
                {
                    label11.Text = string.Empty;

                    con.Open();
                    String ab, cd, ef, gh, ij, kl, mn, op, qr, st, uv, xy, mk, hs;

                    ab = textBox8.Text;
                    cd = dateTimePicker1.Text;
                    ef = comboBox2.Text;
                    gh = textBox4.Text;
                    ij = textBox5.Text;
                    kl = textBox6.Text;
                    mn = textBox10.Text;
                    op = textBox9.Text;
                    qr = dateTimePicker2.Text;
                    st = textBox11.Text;
                    uv = textBox15.Text;
                    xy = textBox14.Text;
                    mk = textBox13.Text;
                    hs = comboBox3.Text;


                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    //string sql = "UPDATE details SET name = '" + ab + "', dob = '" + cd + "', gender = '" + ef + "', address = '" + gh + "', contactNum = '" + ij + "', age = '" + mn + "' , salary = '" + op + "' , joiningDate = '" + qr + "' , email = '" + st + "' , username = '" + uv + "' , password = '" + xy + "' , role = '" + mk + "' where NICno = '" +hs + "'";
                    string sql = "UPDATE details SET name = '" + ab + "',dob = '" + cd + "', gender = '" + ef + "' , address = '" + gh + "' ,contactNum = '" + ij + "', age = '" + mn + "' where NICno = '" + hs + "'";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    //com = new OleDbCommand(sql,con);
                    // com.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Succesfully Updated", "Update");

                    textBox8.Text = "";
                    dateTimePicker1.Text = "";
                    comboBox2.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox10.Text = "";
                    textBox9.Text = "";
                    dateTimePicker2.Text = "";
                    textBox11.Text = "";
                    textBox15.Text = "";
                    textBox14.Text = "";
                    textBox13.Text = "";
                }

                else
                {
                    label11.Text = string.Empty;

                    textBox8.Text = "";
                    dateTimePicker1.Text = "";
                    comboBox2.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox10.Text = "";
                    textBox9.Text = "";
                    dateTimePicker2.Text = "";
                    textBox11.Text = "";
                    textBox15.Text = "";
                    textBox14.Text = "";
                    textBox13.Text = "";
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show("Sorry there are some went to wrong, Please try again..!!");
            }
        }
       
   

      
    }
}
