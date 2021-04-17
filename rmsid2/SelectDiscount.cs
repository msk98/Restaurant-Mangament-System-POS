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
    public partial class SelectDiscount : Form
    {
        public SelectDiscount(float totalamount,int OrderId)
        {

            InitializeComponent();
            dt.totalamnt = totalamount;
            dt.orderid = OrderId;
        }
        Detail dt = new Detail();
        string ConnectionString = "Server=DESKTOP-C27B91F,1433;Database=rmsid;User Id = saadkhan; Password=saad;  ";
        int count = 0;
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void SelectDiscount_Load(object sender, EventArgs e)
        {
            comboBoxpromo.Enabled = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBoxcash.Enabled = true ;
            getdiscounts();
            comboBoxpromo.SelectedIndex = -1;
            count = 1;
            textBoxTotalPrice.Text = (dt.totalamnt).ToString();
        }

        private void radioButtonpercentage_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            groupBox1.Enabled = true;
            groupBoxcash.Enabled = false;
            clear();
        }

        public void clear()
        {
            textBoxDiscountPrice.Text = "";
            textBoxdisamnt.Text = "";
            textBoxpercen.Text = "";
            comboBoxpromo.SelectedIndex = -1;
        }
        private void radioButtoncash_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBoxcash.Enabled = true;
            clear();
        }

        private void radioButtonCode_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            groupBoxcash.Enabled = false;
            comboBoxpromo.Enabled = true;
            clear();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            conn.deldiscountamnt(dt.orderid);
            if ((radioButtoncash.Checked || radioButtonCode.Checked || radioButtonpercentage.Checked) && textBoxDiscountPrice.Text!="")
            {
                if (radioButtoncash.Checked)
                    conn.insertdisamnt(dt.orderid, float.Parse(textBoxDiscountPrice.Text), "Cash Discount");
                else if (radioButtonpercentage.Checked)
                    conn.insertdisamnt(dt.orderid, float.Parse(textBoxDiscountPrice.Text), "Percentage Discount");
                else
                    conn.insertdisamnt(dt.orderid, float.Parse(textBoxDiscountPrice.Text), dt.DiscountType);
            }
          
            this.Close();
        }
        public void getdiscounts()
        {
            SqlConnection sqlcon = new SqlConnection(ConnectionString);
            string sqlquery = "select * from discounts ;";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
            sqlcon.Open();
            SqlDataAdapter dr = new SqlDataAdapter(sqlcom);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            comboBoxpromo.DataSource = dt;
            comboBoxpromo.DisplayMember = "discount_name";
            comboBoxpromo.ValueMember = "discount_id";
            sqlcon.Close();
         }

       

       
        public string afterdiscount
        {
            get { return textBoxprice.Text; }
            set { this.Text = textBoxprice.Text; }

        }
        public string discountamnt
        {
            get { return textBoxDiscountPrice.Text; }
            set { this.Text = textBoxDiscountPrice.Text; }

        }
        private void buttoncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxdisamnt_TextChanged(object sender, EventArgs e)
        {
            if(textBoxdisamnt.Text.Length>0)
            {
                textBoxDiscountPrice.Text = (textBoxdisamnt.Text).ToString();
                textBoxprice.Text = (float.Parse(textBoxTotalPrice.Text) - float.Parse(textBoxDiscountPrice.Text)).ToString();
            }
        }

        private void textBoxpercen_TextChanged(object sender, EventArgs e)
        {
            if (textBoxpercen.Text.Length > 0)
            {
                textBoxDiscountPrice.Text = (dt.totalamnt * (float.Parse(textBoxpercen.Text)/100.0)).ToString();
                textBoxprice.Text = (float.Parse(textBoxTotalPrice.Text) -(dt.totalamnt * (float.Parse(textBoxpercen.Text) / 100.0))).ToString();
            }
        }

        private void comboBoxpromo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int disc = 0;
            if (comboBoxpromo.SelectedIndex != -1 && count != 0)
            {

                SqlConnection conn = new SqlConnection(ConnectionString);
                string sqlquery = "select discount_percentage,discount_name from discounts where discount_id=@dis_id";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlquery, conn);
                cmd.Parameters.AddWithValue("@dis_id", Int16.Parse(comboBoxpromo.SelectedValue.ToString()));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    disc = Int16.Parse(dr["discount_percentage"].ToString());
                    dt.DiscountType = (dr["discount_name"].ToString());

                }
                textBoxDiscountPrice.Text = (dt.totalamnt * disc / 100.0).ToString();
                textBoxprice.Text = (float.Parse(textBoxTotalPrice.Text) - (dt.totalamnt * disc / 100.0)).ToString();
                conn.Close();
            }
        }
    }
}
