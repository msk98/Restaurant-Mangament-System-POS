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
    public partial class Tables : Form
    {
        public Tables()
        {
            InitializeComponent();
        }
        string ConnectionString = "Server=DESKTOP-C27B91F,1433;Database=rmsid;User Id = saadkhan; Password=saad;  ";
        int table_id = 0;
        Connection conn = new Connection();
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            
            if (textBoxname.Text!="" && comboBoxtables.SelectedIndex!=-1)
            {
                if(conn.inserttables(textBoxname.Text, comboBoxtables.SelectedIndex))
                {
                    gettables();
                    clear();
                }
                else
                {
                    MessageBox.Show("Duplicate table Name");
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if(table_id!=0)
            {
                if (conn.updatetable(table_id,textBoxname.Text, comboBoxtables.SelectedIndex))
                {
                    gettables();
                    clear();
                }
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (table_id != 0)
            {
                if (conn.deltable(table_id))
                {
                    gettables();
                    clear();
                }
            }

        }

        private void Tables_Load(object sender, EventArgs e)
        {
            gettables();
        }
        public void gettables()
        {
            Connection conn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tables", ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "tables");
            TablesdataGridView.DataSource = ds.Tables["tables"].DefaultView;
        }

        private void TablesdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //  settnullValue();
                DataGridViewRow row = TablesdataGridView.Rows[e.RowIndex];
                table_id = Int16.Parse(row.Cells[0].Value.ToString());
                textBoxname.Text = row.Cells[1].Value.ToString();
                int checkk = Int16.Parse(row.Cells[2].Value.ToString());
                  comboBoxtables.SelectedIndex = checkk;
                         comboBoxtables.SelectedIndex = checkk;
            }
        }
        public void clear()
        {
            textBoxname.Text = "";
            comboBoxtables.SelectedIndex = -1;
            table_id = 0;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void tabletextBox_TextChanged(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tables where t_name like'" + tabletextBox.Text + "'%", ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "tables");
            TablesdataGridView.DataSource = ds.Tables["tables"].DefaultView;
        }
    }
}
