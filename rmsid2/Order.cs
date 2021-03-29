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
    public partial class Order : Form
    {

        public Order()
        {
            InitializeComponent();
        }
        Detail det = new Detail();
        public Order(string ordertype,string tablename)
        {
            InitializeComponent();
            det.Ordertype = ordertype;
            det.table = tablename;
        }
        string ConnectionString = "Data Source=DESKTOP-C27B91F;Initial Catalog=rmsid;Integrated Security=True";
        int row;
        int sum;

        public ArrayList RetreiveAllCategoriesFromDatabase()
        {
            ArrayList CategoriesList = new ArrayList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM categories;", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        int CategoryID = Int16.Parse((reader["C_id"].ToString()));
                        string CategoryName = (reader["C_name"].ToString());
                        CategoriesList.Add(new Detail() { ID = CategoryID, Name = CategoryName });
                    }
                }
                connection.Close();

                return CategoriesList;
            }
        }

      
        private void Order_Load(object sender, EventArgs e)
        {
            ArrayList AllCategories = RetreiveAllCategoriesFromDatabase();

            foreach (Detail Category in AllCategories)
            {
                Button btn = new Button();
                btn.Text = Category.Name;
                btn.Size = new System.Drawing.Size(60, 50);
                btn.ForeColor = Color.Black;
                btn.Tag = Category.ID;
                catpanel.Controls.Add(btn);
                btn.Click += CategoryButtonClick;
            }
        }
        public ArrayList RetreiveProductsFromCategory(int CategoryID)
        {
            ArrayList ProductsList = new ArrayList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Products where C_id = '" + CategoryID + "';", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int ProductID = Int16.Parse((reader["p_id"].ToString()));
                        string ProductName = (reader["p_name"].ToString());
                        int ProductPrice = Int16.Parse((reader["p_price"].ToString()));

                        ProductsList.Add(new Detail() { ID = ProductID, Name = ProductName, Price = ProductPrice });
                    }
                }
                connection.Close();

                return ProductsList;
            }
        }
        void CategoryButtonClick(object sender, EventArgs e)
        {
            Productpanel.Controls.Clear();

            Button btn = (Button)sender;

            int CategoryID = Convert.ToInt32(btn.Tag);


            foreach (Detail Product in RetreiveProductsFromCategory(CategoryID))
            {
                Button ProductButton = new Button();
                ProductButton.Text = Product.Name;
                ProductButton.Size = new System.Drawing.Size(60, 50);
                ProductButton.ForeColor = Color.Black;



                ProductButton.Tag = Product.ID;

                Productpanel.Controls.Add(ProductButton);

                ProductButton.Click += ProductButton_Click;


            }
        }
        void ProductButton_Click(Object sender, EventArgs e)
        {
            Button ProductButton = sender as Button;
            int ProductID = Convert.ToInt32(ProductButton.Tag);
            getproductdetail(ProductID);

        }

        public void getproductdetail(int p_id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Products where p_id = '" + p_id + "';", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int ProductID = Int16.Parse((reader["p_id"].ToString()));
                        string ProductName = (reader["p_name"].ToString());
                        int ProductPrice = Int16.Parse((reader["p_price"].ToString()));
                        productdataGridView.Rows.Add(ProductID, ProductName, ProductPrice, 1, ProductPrice * 1);
                        totalamount();
                    }
                }
                connection.Close();
            }

        }



        private void productdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (productdataGridView.SelectedRows.Count != -1)
            {
                row = productdataGridView.CurrentRow.Index;
            }
        }

        private void buttontopp_Click(object sender, EventArgs e)
        {
            if (row > 0)
            {
                productdataGridView.Rows[row].Selected = false;
                row = 0;
                productdataGridView.Rows[row].Selected = true;
            }
        }

        private void buttontop_Click(object sender, EventArgs e)
        {
            if (row > 0)
            {
                productdataGridView.Rows[row].Selected = false;

                productdataGridView.Rows[--row].Selected = true;
            }
        }

        private void buttondown_Click(object sender, EventArgs e)
        {
            if (row < productdataGridView.RowCount)
            {
                productdataGridView.Rows[row].Selected = false;
                productdataGridView.Rows[++row].Selected = true;
            }
        }

        private void buttonbuttom_Click(object sender, EventArgs e)
        {
            if (productdataGridView.Rows.Count > 0)
            {
                productdataGridView.Rows[row].Selected = false;
                productdataGridView.Rows[productdataGridView.Rows.Count - 1].Selected = true;

                row = productdataGridView.Rows.Count - 1;

            }
        }

        private void buttondel_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = productdataGridView.CurrentCell.RowIndex;
                if (selectedIndex != -1)
                {
                    productdataGridView.Rows.RemoveAt(selectedIndex);
                    productdataGridView.Refresh(); // if needed
                    totalamount();
                }
            }
            catch (InvalidOperationException ex)
            {

            }
        }

        private void buttonincrease_Click(object sender, EventArgs e)
        {
            if (productdataGridView.SelectedRows.Count != -1)
            {
                Quantity qty = new Quantity();
                qty.ShowDialog();
                productdataGridView.Rows[row].Cells[3].Value = (Int16.Parse(qty.textBox) + Int16.Parse(productdataGridView.Rows[row].Cells[3].Value.ToString())).ToString();
                productdataGridView.Rows[row].Cells[4].Value = (Int16.Parse(productdataGridView.Rows[row].Cells[2].Value.ToString()) * Int16.Parse(productdataGridView.Rows[row].Cells[3].Value.ToString()));
                totalamount();
            }

        }

        public void totalamount()
        {
            sum = 0;
            for (int i = 0; i < productdataGridView.Rows.Count; ++i)
            {
                sum += Convert.ToInt16(productdataGridView.Rows[i].Cells[4].Value);
            }
            textBoxTotalAmount.Text = sum.ToString();
        }

        private void buttonOrder_Click(object sender, EventArgs e)
        {

        }

        private void kotprintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int y = 0;
        
            Connection conn = new Connection();
            if(conn.inserttempOrders(Int16.Parse(textBoxTotalAmount.Text), det.Ordertype, det.table))
            {
               
            }
            
            int OrderId = getorderno();
            e.Graphics.DrawString("Kitchen Slip", new Font("monospaced sans serif", 16, FontStyle.Bold), Brushes.Black, new Point(60, y += 20));
            e.Graphics.DrawString("Order Id", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(5, y += 30));
            e.Graphics.DrawString(OrderId.ToString(), new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(150, y));
            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));

            e.Graphics.DrawString("Item-Name", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(5, y += 20));
            e.Graphics.DrawString("Qty", new Font("monospaced sans serif", 8, FontStyle.Bold), Brushes.Black, new Point(150, y));
            e.Graphics.DrawString("---------------------------------------------------------------------------------", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, y += 20));

            for (int i = 0; i < productdataGridView.Rows.Count; i++)

            {
                MessageBox.Show(OrderId.ToString());
             conn.inserttempOrdersItems(Convert.ToString(productdataGridView.Rows[i].Cells[1].Value),Int16.Parse(productdataGridView.Rows[i].Cells[2].Value.ToString()),Int16.Parse(productdataGridView.Rows[i].Cells[3].Value.ToString()),Int16.Parse(productdataGridView.Rows[i].Cells[4].Value.ToString()),OrderId);
                y = y + 20;
                string productid = Convert.ToString(productdataGridView.Rows[i].Cells[0].Value);
                string name = Convert.ToString(productdataGridView.Rows[i].Cells[1].Value);
                string quantity = Convert.ToString(productdataGridView.Rows[i].Cells[3].Value);

                e.Graphics.DrawString(name, new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(5, y));
                e.Graphics.DrawString(quantity, new Font("monospaced sans serif", 8, FontStyle.Regular), Brushes.Black, new Point(150, y));

            }
        }
        
        public int getorderno()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT TOP 1 t_Oid FROM  temp_orders Order by t_Oid desc ";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlquery, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                int orderId = Int16.Parse(dr["t_Oid"].ToString());
                conn.Close();
                return orderId;


            }
            else
            {
                return 0;
            }
        }

        private void buttonKOT_Click(object sender, EventArgs e)
        {
            if(textBoxTotalAmount.Text!="0")
            {
              //  kotprintPreviewDialog.Document =kotprintDocument;
                kotprintDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("prnm", 285, 600);
                kotprintDocument.Print();
                this.Hide();

            }
        }
    }
}
