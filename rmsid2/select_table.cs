using System;
using System.Collections;
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
    public partial class select_table : Form
    {
        public select_table()
        {
            InitializeComponent();
        }
        Detail dt = new Detail();
        public select_table(string ordertype)
        {
            InitializeComponent();
            dt.Ordertype = ordertype;
        }
        string ConnectionString = "Data Source=DESKTOP-C27B91F;Initial Catalog=rmsid;Integrated Security=True";
        int table_id = 0;
        Connection conn = new Connection();
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void gettable()
        {
            ArrayList Tables = RetrieveTables();

            foreach (Detail table in Tables)
            {
                Button btn = new Button();
                btn.Text = table.tablename;
                btn.Size = new System.Drawing.Size(100, 50);
                btn.ForeColor = Color.White;
                if (table.tableStatus == 0)
                { btn.BackColor = Color.Green; }
                else
                { btn.BackColor = Color.Red; }
                btn.Tag = table.tableid;
                tableflowLayoutPanel.Controls.Add(btn);
                 btn.Click += TableButtonClick;
            }
        }
        void TableButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tablename = btn.Text;
            Order ord = new Order("Dine In",tablename);
            this.Hide();
            ord.ShowDialog();
            

        }
            public ArrayList RetrieveTables()
        {
            ArrayList ProductsList = new ArrayList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Tables;", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int TableId = Int16.Parse((reader["t_id"].ToString()));
                        string t_name = (reader["t_name"].ToString());
                        int t_status = Int16.Parse((reader["t_status"].ToString()));

                        ProductsList.Add(new Detail() { tableid = TableId, tableStatus = t_status, tablename = t_name });
                    }
                }
                connection.Close();

                return ProductsList;
            }
        }

        private void select_table_Load(object sender, EventArgs e)
        {
            gettable();
        }
    }
}
