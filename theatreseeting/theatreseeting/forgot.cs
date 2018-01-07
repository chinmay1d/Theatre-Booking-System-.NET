using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.Mime;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Net;

namespace theatreseeting
{
    public partial class forgot : Form
    {
        SqlConnection cs = new SqlConnection("data source=.;initial catalog=movie;integrated security=true");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        BindingSource bs = new BindingSource();
        DataSet ds = new DataSet();
        public forgot()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter proper details");
            }
            else
            {
                string CS = @"data source=.;initial catalog=movie;integrated security=true";
                SqlConnection con = new SqlConnection(CS);
                SqlDataAdapter DA = new SqlDataAdapter();
                SqlCommand CMD = new SqlCommand("Select * from accounts where EMAIL=@EMAIL", con);
                CMD.Parameters.AddWithValue("@EMAIL", textBox1.Text);
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(CMD);
                DataSet DS = new DataSet();
                adapt.Fill(DS);
                con.Close();
                int count = DS.Tables[0].Rows.Count;
                if (count == 1)
                {
                    string allowedChars = "", pass;
                    allowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";
                    allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
                    allowedChars += "1,2,3,4,5,6,7,8,9,0,!,@,#,$,%,&,?";
                    char[] sep = { ',' };
                    string[] arr = allowedChars.Split(sep);
                    string passwordString = "";
                    string temp = "";
                    Random rand = new Random();
                    for (int i = 0; i < 8; i++)
                    {
                        temp = arr[rand.Next(0, arr.Length)];
                        passwordString += temp;
                    }
                    pass = passwordString;

                    da.UpdateCommand = new SqlCommand("UPDATE accounts SET PSWD=@PSWD where EMAIL=@EMAIL", cs);
                    da.UpdateCommand.Parameters.Add("PSWD", SqlDbType.NVarChar).Value = pass;
                    da.UpdateCommand.Parameters.Add("EMAIL", SqlDbType.VarChar).Value = textBox1.Text;
                    cs.Open();
                    da.UpdateCommand.ExecuteNonQuery();
                    cs.Close();


                    string to, sub, mssg;
                    MessageBox.Show("NEW PASSWORD HAS BEEN SENT TO YOUR E-MAIL ADDRESS");
                    to = textBox1.Text;
                    sub = "E TICKET";
                    mssg = "YOUR NEW PASSWORD IS " + pass + " DONT SHARE IT WITH ANYONE.";
                    MailMessage msg = new MailMessage();
                    SmtpClient mail = new SmtpClient("smtp.gmail.com");
                    msg.From = new MailAddress("mticket.confirm@gmail.com");
                    msg.To.Add(to);
                    msg.Subject = sub;
                    msg.Body = mssg;
                    mail.Port = 587;
                    mail.Credentials = new NetworkCredential("mticket.confirm@gmail.com", "moviesystem"); ;
                    mail.EnableSsl = true;
                    mail.Send(msg);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("INVALID DETAILS");
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 backobj = new Form1();
            this.Hide();
        }

        private void forgot_Load(object sender, EventArgs e)
        {
            button7.BackColor = Color.Transparent;
        }
    }
}
