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
    public partial class leaderedit : UserControl
    {
        public leaderedit()
        {
            InitializeComponent();
        }
        // Leader Edit Information Button
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            string mycon = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            if (bunifuMaterialTextbox2.Text != bunifuMaterialTextbox4.Text)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPassword Don't Match ");

            }
            else if (bunifuMaterialTextbox5.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Fill Email ");

            }
            else if (bunifuMaterialTextbox2.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Fill Password ");

            }
            else if (bunifuMaterialTextbox4.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Fill Repeat Password ");

            }
            else if (bunifuMaterialTextbox6.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Fill Phone ");

            }
            else if (bunifuMaterialTextbox7.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Fill Address ");

            }
            else
            {
                string query = "update Leader set l_email='" + this.bunifuMaterialTextbox5.Text + "',l_password='" + this.bunifuMaterialTextbox2.Text + "',l_address='" + this.bunifuMaterialTextbox7.Text + "',l_phone='" + this.bunifuMaterialTextbox6.Text + "' where l_username ='" + this.bunifuMaterialTextbox10.Text + "' ;";
                con.Open();
                SqlCommand cmd1 = new SqlCommand(query, con);
                SqlDataReader reader;
                try
                {
                    //con.Open();
                    reader = cmd1.ExecuteReader();
                    MetroFramework.MetroMessageBox.Show(this, "\n\n\t  Information has Been Edit Succefully ");
                    while (reader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MetroFramework.MetroMessageBox.Show(this, ex.Message);
                }
            }
        }

        private void bunifuMaterialTextbox10_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
