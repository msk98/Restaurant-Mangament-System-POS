using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rmsid2
{
    class Connection
    {
        string ConnectionString = "Server=DESKTOP-C27B91F,1433;Database=rmsid;User Id = saadkhan; Password=saad; ";
        SqlConnection con;
        public void OpenConection()
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
        }
        public void CloseConnection()
        {
            con = new SqlConnection(ConnectionString);
            con.Close();
        }

        public int getuser(string username, string userpass)
        {
            int count = 0;
            OpenConection();
            string query = "select user_id from users where username=@username and user_pass=@userpass";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@userpass", userpass);

            try
            {
                OpenConection();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    count = Int16.Parse(dr["user_id"].ToString());

                }
                return count;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return count;
            }
            finally
            {
                CloseConnection();

            }
        }
        public string getprivelage(string username)
        {
            OpenConection();
            string query = "select user_privelage from users where username=@username ";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@username", username);
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                string user_privelage=null;
                OpenConection();
                while (dr.Read())
                {
                    user_privelage=(dr["user_privelage"].ToString());

                }
                return user_privelage;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return null;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool insertlogintime(string username)
        {
            OpenConection();
            string query = "update users set user_lastlogin=getDate(),user_lastlogout='' where username=@username";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@username", username);
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool insertcat(string C_name,int dis_avail)
        {
            OpenConection();
            string query = "INSERT INTO categories (C_name,DisAvail) VALUES(@C_name,@dis_avail)";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@C_name", C_name); 
            cmd.Parameters.AddWithValue("@dis_avail", dis_avail);
            //    cmd.Parameters.AddWithValue("@DisAvail", DisAvail);        
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool updatecat(int c_id, string C_name,int dis_avail)
        {

            OpenConection();
            string query = "update  categories set C_name=@C_name,DisAvail=@dis_avail where c_id=@c_id";
            string query1 = "update  products set dis_avail=@dis_avail where c_id=@c_id";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlCommand cmd1 = new SqlCommand(query1, con);

            //Pass values to Parameters

            cmd.Parameters.AddWithValue("@C_name", C_name);
            cmd.Parameters.AddWithValue("@c_id", c_id);
            cmd1.Parameters.AddWithValue("@c_id", c_id);

            cmd.Parameters.AddWithValue("@dis_avail", dis_avail);
            cmd1.Parameters.AddWithValue("@dis_avail", dis_avail);


            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error Generated. Details: " + e.ToString());
                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool delcat(int c_id)
        {
            OpenConection();
            string query = "delete from  categories  where c_id=@c_id";
            SqlCommand cmd = new SqlCommand(query, con);

            //Pass values to Parameters

            cmd.Parameters.AddWithValue("@c_id", c_id);

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error Generated. Details: " + e.ToString());
                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool insertprod(int C_id, string p_name,int p_price)
        {
            OpenConection();
            //string query = "INSERT INTO products (C_id,p_name,p_price) VALUES(@C_id,@p_name,@p_price)";
            string query = "  INSERT INTO products(C_id, p_name, p_price, dis_avail) SELECT @C_id, @p_name, @p_price, categories.DisAvail FROM categories WHERE categories.C_id = @C_id;";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@C_id", C_id);
            cmd.Parameters.AddWithValue("@p_name", p_name);
            cmd.Parameters.AddWithValue("@p_price", p_price);
           

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }

        public bool updateprod(int p_id, string p_name, int p_price,int C_id)
        {
            OpenConection();
            string query = "update  products set C_id=@C_id,p_name=@p_name,p_price=@p_price where p_id=@p_id";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@p_id", p_id);
            cmd.Parameters.AddWithValue("@C_id", C_id);
            cmd.Parameters.AddWithValue("@p_name", p_name);
            cmd.Parameters.AddWithValue("@p_price", p_price);
         

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool delprod(int p_id)
        {
            OpenConection();
            string query = "delete from  products  where p_id=@p_id";
            SqlCommand cmd = new SqlCommand(query, con);

            //Pass values to Parameters

            cmd.Parameters.AddWithValue("@p_id", p_id);

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error Generated. Details: " + e.ToString());
                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool insertinven(string Inven_Name, int Inven_Qty)
        {
            OpenConection();
            string query = "INSERT INTO inventory (Inven_Name,Inven_Qty) VALUES(@Inven_Name,@Inven_Qty)";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@Inven_Name", Inven_Name);
            cmd.Parameters.AddWithValue("@Inven_Qty", Inven_Qty);

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool updateinven(int Inven_id, string Inven_Name, int Inven_Qty)
        {
            OpenConection();
            string query = "update inventory set Inven_Qty=@Inven_Qty,Inven_Name=@Inven_Name where Inven_id=@Inven_id";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@Inven_Name", Inven_Name);
            cmd.Parameters.AddWithValue("@Inven_Qty", Inven_Qty);
            cmd.Parameters.AddWithValue("@Inven_id", Inven_id);

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool delinven(int Inven_id)
        {
            OpenConection();
            string query = "delete from  inventory  where Inven_id=@Inven_id";
            SqlCommand cmd = new SqlCommand(query, con);

            //Pass values to Parameters

            cmd.Parameters.AddWithValue("@Inven_id", Inven_id);

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error Generated. Details: " + e.ToString());
                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool insertingred(int Inven_id, int C_id,int p_id,int qty)
        {
            OpenConection();
            string query = "INSERT INTO incredients (Inven_id,C_id,p_id,qty) VALUES(@Inven_id,@C_id,@p_id,@qty)";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@Inven_id", Inven_id);
            cmd.Parameters.AddWithValue("@C_id", C_id);
            cmd.Parameters.AddWithValue("@p_id", p_id);
            cmd.Parameters.AddWithValue("@qty", qty);

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool updateingred(int inc_id,int Inven_id, int C_id, int p_id, int qty)
        {
            OpenConection();
            string query = "update incredients set Inven_id=@Inven_id ,C_id=@C_id,p_id=@p_id,qty=@qty where Inven_id=@inc_id";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@Inven_id", Inven_id);
            cmd.Parameters.AddWithValue("@C_id", C_id);
            cmd.Parameters.AddWithValue("@p_id", p_id);
            cmd.Parameters.AddWithValue("@qty", qty);
            cmd.Parameters.AddWithValue("@inc_id", inc_id);


            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool delinc(int inc_id)
        {
            OpenConection();
            string query = "delete from  incredients  where inc_id=@inc_id";
            SqlCommand cmd = new SqlCommand(query, con);

            //Pass values to Parameters

            cmd.Parameters.AddWithValue("@inc_id", inc_id);

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error Generated. Details: " + e.ToString());
                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool inserttables(string t_name, int t_status)
        {
            OpenConection();
            string query = "INSERT INTO tables (t_name,t_status) VALUES(@t_name,@t_status)";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@t_name", t_name);
            cmd.Parameters.AddWithValue("@t_status", t_status);

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {
                //string err = "Error Generated. Details: " + e.ToString();
               MessageBox.Show(ex.ToString());

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool updatetable(int t_id, string t_name, int t_status)
        {
            OpenConection();
            string query = "update tables set t_name=@t_name ,t_status=@t_status where t_id=@t_id";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@t_id", t_id);
            cmd.Parameters.AddWithValue("@t_name", t_name);
            cmd.Parameters.AddWithValue("@t_status", t_status);
           try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool deltable(int t_id)
        {
            OpenConection();
            string query = "delete from  tables  where t_id=@t_id";
            SqlCommand cmd = new SqlCommand(query, con);
             //Pass values to Parameters
             cmd.Parameters.AddWithValue("@t_id", t_id);

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error Generated. Details: " + e.ToString());
                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool inserttempOrders(int t_netamnt, string t_ordertype, string t_tablename)
        {
            OpenConection();
            string query = "INSERT INTO temp_orders (t_netamnt,t_tablename,t_ordertype,Dateorder) VALUES(@t_netamnt,@t_tablename,@t_ordertype,getDate())";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@t_netamnt",t_netamnt);
            cmd.Parameters.AddWithValue("@t_tablename", t_tablename);
            cmd.Parameters.AddWithValue("@t_ordertype", t_ordertype);

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                              MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        
        public bool inserttempOrdersItems(string t_iName, int t_iprice, int t_iqty,int t_inetprice,int t_Oid,int p_id,int dis_avail)
        {
            OpenConection();
            string query = "INSERT INTO temp_orderitems (t_iName,t_iprice,t_iqty,t_inetprice,t_Oid,p_id,dis_avail) VALUES(@t_iName,@t_iprice,@t_iqty,@t_inetprice,@t_Oid,@p_id,@dis_avail)";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@t_iName", t_iName);
            cmd.Parameters.AddWithValue("@t_iprice", t_iprice);
            cmd.Parameters.AddWithValue("@t_iqty", t_iqty);
            cmd.Parameters.AddWithValue("@t_inetprice", t_inetprice);
            cmd.Parameters.AddWithValue("@t_Oid", t_Oid);
            cmd.Parameters.AddWithValue("@p_id", p_id);
            cmd.Parameters.AddWithValue("@dis_avail", dis_avail);            
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool updatetablestatus(string t_name)
        {
            OpenConection();
            string query = "update tables set t_status=1 where t_name=@t_name and t_status=0";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@t_name", t_name);     
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public int checkstatustable(string t_name)
        {
            OpenConection();
            int count = 0;
            SqlConnection conn = new SqlConnection(ConnectionString);
        String sqlQuery = "SELECT COUNT(*) FROM tables where t_name='"+ t_name+ "' and t_status=0";
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            try
            {
                conn.Open();
                //Since return type is System.Object, a typecast is must
                count = (Int32)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return count;
        }
         public int getOrderNo(string t_name)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT * FROM  temp_orders where t_tablename='" + t_name+"' ";
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
        public bool updatebill(string t_name,int total)
        {
            OpenConection();
            string query = "update temp_orders set t_netamnt=(t_netamnt+@total) where t_tablename=@t_name ";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@t_name", t_name);
            cmd.Parameters.AddWithValue("@total", total);
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool insertCustomers(string cust_name, string cust_phone, string cust_address)
        {
            OpenConection();
            string query = "INSERT INTO customer (cust_name,cust_phone,cust_address) VALUES(@cust_name,@cust_phone,@cust_address)";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@cust_name", cust_name);
            cmd.Parameters.AddWithValue("@cust_phone", cust_phone);
            cmd.Parameters.AddWithValue("@cust_address", cust_address);
         

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool updatecust(int c_id, string cust_name, string cust_phone, string cust_address)
        {
            OpenConection();
            string query = "update customer set cust_name=@cust_name ,cust_phone=@cust_phone,cust_address=@cust_address where cus_id=@c_id";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@c_id", c_id);
            cmd.Parameters.AddWithValue("@cust_name", cust_name);
            cmd.Parameters.AddWithValue("@cust_phone", cust_phone);
            cmd.Parameters.AddWithValue("@cust_address", cust_address);

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool delcust(int c_id)
        {
            OpenConection();
            string query = "delete from  customer  where c_id=@c_id";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@c_id", c_id);

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error Generated. Details: " + e.ToString());
                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool insertCustomerOrder(int cus_id, int Order_id)
        {
            OpenConection();
            string query = "INSERT INTO customerOrders (cus_id,Order_id) VALUES(@cus_id,@Order_id)";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@cus_id", cus_id);
            cmd.Parameters.AddWithValue("@Order_id", Order_id);


            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }

        public bool insertdeliverorder(int d_id, int Order_id)
        {
            OpenConection();
            string query = "INSERT INTO del_orders (Order_id,d_id) VALUES(@order_id,@d_id)";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@d_id", d_id);
            cmd.Parameters.AddWithValue("@order_id", Order_id);
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool insertOrder(int Order_id)
        {
            OpenConection();
            string query = "INSERT INTO Orders(t_Oid, t_netamnt, t_tablename, t_ordertype,Dateorder) SELECT t_Oid, t_netamnt,t_tablename, t_ordertype,getDate() FROM  temp_orders WHERE t_Oid =@order_id";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@order_id", Order_id);
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }

        public bool insertOrderItems(int Order_id)
        {
            OpenConection();
            string query = "INSERT INTO OrderItems(t_iName, t_iprice, t_iqty,t_inetprice,t_Oid,p_id,dis_avail) SELECT t_iName, t_iprice, t_iqty,t_inetprice,t_Oid,p_id,dis_avail FROM  temp_orderitems WHERE   t_Oid =@order_id";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@order_id", Order_id);
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool delorders(int Order_id)
        {
            OpenConection();
            string query = "delete from  temp_orders  where t_Oid=@Order_id";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@Order_id", Order_id);

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error Generated. Details: " + e.ToString());
                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool delorderItems(int Order_id)
        {
            OpenConection();
            string query = "delete from  temp_orderitems  where t_Oid=@Order_id";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@Order_id", Order_id);

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error Generated. Details: " + e.ToString());
                return false;
            }
            finally
            {
                CloseConnection();

            }
        }

        public bool updatetablestats(string t_name)
        {
            OpenConection();
            string query = "update tables set t_status=0 where t_name=@t_name";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@t_name", t_name);

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }

        public bool updateInventory(int o_id)
        {
            OpenConection();
            string query = "update i set i.Inven_Qty= i.Inven_Qty-(OrderItems.t_iqty * incredients.qty)from inventory i inner join incredients on incredients.Inven_id=i.Inven_id inner join OrderItems on OrderItems.p_id= incredients.p_id where OrderItems.t_Oid= @o_id; ";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@o_id", o_id);

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public int checkSecretKey(int secretKey)
        {
            OpenConection();
            int count = 0;
            SqlConnection conn = new SqlConnection(ConnectionString);
            String sqlQuery = "SELECT COUNT(*) FROM secretkey where secretkey=@secretKey";
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.Parameters.AddWithValue("@secretKey", secretKey);

            try
            {
                conn.Open();
                //Since return type is System.Object, a typecast is must
                count = (Int32)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return count;
        }
        public bool deldateOrders(DateTime stardate ,DateTime enddate)
        {
            OpenConection();
            string query = "delete from  Orders  where Dateorder between @startdate and @endate";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@stardate", stardate);
            cmd.Parameters.AddWithValue("@enddate", enddate);

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error Generated. Details: " + e.ToString());
                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool delcanceldateOrders(DateTime stardate, DateTime enddate)
        {
            OpenConection();
            string query = "delete from  cancelOrders  where Dateorder between @startdate and @endate";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@stardate", stardate);
            cmd.Parameters.AddWithValue("@enddate", enddate);

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error Generated. Details: " + e.ToString());
                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool insertdiscounts(string d_name, int d_percent)
        {
            OpenConection();
            string query = "INSERT INTO discounts (discount_name,discount_percentage) VALUES(@d_name,@d_percent)";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@d_percent", d_percent);
            cmd.Parameters.AddWithValue("@d_name", d_name);
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool updatedis(int dis_id,string discount_name, int discount_percentage)
        {
            OpenConection();
            string query = "update discounts set discount_name=@discount_name,discount_percentage=@discount_percentage where discount_id=@dis_id ";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@dis_id", dis_id);
            cmd.Parameters.AddWithValue("@discount_name", discount_name);
            cmd.Parameters.AddWithValue("@discount_percentage", discount_percentage);
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool delDiss(int dis_id)
        {
            OpenConection();
            string query = "delete from  discounts  where discount_id=@dis_id";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@dis_id", dis_id);

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error Generated. Details: " + e.ToString());
                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool insertusers(string username,string userpass,string privileges)
        {
            OpenConection();
            string query = "INSERT INTO users (username,user_pass,user_privelage) VALUES(@username,@userpass,@privileges)";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@userpass", userpass);
            cmd.Parameters.AddWithValue("@privileges", privileges);
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool updateusers(int user_id,string username, string userpass, string privileges)
        {
            OpenConection();
            string query = "update users set username=@username,user_pass=@userpass ,user_privelage=@privileges where user_id=@user_id ";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@userpass", userpass);
            cmd.Parameters.AddWithValue("@privileges", privileges);
            cmd.Parameters.AddWithValue("@user_id", user_id);

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool delUsers(int user_id)
        {
            OpenConection();
            string query = "delete from  users  where user_id=@user_id";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@user_id", user_id);

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error Generated. Details: " + e.ToString());
                return false;
            }
            finally
            {
                CloseConnection();

            }
        }

        public bool insertdisamnt(int orderid,float amnt,string distype)
        {
            OpenConection();
            string query = "INSERT INTO discoutAmount (order_id,discountAmount,discountType) VALUES(@orderid,@amnt,@distype)";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.Parameters.AddWithValue("@amnt", amnt);
            cmd.Parameters.AddWithValue("@distype", distype);
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool deldiscountamnt(int orderid)
        {
            OpenConection();
            string query = "delete from discoutAmount  where order_id=@orderid";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@orderid", orderid);

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error Generated. Details: " + e.ToString());
                return false;
            }
            finally
            {
                CloseConnection();

            }

        }
        public bool insertcrpayment(int orderid,int CardAmount)
        {
            OpenConection();
            string query = "INSERT INTO CardAmount (orderid,CardAmount) VALUES(@orderid,@CardAmount)";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.Parameters.AddWithValue("@CardAmount", CardAmount);
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool inserttax(int orderid, float taxAmount)
        {
            OpenConection();
            string query = "INSERT INTO taxAmount (order_id,taxAmount) VALUES(@orderid,@taxAmount)";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.Parameters.AddWithValue("@taxAmount", taxAmount);
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool insertservicetax(int orderid, int ServiceAmount)
        {
            OpenConection();
            string query = "INSERT INTO serviceAmount (order_id,ServiceAmount) VALUES(@orderid,@ServiceAmount)";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.Parameters.AddWithValue("@ServiceAmount", ServiceAmount);
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public int RegOpenClose (int userid)
        {
            int count =-1;
            OpenConection();
            string query = "select reg_open from users where user_id=@userid ";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@userid", userid);

            try
            {
                OpenConection();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    count = Int16.Parse(dr["user_id"].ToString());

                }
                return count;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return count;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool Updateregopen(int userid)
        {
            OpenConection();
            string query = "  update users  set reg_open =1  where user_id=@userid;";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
 
            cmd.Parameters.AddWithValue("@userid", userid);
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool Updateregclose(int userid)
        {
            OpenConection();
            string query = "  update users  set reg_open =0  where user_id=@userid;";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters

            cmd.Parameters.AddWithValue("@userid", userid);
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }

        public bool startregister(int userid,int Startamount)
        {
            OpenConection();
            string query = "INSERT INTO openregister (userid,openregister,Startamount) VALUES(@userid,getDate(),@Startamount)";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@Startamount", Startamount);
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }

        public bool endregister(int userid,int endid)
        {
            OpenConection();
            string query = "INSERT INTO closeregister (userid,closeregister,startregisterid) VALUES(@userid,getDate(),@endid)";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@endid", endid);
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool insertuserorders(int userid, int orderid)
        {
            OpenConection();
            string query = "INSERT INTO userord (user_id,order_id) VALUES(@userid,@orderid)";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@orderid", orderid);
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();
                MessageBox.Show("working");
                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }

        public bool updatelastlogin(string username)
        {
            OpenConection();
            string query = "update users set user_lastlogout=getDate() where username=@username";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@username", username);
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
         
        }
        public bool deluserorders(int userid, int orderid)
        {
            OpenConection();
            string query = "delete from  usersOrders where user_id=@userid and order_id=@orderid)";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@orderid", orderid);
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool Insertcountinven(int OrderId)
        {
            OpenConection();
            string query = "insert into inven_count(incrd_id,incr_qty,order_id)  select incredients.inc_id,incredients.qty*temp_orderitems.t_iqty,temp_orderitems.t_Oid from incredients join products on products.p_id=incredients.p_id join temp_orderitems on temp_orderitems.t_Oid=@OrderId";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@OrderId", OrderId);
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public ArrayList retrieveUsedInventory(DateTime startdate,DateTime enddate ,int user_id)
        {
            ArrayList inventorylist = new ArrayList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("select  isnull(sum(inven_count.incr_qty),0) as Invenqty,inventory.Inven_Name as InventoryName from inven_count inner join incredients on incredients.inc_id=inven_count.incrd_id inner join inventory on inventory.Inven_id=incredients.Inven_id join Orders on Orders.t_Oid=inven_count.order_id inner join userord on userord.order_id=Orders.t_Oid where Orders.Dateorder between  @startdate and @enddate and userord.user_id=@user_id group by inventory.Inven_Name", connection);
                command.Parameters.AddWithValue("@startdate", startdate);
                command.Parameters.AddWithValue("@enddate", enddate);
                command.Parameters.AddWithValue("@user_id", user_id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        inventorylist.Add(new Detail() { invenname = reader["InventoryName"].ToString(), invenqty = Int16.Parse((reader["Invenqty"].ToString())) });
                    }
                }
                connection.Close();

                return inventorylist;
            }
        }
        public ArrayList retrievediscounts(DateTime startdate, DateTime enddate, int user_id)
        {
            ArrayList discountList = new ArrayList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("select isnull(sum(discoutAmount.discountAmount),0) as DiscountAmount, DiscountType from discoutAmount inner join Orders on Orders.t_Oid=discoutAmount.order_id join userord usr on usr.order_id = Orders.t_Oid 	where (Orders.Dateorder between @startdate and @enddate) and   usr.user_id =@user_id  group by discountType;", connection);
                command.Parameters.AddWithValue("@startdate", startdate);
                command.Parameters.AddWithValue("@enddate", enddate);
                command.Parameters.AddWithValue("@user_id", user_id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        discountList.Add(new Detail() { DiscountAmount = Int16.Parse(reader["DiscountAmount"].ToString()), DiscountType = (reader["DiscountType"].ToString()) });
                    }
                }
                connection.Close();

                return discountList;
            }
        }

        public ArrayList retrievedProducts(DateTime startdate, DateTime enddate,int user_id)
        {
            ArrayList productslist = new ArrayList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT OrderItems.t_iName as ItemName, isnull(sum(OrderItems.t_iqty),0) as qty from OrderItems inner join Orders on Orders.t_Oid= OrderItems.t_Oid  join userord usr on usr.order_id = Orders.t_Oid 	where (Orders.Dateorder between @startdate and @enddate) and   usr.user_id =@user_id  group by OrderItems.t_iName;", connection);
                command.Parameters.AddWithValue("@startdate", startdate);
                command.Parameters.AddWithValue("@enddate", enddate);
                command.Parameters.AddWithValue("@user_id", user_id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        productslist.Add(new Detail() { p_qty = Int16.Parse(reader["qty"].ToString()), p_name = (reader["ItemName"].ToString()) });
                    }
                }
                connection.Close();

                return productslist;
            }
        }

        public ArrayList retrievedOrders(DateTime startdate, DateTime enddate,int user_id)
        {
            ArrayList OrderList = new ArrayList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT count(t_ordertype) as Orders,isnull(sum(Orders.t_netamnt),0) as netsale,t_ordertype as OrderType from Orders join userord usr on usr.order_id = Orders.t_Oid 	where (Orders.Dateorder between @startdate and @enddate) and   usr.user_id =@user_id  group by t_ordertype;", connection);
                command.Parameters.AddWithValue("@startdate", startdate);
                command.Parameters.AddWithValue("@enddate", enddate);
                command.Parameters.AddWithValue("@user_id", user_id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrderList.Add(new Detail() { Orders = Int16.Parse(reader["Orders"].ToString()), OrderType = (reader["OrderType"].ToString()), netsale = Int16.Parse(reader["netsale"].ToString()), });
                    }
                }
                connection.Close();

                return OrderList;
            }
        }
      
        public int retrievedtaxes(DateTime startdate, DateTime enddate,int user_id)
        {
            int Taxes = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("select isnull(sum(taxAmount),0) as Taxes from taxAmount inner join Orders on Orders.t_Oid=taxAmount.order_id join userord usr on usr.order_id = Orders.t_Oid 	where (Orders.Dateorder between @startdate and @enddate) and   usr.user_id =@user_id ;", connection);
                command.Parameters.AddWithValue("@startdate", startdate);
                command.Parameters.AddWithValue("@enddate", enddate);
                command.Parameters.AddWithValue("@user_id", user_id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Taxes = Int16.Parse(reader["Taxes"].ToString());
                    }
                }
                connection.Close();

                return Taxes;
            }
        }
        public int calculatesercharge(DateTime startdate, DateTime enddate,int user_id)
        {
            int servicecharges = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("select  isnull(sum(serviceAmount),0) as serviceAmount from serviceAmount inner join Orders on Orders.t_Oid=serviceAmount.order_id join userord usr on usr.order_id = Orders.t_Oid 	where (Orders.Dateorder between @startdate and @enddate) and   usr.user_id =@user_id", connection);
                command.Parameters.AddWithValue("@startdate", startdate);
                command.Parameters.AddWithValue("@enddate", enddate);
                command.Parameters.AddWithValue("@user_id", user_id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        servicecharges = Int16.Parse(reader["serviceAmount"].ToString());
                    }
                }
                connection.Close();

                return servicecharges;
            }
        }
        public int calculateCrtaxes(DateTime startdate, DateTime enddate, int user_id)
        {
            int servicecharges = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("select  isnull(sum(CardAmount),0) as CardAmount from CardAmount inner join Orders on Orders.t_Oid=CardAmount.orderid join userord usr on usr.order_id = Orders.t_Oid 	where (Orders.Dateorder between @startdate and @enddate) and   usr.user_id =@user_id", connection);
                command.Parameters.AddWithValue("@startdate", startdate);
                command.Parameters.AddWithValue("@enddate", enddate);
                command.Parameters.AddWithValue("@user_id", user_id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        servicecharges = Int16.Parse(reader["CardAmount"].ToString());
                    }
                }
                connection.Close();

                return servicecharges;
            }
        }
        public int calculatenetsale(DateTime startdate, DateTime enddate, int user_id)
        {
            int servicecharges = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("select  isnull(sum(t_netamnt),0) as totalamount from Orders  join userord usr on usr.order_id = Orders.t_Oid 	where (Orders.Dateorder between @startdate and @enddate) and   usr.user_id =@user_id", connection);
                command.Parameters.AddWithValue("@startdate", startdate);
                command.Parameters.AddWithValue("@enddate", enddate);
                command.Parameters.AddWithValue("@user_id", user_id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        servicecharges = Int16.Parse(reader["totalamount"].ToString());
                    }
                }
                connection.Close();

                return servicecharges;
            }
        }

        public DateTime getregtime(int user_id)
        {
            DateTime regtime = DateTime.Now;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(" select top 1 openregister from openregister where userid=@user_id order by openregister desc ;", connection);
                
                command.Parameters.AddWithValue("@user_id", user_id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        regtime = DateTime.Parse(reader["openregister"].ToString());
                    }
                }
                connection.Close();

                return regtime;
            }
        }
        public int getregid(int user_id)
        {
            int registerid = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(" select top 1 registerid from openregister where userid=@user_id order by registerid desc ;", connection);

                command.Parameters.AddWithValue("@user_id", user_id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        registerid = Int16.Parse(reader["registerid"].ToString());
                    }
                }
                connection.Close();

                return registerid;
            }
        }

        public bool insertrider(string name,string phonenum)
        {
            OpenConection();
            string query = "INSERT INTO DeliveryBoys (d_name,d_phoneno) VALUES(@name,@phonenum)";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@phonenum", phonenum);
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }

        public bool updaterider(int del_id,string name,string phonenum)
        {
            OpenConection();
            string query = "update DeliveryBoys set d_name=@name,d_phoneno=@phonenum where d_id=@del_id";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@phonenum", phonenum);
            cmd.Parameters.AddWithValue("@del_id", del_id);

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }

        }
        public bool deleterider(int del_id)
        {
            OpenConection();
            string query = "delete from DeliveryBoys where d_id=@del_id";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
          
            cmd.Parameters.AddWithValue("@del_id", del_id);

            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }

        }

        public bool InsertCancelOrder(int OrderId)
        {
            OpenConection();
            string query = "INSERT INTO cancelOrders(t_Oid, t_tablename,t_ordertype, Dateorder,cancelorder,t_netamnt) SELECT t_Oid, t_tablename,t_ordertype,Dateorder,getDate(),t_netamnt FROM  temp_orders WHERE   t_Oid =@OrderId";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@OrderId", OrderId);
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
        public bool insertcancelOrderItems(int Order_id)
        {
            OpenConection();
            string query = "INSERT INTO cancelOrdersItems(t_iName, t_iprice, t_iqty,t_inetprice,t_Oid,p_id) SELECT t_iName, t_iprice, t_iqty,t_inetprice,t_Oid,p_id FROM  temp_orderitems WHERE   t_Oid =@order_id";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@order_id", Order_id);
            try
            {
                OpenConection();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                string err = "Error Generated. Details: " + e.ToString();
                MessageBox.Show(err);

                return false;
            }
            finally
            {
                CloseConnection();

            }
        }
    }
}
