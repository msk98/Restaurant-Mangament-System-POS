using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rmsid2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            if (conn.getuser(textBoxusername.Text, textBoxpassword.Text) !=0)
            {
                if (conn.insertlogintime(textBoxusername.Text))
                {
                    
                    
                    Dashboard db = new Dashboard(conn.getprivelage(textBoxusername.Text), textBoxusername.Text, conn.getuser(textBoxusername.Text, textBoxpassword.Text));
                    this.Hide();
                    db.ShowDialog();
                    
                }
                else
                    MessageBox.Show("error");
            }
            else
                MessageBox.Show("Incorrect username or password");
        }

       
    }
}
