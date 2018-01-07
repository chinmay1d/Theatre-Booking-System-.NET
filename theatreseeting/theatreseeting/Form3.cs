using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace theatreseeting
{
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form1 obj1 = new Form1(1);
            obj1.Show();
            this.Hide();
            MessageBox.Show("CHOOSE THE SHOW DATE AND TIME");

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form1 obj2 = new Form1(2);
            obj2.Show();
            this.Hide();
            MessageBox.Show("CHOOSE THE SHOW DATE AND TIME");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form1 obj3 = new Form1(3);
            obj3.Show();
            this.Hide();
            MessageBox.Show("CHOOSE THE SHOW DATE AND TIME");
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Form1 obj4= new Form1(4);
            obj4.Show();
            this.Hide();
            MessageBox.Show("CHOOSE THE SHOW DATE AND TIME");
        }

        private void button5_Click(object sender, EventArgs e)
        {

           /* Form1 obj5 = new Form1(5);
            obj5.Show();
            this.Hide();
            MessageBox.Show("CHOOSE THE SHOW TIME");*/
        }

        private void button6_Click(object sender, EventArgs e)
        {
          /*  Form1 obj6 = new Form1(6);
            obj6.Show();
            this.Hide();
            MessageBox.Show("CHOOSE THE SHOW TIME");*/
        }

        private void button7_Click(object sender, EventArgs e)
        {
          /*  Form1 obj7 = new Form1(7);
            obj7.Show();
            this.Hide();
            MessageBox.Show("CHOOSE THE SHOW TIME");*/
        }

        private void button8_Click(object sender, EventArgs e)
        {
           /* Form1 obj8 = new Form1(8);
            obj8.Show();
            this.Hide();
            MessageBox.Show("CHOOSE THE SHOW TIME");*/
        }

        private void button9_Click(object sender, EventArgs e)
        {

            
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                TopMost = true;
           
        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        public void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void dETAILSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("chrome.exe", "www.imdb.com/title/tt5624748/");

        }

        private void dETAILSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("chrome.exe", "www.imdb.com/title/tt5764096/");
        }

        private void contextMenuStrip3_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dETAILSToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("chrome.exe", "www.imdb.com/title/tt1790809/");
        }

        private void dETAILSToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("chrome.exe", "www.imdb.com/title/tt5474042/");
        }

        private void dETAILSToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("chrome.exe", "www.imdb.com/title/tt2091256/");
        }

        private void contextMenuStrip6_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dETAILSToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("chrome.exe", "www.imdb.com/title/tt2250912/");
        }

        private void dETAILSToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("chrome.exe", "www.imdb.com/title/tt5882970/");
        }

        private void dETAILSToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("chrome.exe", "www.imdb.com/title/tt3469046/");
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            home backobj = new home();
            backobj.Show();
            this.Hide();
        }
    }
}
