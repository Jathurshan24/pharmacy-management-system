using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Pharmacy_Management_System
{
    public partial class ChangePassword : Form
    {
       // SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Jathurshan Sumaniran\Desktop\karna\Pharmacy_Management_System\Pharmacy_Management_System\staffDetails.mdf;Integrated Security=True;User Instance=True");
         SqlDataAdapter sda,sda2;
        DataTable data;
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Login_Admin lg = new Login_Admin();
            lg.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f = new Form1();
            f.Show();
        }



        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("One or more fields are blank..!!", "Warning");
            }

            else
            {
                StringBuilder hash = new StringBuilder();
                MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
                byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(textBox2.Text));

                for (int i = 0; i < bytes.Length; i++)
                {
                    hash.Append(bytes[i].ToString("x2"));
                }

                StringBuilder hash1 = new StringBuilder();
                MD5CryptoServiceProvider md5provider1 = new MD5CryptoServiceProvider();
                byte[] bytes1 = md5provider1.ComputeHash(new UTF8Encoding().GetBytes(textBox1.Text));

                for (int j = 0; j < bytes1.Length; j++)
                {
                    hash1.Append(bytes1[j].ToString("x2"));
                }
                try
                {

                    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\Pharmacy_Management_System\Pharmacy_Management_System\staffDetails.mdf;Integrated Security=True;User Instance=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update detailsAdmin set password='" + hash + "' where username='" + textBox4.Text + "' and password = '" + hash1 + "'", con);
                    SqlCommand cmd1 = new SqlCommand("update details set password='" + hash + "' where username='" + textBox4.Text + "' and password = '" + hash1 + "'", con);
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    label5.Text = "Successfully updated..!!";
                    label5.ForeColor = System.Drawing.Color.Green;


                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                   
                }



                catch (Exception ex1)
                {
                    label5.Text = "You have some problems in updating please try again..!!";
                    label5.ForeColor = System.Drawing.Color.Red;

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";

                }




            }

                    }

                

               
       
     
       


        private void textBox3_TextChanged(object sender, EventArgs e)
        {
          

            if ((textBox2.Text == textBox3.Text) && textBox1.Text != "" && textBox2.Text != "")
            {
                label5.Text = "Password is matching..!!";
                label5.ForeColor = System.Drawing.Color.Green;
            }

            if ((textBox2.Text != textBox3.Text))
            {
                label5.Text = "Password is not matching..!!";
                label5.ForeColor = System.Drawing.Color.Red;
            }
        
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
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
                 button2.PerformClick();
            }
        }

    }
}
