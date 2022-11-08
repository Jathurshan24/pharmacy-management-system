using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Pharmacy_Management_System.Properties;

namespace Pharmacy_Management_System
{
    public partial class Retail_Sales_Details : Form
    {
        SqlConnection con;
        SqlCommand com,com1;
        String sql,sql1;
        public Retail_Sales_Details()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Jathurshan Sumaniran\Desktop\Pharmacy_Management_System\Pharmacy_Management_System\Medicine.mdf;Integrated Security=True;User Instance=True");
        }

        private List<Retail> shoppingCart = new List<Retail>(); 

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if ((textBox12.Text == ""))
            {
                MessageBox.Show("Sorry,please add the full details", "Warning");
            }

            con.Open();

            com = new SqlCommand("select mName,expiryDate,dosage,sellingPrice from details_M where CONVERT (varchar,mID) ='" + textBox12.Text + "'", con);
            //sql = "select * from details where CONVERT (varchar,mID) ='" + textBox12.Text + "'";
            SqlDataReader dr;
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                textBox2.Text = dr[0].ToString();
                textBox14.Text = dr[1].ToString();
                textBox4.Text = dr[2].ToString();
                textBox5.Text = dr[3].ToString();
                
                
            }
            dr.Close();
            con.Close();


           /* SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataTable di = new DataTable();
            da.Fill(di);
            dataGridView1.DataSource = di;
            
            */
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            double anDouble;
            anDouble = Convert.ToInt32(textBox5.Text);
            anDouble = Double.Parse(textBox5.Text);
            if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox5.Text))
                textBox6.Text = (Double.Parse(textBox3.Text) * anDouble).ToString();
        }

        private void Retail_Sales_Details_Load(object sender, EventArgs e)
        {
            textBox13.Text = dateTimePicker1.Value.ToShortDateString();

            con.Open();

            com = new SqlCommand("select max(convert(int,billNo)) from retails", con);

            SqlDataReader dr2;
            dr2 = com.ExecuteReader();
            String x1 = "";
            while (dr2.Read())
            {
                x1 = dr2[0].ToString();

            }
            dr2.Close();

            double anDouble;
            anDouble = Convert.ToInt32(x1);
            anDouble = Double.Parse(x1);

            anDouble = anDouble + 1;
            textBox1.Text = anDouble.ToString();
            con.Close();

          
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT billNo FROM retails", con);

            SqlDataReader reader = cmd.ExecuteReader();
            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            while (reader.Read())
            {
                MyCollection.Add(reader.GetString(0));
            }
            textBox1.AutoCompleteCustomSource = MyCollection;
            con.Close();

            con.Open();
            SqlCommand cmd0 = new SqlCommand("SELECT mID FROM details_M", con);

            SqlDataReader reader0 = cmd0.ExecuteReader();
            AutoCompleteStringCollection MyCollection0 = new AutoCompleteStringCollection();
            while (reader0.Read())
            {
                MyCollection0.Add(reader0.GetString(0));
            }
            textBox12.AutoCompleteCustomSource = MyCollection0;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();

                com = new SqlCommand("select SUM(amount) from retails where billNo ='" + textBox1.Text + "'", con);
                //sql = "select * from details where CONVERT (varchar,mID) ='" + textBox12.Text + "'";
                SqlDataReader dr;
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    textBox7.Text = dr[0].ToString();
                }
                dr.Close();

                con.Close();


                
            }
            catch (Exception ex2)
            {
                MessageBox.Show("this Bill No is already available");
            }
           

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrEmpty(textBox8.Text))
                textBox9.Text = ((Double.Parse(textBox7.Text))-((Double.Parse(textBox7.Text) * Double.Parse(textBox8.Text)/100))).ToString();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrEmpty(textBox10.Text))
                textBox11.Text = (Double.Parse(textBox10.Text) - Double.Parse(textBox9.Text)).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string ab, cd, ef, gh, ij, kl, mn, mk;

                ij = textBox1.Text;
                kl = textBox13.Text;
                ab = textBox7.Text;
                cd = textBox8.Text;
                ef = textBox9.Text;
                mn = textBox10.Text;
                gh = textBox11.Text;


                if ((ij == "") || (kl == "") || (ab == "") || (cd == "") || (ef == "") || (ef == "") || (gh == ""))
                {
                    MessageBox.Show("please add the full details", "Warning");
                }
                else
                {
                    con.Open();
                    sql = "insert into purchase values('" + ij + "','" + kl + "','" + ab + "','" + cd + "','" + ef + "','" + mn + "','" + gh + "')";
                    com = new SqlCommand(sql, con);
                    com.ExecuteNonQuery();

                    con.Close();
                   MessageBox.Show("Bill is Finalised", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   //dataGridView1.Rows.Clear();

               }
            }
            
            catch (Exception ex1)
            {
                MessageBox.Show("this Bill No is already available");
            }
             
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login_Admin la = new Login_Admin();
            la.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string x, ab, cd, ef, gh, ij, kl, mn, op, qr, st, uv, xy, mk, im, br, gn;

            ab = textBox1.Text;
            cd = textBox13.Text;
            ef = textBox12.Text;
            gh = textBox2.Text;
            ij = textBox3.Text;
            kl = textBox14.Text;
            mn = textBox4.Text;
            op = textBox5.Text;
            qr = textBox6.Text;

            if (textBox1.Text != "" && ((ab != "") || (cd != "") || (ef != "") || (gh != "") || (ij != "") || (kl != "") || (mn != "") || (op != "") || (qr != "")))
            {
                if (IsValidated())
                {
                    Retail item = new Retail()
                    {
                        mName = textBox2.Text,
                        quantity = textBox3.Text.Trim(),
                        dosage = textBox4.Text.Trim(),
                        mID = textBox12.Text.Trim(),
                        expiryDate = textBox14.Text.Trim(),
                        unitPrice = textBox5.Text.Trim(),
                        amount = textBox6.Text.Trim(),
                    };

                    shoppingCart.Add(item);
                    dataGridView1.DataSource = null;

                    dataGridView1.DataSource = shoppingCart;

                }
            }
              try
            {
                 // string x, ab, cd, ef, gh, ij, kl, mn, op, qr, st, uv, xy, mk, im, br, gn;


            ab = textBox1.Text;
            cd = textBox13.Text;
            ef = textBox12.Text;
            gh = textBox2.Text;
            ij = textBox3.Text;
            kl = textBox14.Text;
            mn = textBox4.Text;
            op = textBox5.Text;
            qr = textBox6.Text;

            if ((ab == "") || (cd == "") || (ef == "") || (gh == "") || (ij == "") || (kl == "") || (mn == "") || (op == "") || (qr == ""))
            {
                MessageBox.Show("please add the full details", "Warning");
            }
            else
            {
                con.Open();
                com = new SqlCommand("select SUM(quantity) from details_M where mID = '" + textBox12.Text + "'", con);

                SqlDataReader dr2;
                dr2 = com.ExecuteReader();
                String x1 = "";
                while (dr2.Read())
                {
                    x1 = dr2[0].ToString();

                }
                dr2.Close();

                double anDouble;
                anDouble = Convert.ToInt32(x1);
                anDouble = Double.Parse(x1);

                double anDouble1;
                anDouble1 = Convert.ToInt32(ij);
                anDouble1 = Double.Parse(ij);
                if (anDouble <= anDouble1)
                {
                    MessageBox.Show("Your available quantity is low ................. ");
                }







                else
                {
                    sql = "insert into retails values('" + ab + "','" + cd + "','" + ef + "','" + gh + "','" + ij + "','" + kl + "','" + mn + "','" + op + "','" + qr + "')";
                    com1 = new SqlCommand(sql, con);
                    com1.ExecuteNonQuery();


                    //MessageBox.Show("successfully added", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   
                    com = new SqlCommand("select SUM(quantity) from details_M where mID = '" + textBox12.Text + "'", con);

                    SqlDataReader dr1;
                    dr1 = com.ExecuteReader();
                    String x5 = "";
                    String Quant = "";
                    while (dr1.Read())
                    {
                        x5 = dr1[0].ToString();

                    }
                    dr1.Close();

                    double anDouble5;
                    anDouble5 = Convert.ToInt32(x5);
                    anDouble5 = Double.Parse(x5);
                    if (!string.IsNullOrEmpty(x5) && !string.IsNullOrEmpty(textBox3.Text))
                        Quant = (anDouble5 - Double.Parse(textBox3.Text)).ToString();

                    SqlCommand cmd = new SqlCommand("UPDATE details_M SET quantity = '" + Quant + "' WHERE mID ='" + textBox12.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Details are modified");
                    




                    sql1 = "select mID,mName,quantity,expiryDate,dosage,unitPrice,amount from retails where billNo ='" + textBox1.Text + "'";


                    SqlDataAdapter da = new SqlDataAdapter(sql1, con);

                    DataTable di = new DataTable();
                    da.Fill(di);
                   // dataGridView1.DataSource = di;
                }
                con.Close();

                
            }
                
           }


              catch (Exception ex)
              {
                  MessageBox.Show("this Bill No is already available");
              }

             
        
        }

        private bool IsValidated()
        {
            return true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image image = Resources.atlanta;
            e.Graphics.DrawImage(image, 125, 20, image.Width, image.Height);

            e.Graphics.DrawString("Date: " + DateTime.Now, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 160));

            e.Graphics.DrawString("Invoice No: " + textBox1.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 190));
            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------------- ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 235));

            e.Graphics.DrawString("Medicine Name " , new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 255));
            e.Graphics.DrawString("Quantity " , new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(240, 255));
            e.Graphics.DrawString("Dosage ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(410, 255));
            e.Graphics.DrawString("Unit Price " , new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(560, 255));
            e.Graphics.DrawString("Total Price " , new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(710, 255));
            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------------- ", new Font("Times and Newroman", 12, FontStyle.Regular), Brushes.Black, new Point(25, 270));

            int y = 295;

            foreach (var i in shoppingCart)
            {

                e.Graphics.DrawString(i.mName, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, y));
                e.Graphics.DrawString(i.quantity.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(240, y));
                e.Graphics.DrawString(i.dosage.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(430, y));
                e.Graphics.DrawString(i.unitPrice.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(560, y));
                e.Graphics.DrawString(i.mID.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(710, y));
              
               
                y += 30;
            }
            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------------- ", new Font("Times and Newroman", 12, FontStyle.Regular), Brushes.Black, new Point(25, y));

            e.Graphics.DrawString("Total Amount  : " + textBox7.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, y + 30));
            e.Graphics.DrawString("Discount(%)    : " + textBox8.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, y + 60));
            e.Graphics.DrawString("Total Pay       : " + textBox9.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, y + 90));

        }

  

        public string quantity { get; set; }

        public string mName { get; set; }

        private void button7_Click_1(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();



            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox14.Text = "";

            textBox13.Text = dateTimePicker1.Value.ToShortDateString();
            dataGridView1.DataSource = null;

            con.Open();

            com = new SqlCommand("select max(convert(int,billNo)) from retails", con);

            SqlDataReader dr2;
            dr2 = com.ExecuteReader();
            String x1 = "";
            while (dr2.Read())
            {
                x1 = dr2[0].ToString();

            }
            dr2.Close();

            double anDouble;
            anDouble = Convert.ToInt32(x1);
            anDouble = Double.Parse(x1);

            anDouble = anDouble + 1;
            textBox1.Text = anDouble.ToString();
            con.Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
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
                button6.PerformClick();
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
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
                button2.PerformClick();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    var hit = dataGridView1.HitTest(e.X, e.Y);
                    dataGridView1.Rows[hit.RowIndex].Selected = true;
                    contextMenuStrip1.Show(dataGridView1, e.X, e.Y);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There are some problem..!!");
            }
                    
        }

        private void deletItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
             if ((textBox1.Text == ""))
                    {
                        MessageBox.Show("Sorry,please add the full details", "Warning");
                    }
                    else
                    {

                        con.Open();

                        DialogResult result = MessageBox.Show("Do you want to Remove the Member ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            int index = dataGridView1.CurrentCell.RowIndex;

                            shoppingCart.RemoveAt(index);

                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = shoppingCart;

                            sql = ("delete from retails where billNo ='" + textBox1.Text + "'");

                            com = new SqlCommand(sql, con);

                            com.ExecuteNonQuery();

                            MessageBox.Show("Successfully deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                           // textBox1.Text = "";

                            sql1 = "select mID,mName,quantity,expiryDate,dosage,unitPrice,amount from retails where billNo ='" + textBox1.Text + "'";


                            SqlDataAdapter da = new SqlDataAdapter(sql1, con);

                            DataTable di = new DataTable();
                            da.Fill(di);
                            //dataGridView1.DataSource = di;



                            com = new SqlCommand("select SUM(quantity) from details_M where mID = '" + textBox12.Text + "'", con);

                            SqlDataReader dr1;
                            dr1 = com.ExecuteReader();
                            String x6 = "";
                            String Quant1 = "";
                            while (dr1.Read())
                            {
                                x6 = dr1[0].ToString();

                            }
                            dr1.Close();

                            double anDouble6;
                            anDouble6 = Convert.ToInt32(x6);
                            anDouble6 = Double.Parse(x6);
                            if (!string.IsNullOrEmpty(x6) && !string.IsNullOrEmpty(textBox3.Text))
                                Quant1 = (anDouble6 + Double.Parse(textBox3.Text)).ToString();

                            SqlCommand cmd = new SqlCommand("UPDATE details_M SET quantity = '" + Quant1 + "' WHERE mID ='" + textBox12.Text + "'", con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Details are modified");
                        }
                        else
                        {
                            MessageBox.Show("not deleted", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           // textBox1.Text = "";

                        }
                        con.Close();
                    }
                }
            
            catch (Exception ex)
            {
                MessageBox.Show("There are some problem..!!");
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                textBox12.Focus();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
