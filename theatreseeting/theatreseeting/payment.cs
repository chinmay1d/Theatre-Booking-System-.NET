using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace theatreseeting
{
    public partial class payment : Form
    {

        int ID, NO,H;
        public payment(int no ,int cp,int cg,int cs,string dte,string clk,string name,string [] arr,int id,string MAIL,int h)
        {
            ID = id;
            NO = no;
            H = h;
            InitializeComponent();
            if (no == 1)
                textBox1.Text = "SACHIN-A BILLION DREAMS";
            if (no == 2)
                textBox1.Text = "HINDI MEDIUM";
            if (no == 3)
                textBox1.Text = "PIRATES OF CARIBBEAN-DEAD MEN TELL NO TALES";
            if (no == 4)
                textBox1.Text = "HALF GIRLFRIEND";
            if(cg==0&&cs==0)
            textBox2.Text = "SEATS : " + cp+" (Platinum)";
            if (cp == 0 && cs == 0)
                textBox2.Text = "SEATS : " + cg + " (Gold)" ;
            if (cp == 0 && cg == 0)
                textBox2.Text = "SEATS : " + cs + " (Silver)";
            textBox6.Text = Convert.ToString(cg * 150 + cp * 180 + cs * 100);
            textBox3.Text = dte;
            textBox4.Text = clk;
            textBox7.Text = name.ToUpper();
            string[] arr2 = new string[cp+cg+cs];
            string separator = " , ";
            int j = 0;
            for (int i = 0; i < 216; i++)
            {
                if (arr[i] == "1")
                {
                    arr2[j] = Convert.ToString(i);
                    //j++;
                    //arr2[j] = " , ";
                    j++;
                }
            }
            textBox5.Text = string.Join(separator, arr2);
            string to,sub,mssg;
            
            to = MAIL;
            sub = "E TICKET";
            mssg = textBox7.Text+" Your ticket is confirmed for "+textBox3.Text+" for "+textBox2.Text+" of movie "+textBox1.Text+" PLEASE BRING YOUR CASH AND PAY AT TICKET COUNTER TO RECIVE YOUR TICKETS. THANK YOU FOR USING OUR SERVICES";
            MailMessage msg = new MailMessage();
            SmtpClient mail = new SmtpClient("smtp.gmail.com");
            msg.From = new MailAddress("mticket.confirm@gmail.com");
            msg.To.Add(to);
            msg.Subject=sub;
            msg.Body = mssg;
            mail.Port = 587;
            mail.Credentials = new NetworkCredential("mticket.confirm@gmail.com","moviesystem");
            mail.EnableSsl = true;
            mail.Send(msg);
        }

        public payment()
        {

        }
        private void payment_Load(object sender, EventArgs e)
        {
            button7.BackColor = Color.Transparent;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }
        Bitmap bitmap;
        private void button1_Click(object sender, EventArgs e)
        {
            //Add a Panel control.
            Panel panel = new Panel();
            this.Controls.Add(panel);

            //Create a Bitmap of size same as that of the Form.
            Graphics grp = panel.CreateGraphics();
            Size formSize = this.ClientSize;
            bitmap = new Bitmap(formSize.Width, formSize.Height, grp);
            grp = Graphics.FromImage(bitmap);

            //Copy screen area that that the Panel covers.
            Point panelLocation = PointToScreen(panel.Location);
            grp.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, formSize);

            //Show the Print Preview Dialog.
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            home back = new home();
            this.Hide();
            back.Show();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Print the contents.
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 homeobj = new Form3();
            homeobj.Show();
            this.Hide();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
