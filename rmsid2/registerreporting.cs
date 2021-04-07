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
    public partial class registerreporting : Form
    {
        public registerreporting()
        {
            InitializeComponent();
        }
        string ConnectionString = "Data Source=DESKTOP-C27B91F;Initial Catalog=rmsid;Integrated Security=True";
        
        private void buttonclose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void getregisters()
        {
            Connection conn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("select op.userid as UserID,un.username as UserName,op.openregister as OpeningTime ,cr.closeregister as ClosingTime,op.Startamount as OpeningAmount from openregister op   join  closeregister cr on cr.startregisterid=op.registerid   join  users un on un.user_id=cr.userid and cr.userid=un.user_id;", ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "registers");
            dataGridregisterreport.DataSource = ds.Tables["registers"].DefaultView;

        }

        private void registerreporting_Load(object sender, EventArgs e)
        {
            getregisters();
        }

        private void dataGridregisterreport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridregisterreport.Rows[e.RowIndex];
                UserIDlabel.Text = (row.Cells[0].Value.ToString());
                labelusername.Text = (row.Cells[1].Value.ToString());
                labelopeningtime.Text = row.Cells[2].Value.ToString();
                labelclosetime.Text = row.Cells[3].Value.ToString();
                labelopeningamount.Text= row.Cells[4].Value.ToString();
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select op.userid as UserID,un.username as UserName,op.openregister as OpeningTime ,cr.closeregister as ClosingTime,op.Startamount as OpeningAmount  from openregister op   join  closeregister cr on cr.startregisterid=op.registerid   join  users un on un.user_id=cr.userid and cr.userid=un.user_id     where op.openregister between '" + dateTimePickerFrom.Value + "' and '" + dateTimePickerto.Value + "'", ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "registers");
            dataGridregisterreport.DataSource = ds.Tables["registers"].DefaultView;
          
        }
        public void clear()
        {
            UserIDlabel.Text = "";
            labelusername.Text = "";
            labelopeningtime.Text = "";
            labelclosetime.Text = "";
            labelopeningamount.Text = "";
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if(UserIDlabel.Text!="" && labelusername.Text!="" && labelopeningtime.Text!="" && labelclosetime.Text!="")
            {
                printRegisterDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("prnm", 285, 1000);
                printRegisterDocument.Print();
            }
        }

        private void printRegisterDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int y = 0;
            Connection conn = new Connection();
           
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
            e.Graphics.DrawString("Opening Time:" +labelopeningtime.Text, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Closing Time:" + labelclosetime.Text, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Closing Person:" + labelusername.Text, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Opening Amount:" + labelopeningamount.Text, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));
            e.Graphics.DrawString("Sale Summary", new Font("monospaced sans serif", 14, FontStyle.Bold), Brushes.Black, new Point(40, y += 20));
            ArrayList discounts = conn.retrievediscounts(DateTime.Parse(labelopeningtime.Text), DateTime.Parse(labelclosetime.Text), Int16.Parse(UserIDlabel.Text));
            int disc = 0;
            foreach (Detail discount in discounts)
            {
                e.Graphics.DrawString(discount.DiscountType, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
                disc += discount.DiscountAmount;
                e.Graphics.DrawString(discount.DiscountAmount.ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(150, y));
            }
            e.Graphics.DrawString("Taxes", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString(conn.retrievedtaxes(DateTime.Parse(labelopeningtime.Text), DateTime.Parse(labelclosetime.Text), Int16.Parse(UserIDlabel.Text)).ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(150, y));
            e.Graphics.DrawString("Extra Charges: ", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString(conn.calculatesercharge(DateTime.Parse(labelopeningtime.Text), DateTime.Parse(labelclosetime.Text), Int16.Parse(UserIDlabel.Text)).ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(150, y));
            e.Graphics.DrawString("Card payments: ", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString(conn.calculateCrtaxes(DateTime.Parse(labelopeningtime.Text), DateTime.Parse(labelclosetime.Text), Int16.Parse(UserIDlabel.Text)).ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(150, y));
            e.Graphics.DrawString("Total sales", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString(conn.calculatenetsale(DateTime.Parse(labelopeningtime.Text), DateTime.Parse(labelclosetime.Text), Int16.Parse(UserIDlabel.Text)).ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(150, y));
            e.Graphics.DrawString("Net sales(total+charges+tax+cr pay-discount)", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
            int NetSale = conn.calculatenetsale(DateTime.Parse(labelopeningtime.Text), DateTime.Parse(labelclosetime.Text), Int16.Parse(UserIDlabel.Text)) + conn.retrievedtaxes(DateTime.Parse(labelopeningtime.Text), DateTime.Parse(labelclosetime.Text), Int16.Parse(UserIDlabel.Text)) + conn.calculatesercharge(DateTime.Parse(labelopeningtime.Text), DateTime.Parse(labelclosetime.Text), Int16.Parse(UserIDlabel.Text)) - disc;
            e.Graphics.DrawString((NetSale).ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Cash In Hand(Netsale + Opening Amnt)", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString((NetSale + Int16.Parse(labelopeningamount.Text)).ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            //  e.Graphics.DrawString(conn.calculatenetsale(dt.startreg, DateTime.Now, dt.userid).ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(150, y));
            e.Graphics.DrawString("------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));
            e.Graphics.DrawString("Order Details", new Font("monospaced sans serif", 14, FontStyle.Bold), Brushes.Black, new Point(40, y += 20));
            e.Graphics.DrawString("OrderType", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
            e.Graphics.DrawString("Orders", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(80, y));
            e.Graphics.DrawString("Total Amount", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(120, y));
            ArrayList orderdetails = conn.retrievedOrders(DateTime.Parse(labelopeningtime.Text), DateTime.Parse(labelclosetime.Text), Int16.Parse(UserIDlabel.Text));
            foreach (Detail order in orderdetails)
            {
                e.Graphics.DrawString(order.OrderType.ToString(), new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(order.Orders.ToString(), new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(80, y));
                e.Graphics.DrawString(order.netsale.ToString(), new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(120, y));

            }
            ArrayList invendetails = conn.retrieveUsedInventory(DateTime.Parse(labelopeningtime.Text), DateTime.Parse(labelclosetime.Text), Int16.Parse(UserIDlabel.Text));
            e.Graphics.DrawString("Inventory Detail", new Font("monospaced sans serif", 14, FontStyle.Bold), Brushes.Black, new Point(40, y += 20));
            e.Graphics.DrawString("Inventory", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(10, y += 20));
            e.Graphics.DrawString("Quantity", new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(120, y));

            foreach (Detail Inventory in invendetails)
            {
                e.Graphics.DrawString(Inventory.invenname.ToString(), new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(10, y += 20));
                e.Graphics.DrawString(Inventory.invenqty.ToString(), new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(120, y));
            }
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));
            e.Graphics.DrawString("Products Details", new Font("monospaced sans serif", 14, FontStyle.Bold), Brushes.Black, new Point(40, y += 20));
            ArrayList productsdetail = conn.retrievedProducts(DateTime.Parse(labelopeningtime.Text), DateTime.Parse(labelclosetime.Text), Int16.Parse(UserIDlabel.Text));
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
    }
}
