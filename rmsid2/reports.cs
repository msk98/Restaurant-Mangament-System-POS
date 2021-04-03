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
    public partial class reports : Form
    {
        public reports()
        {
            InitializeComponent();
        }
        string ConnectionString = "Data Source=DESKTOP-C27B91F;Initial Catalog=rmsid;Integrated Security=True";
        int OrderId = 0;
        DateTime StartDate;
        DateTime EndDate;
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT t_Oid as OrderId,t_netamnt as TotalAmount,t_ordertype as OrderType,Dateorder as Date FROM  Orders where Dateorder between '" + dateTimePickerFrom.Value+"' and '"+dateTimePickerto.Value+"'", ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "Orders");
            dataGridorders.DataSource = ds.Tables["Orders"].DefaultView;
            StartDate = dateTimePickerFrom.Value;
            EndDate = dateTimePickerto.Value;

        }

        private void dataGridorders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridorders.Rows[e.RowIndex];
                OrderId = Int16.Parse(row.Cells[0].Value.ToString());
         
                Connection conn = new Connection();
                SqlDataAdapter da = new SqlDataAdapter("SELECT t_iName as ItemName,t_iprice as UnitPrice,t_iqty as Quantity,t_inetprice as TotalPrice FROM OrderItems where t_Oid='" + OrderId + "'", ConnectionString);
                DataSet ds = new DataSet();
                da.Fill(ds, "orderitems");
                dataGridVieworderitems.DataSource = ds.Tables["orderitems"].DefaultView;

            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if(dataGridorders.Rows.Count>0)
            {
                printReportDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("prnm", 285, 900);
                printReportDocument.Print();
            //    this.Hide();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
        public int totalsale()
        {
            int sum = 0;
            for (int i = 0; i < dataGridorders.Rows.Count; ++i)
            {
                sum += Convert.ToInt16(dataGridorders.Rows[i].Cells[1].Value);
            }
            return sum;
        }

      

       
        private void printReportDocument_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int y = 0;
            var bmp = new Bitmap(rmsid2.Properties.Resources.logo, new Size(180, 70));
            e.Graphics.DrawImage(bmp, new Point(50, y));
            //  e.Graphics.DrawImage(bmp, new Point(50, y));
            //  e.Graphics.DrawString("2GB", new Font("monospaced sans serif", 38, FontStyle.Bold), Brushes.Black, new Point(50, y));
            e.Graphics.DrawString("PLOT GPC SHOP #1 GULSHAN E IQBAL BLOCK 4", new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(5, y += 80));
            e.Graphics.DrawString(" (03)-111-888-242", new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(60, y += 20));
            e.Graphics.DrawString(" SNTN#S6601547-2", new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(60, y += 20));
            e.Graphics.DrawString(" INFO@THE2GB.COM", new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(60, y += 20));
            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));
            e.Graphics.DrawString("DATE From:" + StartDate, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Date To:" + EndDate, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));
            e.Graphics.DrawString("Order Report", new Font("monospaced sans serif", 12, FontStyle.Bold), Brushes.Black, new Point(100, y += 20));
            e.Graphics.DrawString("Order Id", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(5, y += 20));
            e.Graphics.DrawString("Total", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(55, y));
            e.Graphics.DrawString("OrderType", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
            e.Graphics.DrawString("DateTime", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(163, y));
            foreach (DataGridViewRow row in dataGridorders.Rows)
            {
                e.Graphics.DrawString(row.Cells[0].Value.ToString(), new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(5, y += 20));
                e.Graphics.DrawString(row.Cells[1].Value.ToString(), new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(55, y));
                e.Graphics.DrawString(row.Cells[2].Value.ToString(), new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
                e.Graphics.DrawString(row.Cells[3].Value.ToString(), new Font("monospaced sans serif", 7, FontStyle.Bold), Brushes.Black, new Point(163, y));

            }

            e.Graphics.DrawString("Total Sale: " + totalsale(), new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(5, y += 20));
            e.Graphics.DrawString("Total Orders: " + dataGridorders.Rows.Count, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));

        }

        private void printDocumentOrder_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int y = 0;
            var bmp = new Bitmap(rmsid2.Properties.Resources.logo, new Size(180, 70));
            e.Graphics.DrawImage(bmp, new Point(50, y));
            e.Graphics.DrawString("PLOT GPC SHOP #1 GULSHAN E IQBAL BLOCK 4", new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(5, y += 80));
            e.Graphics.DrawString(" (03)-111-888-242", new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(60, y += 20));
            e.Graphics.DrawString(" SNTN#S6601547-2", new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(60, y += 20));
            e.Graphics.DrawString(" INFO@THE2GB.COM", new Font("monospaced sans serif", 9, FontStyle.Regular), Brushes.Black, new Point(60, y += 20));
            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));
            e.Graphics.DrawString("Order Date: " + dataGridorders.SelectedRows[0].Cells[3].Value.ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Order Id: " + dataGridorders.SelectedRows[0].Cells[0].Value.ToString(), new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));
            e.Graphics.DrawString("Item-Name", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(5, y += 20));
            e.Graphics.DrawString("Price", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
            e.Graphics.DrawString("Qty", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(150, y));
            e.Graphics.DrawString("Amount", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(200, y));
            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT t_iName as ItemName,t_iprice as UnitPrice,t_iqty as Quantity,t_inetprice as TotalPrice FROM OrderItems where t_Oid = '" + Int16.Parse(dataGridorders.SelectedRows[0].Cells[0].Value.ToString()) + "';", connection);
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
            e.Graphics.DrawString(dataGridorders.SelectedRows[0].Cells[1].Value.ToString(), new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));

        }

        private void buttonprintselectedorders_Click(object sender, EventArgs e)
        {
            if (dataGridorders.SelectedRows.Count == 1)
            {
                printDocumentOrder.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("prnm", 285, 600);
                printDocumentOrder.Print();
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            SecretKey sk =new  SecretKey();
            sk.ShowDialog();
            Connection conn = new Connection();
            if(sk.textBox !="0")
            {
                if (conn.checkSecretKey(Int16.Parse(sk.textBox)) > 0)
                {
                    if (conn.deldateOrders(StartDate, EndDate))
                    {
                        MessageBox.Show("deleted");
                    }
                }
            }
         
            dataGridVieworderitems.Refresh();
            dataGridorders.Refresh();
        }
     
    }
}
