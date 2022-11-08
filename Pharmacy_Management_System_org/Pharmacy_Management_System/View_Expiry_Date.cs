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
    public partial class View_Expiry_Date : Form
    {
        SqlConnection con;
        SqlCommand com;
        string sql;
        public View_Expiry_Date()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\Pharmacy_Management_System\Pharmacy_Management_System\Medicine.mdf;Integrated Security=True;User Instance=True");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                if ((dateTimePicker1.Text == ""))
                {
                    MessageBox.Show("sorry,please add the full details", "Warning");
                }
                con.Open();

                //com = new SqlCommand("select * from details where CONVERT (varchar,expiryDate) ='" + dateTimePicker1.Text + "'", con);
                sql = "select * from details_M where expiryDate ='" + dateTimePicker1.Text + "'";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);

                DataTable di = new DataTable();
                da.Fill(di);
                dataGridView1.DataSource = di;
                con.Close();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("sorry there are something went wrong, please try again..!!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if ((dateTimePicker1.Text == ""))
                {
                    MessageBox.Show("sorry,please add the full details", "Warning");
                }
                else
                {

                    con.Open();

                    DialogResult result = MessageBox.Show("Do you want to Remove the Member ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE details_M SET quantity = 0 where expiryDate ='" + dateTimePicker1.Text + "'", con);
                        cmd.ExecuteNonQuery();
                        

                        SqlDataAdapter da = new SqlDataAdapter(sql, con);

                        DataTable di = new DataTable();
                        da.Fill(di);
                        dataGridView1.DataSource = di;
                 

                        MessageBox.Show("successfully deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dateTimePicker1.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("not deleted", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dateTimePicker1.Text = "";

                    }
                    con.Close();
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show("sorry there are something went wrong, please try again..!!");
            }
        }

        private void View_Expiry_Date_Load(object sender, EventArgs e)
        {

        }
    }
}
