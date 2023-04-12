using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IS_PROJECT_17
{
    public partial class Admin_login : UserControl
    {
        public Admin_login()
        {
            InitializeComponent();
        }
        // Admin Login Button
        // Open Admin Form
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

            string mycon = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cod = new SqlCommand("Select * from Dean where username='" + this.bunifuMaterialTextbox1.Text + "' and password ='" + this.bunifuMaterialTextbox2.Text + "';", con);
            SqlDataReader myreader;
            myreader = cod.ExecuteReader();
            int count = 0;
            while (myreader.Read())
            {
                count = count + 1;
            }
            if(count==1)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tWelcome \t"+this.bunifuMaterialTextbox1.Text);
                Collage_System cs = new Collage_System();
                cs.Close();
                Adminlogin al = new Adminlogin();
                al.Show();
            }
            else if(count >1)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tDuplicate Username and Password ... Access Denied");
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tUsername and Password Is not Correct ... Try Again");
            }
        
        }
    }
}
