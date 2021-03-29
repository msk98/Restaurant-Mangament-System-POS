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
        public Dashboard()
        {
            InitializeComponent();
        }
        string ConnectionString = "Data Source=DESKTOP-C27B91F;Initial Catalog=rmsid;Integrated Security=True";

        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

        }

        private void menuItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products p = new Products();
            p.Show();
        }

        private void incredientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Incredients inc = new Incredients();
            inc.Show();
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            categories cat = new categories();
            cat.Show();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory inven = new Inventory();
            inven.Show();
        }

       

        private void buttonDelivery_Click(object sender, EventArgs e)
        {
            
          
        }

        private void buttonTakeAway_Click(object sender, EventArgs e)
        {
            Order ord = new Order("Take Away","none");
            ord.ShowDialog();
        }

        private void timerfunc_Tick(object sender, EventArgs e)
        {
            getOrders();
        }
        public void getOrders()
        {
            Connection conn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM temp_orders", ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "temp_orders");
            dataGridViewOrderlist.DataSource = ds.Tables["temp_orders"].DefaultView;
        }

        private void dataGridViewOrderlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //  settnullValue();
                DataGridViewRow row = dataGridViewOrderlist.Rows[e.RowIndex];
             int   OrderId  = Int16.Parse(row.Cells[0].Value.ToString());
                Connection conn = new Connection();
               SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM temp_orderitems where t_Oid='" + OrderId + "'", ConnectionString);
                     DataSet ds = new DataSet();
                da.Fill(ds, "temp_orderitems");
                dataGridViewOrderItems.DataSource = ds.Tables["temp_orderitems"].DefaultView;

            }
        }
    }
}
