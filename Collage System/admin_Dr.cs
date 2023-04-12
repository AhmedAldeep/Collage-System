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
    public partial class admin_Dr : UserControl
    {
        public admin_Dr()
        {
            InitializeComponent();
            fillcombo();
        }
        //Doctor username combo box auto Fill From Sql 
        void fillcombo()
        {
            string mycon = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            string queryy = "select * from Doctor;";
            SqlConnection con = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand(queryy, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string u = (string)reader["dr_username"].ToString();
                    comboBox1.Items.Add(u);
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }


        }
        // Add Doctor 
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            bool flag = false;

            string newState = "";
            if (radioButton1.Checked)
                newState = "Male";

            else if (radioButton2.Checked)
                newState = "Female";
            string mycon = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            if (bunifuMaterialTextbox2.Text != bunifuMaterialTextbox4.Text)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPassword Don't Match ");

            }
            else if (bunifuMaterialTextbox3.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Fill First Name ");

            }
            else if (bunifuMaterialTextbox8.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Fill Last Name ");

            }
            else if (bunifuMaterialTextbox5.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Fill Email ");

            }
            else if (bunifuMaterialTextbox10.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Fill Username ");

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
            else if (radioButton1.Checked == null || radioButton2.Checked == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Choose The Gender ");

            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select dr_username from [Doctor]", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader re = cmd.ExecuteReader();
                while (re.Read())
                {
                    if (re["dr_username"].ToString() == bunifuMaterialTextbox10.Text)
                    {
                        flag = true;
                        break;
                    }
                }

                re.Close();
                if (flag == true)
                    MetroFramework.MetroMessageBox.Show(this, "\n\n\tThe Username is already Exist ");
                else
                {

                    string query = "insert into Doctor (dr_fname,dr_lname,dr_email,dr_username,dr_password,dr_gender,dr_address,dr_phone) Values ('" + this.bunifuMaterialTextbox3.Text + "','" + this.bunifuMaterialTextbox8.Text + "','" + this.bunifuMaterialTextbox5.Text + "','" + this.bunifuMaterialTextbox10.Text + "','" + this.bunifuMaterialTextbox2.Text + "','" + newState + "','" + this.bunifuMaterialTextbox7.Text + "','" + this.bunifuMaterialTextbox6.Text + "') ";
                    SqlCommand cmd1 = new SqlCommand(query, con);
                    SqlDataReader reader;
                    try
                    {
                        //con.Open();
                        reader = cmd1.ExecuteReader();
                        MetroFramework.MetroMessageBox.Show(this, "\n\n\tNew Doctor Add Succefully ");
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

        }
        // Fill Textbox With Username When Select Item In Combo Box From DataBase
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mycon = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            string queryy = "select * from Doctor where dr_username='" + comboBox1.Text + "';";
            SqlConnection con = new SqlConnection(mycon);

            SqlCommand cmd = new SqlCommand(queryy, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string id = (string)reader["dr_id"].ToString();
                    string firstname = (string)reader["dr_fname"].ToString();
                    string lastname = (string)reader["dr_lname"].ToString();
                    string username = (string)reader["dr_username"].ToString();
                    string pass = (string)reader["dr_password"].ToString();
                    string gender = (string)reader["dr_gender"].ToString();
                    string phone = (string)reader["dr_phone"].ToString();
                    string address = (string)reader["dr_address"].ToString();
                    string email = (string)reader["dr_email"].ToString();

                    label4.Text = id;
                    bunifuMaterialTextbox2.Text = pass;
                    bunifuMaterialTextbox3.Text = firstname;
                    bunifuMaterialTextbox4.Text = pass;
                    bunifuMaterialTextbox5.Text = email;
                    bunifuMaterialTextbox6.Text = phone;
                    bunifuMaterialTextbox7.Text = address;
                    bunifuMaterialTextbox8.Text = lastname;
                    bunifuMaterialTextbox10.Text = username;

                    if (gender == "Male")
                    {
                        radioButton1.PerformClick();
                    }
                    else if (gender == "Female")
                    {
                        radioButton2.PerformClick();
                    }





                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        // Edit Doctor
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            bool flag = false;

            string newState = "";
            if (radioButton1.Checked)
                newState = "Male";

            else if (radioButton2.Checked)
                newState = "Female";
            string mycon = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            if (bunifuMaterialTextbox2.Text != bunifuMaterialTextbox4.Text)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPassword Don't Match ");

            }
            else if (bunifuMaterialTextbox3.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Fill First Name ");

            }
            else if (bunifuMaterialTextbox8.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Fill Last Name ");

            }
            else if (bunifuMaterialTextbox5.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Fill Email ");

            }
            else if (bunifuMaterialTextbox10.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Fill Username ");

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
            else if (radioButton1.Checked == null || radioButton2.Checked == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Choose The Gender ");

            }


            else
            {

                string query = "update Doctor set dr_fname='" + this.bunifuMaterialTextbox3.Text + "',dr_lname='" + this.bunifuMaterialTextbox8.Text + "',dr_email='" + this.bunifuMaterialTextbox5.Text + "',dr_password='" + this.bunifuMaterialTextbox2.Text + "',dr_gender='" + newState + "',dr_address='" + this.bunifuMaterialTextbox7.Text + "',dr_phone='" + this.bunifuMaterialTextbox6.Text + "' where dr_username='" + this.bunifuMaterialTextbox10.Text + "' ;";

                con.Open();
               
                SqlCommand cmd1 = new SqlCommand(query, con);
                SqlDataReader reader;
                try
                {
                    //con.Open();
                    reader = cmd1.ExecuteReader();
                    MetroFramework.MetroMessageBox.Show(this, "\n\n\t Doctor " + bunifuMaterialTextbox3.Text + " Edit Succefully ");
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
        // Delete Doctor
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            string mycon = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);

            con.Open();
            string query = "Delete from Doctor where dr_username='" + this.bunifuMaterialTextbox10.Text + "' ;";
            SqlCommand cmd1 = new SqlCommand(query, con);
            cmd1.CommandText = query;
            cmd1.Connection = con;
            cmd1.ExecuteNonQuery();
            MetroFramework.MetroMessageBox.Show(this, "\n\n\t Doctor " + bunifuMaterialTextbox3.Text + " Delete Succefully ");

        }

    }
}