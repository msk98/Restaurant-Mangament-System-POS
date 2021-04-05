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
    public partial class categories : Form
    {
        public categories()
        {
            InitializeComponent();
        }
        string ConnectionString = "Data Source=DESKTOP-C27B91F;Initial Catalog=rmsid;Integrated Security=True";
        int cat_id = 0;
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            if (CatnametextBox.Text != "" )
            {
                

                    if (conn.insertcat(CatnametextBox.Text))
                    MessageBox.Show("Inserted");
                clearFunction();
                getcat();
            }
            else
            {
                MessageBox.Show("please Fill all fields");
            }
        }
        public void getcat()
        {
            Connection conn = new Connection();


            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM categories", ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "categories");
            CatdataGridView.DataSource = ds.Tables["categories"].DefaultView;
        }
        public void clearFunction()
        {
            CatnametextBox.Text = "";
            
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (CatnametextBox.Text != "")
            {
                if (cat_id != 0)
                {
                    Connection conn = new Connection();
                    if (conn.updatecat(cat_id, CatnametextBox.Text))
                    {
                        //    MessageBox.Show("updated");
                      

                    }
                    clearFunction();
                    getcat();
                    cat_id = 0;
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
            if (CatnametextBox.Text != "" )
            {
                if (cat_id != 0)
                {
                    Connection conn = new Connection();
                    if (conn.delcat(cat_id))
                    {
                        //   MessageBox.Show("Deleted");

                    }
                    clearFunction();
                    getcat();
                  
                    cat_id = 0;
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

        private void CatdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //  settnullValue();
                DataGridViewRow row = CatdataGridView.Rows[e.RowIndex];
                cat_id = Int16.Parse(row.Cells[0].Value.ToString());
                CatnametextBox.Text = row.Cells[1].Value.ToString();
             
              

            }
        }

        private void categories_Load(object sender, EventArgs e)
        {
            getcat();
        }

        private void cattextBox_TextChanged(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM categories where C_name like '%"+cattextBox.Text+"%' ", ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "categories");
            CatdataGridView.DataSource = ds.Tables["categories"].DefaultView;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
