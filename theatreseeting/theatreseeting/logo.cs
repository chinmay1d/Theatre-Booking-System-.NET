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
    public partial class logo : Form
    {
        System.Windows.Forms.Timer time = new System.Windows.Forms.Timer();

        public logo()
        {
            InitializeComponent();
        }

        private void logo_Load(object sender, EventArgs e)
        {
            time.Interval = 2000;
            time.Tick += new EventHandler(timer1_Tick);
            time.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            home obj1 = new home();
            obj1.Show();
            this.Hide();
            time.Stop();
        }
    }
}
