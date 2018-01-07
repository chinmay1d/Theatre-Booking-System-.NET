using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace theatreseeting
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            button7.BackColor = Color.Transparent;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
            else
            {
                if (textBox4.Text == textBox5.Text)
                {
                    SqlConnection cs = new SqlConnection("data source=.;initial catalog=movie;integrated security=true");
                    SqlDataAdapter da = new SqlDataAdapter();
                    cs.Open();
                    SqlCommand cmmd = new SqlCommand("SELECT * FROM accounts", cs);
                    SqlDataReader reader = cmmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string pas = reader.GetString(3);
                        string mail = reader.GetString(2);
                        if (pas == textBox4.Text )
                       {
                            MessageBox.Show("PASSWORD ALREADY USED");
                            count++;
                            textBox4.Clear();
                            textBox5.Clear();
                        }
                        if (mail == textBox3.Text)
                        {
                            MessageBox.Show("THIS EMAIL-ID IS ALREADY REGISTERED");
                            count++;
                            textBox3.Clear();
                        }
                    }
                    cs.Close();
                    if (count==0)
                    {
                        da.InsertCommand = new SqlCommand("insert into accounts values(@NAME,@MOB,@EMAIL,@PSWD)", cs);
                        da.InsertCommand.Parameters.Add("NAME", SqlDbType.VarChar).Value = textBox1.Text;
                        da.InsertCommand.Parameters.Add("MOB", SqlDbType.NVarChar).Value = textBox2.Text;
                        da.InsertCommand.Parameters.Add("EMAIL", SqlDbType.VarChar).Value = textBox3.Text;
                        da.InsertCommand.Parameters.Add("PSWD", SqlDbType.NVarChar).Value = textBox4.Text;
                        cs.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        cs.Close();
                        MessageBox.Show("ACCOUNT CREATED SUCCESSFULLY");
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("PASSWORD DOES NOT MATCH");
                    textBox4.Clear();
                    textBox5.Clear();
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
        }

        private void Form4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 backobj = new Form1();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

