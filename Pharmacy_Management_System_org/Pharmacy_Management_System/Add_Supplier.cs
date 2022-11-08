using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pharmacy_Management_System
{
    public partial class Add_Supplier : Form
    {
        SqlConnection con;
        SqlCommand com;
        string sql;
        public Add_Supplier()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Jathurshan Sumaniran\Desktop\karna\Pharmacy_Management_System\Pharmacy_Management_System\Medicine.mdf;Integrated Security=True;User Instance=True");
        }
              
   

        private void Add_Supplier_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT companyName FROM sDetails", con);

            SqlDataReader reader = cmd.ExecuteReader();
            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            while (reader.Read())
            {
                MyCollection.Add(reader.GetString(0));
            }
            textBox3.AutoCompleteCustomSource = MyCollection;
            con.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
                label9.Text = "Valid mail Id";
                label9.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label9.Text = "InValid mail Id";
                label9.ForeColor = System.Drawing.Color.Red;
            }
        }                 

        private void button4_Click(object sender, EventArgs e)
        {
            Login_Admin la = new Login_Admin();
            la.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string ab, cd, ef, gh, ij, kl, mn, mk;

                ab = textBox1.Text;
                cd = textBox2.Text;
                ef = textBox3.Text;
                mn = textBox6.Text;
                gh = textBox4.Text;
                ij = textBox5.Text;
                kl = richTextBox1.Text;

                mk = textBox1.Text;
                if ((ab == "") || (cd == "") || (ef == "") || (ef == "") || (gh == "") || (ij == "") || (kl == ""))
                {
                    MessageBox.Show("please add the full details", "Warning");
                    label9.Text = string.Empty;
                }

                else if (RegExp.checkForEmail(textBox4.Text.ToString()))
                {
                    label9.Text = string.Empty;

                    con.Open();
                    sql = "insert into details_M values('" + ab + "','" + cd + "','" + ef + "','" + ef + "','" + gh + "','" + ij + "','" + kl + "')";
                    com = new SqlCommand(sql, con);
                    com.ExecuteNonQuery();

                    con.Close();
                    MessageBox.Show("successfully added", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);



                    textBox4.Text = "";
                    textBox5.Text = "";
                    richTextBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = "";
                    textBox3.Text = "";
                    textBox6.Text = "";

                }

                else
                {
                    label9.Text = string.Empty;
                    textBox4.Text = "";
                    textBox5.Text = "";
                    richTextBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = "";
                    textBox3.Text = "";
                    textBox6.Text = "";
                }
            }

            catch (Exception ex1)
            {
                MessageBox.Show("Sorry there are some went to wrong, please try again..!!");
            }
    
        }
        private void button6_Click(object sender, EventArgs e)
        {
            label9.Text = string.Empty;
            textBox4.Text = "";
            textBox5.Text = "";
            richTextBox1.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
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
                textBox6.Focus();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
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
                richTextBox1.Focus();
            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button5.PerformClick();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length < 10)
            {
                label10.Text = "Enter the correct number..";
                label10.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label10.Text = "Valid number..";
                label10.ForeColor = System.Drawing.Color.Green;
            }
        }        
    }
}
