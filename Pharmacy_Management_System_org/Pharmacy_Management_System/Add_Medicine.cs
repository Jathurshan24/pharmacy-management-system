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
    public partial class Add_Medicine : Form
    {
        SqlConnection con;
        SqlCommand com;
        string sql;
        public Add_Medicine()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Pharmacy_Management_System\Pharmacy_Management_System\Medicine.mdf;Integrated Security=True;User Instance=True");
        }
        
        private void Add_Medicine_Load(object sender, EventArgs e)
        {
            textBox12.Text = dateTimePicker1.Value.ToShortDateString();

            con.Open();
            SqlCommand cmd0 = new SqlCommand("SELECT mID FROM details_M", con);

            SqlDataReader reader0 = cmd0.ExecuteReader();
            AutoCompleteStringCollection MyCollection0 = new AutoCompleteStringCollection();
            while (reader0.Read())
            {
                MyCollection0.Add(reader0.GetString(0));
            }
            textBox1.AutoCompleteCustomSource = MyCollection0;
            con.Close();
            
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT mName FROM details_M", con);

            SqlDataReader reader = cmd.ExecuteReader();
            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            while (reader.Read())
            {
                MyCollection.Add(reader.GetString(0));
            }
            textBox2.AutoCompleteCustomSource = MyCollection;
            con.Close();

            con.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT batchNo FROM details_M", con);

            SqlDataReader reader1 = cmd1.ExecuteReader();
            AutoCompleteStringCollection MyCollection1 = new AutoCompleteStringCollection();
            while (reader1.Read())
            {
                MyCollection1.Add(reader1.GetString(0));
            }
            textBox3.AutoCompleteCustomSource = MyCollection1;
            con.Close();

            con.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT dosage FROM details_M", con);

            SqlDataReader reader2 = cmd2.ExecuteReader();
            AutoCompleteStringCollection MyCollection2 = new AutoCompleteStringCollection();
            while (reader2.Read())
            {
                MyCollection2.Add(reader2.GetString(0));
            }
            textBox4.AutoCompleteCustomSource = MyCollection2;
            con.Close();

            con.Open();
            SqlCommand cmd3 = new SqlCommand("SELECT manufacturer FROM details_M", con);

            SqlDataReader reader3 = cmd3.ExecuteReader();
            AutoCompleteStringCollection MyCollection3 = new AutoCompleteStringCollection();
            while (reader3.Read())
            {
                MyCollection3.Add(reader3.GetString(0));
            }
            textBox5.AutoCompleteCustomSource = MyCollection3;
            con.Close();


            con.Open();
            SqlCommand cmd4 = new SqlCommand("SELECT importBy FROM details_M", con);

            SqlDataReader reader4 = cmd4.ExecuteReader();
            AutoCompleteStringCollection MyCollection4 = new AutoCompleteStringCollection();
            while (reader4.Read())
            {
                MyCollection4.Add(reader4.GetString(0));
            }
            textBox9.AutoCompleteCustomSource = MyCollection4;
            con.Close();

            con.Open();
            SqlCommand cmd5 = new SqlCommand("SELECT brandName FROM details_M", con);

            SqlDataReader reader5 = cmd5.ExecuteReader();
            AutoCompleteStringCollection MyCollection5 = new AutoCompleteStringCollection();
            while (reader5.Read())
            {
                MyCollection5.Add(reader5.GetString(0));
            }
            textBox10.AutoCompleteCustomSource = MyCollection5;
            con.Close();

            con.Open();
            SqlCommand cmd6 = new SqlCommand("SELECT genericName FROM details_M", con);

            SqlDataReader reader6 = cmd6.ExecuteReader();
            AutoCompleteStringCollection MyCollection6 = new AutoCompleteStringCollection();
            while (reader6.Read())
            {
                MyCollection6.Add(reader6.GetString(0));
            }
            textBox11.AutoCompleteCustomSource = MyCollection6;
            con.Close();
        }              

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 109 || e.KeyChar == 108 || e.KeyChar == 103 || e.KeyChar == 107 ? false : true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46 ? false : true;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46 ? false : true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login_Admin la = new Login_Admin();
            la.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string x, ab, cd, ef, gh, ij, kl, mn, op, qr, st, uv, xy, mk, im, br, gn, cv;

                x = comboBox1.Text;
                ab = textBox1.Text;
                cd = textBox2.Text;
                ef = textBox3.Text;
                gh = textBox4.Text;
                ij = textBox5.Text;
                im = textBox9.Text;
                br = textBox10.Text;
                gn = textBox11.Text;
                kl = textBox6.Text;
                mn = textBox12.Text;
                op = dateTimePicker2.Text;
                qr = dateTimePicker3.Text;
                st = textBox7.Text;
                uv = textBox8.Text;
                cv = textBox13.Text;


                if ((x == "") || (ab == "") || (cd == "") || (ef == "") || (gh == "") || (ij == "") || (kl == "") || (mn == "") || (op == "") || (qr == "") || (st == "") || (uv == "") || (im == "") || (br == "") || (gn == "") || (cv == ""))
                {
                    MessageBox.Show("please add the full details", "Warning");
                }
                else 
                {
                    
                    con.Open();
                    sql = "insert into details_M values('" + x + "','" + ab + "','" + cd + "','" + ef + "','" + gh + "','" + im + "','" + br + "','" + gn + "','" + ij + "','" + kl + "','" + mn + "','" + op + "','" + qr + "','" + st + "','" + uv + "','" + cv + "')";
                    com = new SqlCommand(sql, con);
                    com.ExecuteNonQuery();

                    con.Close();
                    MessageBox.Show("successfully added", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);



                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = "";
                    textBox3.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
                    textBox11.Text = "";
                    dateTimePicker1.Text = "";
                    dateTimePicker2.Text = "";
                    dateTimePicker3.Text = "";
                    textBox13.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("something went wrong, try again..!!");
            }
        }
         
        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox5.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            dateTimePicker3.Text = "";
            textBox13.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
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
                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
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
                textBox9.Focus();
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox10.Focus();
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox13.Focus();
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
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
                dateTimePicker2.Focus();
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker3.Focus();
            }
        }

        private void dateTimePicker3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox7.Focus();
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox8.Focus();
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value > DateTime.Now)
            {
                dateTimePicker2.Value = DateTime.Now;
                MessageBox.Show("select the correct date ..!!","warning");
               
            }

         
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker3.Value < DateTime.Now)
            {

                dateTimePicker3.Value = DateTime.Now;
                MessageBox.Show("select the correct date ..!!", "warning");
                
            }

        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox11.Focus();
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
