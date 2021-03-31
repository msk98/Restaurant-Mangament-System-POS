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
    public partial class Quantity : Form
    {
        public Quantity()
        {
            InitializeComponent();
        }
        public string textBox
        {
            get { return textBoxQuantity.Text; }
            set { this.Text = textBoxQuantity.Text; }
           
        }

        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            textBox = textBoxQuantity.Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonadd_Click(object sender, EventArgs e)
        {

            int qty = Int16.Parse(textBoxQuantity.Text);
            if(qty>0)
            {
                qty++;
                textBoxQuantity.Text = qty.ToString();
            }
          

        }

        private void buttonminus_Click(object sender, EventArgs e)
        {
            int qty = Int16.Parse(textBoxQuantity.Text);
            if(qty!=0)
            {
                qty--;
                textBoxQuantity.Text = qty.ToString();
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBoxQuantity.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBoxQuantity.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBoxQuantity.Text += "9";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxQuantity.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBoxQuantity.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBoxQuantity.Text += "6";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxQuantity.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxQuantity.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxQuantity.Text += "3";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBoxQuantity.Text += "0";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxQuantity.Text = textBoxQuantity.Text.Remove(textBoxQuantity.Text.Length - 1, 1);

        }

        private void textBoxQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBoxQuantity.Text = "0";
        }
    }
}
