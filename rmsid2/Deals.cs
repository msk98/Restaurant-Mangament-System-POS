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
    public partial class Deals : Form
    {
        public Deals()
        {
            InitializeComponent();
            getDeals();
            comboBoxDealsP.SelectedIndex = -1;
            getproducts();
            getdealitems();
        }

        string ConnectionString = "Server=DESKTOP-C27B91F,1433;Database=rmsid;User Id = saadkhan; Password=saad; ";

        public void getDeals()
        {
            SqlConnection sqlcon = new SqlConnection(ConnectionString);
            string sqlquery = "select * from products p inner join categories cat on p.C_id=cat.C_id where cat.C_name like 'deal%'; ;";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
            sqlcon.Open();
            SqlDataAdapter dr = new SqlDataAdapter(sqlcom);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            comboBoxDealsP.DataSource = dt;
            comboBoxDealsP.DisplayMember = "p_name";
            comboBoxDealsP.ValueMember = "p_id";
            sqlcon.Close();
        }
        DataTable dt = new DataTable();

        public void getproducts()
        {          
            SqlConnection sqlcon = new SqlConnection(ConnectionString);
            sqlcon.Open();
            string sqlquery = "select * from products where p_name not like 'deal%';";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
            SqlDataAdapter dr = new SqlDataAdapter(sqlcom);
            DataSet ds = new DataSet();
            dr.Fill(ds,"products");
            dt = ds.Tables["products"];
            sqlcon.Close();
            for(int i=0;i<dt.Rows.Count;i++)
            {
                string[] row = { dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[1].ToString(), dt.Rows[i].ItemArray[2].ToString() };
                ListViewItem item = new ListViewItem(row);
                listViewproducts.Items.Add(item);             
            }
        }
       
        private void listViewproducts_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxname.Text=listViewproducts.SelectedItems[0].SubItems[2].Text;
        }

        private void buttonadd_Click(object sender, EventArgs e)
        {
            if(comboBoxDealsP.SelectedIndex!=-1 && textBoxname.Text!="" && listViewproducts.SelectedItems.Count>0)
            {
                Connection conn = new Connection();
               if(conn.Insertdealitem(Int16.Parse(listViewproducts.SelectedItems[0].SubItems[0].Text), Int16.Parse(listViewproducts.SelectedItems[0].SubItems[1].Text),Int16.Parse(comboBoxDealsP.SelectedValue.ToString()), Convert.ToInt32(numericUpDownqty.Value)))
                {
                    clear();
                    getdealitems();
                }
             
            }
            //Insertdealitem()
        }
        public void getdealitems()
        {
            SqlConnection sqlcon = new SqlConnection(ConnectionString);
            sqlcon.Open();
            string sqlquery = "select p.p_name as ProductName,c.c_name CatName,d.p_id as pId,d.p_cat_id cat_id,d.deal_id,d.qty from DealsDetail d inner join products p on p.p_id=d.deal_id inner join categories c on c.C_id=d.p_cat_id;";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcom);
            DataSet ds = new DataSet();
            da.Fill(ds, "deals");
            dataGridViewdeals.DataSource = ds.Tables["deals"].DefaultView;
        }

        private void buttonclose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        int dealid = 0;
        int productId = 0;
        private void dataGridViewdeals_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //  settnullValue();
                DataGridViewRow row = dataGridViewdeals.Rows[e.RowIndex];
                dealid = Int16.Parse(row.Cells[4].Value.ToString());
                productId = Int16.Parse(row.Cells[2].Value.ToString());
                numericUpDownqty.Value = Int16.Parse(row.Cells[5].Value.ToString());
                textBoxname.Text = row.Cells[1].Value.ToString();
            }
        }

        private void buttonupdate_Click(object sender, EventArgs e)
        {
            if(dealid!=0 && productId!=0)
            {
                Connection conn = new Connection();
                conn.updatedealitem(dealid, Convert.ToInt32(numericUpDownqty.Value), productId);
                clear();
                getdealitems();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dealid != 0 && productId != 0)
            {
                Connection conn = new Connection();
                conn.deletedealitem(dealid, productId);
                clear();
                getdealitems();
            }
        }
        public void clear()
        {
            textBoxname.Text = "";
            listViewproducts.SelectedItems.Clear();
            comboBoxDealsP.SelectedIndex = -1;
            numericUpDownqty.Value = 1;
            productId = 0;
            dealid = 0;
        }
    }
}
