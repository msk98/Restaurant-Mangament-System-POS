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
    public partial class CancelOrders : Form
    {
        public CancelOrders()
        {
            InitializeComponent();
        }
        string ConnectionString = "Server=DESKTOP-C27B91F,1433;Database=rmsid;User Id = saadkhan; Password=saad;  ";
        DateTime StartDate, EndDate;
        int OrderId = 0;
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (dataGridorders.Rows.Count > 0)
            {
                 printReportDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("prnm", 285, 900);
                printReportDocument.Print();
                //this.Hide();
            }
        }

        private void printReportDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
            e.Graphics.DrawString("--------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));
            e.Graphics.DrawString("DATE From:" + StartDate, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("Date To:" + EndDate, new Font("monospaced sans serif", 9, FontStyle.Bold), Brushes.Black, new Point(20, y += 20));
            e.Graphics.DrawString("---------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));
            e.Graphics.DrawString("Cancel Orders Report", new Font("monospaced sans serif", 12, FontStyle.Bold), Brushes.Black, new Point(100, y += 20));
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
            e.Graphics.DrawString("Net Amount: " + totalsale(), new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(5, y += 20));
            e.Graphics.DrawString("Total Cancel Orders: " + dataGridorders.Rows.Count, new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(100, y));
            e.Graphics.DrawString("---------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));

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

        private void dataGridorders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridorders.Rows[e.RowIndex];
                OrderId = Int16.Parse(row.Cells[0].Value.ToString());

                Connection conn = new Connection();
                SqlDataAdapter da = new SqlDataAdapter("SELECT t_iName as ItemName,t_iprice as UnitPrice,t_iqty as Quantity,t_inetprice as TotalPrice FROM cancelOrdersItems where t_Oid='" + OrderId + "'", ConnectionString);
                DataSet ds = new DataSet();
                da.Fill(ds, "Cancelorderitems");
                dataGridVieworderitems.DataSource = ds.Tables["Cancelorderitems"].DefaultView;

            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            SecretKey sk = new SecretKey();
            sk.ShowDialog();
            Connection conn = new Connection();
            if (sk.textBox != "0")
            {
                if (conn.checkSecretKey(Int16.Parse(sk.textBox)) > 0)
                {
                    if (conn.delcanceldateOrders(StartDate, EndDate))
                    {
                   //     delcanceldateOrders
                        MessageBox.Show("deleted");
                    }
                }
            }

            dataGridVieworderitems.Refresh();
            dataGridorders.Refresh();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT t_Oid as OrderId,t_netamnt as TotalAmount,t_ordertype as OrderType,cancelorder as CancelTime,Dateorder as dateOrder FROM  cancelOrders where Dateorder between '" + dateTimePickerFrom.Value + "' and '" + dateTimePickerto.Value + "'", ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "CancelOrders");
            dataGridorders.DataSource = ds.Tables["CancelOrders"].DefaultView;
            StartDate = dateTimePickerFrom.Value;
            EndDate = dateTimePickerto.Value;
        }
    }
}
