using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rmsid2
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }
        public register(int userid)
        {
            InitializeComponent();
            dt.userid = userid;
        }
        Detail dt = new Detail();
        public string registertext
        {
            get { return textBoxregister.Text; }
            set { this.Text = textBoxregister.Text; }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxregister.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxregister.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxregister.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxregister.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBoxregister.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBoxregister.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBoxregister.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBoxregister.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBoxregister.Text += "9";
        }

        private void button1000_Click(object sender, EventArgs e)
        {
            textBoxregister.Text += "1000";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBoxregister.Text += "0";
        }

        private void button00_Click(object sender, EventArgs e)
        {
            textBoxregister.Text += "00";
        }

        private void button500_Click(object sender, EventArgs e)
        {
            textBoxregister.Text += "500";
        }

        private void button5000_Click(object sender, EventArgs e)
        {
            textBoxregister.Text += "5000";
        }

        private void buttonclear_Click(object sender, EventArgs e)
        {
            if (textBoxregister.Text.Length > 0)
                textBoxregister.Text = textBoxregister.Text.Remove(textBoxregister.Text.Length - 1, 1);
        }

        private void buttonall_Click(object sender, EventArgs e)
        {
            textBoxregister.Text = "";
        }

        private void buttonstart_Click(object sender, EventArgs e)
        {
            if(textBoxregister.Text.Length>0)
            {
                Connection conn = new Connection();
                if(conn.startregister(dt.userid, Int16.Parse(textBoxregister.Text)))
                {
                    this.Hide();
                }

            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
