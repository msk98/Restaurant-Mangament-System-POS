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
        string ConnectionString = "Data Source=DESKTOP-C27B91F;Initial Catalog=rmsid;Integrated Security=True";
        int ing_id = 0;
        Connection conn = new Connection();
        private void Incredients_Load(object sender, EventArgs e)
        {
            getinc();
            getinven();
            getcat();
        }
        public void getinc()
        {
            Connection conn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM incredients", ConnectionString);
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
            string sqlquery = "select * from products where C_id='" + Int16.Parse(CatcomboBox.SelectedValue.ToString()) + "'";
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
                    clear();
                }

            }
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
                        clear();
                    }

                }
            }
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
                        clear();
                    }
                }
            }
        }

      
        public void clear()
            {
           
            comboBoxIncredients.SelectedIndex = -1;
            comboBoxproduct.DataSource = null;
            CatcomboBox.SelectedIndex = -1;
            comboBoxIncredients.SelectedIndex = -1;


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
                SqlConnection conn = new SqlConnection(ConnectionString);
                string sqlquery = "select *  from inventory where Inven_id='" + Int16.Parse(row.Cells[1].Value.ToString()) + "'";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlquery, conn);

                SqlDataReader dr = cmd.ExecuteReader();
                string xyz = "";
                while (dr.Read())
                {
                    xyz = (dr["Inven_Name"].ToString());

                }
                
                    int index = comboBoxIncredients.FindString(xyz);
                comboBoxIncredients.SelectedIndex = index;
                conn.Close();
                xyz = getct(Int16.Parse(row.Cells[2].Value.ToString()));

                index = CatcomboBox.FindString(xyz);
                CatcomboBox.SelectedIndex = index;
                getprod();
                xyz = getprod(Int16.Parse(row.Cells[3].Value.ToString()));
                index = comboBoxproduct.FindString(xyz);
                comboBoxproduct.SelectedIndex = index;
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

        private void cattextBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
