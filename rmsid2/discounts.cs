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
    public partial class disocunts : Form
    {
        public disocunts()
        {
            InitializeComponent();
        }
        string ConnectionString = "Server=DESKTOP-C27B91F,1433;Database=rmsid;User Id = saadkhan; Password=saad;  ";
        int disId = 0;
        private void textBoxdispercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            if(textBoxdisname.Text.Length>0 && textBoxdispercent.Text.Length>0)
            {
                conn.insertdiscounts(textBoxdisname.Text, Int16.Parse(textBoxdispercent.Text));
                clear();
                getdiscounts();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            if (disId != 0 && textBoxdisname.Text != "" && textBoxdispercent.Text != "")
            {
                conn.updatedis(disId, textBoxdisname.Text, Int16.Parse(textBoxdispercent.Text));
                clear();
                getdiscounts();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            if (disId != 0 )
            {
                conn.delDiss(disId);
                clear();
                getdiscounts();
            }
        }

        public void clear()
        {
            textBoxdisname.Text = "";
            textBoxdispercent.Text = "";
            disId = 0;
        }

        public void getdiscounts()
        {
            Connection conn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM discounts where discount_name like'" + textBoxdisname.Text + "%'", ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "discounts");
            discountsdataGridView.DataSource = ds.Tables["discounts"].DefaultView;
        }

        private void disnametextBox_TextChanged(object sender, EventArgs e)
        {
            getdiscounts();
        }

        private void disocunts_Load(object sender, EventArgs e)
        {
            getdiscounts();
        }

        private void discountsdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //  settnullValue();
                DataGridViewRow row = discountsdataGridView.Rows[e.RowIndex];
                disId = Int16.Parse(row.Cells[0].Value.ToString());
                textBoxdisname.Text = (row.Cells[1].Value.ToString());
                textBoxdispercent.Text = row.Cells[2].Value.ToString();

            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
