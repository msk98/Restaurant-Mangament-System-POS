using System;
using System.Collections.Generic;
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
            string query = "update products set Inven_Qty=@Inven_Qty,Inven_Name=@Inven_Name where Inven_id=@Inven_id";
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
            catch (SqlException e)
            {
                //string err = "Error Generated. Details: " + e.ToString();
//                MessageBox.Show(err);

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
            string query = "INSERT INTO temp_orders (t_netamnt,t_tablename,t_ordertype) VALUES(@t_netamnt,@t_tablename,@t_ordertype)";
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
        
        public bool inserttempOrdersItems(string t_iName, int t_iprice, int t_iqty,int t_inetprice,int t_Oid)
        {
            OpenConection();
            string query = "INSERT INTO temp_orderitems (t_iName,t_iprice,t_iqty,t_inetprice,t_Oid) VALUES(@t_iName,@t_iprice,@t_iqty,@t_inetprice,@t_Oid)";
            SqlCommand cmd = new SqlCommand(query, con);
            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@t_iName", t_iName);
            cmd.Parameters.AddWithValue("@t_iprice", t_iprice);
            cmd.Parameters.AddWithValue("@t_iqty", t_iqty);
            cmd.Parameters.AddWithValue("@t_inetprice", t_inetprice);
            cmd.Parameters.AddWithValue("@t_Oid", t_Oid);

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
