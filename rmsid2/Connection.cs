﻿using System;
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
        string ConnectionString = "Data Source=DESKTOP-C27B91F;Initial Catalog=rmsid;Integrated Security=True";
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
            string query = "update users set user_lastlogin=CURRENT_TIMESTAMP where username=@username";
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
        public bool insertcat(string C_name, int DisAvail)
        {
            OpenConection();
            string query = "INSERT INTO categories (C_name,DisAvail) VALUES(@C_name,@DisAvail)";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@C_name", C_name);
            cmd.Parameters.AddWithValue("@DisAvail", DisAvail);        
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
        public bool updatecat(int c_id, string C_name, int DisAvail)
        {

            OpenConection();
            string query = "update  categories set C_name=@C_name,DisAvail=@DisAvail where c_id=@c_id";
            SqlCommand cmd = new SqlCommand(query, con);

            //Pass values to Parameters

            cmd.Parameters.AddWithValue("@C_name", C_name);
            cmd.Parameters.AddWithValue("@DisAvail", DisAvail);
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
            string query = "INSERT INTO products (C_id,p_name,p_price) VALUES(@C_id,@p_name,@p_price)";
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
            string query = "INSERT INTO temp_orders (t_netamnt,t_tablename,t_ordertype,Dateorder) VALUES(@t_netamnt,@t_tablename,@t_ordertype,CURRENT_TIMESTAMP)";
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
        
        public bool inserttempOrdersItems(string t_iName, int t_iprice, int t_iqty,int t_inetprice,int t_Oid,int p_id)
        {
            OpenConection();
            string query = "INSERT INTO temp_orderitems (t_iName,t_iprice,t_iqty,t_inetprice,t_Oid,p_id) VALUES(@t_iName,@t_iprice,@t_iqty,@t_inetprice,@t_Oid,@p_id)";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@t_iName", t_iName);
            cmd.Parameters.AddWithValue("@t_iprice", t_iprice);
            cmd.Parameters.AddWithValue("@t_iqty", t_iqty);
            cmd.Parameters.AddWithValue("@t_inetprice", t_inetprice);
            cmd.Parameters.AddWithValue("@t_Oid", t_Oid);
            cmd.Parameters.AddWithValue("@p_id", p_id);


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
            string query = "INSERT INTO OrderItems(t_iName, t_iprice, t_iqty,t_inetprice,t_Oid,p_id) SELECT t_iName, t_iprice, t_iqty,t_inetprice,t_Oid,p_id FROM  temp_orderitems WHERE   t_Oid =@order_id";
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
            String sqlQuery = "SELECT COUNT(*) FROM secretkey where secretkey='" + secretKey + "'";
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
        public bool deldateOrders(DateTime stardate ,DateTime enddate)
        {
            OpenConection();
            string query = "delete from  temp_orderitems  where Dateorder between @startdate and @endate";
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
            string query = "update users set username=@username,user_pass=@userpass ,user_privelage=@privileges where user_id@user_id ";
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

        public bool insertdisamnt(int orderid,int amnt,string distype)
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
    }
}
