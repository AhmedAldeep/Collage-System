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
    public partial class admin_pss : UserControl
    {
        public admin_pss()
        {
            InitializeComponent();
        }
        //Change Dean's Password
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string mycon = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);

            con.Open();
            SqlCommand cmd = new SqlCommand("Select password from [Dean]", con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader re = cmd.ExecuteReader();
            while (re.Read())
            {
                if (re["password"].ToString() == bunifuMaterialTextbox1.Text)
                {
                    flag = true;
                    break;
                }
            }

            re.Close();
            if (flag == true)
            {
                string query = "update Dean set password='" + this.bunifuMaterialTextbox2.Text + "' where username='" + this.bunifuMaterialTextbox4.Text + "' ;";
                SqlCommand cmd1 = new SqlCommand(query, con);
                SqlDataReader reader;
                try
                {
                    reader = cmd1.ExecuteReader();
                    MetroFramework.MetroMessageBox.Show(this, "\n\n\t Password Changed ");
                    while (reader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MetroFramework.MetroMessageBox.Show(this, ex.Message);
                }
            }
            else
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tThe Password is Incorrect ... Please Try Again ");
            
                


        }
    }
}
