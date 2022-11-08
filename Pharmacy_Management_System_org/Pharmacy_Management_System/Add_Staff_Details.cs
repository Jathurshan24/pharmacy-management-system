using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace Pharmacy_Management_System
{
    public partial class Add_Staff_Details : Form
    {
        SqlConnection con;
        SqlCommand com;
        string sql;
        public Add_Staff_Details()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Jathurshan Sumaniran\Desktop\Pharmacy_Management_System\Pharmacy_Management_System\staffDetails.mdf;Integrated Security=True;User Instance=True");
           

        }

           

        public long CalcAge(System.DateTime StartDate, System.DateTime EndDate)
            {
	            long age =0;
            System.TimeSpan ts = new TimeSpan(EndDate.Ticks - StartDate.Ticks);
            age = (long)(ts.Days/365);

            return age;
            }
                
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (RegExp.checkForEmail(textBox11.Text.ToString()))
            {
                label18.Text = "Valid mail Id";
                label18.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label18.Text = "InValid mail Id";
                label18.ForeColor = System.Drawing.Color.Red;
            }
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
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 118 || e.KeyChar == 120 || e.KeyChar == 86 || e.KeyChar == 88 ? false : true;
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 32 ? false : true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string ab, cd, ef, gh, ij, kl, mn, op, qr, st, uv, xy, mk;

                ab = textBox8.Text;
                cd = dateTimePicker1.Text;
                ef = comboBox1.Text;
                gh = textBox4.Text;
                ij = textBox5.Text;
                kl = textBox6.Text;
                mn = textBox10.Text;
                op = textBox9.Text;
                qr = dateTimePicker2.Text;
                st = textBox11.Text;
                uv = textBox13.Text;
                xy = textBox2.Text;
                mk = textBox1.Text;

               
                    


               
                if ((ab == "") || (cd == "") || (ef == "") || (gh == "") || (ij == "") || (kl == "") || (mn == "") || (op == "") || (ab == "") || (qr == "") || (st == "") || (uv == "") || (xy == "") || (mk == ""))
                {
                    MessageBox.Show("please add the full details", "Warning");
                    label18.Text = string.Empty;
                }
                   
                 else if (RegExp.checkForEmail(textBox11.Text.ToString()))
                {
                    label18.Text = string.Empty;

                    StringBuilder hash = new StringBuilder();
                MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
                byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(xy));

                for (int i = 0; i < bytes.Length; i++)
                {
                    hash.Append(bytes[i].ToString("x2"));
                }

                        con.Open();
                        sql = "insert into details values('" + ab + "','" + cd + "','" + ef + "','" + gh + "','" + ij + "','" + kl + "','" + mn + "','" + op + "','" + qr + "','" + st + "','" + uv + "','" + hash + "','" + mk + "')";
                        com = new SqlCommand(sql, con);
                        com.ExecuteNonQuery();

                        con.Close();

                     /*   con.Open();
                        sql = "insert into detailsAdmin values('" + uv + "','" + hash + "','" + mk + "')";
                        com = new SqlCommand(sql, con);
                        com.ExecuteNonQuery();

                        con.Close();*/

                
                    MessageBox.Show("successfully added", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    label18.Text = string.Empty;
                    textBox8.Text = "";
                    dateTimePicker1.Text = "";
                    comboBox1.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox10.Text = "";
                    textBox9.Text = "";
                    dateTimePicker2.Text = "";
                    textBox11.Text = "";
                    textBox13.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = "";

                }
                else
                {
                    label18.Text = string.Empty;
                    textBox8.Text = "";
                    dateTimePicker1.Text = "";
                    comboBox1.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox10.Text = "";
                    textBox9.Text = "";
                    dateTimePicker2.Text = "";
                    textBox11.Text = "";
                    textBox13.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = "";
              
                }
            }


           catch (Exception ex1)
            {
                MessageBox.Show("sorry there are something went wrong, please try again..!!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
            dateTimePicker1.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox10.Text = "";
            textBox9.Text = "";
            dateTimePicker2.Text = "";
            textBox11.Text = "";
            textBox13.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";
            label18.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login_Admin la = new Login_Admin();
            la.Show();
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > DateTime.Now)
            {

                dateTimePicker1.Value = DateTime.Now;
                MessageBox.Show("select the correct date ..!!");
            }
            else
            {
                DateTime startdate = dateTimePicker1.Value;
                DateTime Enddate = dateTimePicker3.Value;
                textBox10.Text = CalcAge(startdate, Enddate).ToString();
            }
        }

        private void Add_Staff_Details_Load(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker1.Focus();
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox9.Focus();
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker2.Focus();
            }
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox11.Focus();
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox13.Focus();
            }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length < 10)
            {
                label19.Text = "Enter the correct number..";
                label19.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label19.Text = "Valid number..";
                label19.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text.Length < 10)
            {
                label20.Text = "Enter the correct NIC no..";
                label20.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label20.Text = "Valid number NIC no..";
                label20.ForeColor = System.Drawing.Color.Green;
            }
        }

    }
}
