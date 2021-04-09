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
    public partial class CustHistory : Form
    {
        int t_id=0,order_id=0;
        string ConnectionString = "Server=DESKTOP-C27B91F,1433;Database=rmsid;User Id = saadkhan; Password=saad;  ";

        public CustHistory(int c_id)
        {
            InitializeComponent();
            t_id = c_id;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void getcusthistory()
        {
            Connection conn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("select ord.t_Oid as OrderId ,ord.t_netamnt as TotalAmount,cust.cus_id as customerid from Orders ord inner join customerOrders cust on ord.t_Oid = cust.Order_id and cust.cus_id = '"+t_id+"';   ", ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "customerorders");
            dataGridVieworders.DataSource = ds.Tables["customerorders"].DefaultView;
        }

        public void getcustdata()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM customer WHERE cust_id ='"+t_id+"';"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        customerName.Text = sdr["cust_name"].ToString();
                        custphone.Text = sdr["cust_phone"].ToString();
                        custaddress.Text = sdr["cust_address"].ToString();
                    }
                    con.Close();
                }
            }
        }

        private void CustHistory_Load(object sender, EventArgs e)
        {
            getcustdata();
            getcusthistory();
        }

        private void dataGridVieworders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //  settnullValue();
                DataGridViewRow row = dataGridVieworders.Rows[e.RowIndex];
                order_id = Int16.Parse(row.Cells[0].Value.ToString());
                Connection conn = new Connection();
                SqlDataAdapter da = new SqlDataAdapter("select * from OrderItems where  t_Oid = '" + order_id + "';   ", ConnectionString);
                DataSet ds = new DataSet();
                da.Fill(ds, "customerorders");
                dataGridVieworderitems.DataSource = ds.Tables["customerorders"].DefaultView;

            }
        }
    }
}
