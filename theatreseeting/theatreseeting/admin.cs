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
    public partial class admin : Form
    {
        DataSet ds = new DataSet();
        SqlConnection CS = new SqlConnection("Data Source=.;Initial Catalog=movie;Integrated Security=True");
        SqlDataAdapter DA = new SqlDataAdapter();
        BindingSource BS = new BindingSource();
        DataTable dt = new DataTable();
        public admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DA.SelectCommand = new SqlCommand("SELECT * FROM SEATING", CS);
            ds.Clear();
            DA.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DA.SelectCommand = new SqlCommand("SELECT * FROM SEATING1", CS);
            ds.Clear();
            DA.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DA.SelectCommand = new SqlCommand("select * from SEATING where  STATUS1='" + textBox3.Text + "' or STATUS2='" + textBox3.Text + "' or STATUS3='" + textBox3.Text + "' or STATUS4='" + textBox3.Text + "' or STATUS5='" + textBox3.Text + "' or STATUS6='" + textBox3.Text + "'", CS);
            DA.Fill(ds);
            ds.Clear();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DA.SelectCommand.Parameters.Add("@", SqlDbType.Int).Value = ds.Tables[0].Rows[BS.Position][0];

                CS.Open();
                DA.SelectCommand.ExecuteNonQuery();
                CS.Close();
                ds.Clear();
                DA.Fill(ds);


            }
            else
            {
                MessageBox.Show("DATA not found");
                CS.Close();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dt.Clear();
            DA.SelectCommand = new SqlCommand("select * from SEATING where STATUS1 like '" + textBox3.Text + "%' OR STATUS2 like '" + textBox3.Text + "%' OR STATUS3 like '" + textBox3.Text + "%' OR STATUS4 like '" + textBox3.Text + "%' OR STATUS5 like '" + textBox3.Text + "%' OR STATUS6 like '" + textBox3.Text + "%' ", CS);
            DA.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            home backobj = new home();
            backobj.Show();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}
