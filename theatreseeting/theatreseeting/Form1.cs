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
    public partial class Form1 : Form
    {
        int counterp = 0, counterg = 0, counters = 0, counter = 0, no, log = 0, h, ho, visit = 0,vist1=0, j = -2, ID;
        string MAIL,DATE;
        string[] arr2 = new string[216];
        SqlConnection cs = new SqlConnection("data source=.;initial catalog=movie;integrated security=true");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        BindingSource bs = new BindingSource();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public Form1(int n)
        {
            InitializeComponent();
            no = n;
        }
        public Form1()
        {
            InitializeComponent();          
        }
        public Form1(int n,int ho,int jo,string date)
        {
           
            InitializeComponent();
            no = n;
            h = ho;
            j = jo;
            DATE = date;
            vist1++;
           
        }


        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            visit++;
            //combobox ki value store karne k liye
            if (visit>= 3 && j==-2)
            {
                j = comboBox1.SelectedIndex;
                if (no == 1 || no == 3)
                {
                    h = comboBox1.SelectedIndex + 2;//+2 coz status 1-3 for screen of timing 8.30,....
                }
                if (no == 2 || no == 4)
                {
                    h = comboBox1.SelectedIndex + 5;//+5 coz status 4-6 for screen of timings 10.00,....
                }
                Form1 obj = new Form1(no,h,j,dateTimePicker1.Text);
                this.Hide();
                obj.Show();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //disabling dates before today's date in datetime picker
            dateTimePicker1.MinDate = DateTime.Today;
            if (vist1 == 1)
            {
                dateTimePicker1.Text = DATE;
                vist1 = 0;
            }
            visit++;   
            //adding data in combobox      
            string[] array2 = new string[3] { "10:00", "16:00", "22:00" };
            string[] array1 = new string[3] { "8:30", "13:30", "19:00" };
            
            if (no == 1 || no == 3)
            {
                comboBox1.DataSource = array1;
            }

            if (no == 2 || no == 4)
            {
                comboBox1.DataSource = array2;
            }
            //form update k bad selected option dikhane k liye
            if (visit == 2 && j !=-2)
            {
               // dateTimePicker1.Text = DATE;
                comboBox1.SelectedIndex = j;
                j = -2;
            }
            groupBox1.BackColor = Color.Transparent;
            groupBox2.BackColor = Color.Transparent;
            groupBox3.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            groupBox4.BackColor = Color.Transparent;
            button7.BackColor = Color.Transparent;

            int i = 0;
            string[] arr;
            arr = new string[216];
            /*for (i = 0; i < 216; i++)
            {
                arr[i] = 0;
                arr2[i] = 0;
            }*/
            cs.Open();
            //for selecting screen 1 or 2
            if (no == 1 || no == 2)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM SEATING", cs);
                i = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                //for selecting status in screen according to show time
                if (visit == 2 && j == -2)
                {
                    if (no == 1)
                    {
                        h = 2;
                    }
                    if (no == 2)
                    {
                        h = 5;
                    }
                }
                while (reader.Read())
                {
                    string status = reader.GetString(h);
                    arr[i] = status;
                    i++;
                    ho = h;
                }
            }
            if (no == 3 || no == 4)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM SEATING1", cs);
                i = 0;
                //for selecting status in screen according to show time
                SqlDataReader reader = cmd.ExecuteReader();
                if (visit == 2 && j == -2)
                {
                    if ( no == 3)
                    {
                        h = 2;
                    }
                    if (no == 4)
                    {
                        h = 5;
                    }
                }
                while (reader.Read())
                {
                    string status = reader.GetString(h);
                    arr[i] = status;
                    i++;
                    ho = h;
                }
            }
            
            //filling checkboxes on form refresh or update
            i = 71;
            foreach (Control c in groupBox1.Controls)
            {
                
                CheckBox temp = (CheckBox)c;
                if (arr[i].Contains(dateTimePicker1.Text) )
                {
                    temp.Checked = true;
                    temp.Enabled = false;
                }
                i--;         
            }
            i = 143;
            foreach (Control c in groupBox2.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox temp = (CheckBox)c; 
                    if (arr[i].Contains(dateTimePicker1.Text))
                    {
                        temp.Checked = true;
                        temp.Enabled = false;
                    }
                }
                i--;
            }
            i = 215;
            foreach (Control c in groupBox3.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox temp = (CheckBox)c;
                    if (arr[i].Contains(dateTimePicker1.Text))
                    {
                        temp.Checked = true;
                        temp.Enabled = false;
                    }
                }
                i--;
            }
            cs.Close();
            if (no == 1)
                label5.Text = "SACHIN-A BILLION DREAMS";
            if (no == 2)
                label5.Text = "HINDI MEDIUM";
            if (no == 3)
                label5.Text = "PIRATES OF CARIBBEAN-DEAD MEN TELL NO TALES";
            if (no == 4)
                label5.Text = "HALF GIRLFRIEND";
           /* if (no == 5)
                label5.Text = "CAPTAIN UNDERPANTS THE FIRST EPIC MOVIE";
            if (no == 6)
                label5.Text = "SPIDER-MAN HOMECOMING";
            if (no == 7)
                label5.Text = "TUBELIGHT";
            if (no == 8)
                label5.Text = "DESPICABLE ME 3";*/
            if (no == 1 || no == 2)
                label6.Text = "SCREEN 1";
            if (no == 3 || no == 4)
                label6.Text = "SCREEN 2";
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 backobj = new Form3();
            backobj.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Value + 10;
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                
                this.Hide();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (vist1==0)
            {
                string l;
                l = dateTimePicker1.Text;
                Form1 obj = new Form1(no, h, j, l);
                this.Hide();
                obj.Show();
            }
            vist1++;
    }

        private void button6_Click(object sender, EventArgs e)
        {
            forgot objopen = new forgot();
            objopen.Show();
        }

        private void checkBox160_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox206_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        string name;
        private void button4_Click_1(object sender, EventArgs e)
        {
            string cs = @"data source=.;initial catalog=movie;integrated security=true";
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("Select * from accounts where NAME=@NAME and PSWD=@PSWD", con);
            cmd.Parameters.AddWithValue("@NAME", textBox1.Text);
            cmd.Parameters.AddWithValue("@PSWD", textBox2.Text);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            con.Close();
            int count = ds.Tables[0].Rows.Count;
            if (count == 1)
            {
                MessageBox.Show("Login Successful!");
                log = 1;
                name = textBox1.Text;
                
            }
            else
            {
                MessageBox.Show("Login Failed!");
            }
  
            //getting id
            con.Open();
            SqlCommand cmmd = new SqlCommand("SELECT * FROM accounts", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(0);
                string pas = reader.GetString(3);
                string mail = reader.GetString(2);
                int id = reader.GetInt32(4);
                if (name == textBox1.Text && pas==textBox2.Text)
                {
                    ID = id;//got id
                    MAIL = mail;
                }
            }
            con.Close();
        }

       
        private void button5_Click(object sender, EventArgs e)
        {
            Form4 objs = new Form4();
            objs.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
            string hell="";
            if (log == 1)
            {
                int x=ID;
                int i = 71;
                foreach (Control c in groupBox1.Controls)
                {
                    if (c is CheckBox)
                    {
                        CheckBox temp = (CheckBox)c;
                        if (temp.Checked && temp.Enabled == true)
                        {
                            counterp++;
                            arr2[i] = "1";
                        }
                        i--;
                    }
                }
                i = 143;
                foreach (Control c in groupBox2.Controls)
                {
                    if (c is CheckBox)
                    {
                        CheckBox temp = (CheckBox)c;
                        if (temp.Checked && temp.Enabled == true)
                        {
                            counterg++;
                            arr2[i]="1";
                        }
                        i--;
                    }
                }
                i = 215;
                foreach (Control c in groupBox3.Controls)
                {
                    if (c is CheckBox)
                    {
                        CheckBox temp = (CheckBox)c;
                        if (temp.Checked && temp.Enabled == true)
                        {
                            counters++;
                            arr2[i] = "1";
                        }
                        i--;
                    }
                }
                counter = counterp + counterg + counters;
                string CCS = @"data source=.;initial catalog=movie;integrated security=true";
                SqlConnection CONS = new SqlConnection(CCS);
                
                SqlDataAdapter DAA = new SqlDataAdapter();

                if (counter != 0)
                {
                    MessageBox.Show("You have selected " + counter + " seats ");
                    DialogResult res = MessageBox.Show("Do you want confirm it", "Select An Option", MessageBoxButtons.YesNoCancel);
                    if(no==1||no==2)
                    {
                    if (ho == 2)
                    {
                        if (res == DialogResult.Yes)
                        {

                            foreach (Control c in groupBox1.Controls)
                            {
                                if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING", CONS);
                                        CONS.Open();
                                    SqlDataReader READER = CCMD.ExecuteReader();
                                    while (READER.Read())
                                    {
                                        int sea = READER.GetInt32(0);
                                        string stat = READER.GetString(2);
                                        if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                        {
                                            hell = stat;
                                            hell += " ,";
                                        }
                                    }
                                    CONS.Close();
                                    da.UpdateCommand = new SqlCommand("UPDATE SEATING SET STATUS1=@STATUS1 where SEATS=@SEATS ", cs);
                                    da.UpdateCommand.Parameters.Add("STATUS1", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                    da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                    cs.Open();
                                    da.UpdateCommand.ExecuteNonQuery();
                                    cs.Close();
                                }
                            }
                            foreach (Control c in groupBox2.Controls)
                            {
                                if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING", CONS);
                                        CONS.Open();
                                    SqlDataReader READER = CCMD.ExecuteReader();
                                    while (READER.Read())
                                    {
                                        int sea = READER.GetInt32(0);
                                        string stat = READER.GetString(2);
                                        if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                        {
                                            hell = stat;
                                            hell += " ,";
                                        }
                                    }
                                    CONS.Close();
                                    da.UpdateCommand = new SqlCommand("UPDATE SEATING SET STATUS1=@STATUS1 where SEATS=@SEATS ", cs);
                                    da.UpdateCommand.Parameters.Add("STATUS1", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                    da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                    cs.Open();
                                    da.UpdateCommand.ExecuteNonQuery();
                                    cs.Close();
                                }
                            }
                            foreach (Control c in groupBox3.Controls)
                            {
                                if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING", CONS);
                                        CONS.Open();
                                    SqlDataReader READER = CCMD.ExecuteReader();
                                    while (READER.Read())
                                    {
                                        int sea = READER.GetInt32(0);
                                        string stat = READER.GetString(2);
                                        if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                        {
                                            hell = stat;
                                            hell += " ,";
                                        }
                                    }
                                    CONS.Close();
                                    da.UpdateCommand = new SqlCommand("UPDATE SEATING SET STATUS1=@STATUS1 where SEATS=@SEATS ", cs);
                                    da.UpdateCommand.Parameters.Add("STATUS1", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                    da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                    cs.Open();
                                    da.UpdateCommand.ExecuteNonQuery();
                                    cs.Close();
                                }
                            }
                                // MessageBox.Show("Proceeding to payment......");
                                timer1.Start();
                                
                                payment objopen = new payment(no, counterp, counterg, counters, dateTimePicker1.Text, comboBox1.Text, name, arr2, x, MAIL,h);
                                objopen.Show();
                            }
                        else if (res == DialogResult.No)
                        {
                            Form1 obj = new Form1();
                            obj.Show();
                            this.Hide();
                        }
                    }
                    if (ho == 3)
                    {
                        if (res == DialogResult.Yes)
                        {

                            foreach (Control c in groupBox1.Controls)
                            {
                                if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING", CONS);
                                        CONS.Open();
                                    SqlDataReader READER = CCMD.ExecuteReader();
                                    while (READER.Read())
                                    {
                                        int sea = READER.GetInt32(0);
                                        string stat = READER.GetString(3);
                                        if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                        {
                                            hell = stat;
                                            hell += " ,";
                                        }
                                    }
                                    CONS.Close();
                                    da.UpdateCommand = new SqlCommand("UPDATE SEATING SET STATUS2=@STATUS2 where SEATS=@SEATS ", cs);
                                    da.UpdateCommand.Parameters.Add("STATUS2", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                    da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                    cs.Open();
                                    da.UpdateCommand.ExecuteNonQuery();
                                    cs.Close();
                                }
                            }
                            foreach (Control c in groupBox2.Controls)
                            {
                                if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING", CONS);
                                        CONS.Open();
                                    SqlDataReader READER = CCMD.ExecuteReader();
                                    while (READER.Read())
                                    {
                                        int sea = READER.GetInt32(0);
                                        string stat = READER.GetString(3);
                                        if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                        {
                                            hell = stat;
                                            hell += " ,";
                                        }
                                    }
                                    CONS.Close();
                                    da.UpdateCommand = new SqlCommand("UPDATE SEATING SET STATUS2=@STATUS2 where SEATS=@SEATS ", cs);
                                    da.UpdateCommand.Parameters.Add("STATUS2", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                    da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                    cs.Open();
                                    da.UpdateCommand.ExecuteNonQuery();
                                    cs.Close();
                                }
                            }
                            foreach (Control c in groupBox3.Controls)
                            {
                                if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING", CONS);
                                        CONS.Open();
                                    SqlDataReader READER = CCMD.ExecuteReader();
                                    while (READER.Read())
                                    {
                                        int sea = READER.GetInt32(0);
                                        string stat = READER.GetString(3);
                                        if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                        {
                                            hell = stat;
                                            hell += " ,";
                                        }
                                    }
                                    CONS.Close();
                                    da.UpdateCommand = new SqlCommand("UPDATE SEATING SET STATUS2=@STATUS2 where SEATS=@SEATS ", cs);
                                    da.UpdateCommand.Parameters.Add("STATUS2", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                    da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                    cs.Open();
                                    da.UpdateCommand.ExecuteNonQuery();
                                    cs.Close();
                                }
                            }
                                // MessageBox.Show("Proceeding to payment......");
                                timer1.Start();
                                payment objopen = new payment(no, counterp, counterg, counters, dateTimePicker1.Text, comboBox1.Text, name, arr2, x, MAIL,h);
                                objopen.Show();
                            }
                        else if (res == DialogResult.No)
                        {
                            Form1 obj = new Form1();
                            obj.Show();
                            this.Hide();
                        }
                    }
                    if (ho == 4)
                    {
                        if (res == DialogResult.Yes)
                        {

                            foreach (Control c in groupBox1.Controls)
                            {
                                if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING", CONS);
                                        CONS.Open();
                                    SqlDataReader READER = CCMD.ExecuteReader();
                                    while (READER.Read())
                                    {
                                        int sea = READER.GetInt32(0);
                                        string stat = READER.GetString(4);
                                        if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                        {
                                            hell = stat;
                                            hell += " ,";
                                        }
                                    }
                                    CONS.Close();
                                    da.UpdateCommand = new SqlCommand("UPDATE SEATING SET STATUS3=@STATUS3 where SEATS=@SEATS ", cs);
                                    da.UpdateCommand.Parameters.Add("STATUS3", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                    da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                    cs.Open();
                                    da.UpdateCommand.ExecuteNonQuery();
                                    cs.Close();
                                }
                            }
                            foreach (Control c in groupBox2.Controls)
                            {
                                if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING", CONS);
                                        CONS.Open();
                                    SqlDataReader READER = CCMD.ExecuteReader();
                                    while (READER.Read())
                                    {
                                        int sea = READER.GetInt32(0);
                                        string stat = READER.GetString(4);
                                        if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                        {
                                            hell = stat;
                                            hell += " ,";
                                        }
                                    }
                                    CONS.Close();
                                    da.UpdateCommand = new SqlCommand("UPDATE SEATING SET STATUS3=@STATUS3 where SEATS=@SEATS ", cs);
                                    da.UpdateCommand.Parameters.Add("STATUS3", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                    da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                    cs.Open();
                                    da.UpdateCommand.ExecuteNonQuery();
                                    cs.Close();
                                }
                            }
                            foreach (Control c in groupBox3.Controls)
                            {
                                if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING", CONS);
                                        CONS.Open();
                                    SqlDataReader READER = CCMD.ExecuteReader();
                                    while (READER.Read())
                                    {
                                        int sea = READER.GetInt32(0);
                                        string stat = READER.GetString(4);
                                        if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                        {
                                            hell = stat;
                                            hell += " ,";
                                        }
                                    }
                                    CONS.Close();
                                    da.UpdateCommand = new SqlCommand("UPDATE SEATING SET STATUS3=@STATUS3 where SEATS=@SEATS ", cs);
                                    da.UpdateCommand.Parameters.Add("STATUS3", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                    da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                    cs.Open();
                                    da.UpdateCommand.ExecuteNonQuery();
                                    cs.Close();
                                }
                            }
                                // MessageBox.Show("Proceeding to payment......");
                                timer1.Start();
                                payment objopen = new payment(no, counterp, counterg, counters, dateTimePicker1.Text, comboBox1.Text, name, arr2, x, MAIL,h);
                                objopen.Show();
                            }
                        else if (res == DialogResult.No)
                        {
                            Form1 obj = new Form1();
                            obj.Show();
                            this.Hide();
                        }
                    }
                    if (ho == 5)
                    {
                        if (res == DialogResult.Yes)
                        {

                            foreach (Control c in groupBox1.Controls)
                            {
                                if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING", CONS);
                                        CONS.Open();
                                    SqlDataReader READER = CCMD.ExecuteReader();
                                    while (READER.Read())
                                    {
                                        int sea = READER.GetInt32(0);
                                        string stat = READER.GetString(5);
                                        if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                        {
                                            hell = stat;
                                            hell += " ,";
                                        }
                                    }
                                    CONS.Close();
                                    da.UpdateCommand = new SqlCommand("UPDATE SEATING SET STATUS4=@STATUS4 where SEATS=@SEATS ", cs);
                                    da.UpdateCommand.Parameters.Add("STATUS4", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                    da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                    cs.Open();
                                    da.UpdateCommand.ExecuteNonQuery();
                                    cs.Close();
                                }
                            }
                            foreach (Control c in groupBox2.Controls)
                            {
                                if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING", CONS);
                                        CONS.Open();
                                    SqlDataReader READER = CCMD.ExecuteReader();
                                    while (READER.Read())
                                    {
                                        int sea = READER.GetInt32(0);
                                        string stat = READER.GetString(5);
                                        if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                        {
                                            hell = stat;
                                            hell += " ,";
                                        }
                                    }
                                    CONS.Close();
                                    da.UpdateCommand = new SqlCommand("UPDATE SEATING SET STATUS4=@STATUS4 where SEATS=@SEATS ", cs);
                                    da.UpdateCommand.Parameters.Add("STATUS4", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                    da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                    cs.Open();
                                    da.UpdateCommand.ExecuteNonQuery();
                                    cs.Close();
                                }
                            }
                            foreach (Control c in groupBox3.Controls)
                            {
                                if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING", CONS);
                                        CONS.Open();
                                    SqlDataReader READER = CCMD.ExecuteReader();
                                    while (READER.Read())
                                    {
                                        int sea = READER.GetInt32(0);
                                        string stat = READER.GetString(5);
                                        if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                        {
                                            hell = stat;
                                            hell += " ,";
                                        }
                                    }
                                    CONS.Close();
                                    da.UpdateCommand = new SqlCommand("UPDATE SEATING SET STATUS4=@STATUS4 where SEATS=@SEATS ", cs);
                                    da.UpdateCommand.Parameters.Add("STATUS4", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                    da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                    cs.Open();
                                    da.UpdateCommand.ExecuteNonQuery();
                                    cs.Close();
                                }
                            }
                                // MessageBox.Show("Proceeding to payment......");
                                timer1.Start();
                                payment objopen = new payment(no, counterp, counterg, counters, dateTimePicker1.Text, comboBox1.Text, name, arr2, x, MAIL,h);
                                objopen.Show();
                            }
                        else if (res == DialogResult.No)
                        {
                            Form1 obj = new Form1();
                            obj.Show();
                            this.Hide();
                        }
                    }
                    if (ho == 6)
                    {
                        if (res == DialogResult.Yes)
                        {

                            foreach (Control c in groupBox1.Controls)
                            {
                                if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING", CONS);
                                        CONS.Open();
                                    SqlDataReader READER = CCMD.ExecuteReader();
                                    while (READER.Read())
                                    {
                                        int sea = READER.GetInt32(0);
                                        string stat = READER.GetString(6);
                                        if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                        {
                                            hell = stat;
                                            hell += " ,";
                                        }
                                    }
                                    CONS.Close();
                                    da.UpdateCommand = new SqlCommand("UPDATE SEATING SET STATUS5=@STATUS5 where SEATS=@SEATS ", cs);
                                    da.UpdateCommand.Parameters.Add("STATUS5", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                    da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                    cs.Open();
                                    da.UpdateCommand.ExecuteNonQuery();
                                    cs.Close();
                                }
                            }
                            foreach (Control c in groupBox2.Controls)
                            {
                                if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING", CONS);
                                        CONS.Open();
                                    SqlDataReader READER = CCMD.ExecuteReader();
                                    while (READER.Read())
                                    {
                                        int sea = READER.GetInt32(0);
                                        string stat = READER.GetString(6);
                                        if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                        {
                                            hell = stat;
                                            hell += " ,";
                                        }
                                    }
                                    CONS.Close();
                                    da.UpdateCommand = new SqlCommand("UPDATE SEATING SET STATUS5=@STATUS5 where SEATS=@SEATS ", cs);
                                    da.UpdateCommand.Parameters.Add("STATUS5", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                    da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                    cs.Open();
                                    da.UpdateCommand.ExecuteNonQuery();
                                    cs.Close();
                                }
                            }
                            foreach (Control c in groupBox3.Controls)
                            {
                                if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING", CONS);
                                        CONS.Open();
                                    SqlDataReader READER = CCMD.ExecuteReader();
                                    while (READER.Read())
                                    {
                                        int sea = READER.GetInt32(0);
                                        string stat = READER.GetString(6);
                                        if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                        {
                                            hell = stat;
                                            hell += " ,";
                                        }
                                    }
                                    CONS.Close();
                                    da.UpdateCommand = new SqlCommand("UPDATE SEATING SET STATUS5=@STATUS5 where SEATS=@SEATS ", cs);
                                    da.UpdateCommand.Parameters.Add("STATUS5", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                    da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                    cs.Open();
                                    da.UpdateCommand.ExecuteNonQuery();
                                    cs.Close();
                                }
                            }
                                // MessageBox.Show("Proceeding to payment......");
                                timer1.Start();
                                payment objopen = new payment(no, counterp, counterg, counters, dateTimePicker1.Text, comboBox1.Text, name, arr2, x, MAIL,h);
                                objopen.Show();
                            }
                        else if (res == DialogResult.No)
                        {
                            Form1 obj = new Form1();
                            obj.Show();
                            this.Hide();
                        }
                    }
                    if (ho == 7)
                    {
                        if (res == DialogResult.Yes)
                        {

                            foreach (Control c in groupBox1.Controls)
                            {
                                if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING", CONS);
                                        CONS.Open();
                                    SqlDataReader READER = CCMD.ExecuteReader();
                                    while (READER.Read())
                                    {
                                        int sea = READER.GetInt32(0);
                                        string stat = READER.GetString(7);
                                        if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                        {
                                            hell = stat;
                                            hell += " ,";
                                        }
                                    }
                                    CONS.Close();
                                    da.UpdateCommand = new SqlCommand("UPDATE SEATING SET STATUS6=@STATUS6 where SEATS=@SEATS ", cs);
                                    da.UpdateCommand.Parameters.Add("STATUS6", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                    da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                    cs.Open();
                                    da.UpdateCommand.ExecuteNonQuery();
                                    cs.Close();
                                }
                            }
                            foreach (Control c in groupBox2.Controls)
                            {
                                if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING", CONS);
                                        CONS.Open();
                                    SqlDataReader READER = CCMD.ExecuteReader();
                                    while (READER.Read())
                                    {
                                        int sea = READER.GetInt32(0);
                                        string stat = READER.GetString(7);
                                        if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                        {
                                            hell = stat;
                                            hell += " ,";
                                        }
                                    }
                                    CONS.Close();
                                    da.UpdateCommand = new SqlCommand("UPDATE SEATING SET STATUS6=@STATUS6 where SEATS=@SEATS ", cs);
                                    da.UpdateCommand.Parameters.Add("STATUS6", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                    da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                    cs.Open();
                                    da.UpdateCommand.ExecuteNonQuery();
                                    cs.Close();
                                }
                            }
                            foreach (Control c in groupBox3.Controls)
                            {
                                if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING", CONS);
                                        CONS.Open();
                                    SqlDataReader READER = CCMD.ExecuteReader();
                                    while (READER.Read())
                                    {
                                        int sea = READER.GetInt32(0);
                                        string stat = READER.GetString(7);
                                        if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                        {
                                            hell = stat;
                                            hell += " ,";
                                        }
                                    }
                                    CONS.Close();
                                    da.UpdateCommand = new SqlCommand("UPDATE SEATING SET STATUS6=@STATUS6 where SEATS=@SEATS ", cs);
                                    da.UpdateCommand.Parameters.Add("STATUS6", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                    da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                    cs.Open();
                                    da.UpdateCommand.ExecuteNonQuery();
                                    cs.Close();
                                }
                            }
                                // MessageBox.Show("Proceeding to payment......");
                                timer1.Start();
                                payment objopen = new payment(no, counterp, counterg, counters, dateTimePicker1.Text, comboBox1.Text, name, arr2, x, MAIL,h);
                                objopen.Show();
                            }
                        else if (res == DialogResult.No)
                        {
                            Form1 obj = new Form1();
                            obj.Show();
                            this.Hide();
                        }
                    }
                }
                    if (no == 3 || no == 4)
                    {
                        if (ho == 2)
                        {
                            if (res == DialogResult.Yes)
                            {

                                foreach (Control c in groupBox1.Controls)
                                {
                                    if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                    {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING1", CONS);
                                        CONS.Open();
                                        SqlDataReader READER = CCMD.ExecuteReader();
                                        while (READER.Read())
                                        {
                                            int sea = READER.GetInt32(0);
                                            string stat = READER.GetString(2);
                                            if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                            {
                                                hell = stat;
                                                hell += " ,";
                                            }
                                        }
                                        CONS.Close();
                                        da.UpdateCommand = new SqlCommand("UPDATE SEATING1 SET STATUS1=@STATUS1 where SEATS=@SEATS ", cs);
                                        da.UpdateCommand.Parameters.Add("STATUS1", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                        da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                        cs.Open();
                                        da.UpdateCommand.ExecuteNonQuery();
                                        cs.Close();
                                    }
                                }
                                foreach (Control c in groupBox2.Controls)
                                {
                                    if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                    {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING1", CONS);
                                        CONS.Open();
                                        SqlDataReader READER = CCMD.ExecuteReader();
                                        while (READER.Read())
                                        {
                                            int sea = READER.GetInt32(0);
                                            string stat = READER.GetString(2);
                                            if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                            {
                                                hell = stat;
                                                hell += " ,";
                                            }
                                        }
                                        CONS.Close();
                                        da.UpdateCommand = new SqlCommand("UPDATE SEATING1 SET STATUS1=@STATUS1 where SEATS=@SEATS ", cs);
                                        da.UpdateCommand.Parameters.Add("STATUS1", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                        da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                        cs.Open();
                                        da.UpdateCommand.ExecuteNonQuery();
                                        cs.Close();
                                    }
                                }
                                foreach (Control c in groupBox3.Controls)
                                {
                                    if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                    {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING1", CONS);
                                        CONS.Open();
                                        SqlDataReader READER = CCMD.ExecuteReader();
                                        while (READER.Read())
                                        {
                                            int sea = READER.GetInt32(0);
                                            string stat = READER.GetString(2);
                                            if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                            {
                                                hell = stat;
                                                hell += " ,";
                                            }
                                        }
                                        CONS.Close();
                                        da.UpdateCommand = new SqlCommand("UPDATE SEATING1 SET STATUS1=@STATUS1 where SEATS=@SEATS ", cs);
                                        da.UpdateCommand.Parameters.Add("STATUS1", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                        da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                        cs.Open();
                                        da.UpdateCommand.ExecuteNonQuery();
                                        cs.Close();
                                    }
                                }
                                // MessageBox.Show("Proceeding to payment......");
                                timer1.Start();
                                payment objopen = new payment(no, counterp, counterg, counters, dateTimePicker1.Text, comboBox1.Text, name, arr2, x, MAIL,h);
                                objopen.Show();
                            }
                            else if (res == DialogResult.No)
                            {
                                Form1 obj = new Form1();
                                obj.Show();
                                this.Hide();
                            }
                        }
                        if (ho == 3)
                        {
                            if (res == DialogResult.Yes)
                            {

                                foreach (Control c in groupBox1.Controls)
                                {
                                    if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                    {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING1", CONS);
                                        CONS.Open();
                                        SqlDataReader READER = CCMD.ExecuteReader();
                                        while (READER.Read())
                                        {
                                            int sea = READER.GetInt32(0);
                                            string stat = READER.GetString(3);
                                            if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                            {
                                                hell = stat;
                                                hell += " ,";
                                            }
                                        }
                                        CONS.Close();
                                        da.UpdateCommand = new SqlCommand("UPDATE SEATING1 SET STATUS2=@STATUS2 where SEATS=@SEATS ", cs);
                                        da.UpdateCommand.Parameters.Add("STATUS2", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                        da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                        cs.Open();
                                        da.UpdateCommand.ExecuteNonQuery();
                                        cs.Close();
                                    }
                                }
                                foreach (Control c in groupBox2.Controls)
                                {
                                    if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                    {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING1", CONS);
                                        CONS.Open();
                                        SqlDataReader READER = CCMD.ExecuteReader();
                                        while (READER.Read())
                                        {
                                            int sea = READER.GetInt32(0);
                                            string stat = READER.GetString(3);
                                            if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                            {
                                                hell = stat;
                                                hell += " ,";
                                            }
                                        }
                                        CONS.Close();
                                        da.UpdateCommand = new SqlCommand("UPDATE SEATING1 SET STATUS2=@STATUS2 where SEATS=@SEATS ", cs);
                                        da.UpdateCommand.Parameters.Add("STATUS2", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                        da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                        cs.Open();
                                        da.UpdateCommand.ExecuteNonQuery();
                                        cs.Close();
                                    }
                                }
                                foreach (Control c in groupBox3.Controls)
                                {
                                    if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                    {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING1", CONS);
                                        CONS.Open();
                                        SqlDataReader READER = CCMD.ExecuteReader();
                                        while (READER.Read())
                                        {
                                            int sea = READER.GetInt32(0);
                                            string stat = READER.GetString(3);
                                            if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                            {
                                                hell = stat;
                                                hell += " ,";
                                            }
                                        }
                                        CONS.Close();
                                        da.UpdateCommand = new SqlCommand("UPDATE SEATING1 SET STATUS2=@STATUS2 where SEATS=@SEATS ", cs);
                                        da.UpdateCommand.Parameters.Add("STATUS2", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                        da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                        cs.Open();
                                        da.UpdateCommand.ExecuteNonQuery();
                                        cs.Close();
                                    }
                                }
                                // MessageBox.Show("Proceeding to payment......");
                                timer1.Start();
                                payment objopen = new payment(no, counterp, counterg, counters, dateTimePicker1.Text, comboBox1.Text, name, arr2, x, MAIL,h);
                                objopen.Show();
                            }
                            else if (res == DialogResult.No)
                            {
                                Form1 obj = new Form1();
                                obj.Show();
                                this.Hide();
                            }
                        }
                        if (ho == 4)
                        {
                            if (res == DialogResult.Yes)
                            {

                                foreach (Control c in groupBox1.Controls)
                                {
                                    if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                    {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING1", CONS);
                                        CONS.Open();
                                        SqlDataReader READER = CCMD.ExecuteReader();
                                        while (READER.Read())
                                        {
                                            int sea = READER.GetInt32(0);
                                            string stat = READER.GetString(4);
                                            if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                            {
                                                hell = stat;
                                                hell += " ,";
                                            }
                                        }
                                        CONS.Close();
                                        da.UpdateCommand = new SqlCommand("UPDATE SEATING1 SET STATUS3=@STATUS3 where SEATS=@SEATS ", cs);
                                        da.UpdateCommand.Parameters.Add("STATUS3", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                        da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                        cs.Open();
                                        da.UpdateCommand.ExecuteNonQuery();
                                        cs.Close();
                                    }
                                }
                                foreach (Control c in groupBox2.Controls)
                                {
                                    if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                    {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING1", CONS);
                                        CONS.Open();
                                        SqlDataReader READER = CCMD.ExecuteReader();
                                        while (READER.Read())
                                        {
                                            int sea = READER.GetInt32(0);
                                            string stat = READER.GetString(4);
                                            if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                            {
                                                hell = stat;
                                                hell += " ,";
                                            }
                                        }
                                        CONS.Close();
                                        da.UpdateCommand = new SqlCommand("UPDATE SEATING1 SET STATUS3=@STATUS3 where SEATS=@SEATS ", cs);
                                        da.UpdateCommand.Parameters.Add("STATUS3", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                        da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                        cs.Open();
                                        da.UpdateCommand.ExecuteNonQuery();
                                        cs.Close();
                                    }
                                }
                                foreach (Control c in groupBox3.Controls)
                                {
                                    if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                    {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING1", CONS);
                                        CONS.Open();
                                        SqlDataReader READER = CCMD.ExecuteReader();
                                        while (READER.Read())
                                        {
                                            int sea = READER.GetInt32(0);
                                            string stat = READER.GetString(4);
                                            if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                            {
                                                hell = stat;
                                                hell += " ,";
                                            }
                                        }
                                        CONS.Close();
                                        da.UpdateCommand = new SqlCommand("UPDATE SEATING1 SET STATUS3=@STATUS3 where SEATS=@SEATS ", cs);
                                        da.UpdateCommand.Parameters.Add("STATUS3", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                        da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                        cs.Open();
                                        da.UpdateCommand.ExecuteNonQuery();
                                        cs.Close();
                                    }
                                }
                                // MessageBox.Show("Proceeding to payment......");
                                timer1.Start();
                                payment objopen = new payment(no, counterp, counterg, counters, dateTimePicker1.Text, comboBox1.Text, name, arr2, x, MAIL,h);
                                objopen.Show();
                            }
                            else if (res == DialogResult.No)
                            {
                                Form1 obj = new Form1();
                                obj.Show();
                                this.Hide();
                            }
                        }
                        if (ho == 5)
                        {
                            if (res == DialogResult.Yes)
                            {

                                foreach (Control c in groupBox1.Controls)
                                {
                                    if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                    {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING1", CONS);
                                        CONS.Open();
                                        SqlDataReader READER = CCMD.ExecuteReader();
                                        while (READER.Read())
                                        {
                                            int sea = READER.GetInt32(0);
                                            string stat = READER.GetString(5);
                                            if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                            {
                                                hell = stat;
                                                hell += " ,";
                                            }
                                        }
                                        CONS.Close();
                                        da.UpdateCommand = new SqlCommand("UPDATE SEATING1 SET STATUS4=@STATUS4 where SEATS=@SEATS ", cs);
                                        da.UpdateCommand.Parameters.Add("STATUS4", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                        da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                        cs.Open();
                                        da.UpdateCommand.ExecuteNonQuery();
                                        cs.Close();
                                    }
                                }
                                foreach (Control c in groupBox2.Controls)
                                {
                                    if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                    {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING1", CONS);
                                        CONS.Open();
                                        SqlDataReader READER = CCMD.ExecuteReader();
                                        while (READER.Read())
                                        {
                                            int sea = READER.GetInt32(0);
                                            string stat = READER.GetString(5);
                                            if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                            {
                                                hell = stat;
                                                hell += " ,";
                                            }
                                        }
                                        CONS.Close();
                                        da.UpdateCommand = new SqlCommand("UPDATE SEATING1 SET STATUS4=@STATUS4 where SEATS=@SEATS ", cs);
                                        da.UpdateCommand.Parameters.Add("STATUS4", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                        da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                        cs.Open();
                                        da.UpdateCommand.ExecuteNonQuery();
                                        cs.Close();
                                    }
                                }
                                foreach (Control c in groupBox3.Controls)
                                {
                                    if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                    {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING1", CONS);
                                        CONS.Open();
                                        SqlDataReader READER = CCMD.ExecuteReader();
                                        while (READER.Read())
                                        {
                                            int sea = READER.GetInt32(0);
                                            string stat = READER.GetString(5);
                                            if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                            {
                                                hell = stat;
                                                hell += " ,";
                                            }
                                        }
                                        CONS.Close();
                                        da.UpdateCommand = new SqlCommand("UPDATE SEATING1 SET STATUS4=@STATUS4 where SEATS=@SEATS ", cs);
                                        da.UpdateCommand.Parameters.Add("STATUS4", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                        da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                        cs.Open();
                                        da.UpdateCommand.ExecuteNonQuery();
                                        cs.Close();
                                    }
                                }
                                // MessageBox.Show("Proceeding to payment......");
                                timer1.Start();
                                payment objopen = new payment(no, counterp, counterg, counters, dateTimePicker1.Text, comboBox1.Text, name, arr2, x, MAIL,h);
                                objopen.Show();
                            }
                            else if (res == DialogResult.No)
                            {
                                Form1 obj = new Form1();
                                obj.Show();
                                this.Hide();
                            }
                        }
                        if (ho == 6)
                        {
                            if (res == DialogResult.Yes)
                            {

                                foreach (Control c in groupBox1.Controls)
                                {
                                    if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                    {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING1", CONS);
                                        CONS.Open();
                                        SqlDataReader READER = CCMD.ExecuteReader();
                                        while (READER.Read())
                                        {
                                            int sea = READER.GetInt32(0);
                                            string stat = READER.GetString(6);
                                            if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                            {
                                                hell = stat;
                                                hell += " ,";
                                            }
                                        }
                                        CONS.Close();
                                        da.UpdateCommand = new SqlCommand("UPDATE SEATING1 SET STATUS5=@STATUS5 where SEATS=@SEATS ", cs);
                                        da.UpdateCommand.Parameters.Add("STATUS5", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                        da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                        cs.Open();
                                        da.UpdateCommand.ExecuteNonQuery();
                                        cs.Close();
                                    }
                                }
                                foreach (Control c in groupBox2.Controls)
                                {
                                    if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                    {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING1", CONS);
                                        CONS.Open();
                                        SqlDataReader READER = CCMD.ExecuteReader();
                                        while (READER.Read())
                                        {
                                            int sea = READER.GetInt32(0);
                                            string stat = READER.GetString(6);
                                            if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                            {
                                                hell = stat;
                                                hell += " ,";
                                            }
                                        }
                                        CONS.Close();
                                        da.UpdateCommand = new SqlCommand("UPDATE SEATING1 SET STATUS5=@STATUS5 where SEATS=@SEATS ", cs);
                                        da.UpdateCommand.Parameters.Add("STATUS5", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                        da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                        cs.Open();
                                        da.UpdateCommand.ExecuteNonQuery();
                                        cs.Close();
                                    }
                                }
                                foreach (Control c in groupBox3.Controls)
                                {
                                    if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                    {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING1", CONS);
                                        CONS.Open();
                                        SqlDataReader READER = CCMD.ExecuteReader();
                                        while (READER.Read())
                                        {
                                            int sea = READER.GetInt32(0);
                                            string stat = READER.GetString(6);
                                            if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                            {
                                                hell = stat;
                                                hell += " ,";
                                            }
                                        }
                                        CONS.Close();
                                        da.UpdateCommand = new SqlCommand("UPDATE SEATING1 SET STATUS5=@STATUS5 where SEATS=@SEATS ", cs);
                                        da.UpdateCommand.Parameters.Add("STATUS5", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                        da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                        cs.Open();
                                        da.UpdateCommand.ExecuteNonQuery();
                                        cs.Close();
                                    }
                                }
                                // MessageBox.Show("Proceeding to payment......");
                                timer1.Start();
                                payment objopen = new payment(no, counterp, counterg, counters, dateTimePicker1.Text, comboBox1.Text, name, arr2, x, MAIL,h);
                                objopen.Show();
                            }
                            else if (res == DialogResult.No)
                            {
                                Form1 obj = new Form1();
                                obj.Show();
                                this.Hide();
                            }
                        }
                        if (ho == 7)
                        {
                            if (res == DialogResult.Yes)
                            {

                                foreach (Control c in groupBox1.Controls)
                                {
                                    if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                    {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING1", CONS);
                                        CONS.Open();
                                        SqlDataReader READER = CCMD.ExecuteReader();
                                        while (READER.Read())
                                        {
                                            int sea = READER.GetInt32(0);
                                            string stat = READER.GetString(7);
                                            if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                            {
                                                hell = stat;
                                                hell += " ,";
                                            }
                                        }
                                        CONS.Close();
                                        da.UpdateCommand = new SqlCommand("UPDATE SEATING1 SET STATUS6=@STATUS6 where SEATS=@SEATS ", cs);
                                        da.UpdateCommand.Parameters.Add("STATUS6", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                        da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                        cs.Open();
                                        da.UpdateCommand.ExecuteNonQuery();
                                        cs.Close();
                                    }
                                }
                                foreach (Control c in groupBox2.Controls)
                                {
                                    if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                    {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING1", CONS);
                                        CONS.Open();
                                        SqlDataReader READER = CCMD.ExecuteReader();
                                        while (READER.Read())
                                        {
                                            int sea = READER.GetInt32(0);
                                            string stat = READER.GetString(7);
                                            if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                            {
                                                hell = stat;
                                                hell += " ,";
                                            }
                                        }
                                        CONS.Close();
                                        da.UpdateCommand = new SqlCommand("UPDATE SEATING1 SET STATUS6=@STATUS6 where SEATS=@SEATS ", cs);
                                        da.UpdateCommand.Parameters.Add("STATUS6", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                        da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                        cs.Open();
                                        da.UpdateCommand.ExecuteNonQuery();
                                        cs.Close();
                                    }
                                }
                                foreach (Control c in groupBox3.Controls)
                                {
                                    if (((CheckBox)c).Checked && ((CheckBox)c).Enabled == true)
                                    {
                                        SqlCommand CCMD = new SqlCommand("Select * from SEATING1", CONS);
                                        CONS.Open();
                                        SqlDataReader READER = CCMD.ExecuteReader();
                                        while (READER.Read())
                                        {
                                            int sea = READER.GetInt32(0);
                                            string stat = READER.GetString(7);
                                            if (sea == Convert.ToInt32(((CheckBox)c).AccessibleName))
                                            {
                                                hell = stat;
                                                hell += " ,";
                                            }
                                        }
                                        CONS.Close();
                                        da.UpdateCommand = new SqlCommand("UPDATE SEATING1 SET STATUS6=@STATUS6 where SEATS=@SEATS ", cs);
                                        da.UpdateCommand.Parameters.Add("STATUS6", SqlDbType.VarChar).Value = string.Concat(hell,string.Concat(dateTimePicker1.Text,"="+ID));
                                        da.UpdateCommand.Parameters.Add("SEATS", SqlDbType.Int).Value = ((CheckBox)c).AccessibleName;
                                        cs.Open();
                                        da.UpdateCommand.ExecuteNonQuery();
                                        cs.Close();
                                    }
                                }
                                // MessageBox.Show("Proceeding to payment......");
                                timer1.Start();
                                payment objopen = new payment(no, counterp, counterg, counters, dateTimePicker1.Text, comboBox1.Text, name, arr2, ID, MAIL,h);
                                objopen.Show();
                            }
                            else if (res == DialogResult.No)
                            {
                                Form1 obj = new Form1();
                                obj.Show();
                                this.Hide();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("PLEASE SELECT SOME SEATS FIRST");
                }
            }
            else
            {
                MessageBox.Show("LOGIN FIRST");
            }
           
        }

        


        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
           
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            
        }
    }
}
