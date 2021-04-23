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
    public partial class Incredients : Form
    {
        public Incredients()
        {
            InitializeComponent();
        }
        string ConnectionString = "Server=DESKTOP-C27B91F,1433;Database=rmsid;User Id = saadkhan; Password=saad;  ";
        int ing_id = 0;
        Connection conn = new Connection();
        private void Incredients_Load(object sender, EventArgs e)
        {
            getinc();
            getinven();
            getcat();
            getprod();
            clearall();
        }
        public void clearall()
        {
            comboBoxIncredients.SelectedIndex = -1;
            comboBoxproduct.SelectedIndex = -1;
            CatcomboBox.SelectedIndex = -1;
            textBoxIncredient.Text = "";
        }
        public void getinc()
        {
            Connection conn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("select incr.inc_id as incredientID, p.p_name as productName,c.C_name as Cat_Name,inven.Inven_Name as ItemName,incr.qty as quantity from products p inner join incredients incr on incr.p_id=p.p_id inner join categories c on c.C_id=incr.C_id inner join inventory inven on inven.Inven_id=incr.Inven_id;", ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "Incredients");
            IncredientdataGridView.DataSource = ds.Tables["Incredients"].DefaultView;
        }
        public void getinven()
        {
            SqlConnection sqlcon = new SqlConnection(ConnectionString);
            string sqlquery = "select * from inventory ;";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
            sqlcon.Open();
            SqlDataAdapter dr = new SqlDataAdapter(sqlcom);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            comboBoxIncredients.DataSource = dt;
            comboBoxIncredients.DisplayMember = "Inven_Name";
            comboBoxIncredients.ValueMember = "Inven_id";
            sqlcon.Close();
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
            CatcomboBox.DataSource = dt;
            CatcomboBox.DisplayMember = "C_name";
            CatcomboBox.ValueMember = "C_id";
            sqlcon.Close();
        }
        public void getprod()
        {
            SqlConnection sqlcon = new SqlConnection(ConnectionString);
            string sqlquery = "select * from products ";
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
            SqlDataAdapter dr = new SqlDataAdapter(sqlcom);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            comboBoxproduct.DataSource = dt;
            comboBoxproduct.DisplayMember = "p_name";
            comboBoxproduct.ValueMember = "p_id";
            sqlcon.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxIncredients.SelectedIndex != -1 && CatcomboBox.SelectedIndex != -1 && comboBoxproduct.SelectedIndex != -1 && textBoxIncredient.Text != "")
            {

                if (conn.insertingred(Int16.Parse(comboBoxIncredients.SelectedValue.ToString()), Int16.Parse(CatcomboBox.SelectedValue.ToString()), Int16.Parse(comboBoxproduct.SelectedValue.ToString()), Int16.Parse(textBoxIncredient.Text)))
                {
                    getinc();
                    clearall();

                }

            }
            else
                MessageBox.Show("fill the fields");
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (comboBoxIncredients.SelectedIndex != -1 && CatcomboBox.SelectedIndex != -1 && comboBoxproduct.SelectedIndex != -1 && textBoxIncredient.Text != "")
            {
                if (ing_id != 0)
                {
                    if (conn.updateingred(Int16.Parse(comboBoxIncredients.SelectedValue.ToString()), Int16.Parse(comboBoxIncredients.SelectedValue.ToString()), Int16.Parse(CatcomboBox.SelectedValue.ToString()), Int16.Parse(comboBoxproduct.SelectedValue.ToString()), Int16.Parse(textBoxIncredient.Text)))
                    {
                        getinc();
                        clearall();
                    }

                }
            }
            else
                MessageBox.Show("fill the fields");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (comboBoxIncredients.SelectedIndex != -1 && CatcomboBox.SelectedIndex != -1 && comboBoxproduct.SelectedIndex != -1 && textBoxIncredient.Text != "")
            {
                if (ing_id != 0)
                {
                    if (conn.delinc(ing_id))
                    {
                        getinc();
                        clearall();
                    }
                }
            }
            else
                MessageBox.Show("fill the fields");
        }

      
     
        private void CatcomboBox_DropDownClosed(object sender, EventArgs e)
        {

       if (CatcomboBox.SelectedIndex != -1)
               { getprod();
                  }
        }

        private void IncredientdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
               DataGridViewRow row = IncredientdataGridView.Rows[e.RowIndex];
                ing_id = Int16.Parse(row.Cells[0].Value.ToString());
                int index = comboBoxIncredients.FindString(row.Cells[3].Value.ToString());
                comboBoxIncredients.SelectedIndex = index;
                index = comboBoxproduct.FindString(row.Cells[1].Value.ToString());
                comboBoxproduct.SelectedIndex = index;
                index = CatcomboBox.FindString(row.Cells[2].Value.ToString());
                CatcomboBox.SelectedIndex = index;
                textBoxIncredient.Text = row.Cells[4].Value.ToString();
            
            }

        }
        public string getct(int catid)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            string sqlquery = "select *  from categories where C_id='" + catid + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlquery, conn);

            SqlDataReader dr = cmd.ExecuteReader();
            string xyz = "";
            while (dr.Read())
            {
                xyz = (dr["C_name"].ToString());

            }
            conn.Close();
            return xyz;
        }
        public string getprod(int p_id)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            string sqlquery = "select *  from products where p_id='" + p_id + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlquery, conn);

            SqlDataReader dr = cmd.ExecuteReader();
            string xyz = "";
            while (dr.Read())
            {
                xyz = (dr["p_name"].ToString());

            }
            MessageBox.Show(xyz);

            conn.Close();
            return xyz;
        }

     

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cattextBox_TextChanged(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products where p_name like'%" + cattextBox.Text + "%'", ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "Products");
            IncredientdataGridView.DataSource = ds.Tables["Products"].DefaultView;
        }

        private void buttondeals_Click(object sender, EventArgs e)
        {
            Deals deal = new Deals();
            deal.ShowDialog();
        }
    }
}
