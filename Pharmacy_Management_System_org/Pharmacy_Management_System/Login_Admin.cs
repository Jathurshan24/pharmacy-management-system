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
    public partial class Login_Admin : Form
    {
        SqlConnection con;
        SqlCommand com;
        string sql, sql1;
        public Login_Admin()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Jathurshan Sumaniran\Desktop\Pharmacy_Management_System\Pharmacy_Management_System\Medicine.mdf;Integrated Security=True;User Instance=True");
            timer1.Start();
        }

        private void Login_Admin_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label5.Text = DateTime.Now.ToLongDateString();
            label6.Text = DateTime.Now.ToLongTimeString();

            con.Open();

            //com = new SqlCommand("select * from details where CONVERT (varchar,expiryDate) ='" + dateTimePicker1.Text + "'", con);
            sql = "select mID,mName,quantity,expiryDate from details_M where expiryDate = '" + dateTimePicker1.Value.ToShortDateString() + "'";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataTable di = new DataTable();
            da.Fill(di);
            dataGridView1.DataSource = di;
            con.Close();


            con.Open();

            //com = new SqlCommand("select * from details where CONVERT (varchar,expiryDate) ='" + dateTimePicker1.Text + "'", con);
            sql1 = "select mID,mName,quantity,expiryDate from details_M where quantity < 50";

            SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);

            DataTable di1 = new DataTable();
            da1.Fill(di1);
            dataGridView2.DataSource = di1;
            con.Close();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Medicine frm5 = new Add_Medicine();
            frm5.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            View_Stock frm6 = new View_Stock();
            frm6.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            View_Expiry_Date frm8 = new View_Expiry_Date();
            frm8.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Modify_Medicine_Details frm7 = new Modify_Medicine_Details();
            frm7.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Delete_Medicine_Details frm9 = new Delete_Medicine_Details();
            frm9.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Add_Staff_Details frm10 = new Add_Staff_Details();
            frm10.Show();
            this.Hide();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            View_Staff_Details frm11 = new View_Staff_Details();
            frm11.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Delete_Staff_Details frm12 = new Delete_Staff_Details();
            frm12.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Modify_Staff_details frm13 = new Modify_Staff_details();
            frm13.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Add_Supplier frm14 = new Add_Supplier();
            frm14.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            View_Supplier_Details frm15 = new View_Supplier_Details();
            frm15.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Delete_Supplier_Details frm16 = new Delete_Supplier_Details();
            frm16.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Modify_Supplier_Details frm17 = new Modify_Supplier_Details();
            frm17.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Retail_Sales_Details frm18 = new Retail_Sales_Details();
            frm18.Show();
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            View_Sales frm19 = new View_Sales();
            frm19.Show();
            this.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Application.Exit();           
        }

        private void button18_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(button18, 1, button18.Height);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangePassword cp = new ChangePassword();
            cp.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to logout ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

        private void button17_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_Purchase vp = new View_Purchase();
            vp.Show();
        }

        
    }
}
