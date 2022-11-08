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
    public partial class Form1 : Form
    {
        SqlConnection con,con2 ;
        SqlDataAdapter sda,sda2;
        DataTable data;

        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = textBox1;
            textBox1.Focus();
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=H:\drive3\Project Software Eng\Pharmacy_Management_System\Pharmacy_Management_System\staffDetails.mdf;Integrated Security=True;User Instance=True");
            con2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=H:\drive3\Project Software Eng\Pharmacy_Management_System\Pharmacy_Management_System\Medicine.mdf;Integrated Security=True;User Instance=True");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
          try
           {
                if (textBox1.Text == "" || textBox2.Text == "" || (textBox1.Text == "" && textBox2.Text == ""))
                {
                    MessageBox.Show("Please enter the correct Username and Password!!", "Warning");
                }
                else
                {
                  /*  StringBuilder hash = new StringBuilder();
                    MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
                    byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(textBox2.Text));

                    for (int i = 0; i < bytes.Length; i++)
                    {
                        hash.Append(bytes[i].ToString("x2"));
                    }*/
                    con.Open();
                    sda = new SqlDataAdapter("select * from detailsAdmin where username='" + textBox1.Text + "' and password='" + hash + "'", con);
                    sda.SelectCommand.ExecuteNonQuery();
                    data = new System.Data.DataTable();
                    sda.Fill(data);
                    con.Close();


                    if (data.Rows.Count == 1)
                    {

                        MessageBox.Show("Successfully Login as Admin!!");
                        this.Hide();
                        Login_Admin lg = new Login_Admin();
                        lg.Show();


                      


                    }

                    else
                    {
                        con.Open();
                        sda = new SqlDataAdapter("select * from details where role='" + textBox1.Text + "' and password='" + hash + "'", con);
                        sda.SelectCommand.ExecuteNonQuery();
                        data = new System.Data.DataTable();
                        sda.Fill(data);
                        con.Close();

                        if (data.Rows.Count == 1)
                        {
                            MessageBox.Show("Successfully Login as User!!");

                            this.Hide();
                            Login_User lu = new Login_User();
                            lu.Show();

                            SqlCommand cmd = new SqlCommand("Select Count(*) from details_M where quantity<=50", con2);
                            sda2 = new SqlDataAdapter();
                            sda2.SelectCommand = cmd;
                            DataTable data2 = new DataTable();

                            sda2.Fill(data2);
                            if (data2.Rows[0][0].ToString() == "1")
                            {
                                MessageBox.Show("Some of your stocks are less than 50 quantity item so check it and refill it..!!");
                            }



                        }

                        else
                        {
                            MessageBox.Show("Please enter correct Username and Password..!! ");
                            textBox1.Text = "";
                            textBox2.Text = "";
                        }
                    }
                }

        }
            

           catch (Exception ex1)
            {
                MessageBox.Show("Sorry there are some went to wrong, Please try again..!!");
            }
       }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
    }
}
