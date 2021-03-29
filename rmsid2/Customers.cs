using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rmsid2
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }
        int c_id = 0;
        string ConnectionString = "Data Source=DESKTOP-C27B91F;Initial Catalog=rmsid;Integrated Security=True";
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            if ((textBoxName.Text != "" && textBoxPhoneno.Text != "" && richTextBoxaddress.Text != ""))
            {

                if(conn.insertCustomers(textBoxName.Text, textBoxPhoneno.Text, richTextBoxaddress.Text))
                {
                    clear();
                    getcustomer();
                }

            }
            else
            {
                MessageBox.Show("please Fill all fields");
            }
        }

        private void textBoxSearchNumber_TextChanged(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM customer where cust_phone='" + textBoxPhoneno.Text + "%'", ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "customers");
            dataGridViewCustomers.DataSource = ds.Tables["customers"].DefaultView;
        }

          public void getcustomer()
        {
            Connection conn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM customer ", ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "customers");
            dataGridViewCustomers.DataSource = ds.Tables["customers"].DefaultView;
        }
        
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
           if ((textBoxName.Text != "" && textBoxPhoneno.Text != "" && richTextBoxaddress.Text != ""))
            {

                if (c_id != 0)
                {
                    Connection conn = new Connection();
                    if (conn.updatecust(c_id, textBoxName.Text, textBoxPhoneno.Text, richTextBoxaddress.Text))
                    {
                        MessageBox.Show("updated");
                        clear();
                        getcustomer();
                    }

                    c_id = 0;
                }
                else
                {
                    MessageBox.Show("no Item is selected");
                }
            }
            else
            {
                MessageBox.Show("please Fill all fields");
            }
        }

        private void buttondelete_Click(object sender, EventArgs e)
        {
            if ((textBoxName.Text != "" && textBoxPhoneno.Text != "" && richTextBoxaddress.Text != ""))
            {

                if (c_id != 0)
                {
                    Connection conn = new Connection();
                    if (conn.delcust(c_id))
                    {
                        clear();
                        getcustomer();
                    }
                    c_id = 0;
                }
                else
                {
                    MessageBox.Show("no Item is selected");
                }
            }
            else
            {
                MessageBox.Show("please Fill all fields");
            }
        }

        private void dataGridViewCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //  settnullValue();
                DataGridViewRow row = dataGridViewCustomers.Rows[e.RowIndex];
                c_id= Int16.Parse(row.Cells[0].Value.ToString());
                textBoxName.Text = row.Cells[1].Value.ToString();
                textBoxPhoneno.Text = row.Cells[2].Value.ToString();
                richTextBoxaddress.Text =row.Cells[3].Value.ToString();
            }
        }
        public void clear()
        {
            textBoxName.Text = "";
            textBoxPhoneno.Text = "";
            richTextBoxaddress.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(c_id>0)
            {
                deliveryboy db = new deliveryboy("Delivery",c_id);
               db.ShowDialog();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Select Customer Data");
            }
        }

        private void buttoncheck_Click(object sender, EventArgs e)
        {
            CustHistory ch = new CustHistory(c_id);
            ch.ShowDialog();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            getcustomer();
        }
    }
}
