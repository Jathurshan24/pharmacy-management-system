using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pharmacy_Management_System
{
    public partial class Login_User : Form
    {
        public Login_User()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            View_Sales2 frm19 = new View_Sales2();
            frm19.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            View_Stock2 frm6 = new View_Stock2();
            frm6.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_Purchase2 vp = new View_Purchase2();
            vp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Retail_Sales_Details2 frm18 = new Retail_Sales_Details2();
            frm18.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void displayTime()
        {

        }

        private void Login_User_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label3.Text = DateTime.Now.ToLongDateString();
            label4.Text = DateTime.Now.ToLongTimeString();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to logout ?","Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
                Form1 f = new Form1();
                f.Show();
            }

            else
            {
                this.Show();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

     
    }
}