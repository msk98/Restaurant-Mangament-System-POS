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
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }
        string ConnectionString = "Data Source=DESKTOP-C27B91F;Initial Catalog=rmsid;Integrated Security=True";
        int p_id = 0;
        private void Products_Load(object sender, EventArgs e)
        {

            getcat();
            getprod();
        }
        public void getprod()
        {
            Connection conn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM products", ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "products");
            ProductsdataGridView.DataSource = ds.Tables["products"].DefaultView;
        }
        public void getcat()
        {
            SqlConnection sqlcon = new SqlConnection(ConnectionString);
            string sqlquery = "select * from categories ;";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
            sqlcon.Open();
            SqlDataAdapter dr = new SqlDataAdapter(sqlcom);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            catscomboBox.DataSource = dt;
            catscomboBox.DisplayMember = "C_name";
            catscomboBox.ValueMember = "C_id";
            sqlcon.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            if (PnametextBox.Text != "" && catscomboBox.SelectedIndex != -1 && prodPricetextBox.Text!="")
            {


                if (conn.insertprod(Int16.Parse(catscomboBox.SelectedValue.ToString()), PnametextBox.Text, Int16.Parse(prodPricetextBox.Text)))
                   MessageBox.Show("Inserted");
                clear();
            }
            else
            {
                MessageBox.Show("please Fill all fields");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (PnametextBox.Text != "" && catscomboBox.SelectedIndex != -1 && prodPricetextBox.Text != "")
            {

                if (p_id != 0)
                {
                    Connection conn = new Connection();
                    if (conn.updateprod(p_id, PnametextBox.Text, Int16.Parse(prodPricetextBox.Text),Int16.Parse(catscomboBox.SelectedValue.ToString())))
                    {
                      MessageBox.Show("updated");


                    }

                    clear();
              
                    p_id = 0;
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

            if (PnametextBox.Text != "" && catscomboBox.SelectedIndex != -1 && prodPricetextBox.Text != "")
            {

                if (p_id != 0)
                {
                    Connection conn = new Connection();
                    if (conn.delprod(p_id))
                    {
                        clear();
                      
                    }
                      p_id = 0;
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
            PnametextBox.Text = "";
            prodPricetextBox.Text = "";
            getcat();
            getprod();
        }

        private void ProductsdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //  settnullValue();
                DataGridViewRow row = ProductsdataGridView.Rows[e.RowIndex];
                p_id = Int16.Parse(row.Cells[0].Value.ToString());
                PnametextBox.Text = row.Cells[2].Value.ToString();
                prodPricetextBox.Text = (row.Cells[3].Value.ToString());
                SqlConnection conn = new SqlConnection(ConnectionString);
                string sqlquery = "select *  from categories where C_id='" + Int16.Parse(row.Cells[1].Value.ToString()) + "'";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlquery, conn);

                SqlDataReader dr = cmd.ExecuteReader();
                string xyz = "";
                while (dr.Read())
                {
                    xyz= (dr["C_name"].ToString());

                }
                int index = catscomboBox.FindString(xyz);
                catscomboBox.SelectedIndex = index;
                conn.Close();

            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ProdtextBox_TextChanged(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM products where p_name='"+ ProdtextBox.Text+"'", ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "products");
            ProductsdataGridView.DataSource = ds.Tables["products"].DefaultView;
        }
    }
}
