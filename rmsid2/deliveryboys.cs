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
    public partial class deliveryboys : Form
    {
        public deliveryboys()
        {
            InitializeComponent();
        }
        string ConnectionString = "Data Source=DESKTOP-C27B91F;Initial Catalog=rmsid;Integrated Security=True";
        int rider_id = 0;
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxname.Text != "" && textBoxphoneno.Text != "")
            {
                Connection conn = new Connection();
                conn.insertrider(textBoxname.Text, textBoxphoneno.Text);
                clear();
                getriders();
            }
            else
                MessageBox.Show("fill fields");
        }

        private void RidersdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //  settnullValue();
                DataGridViewRow row = RidersdataGridView.Rows[e.RowIndex];
                rider_id = Int16.Parse(row.Cells[0].Value.ToString());
                textBoxname.Text = (row.Cells[1].Value.ToString());
                textBoxphoneno.Text = row.Cells[2].Value.ToString();
            }
        }
        public void clear()
        {
            rider_id = 0;
            textBoxname.Text = "";
            textBoxphoneno.Text = "";
            RiderNametextBox.Text = "";
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxname.Text != "" && textBoxphoneno.Text != "" && rider_id != 0)
            {
                Connection conn = new Connection();
                conn.updaterider(rider_id, textBoxname.Text, textBoxphoneno.Text);
                clear();
                getriders();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textBoxname.Text != "" && textBoxphoneno.Text != "" && rider_id != 0)
            {
                Connection conn = new Connection();
                conn.deleterider(rider_id);
                clear();
                getriders();
            }
        }

        public void getriders()
        {
            Connection conn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DeliveryBoys where d_name like'" + RiderNametextBox.Text + "'%", ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "DeliveryBoys");
            RidersdataGridView.DataSource = ds.Tables["DeliveryBoys"].DefaultView;
        }
    }
}
