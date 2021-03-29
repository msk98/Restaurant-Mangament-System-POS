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
    public partial class Dashboard : Form
    {
        Detail dt = new Detail();

        public Dashboard(string p,string un,int userid)
        {
            InitializeComponent();
            dt.user_privelage = p;
            dt.username = un;
            dt.userid=userid;
        }
        public Dashboard()
        {
            InitializeComponent();
     
        }
        string ConnectionString = "Data Source=DESKTOP-C27B91F;Initial Catalog=rmsid;Integrated Security=True";
        DataGridViewRow row;
        int OrderId = 0;
       
        private void Dashboard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rmsidDataSet.temp_orders' table. You can move, or remove it, as needed.
          
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            getOrders();

        }

        private void menuItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products p = new Products();
            p.ShowDialog();
        }

        private void incredientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Incredients inc = new Incredients();
            inc.ShowDialog();
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            categories cat = new categories();
            cat.ShowDialog();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory inven = new Inventory();
            inven.ShowDialog();
        }

       

        private void buttonDelivery_Click(object sender, EventArgs e)
        {
            Customers cust = new Customers();
            cust.ShowDialog();
          
        }

        private void buttonTakeAway_Click(object sender, EventArgs e)
        {
            Order ord = new Order("Take Away");
            ord.ShowDialog();
        }

       
        public void getOrders()
        {
            Connection conn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("SELECT t_Oid as OrderId,t_netamnt as TotalAmount ,t_tablename as Tables,Dateorder as Time FROM temp_orders", ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "temp_orders");
            dataGridViewOrderlist.DataSource = ds.Tables["temp_orders"].DefaultView;
        }
        string tableno;
        private void dataGridViewOrderlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewOrderlist.Rows[e.RowIndex];
                OrderId  = Int16.Parse(row.Cells[0].Value.ToString());
                tableno = (row.Cells[2].Value.ToString());
                textBoxsubtotal.Text = row.Cells[1].Value.ToString();
                textBoxtotal.Text= row.Cells[1].Value.ToString();
                textBoxNetBill.Text = row.Cells[1].Value.ToString();
                Connection conn = new Connection();
                 SqlDataAdapter da = new SqlDataAdapter("SELECT t_iName as ItemName,t_iqty as Quantity,t_iprice as UnitPrice,t_inetprice as TotalPrice FROM temp_orderitems where t_Oid='" + OrderId + "'", ConnectionString);
                DataSet ds = new DataSet();
                da.Fill(ds, "temp_orderitems");
                dataGridViewOrderItems.DataSource = ds.Tables["temp_orderitems"].DefaultView;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            select_table st = new select_table("Dine In");
            st.ShowDialog();
        }

        private void timerfunc_Tick_1(object sender, EventArgs e)
        {
            getOrders();
        }

        private void ButtonOrdernow_Click(object sender, EventArgs e)
        {
            if ( OrderId!= 0)
            {
                Connection conn = new Connection();
                

                conn.insertOrder(OrderId);
                conn.insertOrderItems(OrderId);
                conn.updatetablestats(tableno);
                conn.delorderItems(OrderId);
                conn.delorders(OrderId);
                conn.updateInventory(OrderId);
                dataGridViewOrderItems.DataSource = null;
                dataGridViewOrderItems.Refresh();

            }
        }

        private void buttonTable_Click(object sender, EventArgs e)
        {
            Tables Table = new Tables();
            Table.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            user.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            reports rep = new reports();
            rep.ShowDialog();
        }

        private void checkBoxtax_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxtax.Checked)
            {
                numericUpDowntax.Enabled = true;
                textBoxtax.Text = (Int16.Parse(textBoxsubtotal.Text) * (Int16.Parse(numericUpDowntax.Value.ToString()) / 100.0)).ToString();
                textBoxtotal.Text = (float.Parse(textBoxsubtotal.Text) + (float.Parse(textBoxsubtotal.Text) * (Int16.Parse(numericUpDowntax.Value.ToString())/100.0))).ToString();
                textBoxNetBill.Text = (float.Parse(textBoxsubtotal.Text) + float.Parse(textBoxtax.Text) - float.Parse(textBoxdiscount.Text) + float.Parse(textBoxserCharge.Text)).ToString();
            }
            else
            {
                try
                {
                    textBoxtotal.Text = (float.Parse(textBoxtotal.Text) - float.Parse(textBoxtax.Text) ).ToString();
                    textBoxNetBill.Text = (Math.Floor((float.Parse(textBoxtotal.Text))-float.Parse(textBoxdiscount.Text) + float.Parse(textBoxserCharge.Text))).ToString();
                    textBoxtax.Text = "0.0";
                    numericUpDowntax.Value = 13;
                    numericUpDowntax.Enabled = false;
                }
                catch(Exception ee)
                {
                    MessageBox.Show(ee.ToString());
                }
            }
        }

        private void numericUpDowntax_ValueChanged(object sender, EventArgs e)
        {
            textBoxtax.Text= (Int16.Parse(textBoxsubtotal.Text) * (Int16.Parse(numericUpDowntax.Value.ToString()) / 100.0)).ToString();
            textBoxtotal.Text = (Int16.Parse(textBoxsubtotal.Text) + (Int16.Parse(textBoxsubtotal.Text) * (Int16.Parse(numericUpDowntax.Value.ToString()) / 100.0))).ToString();
            textBoxNetBill.Text = (float.Parse(textBoxsubtotal.Text) + float.Parse(textBoxtax.Text) - float.Parse(textBoxdiscount.Text) + float.Parse(textBoxserCharge.Text)).ToString();
        }

        private void checkBoxservicecharges_CheckedChanged(object sender, EventArgs e)
        {
           if (checkBoxservicecharges.Checked)
            {
                textBoxservicecharge.Enabled = true;
            }
            else
            {
               
                textBoxNetBill.Text = (float.Parse(textBoxNetBill.Text) - float.Parse(textBoxservicecharge.Text)+ float.Parse(textBoxdiscount.Text)).ToString();
             
                textBoxservicecharge.Text = "0";
                textBoxserCharge.Text = "0.0";
                textBoxservicecharge.Enabled = false;
            }
        }

        private void buttonDISCOUNT_Click(object sender, EventArgs e)
        {
            SelectDiscount sd = new SelectDiscount(float.Parse(textBoxtotal.Text), OrderId);
            sd.ShowDialog();
            textBoxdiscount.Text = sd.discountamnt;
            textBoxNetBill.Text = (float.Parse(textBoxtotal.Text) - float.Parse(textBoxdiscount.Text) + float.Parse(textBoxserCharge.Text)).ToString();
        }

        private void textBoxservicecharge_TextChanged(object sender, EventArgs e)
        {
            if(textBoxservicecharge.Text.Length>0)
            {
                textBoxNetBill.Text = (float.Parse(textBoxtotal.Text) - float.Parse(textBoxdiscount.Text) + float.Parse(textBoxservicecharge.Text)).ToString();
                textBoxserCharge.Text = textBoxservicecharge.Text;

            }
        }

        private void textBoxcashpay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxcaedpay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void textBoxcashpaying_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void textBoxservicecharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void buttonundoDis_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            conn.deldiscountamnt(OrderId);
            textBoxNetBill.Text = (float.Parse(textBoxsubtotal.Text)+ float.Parse(textBoxtax.Text)- float.Parse(textBoxdiscount.Text)+ float.Parse(textBoxserCharge.Text)).ToString();
            textBoxdiscount.Text = "0.0";
        }

        private void incredientsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Incredients incr = new Incredients();
            incr.ShowDialog();
        }

        private void checkBoxmultipayment_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxmultipayment.Checked)
            {
                textBoxcashpay.Enabled = true;
                textBoxcardpay.Enabled = true;
                checkBoxcard.Checked = false;
            }
            else
            {
                textBoxcashpay.Enabled = false;
                textBoxcardpay.Enabled = false;
                textBoxcashpay.Text = "";
                textBoxcardpay.Text = "";
            }
        }

        private void checkBoxcard_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxcard.Checked)
            {
                checkBoxmultipayment.Checked = false;
                textBoxcreditcardpayment.Enabled = true;
            }
            else
            {
                textBoxcreditcardpayment.Enabled = false;
                textBoxcreditcardpayment.Text = "";
            }
        }
    }
}
