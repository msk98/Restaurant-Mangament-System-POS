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
    public partial class deliveryboy : Form
    {
        public deliveryboy(string ordertype,int custid,int userid)
        {
            InitializeComponent();
            dt.Ordertype = ordertype;
            dt.custid = custid;
            dt.userid = userid;
        }
        
        string ConnectionString = "Data Source=DESKTOP-C27B91F;Initial Catalog=rmsid;Integrated Security=True";
        Detail dt = new Detail();
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public ArrayList RetrieveDeliveryBoys()
        {
            ArrayList deliveryBoysList = new ArrayList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM DeliveryBoys;", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int deliverBoyId = Int16.Parse((reader["d_id"].ToString()));
                        string deliveryBoy_Name = (reader["d_name"].ToString());

                        deliveryBoysList.Add(new Detail() { deliverBoyId = deliverBoyId, deliveryBoy_Name = deliveryBoy_Name });
                    }
                }
                connection.Close();

                return deliveryBoysList;
            }
        }

        public void getemp()
        {
            ArrayList Boys = RetrieveDeliveryBoys();
            foreach (Detail boy in Boys)
            {
                Button btn = new Button();
                btn.Text = boy.deliveryBoy_Name;
                btn.Size = new System.Drawing.Size(100, 50);
                btn.ForeColor = Color.White;
                btn.BackColor = Color.Green;
                btn.Tag = boy.deliverBoyId;
                customerflowLayoutPanel.Controls.Add(btn);
             btn.Click += deliveryBoyButtonClick;
            }
        }
        void deliveryBoyButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int del_id = Convert.ToInt32(btn.Tag);
            Order ord = new Order("Delivery",dt.custid, del_id,"none",dt.userid);
            ord.ShowDialog();
            this.Hide();
        }

        private void deliveryboy_Load(object sender, EventArgs e)
        {
            getemp();
        }
    }
}
