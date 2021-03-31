using System;
using System.Collections;
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
            Customers cust = new Customers(dt.userid);
            cust.ShowDialog();
          
        }

        private void buttonTakeAway_Click(object sender, EventArgs e)
        {
            Order ord = new Order("Take Away",dt.userid);
            ord.ShowDialog();
        }

       
        public void getOrders()
        {
            Connection conn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("	SELECT t_Oid as OrderId,t_netamnt as TotalAmount ,t_tablename as Tables,Dateorder as Time,t_ordertype as OrderType FROM temp_orders tempord  join userord usr on usr.order_id = tempord.t_Oid where usr.user_id = '" + dt.userid + "'", ConnectionString);
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
                dt.Ordertype = row.Cells[4].Value.ToString();
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
            select_table st = new select_table("Dine In",dt.userid);
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
                if(checkBoxcard.Checked)
                {
                    conn.insertcrpayment(OrderId, Int16.Parse(textBoxcreditcardpayment.Text));
                }
                else if(checkBoxmultipayment.Checked)
                {
                    conn.insertcrpayment(OrderId, Int16.Parse(textBoxcreditcardpayment.Text));

                }
                if (checkBoxtax.Checked)
                {
                    conn.inserttax(OrderId, Int16.Parse(textBoxtax.Text));

                }
                if (checkBoxservicecharges.Checked)
                {
                    conn.insertservicetax(OrderId, Int16.Parse(textBoxserCharge.Text));
                }
                TakeAwayprintDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("prnm", 285, 600);
                TakeAwayprintDocument.Print();
                conn.Insertcountinven(OrderId);
                conn.insertOrder(OrderId);
                conn.insertOrderItems(OrderId);
                conn.updatetablestats(tableno);
                
                conn.delorderItems(OrderId);
                conn.delorders(OrderId);
                conn.updateInventory(OrderId);
                dataGridViewOrderItems.DataSource = null;
                dataGridViewOrderItems.Refresh();
                clearall();
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
            if(checkBoxtax.Checked && textBoxsubtotal.Text!="0.0")
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
                    textBoxNetBill.Text = (Math.Floor((float.Parse(textBoxtotal.Text))-float.Parse(textBoxdiscount.Text) + float.Parse(textBoxserCharge.Text)+0.0)).ToString();
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
            if (conn.deldiscountamnt(OrderId))
            {
                textBoxdiscount.Text = "0.0";
                textBoxNetBill.Text = (float.Parse(textBoxtotal.Text) + float.Parse(textBoxserCharge.Text)).ToString();
               
            }
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

        private void TakeAwayprintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int y = 0;
            Connection conn = new Connection();
            var bmp = new Bitmap(rmsid2.Properties.Resources.logo, new Size(180, 70));
            e.Graphics.DrawImage(bmp, new Point(50, y));
            //  e.Graphics.DrawImage(bmp, new Point(50, y));
            //  e.Graphics.DrawString("2GB", new Font("monospaced sans serif", 38, FontStyle.Bold), Brushes.Black, new Point(50, y));
            e.Graphics.DrawString("PLOT GPC SHOP #1 GULSHAN E IQBAL BLOCK 4", new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(5, y += 80));
            e.Graphics.DrawString(" (03)-111-888-242", new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(60, y += 20));
            e.Graphics.DrawString(" SNTN#S6601547-2", new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(60, y += 20));
            e.Graphics.DrawString(" INFO@THE2GB.COM", new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(60, y += 20));
            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));
            e.Graphics.DrawString("DATE:" + DateTime.Today, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Order No:" + OrderId, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
        if(dt.Ordertype== "Dine In")
            {
                ArrayList customer = reteievecustomer(OrderId);
                foreach(Detail c in customer)
                {
                    e.Graphics.DrawString("Customer Name:" + c.cust_name, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
                    e.Graphics.DrawString("Customer No:" + c.cust_phone, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
                    e.Graphics.DrawString("Customer Address:" + c.address, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));

                }
            }
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT t_iName as ItemName,t_iprice as UnitPrice,t_iqty as Quantity,t_inetprice as TotalPrice FROM OrderItems where t_Oid = '" + OrderId + "';", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        y += 20;
                        e.Graphics.DrawString((reader["ItemName"].ToString()), new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(5, y));
                        e.Graphics.DrawString((reader["UnitPrice"].ToString()), new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(100, y));
                        e.Graphics.DrawString((reader["Quantity"].ToString()), new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(150, y));
                        e.Graphics.DrawString((reader["TotalPrice"].ToString()), new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(220, y));
                    }
                }
                connection.Close();
            }
            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));
            e.Graphics.DrawString("SubTotal:", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
            e.Graphics.DrawString(textBoxsubtotal.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
            if(checkBoxtax.Checked)
                    {
                    e.Graphics.DrawString("Tax: " + numericUpDowntax, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                    e.Graphics.DrawString(textBoxtax.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
                e.Graphics.DrawString("Total: " + numericUpDowntax, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxtax.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));

            }
            if(textBoxdiscount.Text!="0.0")
            {
                e.Graphics.DrawString("Discount: " + numericUpDowntax, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxdiscount.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));

            }
            if(checkBoxservicecharges.Checked)
            {
                e.Graphics.DrawString("Service Charges: " + numericUpDowntax, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxserCharge.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));

            }
            e.Graphics.DrawString("Net Bill: " + numericUpDowntax, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
            e.Graphics.DrawString(textBoxserCharge.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
            if(checkBoxservicecharges.Checked && (Int16.Parse(textBoxcashpay.Text)+ Int16.Parse(textBoxcardpay.Text)) == Int16.Parse(textBoxNetBill.Text))
            {
                e.Graphics.DrawString("Cash payment: "  , new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxcashpay.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
                e.Graphics.DrawString("Card Payment: "  , new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxcardpay.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));

            }
            if(checkBoxcard.Checked && Int16.Parse(textBoxcreditcardpayment.Text) == Int16.Parse(textBoxNetBill.Text))
            {
                e.Graphics.DrawString("Card Payment: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxcreditcardpayment.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
            }
            e.Graphics.DrawString("Net Bill: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
            e.Graphics.DrawString(textBoxNetBill.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));

            e.Graphics.DrawString("(ALL PRICES ARE INCLUSIVE OF 13% SST)", new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(30, y += 20));
            e.Graphics.DrawString(" !!! QUALITY IS OUR RECIPE !!! ", new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(60, y += 20));
            e.Graphics.DrawString(" Powered By Innovative Ducks", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(60, y += 20));
            e.Graphics.DrawString(" +92 337 3161567   www.innovativeducks.com", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));

        }


        public ArrayList reteievecustomer(int Oid)
        {
            ArrayList CustomerList = new ArrayList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("select cust_name,cust_phone,cust_address from customer inner join customerOrders on customer.cust_id=customer.cust_id inner join temp_orders on customerOrders.Order_id= temp_orders.t_Oid where temp_orders.t_Oid= '" + Oid + "';", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CustomerList.Add(new Detail() { cust_name = (reader["cust_name"].ToString()), cust_phone = (reader["cust_phone"].ToString()), address = (reader["cust_address"].ToString()) });
                    }
                }
                connection.Close();

                return CustomerList;
            }
        }
        public void clearall()
        {
            OrderId = 0;
            checkBoxcard.Checked = false;
            checkBoxmultipayment.Checked = false;
            checkBoxtax.Checked = false;
            checkBoxcard.Checked = false;
            textBoxcashpaying.Text = "";
            textBoxreturn.Text = "";
            textBoxsubtotal.Text = "0.0";
            textBoxtax.Text = "0.0";
            textBoxtotal.Text = "0.0";
            textBoxdiscount.Text = "0.0";
            textBoxserCharge.Text = "0.0";
            textBoxNetBill.Text = "0.0";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == "Open Register")
            {
                register reg = new register(dt.userid);
                reg.ShowDialog();
               if(reg.registertext!="")
                dt.startregister = Int16.Parse(reg.registertext);
                button7.Text = "Close Register";
            }
            else
            {
                button7.Text = "Open Register";
            }

        }

        private void printRegisterDcoumentDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int y = 0;
            Connection conn = new Connection();
            dt.startreg=    conn.getregtime(dt.userid);
            conn.endregister(dt.userid);
            var bmp = new Bitmap(rmsid2.Properties.Resources.logo, new Size(180, 70));
            e.Graphics.DrawImage(bmp, new Point(50, y));
            e.Graphics.DrawString("PLOT GPC SHOP #1 GULSHAN E IQBAL BLOCK 4", new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(5, y += 80));
            e.Graphics.DrawString(" (03)-111-888-242", new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(60, y += 20));
            e.Graphics.DrawString(" SNTN#S6601547-2", new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(60, y += 20));
            e.Graphics.DrawString(" INFO@THE2GB.COM", new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(60, y += 20));
            e.Graphics.DrawString("Shifting Closing Report", new Font("monospaced sans serif", 14, FontStyle.Regular), Brushes.Black, new Point(40, y += 20));
            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));
            e.Graphics.DrawString("Print Date:" + DateTime.Today, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Z-Number:" + DateTime.Now.DayOfYear.ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Print Time:" +DateTime.Now.ToString("hh:mm:ss tt"), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Opening Time:" + dt.startreg.ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Closing Time:" + DateTime.Now.ToString("hh:mm:ss tt"), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Closing Person:"  + dt.username, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));
            e.Graphics.DrawString("Sale Summary", new Font("monospaced sans serif", 14, FontStyle.Regular), Brushes.Black, new Point(40, y += 20));
            foreach (Detail discount in conn.retrievediscounts(DateTime.Now, DateTime.Now, dt.userid))
            {
                e.Graphics.DrawString(discount.DiscountType, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
                e.Graphics.DrawString(discount.DiscountAmount.ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(80, y ));
            }
            
            e.Graphics.DrawString("Taxes", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString(conn.retrievedtaxes(dt.startreg, DateTime.Now, dt.userid).ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(80, y));
            e.Graphics.DrawString("Charges", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString(conn.calculatesercharge(dt.startreg, DateTime.Now, dt.userid).ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(80, y));
            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));
            e.Graphics.DrawString("Net sales", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString(conn.calculatenetsale(dt.startreg, DateTime.Now, dt.userid).ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(80, y));
            foreach (Detail order in conn.retrievedOrders(dt.startreg, DateTime.Now, dt.userid))
            {
                e.Graphics.DrawString("OrderType", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString("Orders", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(80, y ));
                e.Graphics.DrawString("Total Amount", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(120, y));
                e.Graphics.DrawString(order.OrderType.ToString(), new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(order.Orders.ToString(), new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(80, y));
                e.Graphics.DrawString(order.netsale.ToString(), new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(120, y));

            }
            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));
            e.Graphics.DrawString("Inventory Detail", new Font("monospaced sans serif", 14, FontStyle.Regular), Brushes.Black, new Point(40, y += 20));
            foreach (Detail Inventory in conn.retrieveUsedInventory(dt.startreg, DateTime.Now, dt.userid))
            {
                e.Graphics.DrawString("Inventory", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString("Quanity", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(120, y));
                e.Graphics.DrawString(Inventory.invenname.ToString(), new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(Inventory.invenqty.ToString(), new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(120, y));
            }
            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));
            e.Graphics.DrawString("Order Details", new Font("monospaced sans serif", 14, FontStyle.Regular), Brushes.Black, new Point(40, y += 20));
            foreach (Detail product in conn.retrievedProducts(dt.startreg, DateTime.Now, dt.userid))
            {
                e.Graphics.DrawString("Product Name", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString("Quantity", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(120, y));
                e.Graphics.DrawString(product.p_name.ToString(), new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(product.p_qty.ToString(), new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(120, y));
            }
            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));

        }
    }
}
