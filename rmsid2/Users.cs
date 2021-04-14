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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string ConnectionString = "Server=DESKTOP-C27B91F,1433;Database=rmsid;User Id = saadkhan; Password=saad;  ";
        int User_id = 0;
        private void Users_Load(object sender, EventArgs e)
        {
            getusers();
        }
        public void getusers()
        {
            Connection conn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("select user_id as UserId ,username as UserName,user_pass,user_lastlogin as LastLogin,user_lastlogout as LastLogout,user_privelage as privileges from users where username like'"+ usertextBox.Text+ "%'", ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "Users");
            userssdataGridView.DataSource = ds.Tables["Users"].DefaultView;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            if (textBoxname.Text.Length > 0 && textBoxpass.Text.Length > 0 && comboBoxpriv.SelectedIndex!=-1)
            {
                conn.insertusers(textBoxname.Text,textBoxpass.Text,comboBoxpriv.SelectedItem.ToString(),0);
                clear();
                getusers();
            }
        }
        public void clear()
        {
            textBoxname.Text = "";
            textBoxpass.Text = "";
            comboBoxpriv.SelectedIndex = -1;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            if (User_id!=0 && textBoxname.Text.Length > 0 && textBoxpass.Text.Length > 0 && comboBoxpriv.SelectedIndex != -1)
            {
                conn.updateusers(User_id, textBoxname.Text, textBoxpass.Text, comboBoxpriv.SelectedItem.ToString());
                clear();
                getusers();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            if (User_id != 0 && textBoxname.Text.Length > 0 && textBoxpass.Text.Length > 0 && comboBoxpriv.SelectedIndex != -1)
            {
                conn.delUsers(User_id);
                clear();
                getusers();
            }
        }

        private void InventextBox_TextChanged(object sender, EventArgs e)
        {
            getusers();
        }

        private void userssdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //  settnullValue();
                DataGridViewRow row = userssdataGridView.Rows[e.RowIndex];
                User_id = Int16.Parse(row.Cells[0].Value.ToString());
                textBoxname.Text = (row.Cells[1].Value.ToString());
                textBoxpass.Text = row.Cells[2].Value.ToString();
              int  index = comboBoxpriv.FindString(row.Cells[5].Value.ToString());
                comboBoxpriv.SelectedIndex = index;
            }
        }

        private void checkBoxshow_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxshow.Checked)
            {
                textBoxpass.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxpass.UseSystemPasswordChar = true;

            }
        }
    }
}
