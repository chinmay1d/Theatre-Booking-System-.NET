using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace theatreseeting
{
    public partial class cancellation : Form
    {
        int ID, NO, H, SE, counte = 0; 
        string check,mail,MAIL;
        string[] array2 = new string[3] { "10:00", "16:00", "22:00" };
        string[] array1 = new string[3] { "8:30", "13:30", "19:00" };

        private void cancellation_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Today;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            check = (dateTimePicker1.Text + "=" + ID);
            string cs = @"data source=.;initial catalog=movie;integrated security=true";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand CMD = new SqlCommand("Select * from accounts where NAME=@NAME and PSWD=@PSWD", con);
            CMD.Parameters.AddWithValue("@NAME", textBox1.Text);
            CMD.Parameters.AddWithValue("@PSWD", textBox2.Text);
            SqlDataAdapter adapt = new SqlDataAdapter(CMD);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            int count = ds.Tables[0].Rows.Count;
            if (count == 1)
            {
                SqlCommand CMMD = new SqlCommand("Select * from accounts", con);
                SqlDataReader READ = CMMD.ExecuteReader();
                while (READ.Read())
                {
                    string pass = READ.GetString(3);
                    int id = READ.GetInt32(4);
                    MAIL = READ.GetString(2);
                    string name = READ.GetString(0);
                    if (textBox1.Text==name&&textBox2.Text==pass)
                    {
                        ID = id;
                        count++;
                    }
                }
                con.Close();
                if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM SEATING", con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int seats = reader.GetInt32(0);
                        string seat = reader.GetString(H);
                       
                        if (seat.Contains(check))
                        {
                            mail = MAIL;
                            se = seat;
                            SE = seats;
                            counte++;
                        }
                    }
                    if (counte != 0)
                    {
                        con.Close();
                        DialogResult res = MessageBox.Show("ARE YOU SURE", "SELECT AN OPTION", MessageBoxButtons.YesNo);
                        if (res == DialogResult.Yes)
                        {
                            con.Open();
                            if (H == 2)
                            {
                                SqlDataAdapter da = new SqlDataAdapter();
                                da.UpdateCommand = new SqlCommand("UPDATE SEATING SET STATUS1=@STATUS1 where SEATS=@SEATS ", con);
                                da.UpdateCommand.Parameters.Add("STATUS1", SqlDbType.VarChar).Value = se.Replace((dateTimePicker1.Text + "=" + ID), "");
                                da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = SE;
                                da.UpdateCommand.ExecuteNonQuery();
                            }
                            if (H == 3)
                            {
                                SqlDataAdapter da = new SqlDataAdapter();
                                da.UpdateCommand = new SqlCommand("UPDATE SEATING SET STATUS2=@STATUS2 where SEATS=@SEATS ", con);
                                da.UpdateCommand.Parameters.Add("STATUS2", SqlDbType.VarChar).Value = se.Replace((dateTimePicker1.Text + "=" + ID), "");
                                da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = SE;
                                da.UpdateCommand.ExecuteNonQuery();
                            }
                            if (H == 4)
                            {
                                SqlDataAdapter da = new SqlDataAdapter();
                                da.UpdateCommand = new SqlCommand("UPDATE SEATING SET STATUS3=@STATUS3 where SEATS=@SEATS ", con);
                                da.UpdateCommand.Parameters.Add("STATUS3", SqlDbType.VarChar).Value = se.Replace((dateTimePicker1.Text + "=" + ID), "");
                                da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = SE;
                                da.UpdateCommand.ExecuteNonQuery();
                            }
                            if (H == 5)
                            {
                                SqlDataAdapter da = new SqlDataAdapter();
                                da.UpdateCommand = new SqlCommand("UPDATE SEATING SET STATUS4=@STATUS4 where SEATS=@SEATS ", con);
                                da.UpdateCommand.Parameters.Add("STATUS4", SqlDbType.VarChar).Value = se.Replace((dateTimePicker1.Text + "=" + ID), "");
                                da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = SE;
                                da.UpdateCommand.ExecuteNonQuery();
                            }
                            if (H == 6)
                            {
                                SqlDataAdapter da = new SqlDataAdapter();
                                da.UpdateCommand = new SqlCommand("UPDATE SEATING SET STATUS5=@STATUS5 where SEATS=@SEATS ", con);
                                da.UpdateCommand.Parameters.Add("STATUS5", SqlDbType.VarChar).Value = se.Replace((dateTimePicker1.Text + "=" + ID), "");
                                da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = SE;
                                da.UpdateCommand.ExecuteNonQuery();
                            }
                            if (H == 7)
                            {
                                SqlDataAdapter da = new SqlDataAdapter();
                                da.UpdateCommand = new SqlCommand("UPDATE SEATING SET STATUS6=@STATUS6 where SEATS=@SEATS ", con);
                                da.UpdateCommand.Parameters.Add("STATUS6", SqlDbType.VarChar).Value = se.Replace((dateTimePicker1.Text + "=" + ID), "");
                                da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = SE;
                                da.UpdateCommand.ExecuteNonQuery();
                            }
                            con.Close();
                            MessageBox.Show("Ticket cancelled successfully");
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("UNKNOWN REQUEST!");
                    }
                }
                if (comboBox1.SelectedIndex == 2 || comboBox1.SelectedIndex == 3)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM SEATING", con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int seats = reader.GetInt32(0);
                        string seat = reader.GetString(H);
                        if (seat.Contains((dateTimePicker1.Text + "=" + ID)))
                        {                        
                            mail = MAIL;
                            se = seat;
                            SE = seats;
                            counte++;
                        }
                    }
                    con.Close();
                    if (counte != 0)
                    {
                        con.Close();
                        DialogResult res = MessageBox.Show("ARE YOU SURE", "SELECT AN OPTION", MessageBoxButtons.YesNo);
                        if (res == DialogResult.Yes)
                        {
                            con.Open();
                            if (H == 2)
                            {
                                SqlDataAdapter da = new SqlDataAdapter();
                                da.UpdateCommand = new SqlCommand("UPDATE SEATING1 SET STATUS1=@STATUS1 where SEATS=@SEATS ", con);
                                da.UpdateCommand.Parameters.Add("STATUS1", SqlDbType.VarChar).Value = se.Replace((dateTimePicker1.Text + "=" + ID), "");
                                da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = SE;
                                da.UpdateCommand.ExecuteNonQuery();
                            }
                            if (H == 3)
                            {
                                SqlDataAdapter da = new SqlDataAdapter();
                                da.UpdateCommand = new SqlCommand("UPDATE SEATING1 SET STATUS2=@STATUS2 where SEATS=@SEATS ", con);
                                da.UpdateCommand.Parameters.Add("STATUS2", SqlDbType.VarChar).Value = se.Replace((dateTimePicker1.Text + "=" + ID), "");
                                da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = SE;
                                da.UpdateCommand.ExecuteNonQuery();
                            }
                            if (H == 4)
                            {
                                SqlDataAdapter da = new SqlDataAdapter();
                                da.UpdateCommand = new SqlCommand("UPDATE SEATING1 SET STATUS3=@STATUS3 where SEATS=@SEATS ", con);
                                da.UpdateCommand.Parameters.Add("STATUS3", SqlDbType.VarChar).Value = se.Replace((dateTimePicker1.Text + "=" + ID), "");
                                da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = SE;
                                da.UpdateCommand.ExecuteNonQuery();
                            }
                            if (H == 5)
                            {
                                SqlDataAdapter da = new SqlDataAdapter();
                                da.UpdateCommand = new SqlCommand("UPDATE SEATING1 SET STATUS4=@STATUS4 where SEATS=@SEATS ", con);
                                da.UpdateCommand.Parameters.Add("STATUS4", SqlDbType.VarChar).Value = se.Replace((dateTimePicker1.Text + "=" + ID), "");
                                da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = SE;
                                da.UpdateCommand.ExecuteNonQuery();
                            }
                            if (H == 6)
                            {
                                SqlDataAdapter da = new SqlDataAdapter();
                                da.UpdateCommand = new SqlCommand("UPDATE SEATING1 SET STATUS5=@STATUS5 where SEATS=@SEATS ", con);
                                da.UpdateCommand.Parameters.Add("STATUS5", SqlDbType.VarChar).Value = se.Replace((dateTimePicker1.Text + "=" + ID), "");
                                da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = SE;
                                da.UpdateCommand.ExecuteNonQuery();
                            }
                            if (H == 7)
                            {
                                SqlDataAdapter da = new SqlDataAdapter();
                                da.UpdateCommand = new SqlCommand("UPDATE SEATING1 SET STATUS6=@STATUS6 where SEATS=@SEATS ", con);
                                da.UpdateCommand.Parameters.Add("STATUS6", SqlDbType.VarChar).Value = se.Replace((dateTimePicker1.Text + "=" + ID), "");
                                da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = SE;
                                da.UpdateCommand.ExecuteNonQuery();
                            }
                            con.Close();
                            MessageBox.Show("Ticket cancelled successfully");
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("UNKNOWN REQUEST!");
                    }
                    MessageBox.Show("NEW PASSWORD HAS BEEN SENT TO YOUR MAIL ID");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("INVALID USER ID OR PASSWORD");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            home backobj = new home();
            backobj.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
        }

        private void button9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                comboBox1.Visible = false;
            if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 2)
            {
                comboBox2.DataSource = array1;
            }
            if (comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 3)
            {
                comboBox2.DataSource = array2;
            }
            if (comboBox1.SelectedIndex == 0)
            {
                NO = 1;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                NO = 2;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                NO = 3;
            }
            if (comboBox1.SelectedIndex == 3)
            {
                NO = 4;
            }
            comboBox2.SelectedIndex = -1;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NO == 1 || NO == 3)
            {
                H = comboBox2.SelectedIndex +2;//+2 coz status 1-3 for screen of timing 8.30,....
            }
            if (NO == 2 || NO == 4)
            {
                H = comboBox2.SelectedIndex +5;//+5 coz status 4-6 for screen of timings 10.00,....
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        string se;
        public cancellation()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}
            
            
            
        
    

