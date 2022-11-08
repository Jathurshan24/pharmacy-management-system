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

namespace Pharmacy_Management_System
{
    public partial class Delete_Staff_Details : Form

    {
        SqlConnection con;
        SqlCommand com;
        string sql;
        public Delete_Staff_Details()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Jathurshan Sumaniran\Desktop\karna\Pharmacy_Management_System\Pharmacy_Management_System\staffDetails.mdf;Integrated Security=True;User Instance=True");
        }

        private void Delete_Staff_Details_Load(object sender, EventArgs e)
        {
            con.Open();
            com = new SqlCommand("select * from details", con);

            SqlDataReader dr;
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["NICno"].ToString());

            }
            dr.Close();
            con.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (comboBox1.Text == ""))
            {
                MessageBox.Show("Sorry,please add the full details", "Warning");
            }

            sql = "select * from details where NICno ='" + comboBox1.Text + "'";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable di = new DataTable();
            da.Fill(di);
            dataGridView1.DataSource = di;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (comboBox1.Text == ""))
            {
                MessageBox.Show("Sorry,please add the full details", "Warning");
            }
            else
            {

                con.Open();

                DialogResult result = MessageBox.Show("Do you want to Remove the Staff ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    sql = ("delete from details where NICno ='" + comboBox1.Text + "'");

                    com = new SqlCommand(sql, con);

                    com.ExecuteNonQuery();

                    MessageBox.Show("Successfully deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                    comboBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("not deleted", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                    comboBox1.Text = "";
                }
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
        }
    }
}
