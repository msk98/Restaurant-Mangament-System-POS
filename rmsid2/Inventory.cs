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
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
        }
        string ConnectionString = "Data Source=DESKTOP-C27B91F;Initial Catalog=rmsid;Integrated Security=True";
        int inven_id = 0;
        private void Inventory_Load(object sender, EventArgs e)
        {
            getinv();
        }
        public void getinv()
        {
            Connection conn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM inventory", ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "inventory");
            InventorydataGridView.DataSource = ds.Tables["inventory"].DefaultView;
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            if (textBoxname.Text != "" && textBoxqty.Text !="")
            {
                  if (conn.insertinven(textBoxname.Text,Int16.Parse(textBoxqty.Text)))
               
                clear();
                getinv();
            }
            else
            {
                MessageBox.Show("please Fill all fields");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxname.Text != "" && textBoxqty.Text != "")
            {
                if (inven_id != 0)
                {
                    Connection conn = new Connection();
                    if (conn.updateinven(inven_id, textBoxname.Text, Int16.Parse(textBoxqty.Text)))
                    {
                     //  MessageBox.Show("updated");
                    }
                    clear();
                    getinv();
                    inven_id = 0;
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textBoxname.Text != "" && textBoxqty.Text != "")
            {
                if (inven_id != 0)
                {
                    Connection conn = new Connection();
                    if (conn.delinven(inven_id))
                    {
                        //   MessageBox.Show("Deleted");
                    }
                    clear();
                    getinv();
                    inven_id = 0;
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
        public void clear()
        {
            textBoxname.Text = "";
            textBoxqty.Text = "";
        }

        private void InventextBox_TextChanged(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM inventory where Inven_Name like'" + InventextBox.Text+"%'", ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "inventory");
            InventorydataGridView.DataSource = ds.Tables["inventory"].DefaultView;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void InventorydataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //  settnullValue();
                DataGridViewRow row = InventorydataGridView.Rows[e.RowIndex];
                inven_id = Int16.Parse(row.Cells[0].Value.ToString());
                textBoxqty.Text = (row.Cells[2].Value.ToString());
                textBoxname.Text = row.Cells[1].Value.ToString();
               
            }
        }

        
    }
}
