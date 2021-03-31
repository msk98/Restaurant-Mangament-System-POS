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
    public partial class SecretKey : Form
    {
        public SecretKey()
        {
            InitializeComponent();
        }
        Detail dt = new Detail();
        public SecretKey(DateTime StartDate,DateTime EndDate)
        {
            InitializeComponent();
            dt.StartDate = StartDate;
            dt.EndDate = EndDate;
        }
        public Form reports
        { get; set; }
        public string textBox
        {
            get { return textBoxsecretkey.Text; }
            set { this.Text = textBoxsecretkey.Text; }

        }
        private void button7_Click(object sender, EventArgs e)
        {
            textBoxsecretkey.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBoxsecretkey.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBoxsecretkey.Text += "9";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxsecretkey.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBoxsecretkey.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBoxsecretkey.Text += "6";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxsecretkey.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxsecretkey.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxsecretkey.Text += "3";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBoxsecretkey.Text += "0";
        }

        private void buttonclearall_Click(object sender, EventArgs e)
        {
            textBoxsecretkey.Text = "";
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            textBoxsecretkey.Text = "0";
            this.Hide();
        }

        private void buttoncancel_Click(object sender, EventArgs e)
        {
            if(textBoxsecretkey.Text.Length>0)
            textBoxsecretkey.Text= textBoxsecretkey.Text.Remove(textBoxsecretkey.Text.Length - 1, 1);
        }

        private void buttonok_Click(object sender, EventArgs e)
        {

            this.Hide();

        }

        private void SecretKey_FormClosed(object sender, FormClosedEventArgs e)
        {
            textBoxsecretkey.Text = "0";
            this.Close();
        }
    }
}
