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

        public Dashboard(string p, string un, int userid)
        {
            InitializeComponent();
            dt.user_privelage = p;
            dt.username = un;
            dt.userid = userid;
            Username.Text = "Hello " + dt.username;
            Connection conn = new Connection();
            if(conn.RegOpenClose(userid)==1)
            {
                button7.Text = "Close Register";
                registerstart.Text = "Register Start:"+ conn.getregtime(userid) ;
                dt.starttimereg = conn.getregtime(userid);
            }

       //     MessageBox.Show(p);
        }
        public Dashboard()
        {
            InitializeComponent();

        }
        string ConnectionString = "Server=DESKTOP-C27B91F,1433;Database=rmsid;User Id = saadkhan; Password=saad; ";
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
           
            if (String.Compare(dt.user_privelage, "Manager") == 0)
            {
               
                Products p = new Products();
                p.ShowDialog();

            }
            else
                MessageBox.Show("user not have privilege");
        }

        private void incredientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dt.user_privelage == "Manager")
            {
                Incredients inc = new Incredients();
                inc.ShowDialog();
            }
            else
                MessageBox.Show("user not have privilege");
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dt.user_privelage == "Manager")
            {
                categories cat = new categories();
                cat.ShowDialog();

            }
            else
                MessageBox.Show("user not have privilege");
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dt.user_privelage == "Manager")
            {
                Inventory inven = new Inventory();
                inven.ShowDialog();
            }
            else
                MessageBox.Show("user not have privilege");
        }



        private void buttonDelivery_Click(object sender, EventArgs e)
        {
            if (button7.Text != "Open Register")
            {
                Customers cust = new Customers(dt.userid);
                cust.ShowDialog();
            }
            else
            {
                MessageBox.Show("Register is not Open");
            }
        }

        private void buttonTakeAway_Click(object sender, EventArgs e)
        {
            if (button7.Text != "Open Register")
            {
                Order ord = new Order("Take Away", dt.userid);
                ord.ShowDialog();
            }
            else
            {
                MessageBox.Show("Register is not Open");
            }
        }


        public void getOrders()
        {
            Connection conn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("SELECT t_Oid as OrderId,t_netamnt as TotalAmount ,t_tablename as Tables,t_ordertype as OrderType,Dateorder as Time FROM temp_orders tempord  join userord usr on usr.order_id = tempord.t_Oid where usr.user_id = '" + dt.userid + "'", ConnectionString);
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
                OrderId = Int16.Parse(row.Cells[0].Value.ToString());
                tableno = (row.Cells[2].Value.ToString());
                dt.Ordertype = row.Cells[3].Value.ToString();

                textBoxsubtotal.Text = row.Cells[1].Value.ToString();
                textBoxtotal.Text = row.Cells[1].Value.ToString();
                textBoxNetBill.Text = row.Cells[1].Value.ToString();
                Connection conn = new Connection();
                SqlDataAdapter da = new SqlDataAdapter("SELECT t_iName as ItemName,t_iqty as Quantity,t_iprice as UnitPrice,t_inetprice as TotalPrice,dis_avail   FROM temp_orderitems where t_Oid='" + OrderId + "'", ConnectionString);
                DataSet ds = new DataSet();
                da.Fill(ds, "temp_orderitems");
                dataGridViewOrderItems.DataSource = ds.Tables["temp_orderitems"].DefaultView;
            }
        }

        public int calamnt()
        {
            int sum = 0;
            for (int i = 0; i < dataGridViewOrderItems.Rows.Count; i++) /////(i till 12 bcoz you have add 12 rows)
            {
                if(dataGridViewOrderItems.Rows[i].Cells[4].Value.ToString()=="0")
                {
                    sum += Int16.Parse(dataGridViewOrderItems.Rows[i].Cells[3].Value.ToString());
                }
            }
            return sum;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (button7.Text != "Open Register")
            {
                select_table st = new select_table("Dine In", dt.userid);
                st.ShowDialog();
            }
            else
            {
                MessageBox.Show("Register is not Open");
            }
        }

        private void timerfunc_Tick_1(object sender, EventArgs e)
        {
            getOrders();
        }

        private void ButtonOrdernow_Click(object sender, EventArgs e)
        {
            if (OrderId != 0 && Int16.Parse(textBoxreturn.Text) >=0)
            {
                Connection conn = new Connection();
                if (checkBoxcard.Checked)
                {
                    conn.insertcrpayment(OrderId, Int16.Parse(textBoxcreditcardpayment.Text));
                }
                else if (checkBoxmultipayment.Checked)
                {
                    conn.insertcrpayment(OrderId, Int16.Parse(textBoxcardpay.Text));

                }
                if (checkBoxtax.Checked)
                {
                    conn.inserttax(OrderId, float.Parse(textBoxtax.Text));

                }
                if (checkBoxservicecharges.Checked)
                {
                    conn.insertservicetax(OrderId, Int16.Parse(textBoxserCharge.Text));
                }
                TakeAwayprintDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("prnm", 285, 800);
                TakeAwayprintDocument.Print();
                printcustomerDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("prnm", 285, 800);
                printcustomerDocument.Print();
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
            if (dt.user_privelage == "Manager")
            {
                Tables Table = new Tables();
                Table.ShowDialog();
            }
            else
                MessageBox.Show("user not have privilege");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(dt.user_privelage== "Manager")
            {
                Users user = new Users();
                user.ShowDialog();
            }
            else
                MessageBox.Show("user not have privilege");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dt.user_privelage == "Manager")
            {
                reports rep = new reports();
                rep.ShowDialog();
            }
            else
                MessageBox.Show("user not have privilege");
        }

        private void checkBoxtax_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxtax.Checked && textBoxsubtotal.Text != "0.0")
            {
                numericUpDowntax.Enabled = true;
                textBoxtax.Text = (Int16.Parse(textBoxsubtotal.Text) * (Int16.Parse(numericUpDowntax.Value.ToString()) / 100.0)).ToString();
                textBoxtotal.Text = (float.Parse(textBoxsubtotal.Text) + (float.Parse(textBoxsubtotal.Text) * (Int16.Parse(numericUpDowntax.Value.ToString()) / 100.0))).ToString();
                textBoxNetBill.Text = (float.Parse(textBoxsubtotal.Text) + float.Parse(textBoxtax.Text) - float.Parse(textBoxdiscount.Text) + float.Parse(textBoxserCharge.Text)).ToString();
            }
            else
            {
                try
                {
                    textBoxtotal.Text = (float.Parse(textBoxtotal.Text) - float.Parse(textBoxtax.Text)).ToString();
                    textBoxNetBill.Text = (Math.Floor((float.Parse(textBoxtotal.Text)) - float.Parse(textBoxdiscount.Text) + float.Parse(textBoxserCharge.Text) + 0.0)).ToString();
                    textBoxtax.Text = "0.0";
                    numericUpDowntax.Value = 13;
                    numericUpDowntax.Enabled = false;
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.ToString());
                }
            }
            checkBoxcard.Checked = false;
            checkBoxmultipayment.Checked = false;
            checkBoxcash.Checked = true;
        }

        private void numericUpDowntax_ValueChanged(object sender, EventArgs e)
        {
            textBoxtax.Text = (Int16.Parse(textBoxsubtotal.Text) * (Int16.Parse(numericUpDowntax.Value.ToString()) / 100.0)).ToString();
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

                textBoxNetBill.Text = (float.Parse(textBoxNetBill.Text) - float.Parse(textBoxservicecharge.Text) + float.Parse(textBoxdiscount.Text)).ToString();

                textBoxservicecharge.Text = "0";
                textBoxserCharge.Text = "0.0";
                textBoxservicecharge.Enabled = false;
            }
            checkBoxcard.Checked = false;
            checkBoxmultipayment.Checked = false;
            checkBoxcash.Checked = true;
        }

        private void buttonDISCOUNT_Click(object sender, EventArgs e)
        {
            if (OrderId != 0)
            {
                SelectDiscount sd = new SelectDiscount(calamnt()+float.Parse(textBoxtax.Text), OrderId);
                sd.ShowDialog();
                if (sd.discountamnt != "")
                {
                    textBoxdiscount.Text = sd.discountamnt;
                    textBoxNetBill.Text = (float.Parse(textBoxtotal.Text) - float.Parse(textBoxdiscount.Text) + float.Parse(textBoxserCharge.Text)).ToString();
                }
                checkBoxcard.Checked = false;
                checkBoxmultipayment.Checked = false;
                checkBoxcash.Checked = true;
            }
        }

        private void textBoxservicecharge_TextChanged(object sender, EventArgs e)
        {
            if (textBoxservicecharge.Text.Length > 0 && OrderId!=0)
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxcashpaying_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxservicecharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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
            if (checkBoxmultipayment.Checked)
            {
                textBoxcashpay.Enabled = true;
                textBoxcardpay.Enabled = true;
                checkBoxcard.Checked = false;
                checkBoxcash.Checked = false;
                textBoxcashpay.Focus();
            }
            else
            {
                textBoxcashpay.Enabled = false;
                textBoxcardpay.Enabled = false;
                checkBoxcash.Checked = true;
                textBoxcashpay.Text = "";
                textBoxcardpay.Text = "";
            }
        }

        private void checkBoxcard_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxcard.Checked)
            {
                checkBoxmultipayment.Checked = false;
                textBoxcreditcardpayment.Enabled = true;
                checkBoxcash.Checked = false;
                checkBoxcash.Enabled = false;
            }
            else
            {
                textBoxcreditcardpayment.Enabled = false;
                textBoxcreditcardpayment.Text = "";
                checkBoxcash.Checked = true;
            }
        }

        private void TakeAwayprintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
             y = 0;
            var bmp = new Bitmap(rmsid2.Properties.Resources.logo, new Size(180, 70));
            e.Graphics.DrawImage(bmp, new Point(50, y));
            e.Graphics.DrawString("PLOT GPC SHOP #1 GULSHAN E IQBAL BLOCK 4", new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(5, y += 80));
            e.Graphics.DrawString(" (03)-111-888-242", new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(60, y += 20));
            e.Graphics.DrawString(" SNTN#S6601547-2", new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(60, y += 20));
            e.Graphics.DrawString(" INFO@THE2GB.COM", new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(60, y += 20));
            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(5, y += 20));
            e.Graphics.DrawString("DATE:" + DateTime.Now, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Order No:" + OrderId, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Order Type:" + dt.Ordertype, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Order Receipt" , new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
         //   if (dt.Ordertype == "Dine In")
        //    {
                e.Graphics.DrawString("Table : " +tableno, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));

        //    }
         //   if (dt.Ordertype == "Delivery")
         //   {
                ArrayList customer = reteievecustomer(OrderId);
                foreach (Detail c in customer)
                {
                 e.Graphics.DrawString("Cust Name:" + c.cust_name, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(5, y += 20));
                 e.Graphics.DrawString("Cust No:" + c.cust_phone, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(5, y += 20));
                 e.Graphics.DrawString("Cust Address:" + c.address, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(5, y += 20));
                 e.Graphics.DrawString("Rider:" + c.deliveryBoy_Name, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(5, y += 20));

                }
            // }

            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(5, y += 20));
            e.Graphics.DrawString("Order Details", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Item Name", new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(5, y += 20));
            e.Graphics.DrawString("Price", new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(145, y));
            e.Graphics.DrawString("Quantity", new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(170, y));
            e.Graphics.DrawString("Total", new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(220, y));
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT t_iName as ItemName,t_iprice as UnitPrice,t_iqty as Quantity,t_inetprice as TotalPrice FROM temp_orderitems where t_Oid = '" + OrderId + "';", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        y += 20;
                        e.Graphics.DrawString((reader["ItemName"].ToString()), new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(5, y));
                        e.Graphics.DrawString((reader["UnitPrice"].ToString()), new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(145, y));
                        e.Graphics.DrawString((reader["Quantity"].ToString()), new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(170, y));
                        e.Graphics.DrawString((reader["TotalPrice"].ToString()), new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(220, y));
                    }
                }
                connection.Close();
            }
            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(5, y += 20));
            e.Graphics.DrawString("Payment Details", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));

            e.Graphics.DrawString("SubTotal:", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
            e.Graphics.DrawString(textBoxsubtotal.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
            if (checkBoxtax.Checked)
            {
                e.Graphics.DrawString("Tax: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxtax.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
                e.Graphics.DrawString("Total: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxtotal.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));

            }
            if (textBoxdiscount.Text != "0.0")
            {
                e.Graphics.DrawString("Discount: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxdiscount.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));

            }
            if (checkBoxservicecharges.Checked)
            {
                e.Graphics.DrawString("Service Charges: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxserCharge.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));

            }
            e.Graphics.DrawString("Net Bill: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
            e.Graphics.DrawString(textBoxNetBill.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
            if (checkBoxmultipayment.Checked)
            {
                e.Graphics.DrawString("Payment Method: Multi Payment ", new Font("monospaced sans serif", 12, FontStyle.Bold), Brushes.Black, new Point(40, y += 20));
                e.Graphics.DrawString("Cash payment: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxcashpay.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
                e.Graphics.DrawString("Card Payment: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxcardpay.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
                e.Graphics.DrawString("Return: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxreturn.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
            }
            if (checkBoxcard.Checked)
            {
                e.Graphics.DrawString("Payment Method: Card Payment ", new Font("monospaced sans serif", 12, FontStyle.Bold), Brushes.Black, new Point(40, y += 20));

                e.Graphics.DrawString("Card Payment: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxcreditcardpayment.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
                e.Graphics.DrawString("Return: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxreturn.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
            }
            if (checkBoxcash.Checked)
            {
                e.Graphics.DrawString("Payment Method: Cash Payment ", new Font("monospaced sans serif", 12, FontStyle.Bold), Brushes.Black, new Point(40, y += 20));

                e.Graphics.DrawString("Cash Payment: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxcashpaying.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
                e.Graphics.DrawString("Return: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxreturn.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
            }
            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(5, y += 20));
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
                SqlCommand command = new SqlCommand("select cust_name,cust_phone,cust_address,DeliveryBoys.d_name as d_name from customer  inner join customerOrders on customer.cust_id=customer.cust_id  inner join temp_orders  on customerOrders.Order_id= temp_orders.t_Oid inner join del_orders on del_orders.order_id=customerOrders.Order_id inner join DeliveryBoys  on DeliveryBoys.d_id = del_orders.d_id where temp_orders.t_Oid='" + Oid + "';", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CustomerList.Add(new Detail() { cust_name = (reader["cust_name"].ToString()), cust_phone = (reader["cust_phone"].ToString()), address = (reader["cust_address"].ToString()),deliveryBoy_Name= reader["d_name"].ToString() });
                    }
                }
                connection.Close();

                return CustomerList;
            }
        }
        public void clearall()
        {
            OrderId = 0;
            checkBoxservicecharges.Checked = false;
            checkBoxtax.Checked = false;
            checkBoxcard.Checked = false;
            checkBoxmultipayment.Checked = false;
            checkBoxcash.Checked = true;
            textBoxcashpaying.Text = "";
            textBoxreturn.Text = "";
            textBoxsubtotal.Text = "0.0";
            textBoxtax.Text = "0.0";
            textBoxtotal.Text = "0.0";
            textBoxdiscount.Text = "0.0";
            textBoxserCharge.Text = "0.0";
            textBoxNetBill.Text = "0.0";
        }
        int y = 0;
        private void button7_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            if (button7.Text == "Open Register")
            {
                register reg = new register(dt.userid);
                reg.ShowDialog();
                if (reg.registertext != "")
                {
                    dt.startregister = Int16.Parse(reg.registertext);
                    registerstart.Text = "Register Start: " + (DateTime.Now).ToString();
                    
                    conn.Updateregopen(dt.userid);
                    button7.Text = "Close Register";
                }
            }
            else
            {
                printRegisterDcoumentDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("prnm", 285, 1000);
                printRegisterDcoumentDocument.Print();
                registerstart.Text="Register End: "+ (DateTime.Now).ToString();
                conn.Updateregclose(dt.userid);
                button7.Text = "Open Register";
            }

        }

        private void printRegisterDcoumentDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            y = 0;
            Connection conn = new Connection();
            dt.startreg = conn.getregtime(dt.userid);

            conn.endregister(dt.userid,conn.getregid(dt.userid));
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
            e.Graphics.DrawString("Print Time:" + DateTime.Now.ToString("hh:mm:ss tt"), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Opening Time:" + dt.startreg.ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Closing Time:" + DateTime.Now.ToString("hh:mm:ss tt"), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Closing Person:" + dt.username, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Opening Amount:" + dt.startregister.ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));

            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));
            e.Graphics.DrawString("Sale Summary", new Font("monospaced sans serif", 14, FontStyle.Bold), Brushes.Black, new Point(40, y += 20));
            ArrayList discounts = conn.retrievediscounts(dt.startreg, DateTime.Now, dt.userid);
            int disc = 0;
            foreach (Detail discount in discounts)
            {
                e.Graphics.DrawString(discount.DiscountType, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
                disc += discount.DiscountAmount;
                e.Graphics.DrawString(discount.DiscountAmount.ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(150, y));
            }
            e.Graphics.DrawString("Taxes", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString(conn.retrievedtaxes(dt.startreg, DateTime.Now, dt.userid).ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(80, y));
            e.Graphics.DrawString("Extra Charges: ", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString(conn.calculatesercharge(dt.startreg, DateTime.Now, dt.userid).ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(150, y));
            e.Graphics.DrawString("Card payments: ", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString(conn.calculateCrtaxes(dt.startreg, DateTime.Now, dt.userid).ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(150, y));
            e.Graphics.DrawString("Total sales", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString(conn.calculatenetsale(dt.startreg, DateTime.Now, dt.userid).ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(150, y));
            e.Graphics.DrawString("Net sales(total+charges+tax+cr pay-discount)", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
            
            int NetSale = conn.calculatenetsale(dt.startreg, DateTime.Now, dt.userid) + conn.retrievedtaxes(dt.startreg, DateTime.Now, dt.userid)+ conn.calculatesercharge(dt.startreg, DateTime.Now, dt.userid)-disc;
            e.Graphics.DrawString((NetSale).ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Cash In Hand(Netsale + Opening Amnt)", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString((NetSale+dt.startregister).ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));


            //  e.Graphics.DrawString(conn.calculatenetsale(dt.startreg, DateTime.Now, dt.userid).ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(150, y));
            e.Graphics.DrawString("------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));
            e.Graphics.DrawString("Order Details", new Font("monospaced sans serif", 14, FontStyle.Bold), Brushes.Black, new Point(40, y += 20));
            e.Graphics.DrawString("OrderType", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
            e.Graphics.DrawString("Orders", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(80, y));
            e.Graphics.DrawString("Total Amount", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(120, y));
            foreach (Detail order in conn.retrievedOrders(dt.startreg, DateTime.Now, dt.userid))
            {
                 e.Graphics.DrawString(order.OrderType.ToString(), new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(order.Orders.ToString(), new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(80, y));
                e.Graphics.DrawString(order.netsale.ToString(), new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(120, y));

            }
            ArrayList orderdetails = conn.retrieveUsedInventory(dt.startreg, DateTime.Now, dt.userid);
            e.Graphics.DrawString("Inventory Detail", new Font("monospaced sans serif", 14, FontStyle.Bold), Brushes.Black, new Point(40, y += 20));
            e.Graphics.DrawString("Inventory", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
            e.Graphics.DrawString("Quantity", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(120, y));

            foreach (Detail Inventory in orderdetails)
            {
                e.Graphics.DrawString(Inventory.invenname.ToString(), new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(Inventory.invenqty.ToString(), new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(120, y));
            }
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));
            e.Graphics.DrawString("Products Details", new Font("monospaced sans serif", 14, FontStyle.Bold), Brushes.Black, new Point(40, y += 20));
            ArrayList productsdetail = conn.retrievedProducts(dt.startreg, DateTime.Now, dt.userid);
            e.Graphics.DrawString("Product Name", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
            e.Graphics.DrawString("Quantity", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(150, y));

            foreach (Detail product in productsdetail)
            {
                 e.Graphics.DrawString(product.p_name.ToString(), new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(product.p_qty.ToString(), new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(150, y));
            }
      //      MessageBox.Show(dt.startreg.ToString()+ DateTime.Now.ToString());
            e.Graphics.DrawString("----------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            if (button7.Text == "Close Register")
            {
                if (MessageBox.Show("Do you Really want to Logout and Close Register?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    
                    calllastone();
                    Connection conn = new Connection();
                    conn.Updateregclose(dt.userid);
                    conn.updatelastlogin(dt.username);
                    Login log = new Login();
                    this.Hide();
                    log.ShowDialog();

                }

            }
            else
            {
                Connection conn = new Connection();

                conn.updatelastlogin(dt.username);
                Login log = new Login();
                this.Hide();
                log.ShowDialog();
            }


        }
        public void calllastone()
        {
            Connection conn = new Connection();
            conn.updatelastlogin(dt.username);

            foreach (DataGridViewRow row in dataGridViewOrderlist.Rows)
            {
                conn.Insertcountinven(Int16.Parse(row.Cells[0].Value.ToString()));
                conn.insertOrder(Int16.Parse(row.Cells[0].Value.ToString()));
                conn.insertOrderItems(Int16.Parse(row.Cells[0].Value.ToString()));
                conn.updatetablestats(row.Cells[2].Value.ToString());

                conn.delorderItems(Int16.Parse(row.Cells[0].Value.ToString()));
                conn.delorders(Int16.Parse(row.Cells[0].Value.ToString()));
                conn.updateInventory(Int16.Parse(row.Cells[0].Value.ToString()));

                //More code here
            }
            printRegisterDcoumentDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("prnm", 285, 1000);
            printRegisterDcoumentDocument.Print();
            button7.Text = "Open Register";
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (button7.Text == "Close Register")
            {
                if (MessageBox.Show("Do you Really want to Logout and Close Register?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    calllastone();
                    Connection conn = new Connection();
                    conn.Updateregclose(dt.userid);
                    conn.updatelastlogin(dt.username);
                    this.Close();

                }
                else
                {

                }
            }
            else
            {
                Connection conn = new Connection();
                conn.updatelastlogin(dt.username);
            }


        }

        private void discountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dt.user_privelage == "Manager")
            {
                disocunts dis = new disocunts();
                dis.ShowDialog();
            }
            else
                MessageBox.Show("user not have privilege");
        }

        private void buttonriders_Click(object sender, EventArgs e)
        {
            if (dt.user_privelage == "Manager")
            {
                deliveryboys db = new deliveryboys();
                db.ShowDialog();
            }
            else
                MessageBox.Show("user not have privilege");

        }

        private void printcustomerDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
             y = 0;
            var bmp = new Bitmap(rmsid2.Properties.Resources.logo, new Size(180, 70));
            e.Graphics.DrawImage(bmp, new Point(50, y));
            e.Graphics.DrawString("PLOT GPC SHOP #1 GULSHAN E IQBAL BLOCK 4", new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(5, y += 80));
            e.Graphics.DrawString(" (03)-111-888-242", new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(60, y += 20));
            e.Graphics.DrawString(" SNTN#S6601547-2", new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(60, y += 20));
            e.Graphics.DrawString(" INFO@THE2GB.COM", new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(60, y += 20));
            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(5, y += 20));
            e.Graphics.DrawString("DATE:" + DateTime.Now, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Order No:" + OrderId, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Order Type:" + dt.Ordertype, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Customer Receipt", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            //   if (dt.Ordertype == "Dine In")
            //    {
            e.Graphics.DrawString("Table : " + tableno, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));

            //    }
            //   if (dt.Ordertype == "Delivery")
            //   {
            ArrayList customer = reteievecustomer(OrderId);
            foreach (Detail c in customer)
            {
                e.Graphics.DrawString("Cust Name:" + c.cust_name, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(5, y += 20));
                e.Graphics.DrawString("Cust No:" + c.cust_phone, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(5, y += 20));
                e.Graphics.DrawString("Cust Address:" + c.address, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(5, y += 20));
                e.Graphics.DrawString("Rider:" + c.deliveryBoy_Name, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(5, y += 20));

            }
            // }

            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(5, y += 20));
            e.Graphics.DrawString("Order Details", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));

            e.Graphics.DrawString("Item Name", new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(5, y += 20));
            e.Graphics.DrawString("Price", new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(145, y));
            e.Graphics.DrawString("Quantity", new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(190, y));
            e.Graphics.DrawString("Total", new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(230, y));
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT t_iName as ItemName,t_iprice as UnitPrice,t_iqty as Quantity,t_inetprice as TotalPrice FROM temp_orderitems where t_Oid = '" + OrderId + "';", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        y += 20;
                        e.Graphics.DrawString((reader["ItemName"].ToString()), new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(5, y));
                        e.Graphics.DrawString((reader["UnitPrice"].ToString()), new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(145, y));
                        e.Graphics.DrawString((reader["Quantity"].ToString()), new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(190, y));
                        e.Graphics.DrawString((reader["TotalPrice"].ToString()), new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(230, y));
                    }
                }
                connection.Close();
            }
            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(5, y += 20));
            e.Graphics.DrawString("Payment Details", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));

            e.Graphics.DrawString("SubTotal:", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
            e.Graphics.DrawString(textBoxsubtotal.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
            if (checkBoxtax.Checked)
            {
                e.Graphics.DrawString("Tax: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxtax.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
                e.Graphics.DrawString("Total: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxtotal.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));

            }
            if (textBoxdiscount.Text != "0.0")
            {
                e.Graphics.DrawString("Discount: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxdiscount.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));

            }
            if (checkBoxservicecharges.Checked)
            {
                e.Graphics.DrawString("Service Charges: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxserCharge.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));

            }
            e.Graphics.DrawString("Net Bill: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
            e.Graphics.DrawString(textBoxNetBill.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
            if (checkBoxmultipayment.Checked )
            {
                e.Graphics.DrawString("Payment Method: Multi Payment ", new Font("monospaced sans serif", 12, FontStyle.Bold), Brushes.Black, new Point(40, y += 20));

                e.Graphics.DrawString("Cash payment: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxcashpay.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
                e.Graphics.DrawString("Card Payment: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxcardpay.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
                e.Graphics.DrawString("Return: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxreturn.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
            }
            if (checkBoxcard.Checked )
            {
                e.Graphics.DrawString("Payment Method: Card Payment ", new Font("monospaced sans serif", 12, FontStyle.Bold), Brushes.Black, new Point(40, y += 20));

                e.Graphics.DrawString("Card Payment: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxcreditcardpayment.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
                e.Graphics.DrawString("Return: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxreturn.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
            }
            if (checkBoxcash.Checked )
            {
                e.Graphics.DrawString("Payment Method: Cash Payment ", new Font("monospaced sans serif", 12, FontStyle.Bold), Brushes.Black, new Point(40, y += 20));

                e.Graphics.DrawString("Cash Payment: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxcashpaying.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
                e.Graphics.DrawString("Return: ", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(textBoxreturn.Text, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
            }
            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(5, y += 20));
            e.Graphics.DrawString("(ALL PRICES ARE INCLUSIVE OF 13% SST)", new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(30, y += 20));
            e.Graphics.DrawString(" !!! QUALITY IS OUR RECIPE !!! ", new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(60, y += 20));
            e.Graphics.DrawString(" Powered By Innovative Ducks", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(60, y += 20));
            e.Graphics.DrawString(" +92 337 3161567   www.innovativeducks.com", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));

        }

        private void checkBoxcash_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxcash.Checked)
            {
                checkBoxcard.Checked = false;
                checkBoxmultipayment.Checked = false;
                textBoxcashpaying.Enabled = true;
            }
            else
            {
                textBoxcashpaying.Enabled = false;
                textBoxcashpaying.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBoxcash.Checked)
            {
                textBoxcashpaying.Text += "1";
            }
          
            else if (checkBoxcard.Checked)
            {
                textBoxcreditcardpayment.Text += "1";
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBoxcash.Checked)
            {
                textBoxcashpaying.Text += "2";
            }
            
            else if (checkBoxcard.Checked)
            {
                textBoxcreditcardpayment.Text += "4";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBoxcash.Checked)
            {
                textBoxcashpaying.Text += "3";
            }
           
            else if (checkBoxcard.Checked)
            {
                textBoxcreditcardpayment.Text += "3";
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (checkBoxcash.Checked)
            {
                textBoxcashpaying.Text += "4";
            }
         
            else if (checkBoxcard.Checked)
            {
                textBoxcreditcardpayment.Text += "4";
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (checkBoxcash.Checked)
            {
                textBoxcashpaying.Text += "5";
            }
           
            else if (checkBoxcard.Checked)
            {
                textBoxcreditcardpayment.Text += "5";
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (checkBoxcash.Checked)
            {
                textBoxcashpaying.Text += "6";
            }
      
            else if (checkBoxcard.Checked)
            {
                textBoxcreditcardpayment.Text += "6";
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (checkBoxcash.Checked)
            {
                textBoxcashpaying.Text += "7";
            }
       
            else if (checkBoxcard.Checked)
            {
                textBoxcreditcardpayment.Text += "7";
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (checkBoxcash.Checked)
            {
                textBoxcashpaying.Text += "8";
            }
          
            else if (checkBoxcard.Checked)
            {
                textBoxcreditcardpayment.Text += "8";
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (checkBoxcash.Checked)
            {
                textBoxcashpaying.Text += "9";
            }
            
            else if (checkBoxcard.Checked)
            {
                textBoxcreditcardpayment.Text += "9";
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (checkBoxcash.Checked)
            {
                textBoxcashpaying.Text += "0";
            }
         
            else if (checkBoxcard.Checked)
            {
                textBoxcreditcardpayment.Text += "0";
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (checkBoxcash.Checked)
            {
                textBoxcashpaying.Text += "00";
            }
           
            else if (checkBoxcard.Checked)
            {
                textBoxcreditcardpayment.Text += "00";
            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (checkBoxcash.Checked)
            {
                textBoxcashpaying.Text += "500";
            }
       
            else if (checkBoxcard.Checked)
            {
                textBoxcreditcardpayment.Text += "500";
            }

        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (checkBoxcash.Checked)
            {
                textBoxcashpaying.Text += "1000";
            }
          
            else if (checkBoxcard.Checked)
            {
                textBoxcreditcardpayment.Text += "1000";
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (checkBoxcash.Checked)
            {
                textBoxcashpaying.Text += "5000";
            }
           
            else if (checkBoxcard.Checked)
            {
                textBoxcreditcardpayment.Text += "5000";
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (checkBoxcash.Checked)
            {

                if (textBoxcashpaying.TextLength > 0)
                {
                    textBoxcashpaying.Text = textBoxcashpaying.Text.Substring(0, (textBoxcashpaying.TextLength - 1));
                }
            }
            else if (checkBoxmultipayment.Checked)
            {
                 if (textBoxcashpay.Focused==true)
                {
                    if (textBoxcashpay.TextLength > 0)
                    {
                        textBoxcashpay.Text = textBoxcashpay.Text.Substring(0, (textBoxcashpay.TextLength - 1));
                    }
                }
                else
                {

                    if (textBoxcardpay.TextLength > 0)
                    {
                        textBoxcardpay.Text = textBoxcardpay.Text.Substring(0, (textBoxcardpay.TextLength - 1));
                    }

                }

            }
            else if (checkBoxcard.Checked)
            {
                if (textBoxcreditcardpayment.TextLength > 0)
                {
                    textBoxcreditcardpayment.Text = textBoxcreditcardpayment.Text.Substring(0, (textBoxcreditcardpayment.TextLength - 1));
                }
            }
        }

        private void textBoxcashpaying_TextChanged(object sender, EventArgs e)
        {
            if (textBoxcashpaying.TextLength > 0)
            {
                textBoxreturn.Text = (Int16.Parse(textBoxcashpaying.Text) - float.Parse(textBoxNetBill.Text)).ToString();
            }
            else
            {
                textBoxreturn.Text = "0";

            }
        }

        private void textBoxcreditcardpayment_TextChanged(object sender, EventArgs e)
        {
            if (textBoxcreditcardpayment.TextLength > 0 )
            {
                textBoxreturn.Text = (Int16.Parse(textBoxcreditcardpayment.Text) - float.Parse(textBoxNetBill.Text)).ToString();
            }
            else
            {
                textBoxreturn.Text = "0";
            }
        }

        private void textBoxcashpay_TextChanged(object sender, EventArgs e)
        {
            if (textBoxcashpay.TextLength > 0 && textBoxcardpay.TextLength > 0)
            {
                textBoxreturn.Text = (Int16.Parse(textBoxcashpay.Text) + Int16.Parse(textBoxcardpay.Text) - float.Parse(textBoxNetBill.Text)).ToString();

            }
            else if (textBoxcashpay.TextLength > 0 && textBoxcardpay.TextLength == 0)
            {
                textBoxreturn.Text = (Int16.Parse(textBoxcashpay.Text) - float.Parse(textBoxNetBill.Text)).ToString();
            }
            else if (textBoxcashpay.TextLength == 0 && textBoxcardpay.TextLength == 0)
                textBoxreturn.Text = "0";
        }

        private void textBoxcardpay_TextChanged(object sender, EventArgs e)
        {
            if (textBoxcashpay.TextLength > 0 && textBoxcardpay.TextLength > 0)
            {
                textBoxreturn.Text = (Int16.Parse(textBoxcashpay.Text) + Int16.Parse(textBoxcardpay.Text) - float.Parse(textBoxNetBill.Text)).ToString();

            }
            else if (textBoxcashpay.TextLength == 0 && textBoxcardpay.TextLength > 0)
            {
                textBoxreturn.Text = (Int64.Parse(textBoxcardpay.Text) - float.Parse(textBoxNetBill.Text)).ToString();
            }
            else if (textBoxcashpay.TextLength == 0 && textBoxcardpay.TextLength == 0)
                textBoxreturn.Text = "0";
        }

        private void textBoxcashpay_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxcashpay.Focus();
        }

        private void textBoxcardpay_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxcardpay.Focus();
        }

        private void buttonCancelOrder_Click(object sender, EventArgs e)
        {
            SecretKey sk = new SecretKey();
            sk.ShowDialog();
            Connection conn = new Connection();
            if (sk.textBox != "")
            {
                if (conn.checkSecretKey(Int16.Parse(sk.textBox)) > 0)
                {
                    if(OrderId!=0)
                    {
                        if(conn.InsertCancelOrder(OrderId))
                        {
                            conn.updatetablestats(tableno);
                            conn.insertcancelOrderItems(OrderId);
                            conn.delorderItems(OrderId);
                            conn.delorders(OrderId);
                            dataGridViewOrderItems.DataSource = null;
                            clearall();
                        }
                    }
                }
            }

        }

        private void buttoncrep_Click(object sender, EventArgs e)
        {
            if (dt.user_privelage == "Manager")
            {
                CancelOrders co = new CancelOrders();
                co.ShowDialog();
            }
            else
                MessageBox.Show("user not have privilege");
        }

        private void buttonregreport_Click(object sender, EventArgs e)
        {
            if(dt.user_privelage=="Manager")
            {
                registerreporting regrep = new registerreporting();
                regrep.ShowDialog();

            }
            else
            {
                MessageBox.Show("user not have privilege");
            }
        }

        
    }
}
