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
    public partial class Student_Resgister : UserControl
    {
        public Student_Resgister()
        {
            InitializeComponent();
            cfillchecked();
        }
        // Register Button
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            bool flag = false;

            string r1 = null;
            string r2 = null;
            string r3 = null;
            string r4 = null;
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                if (i == 0)
                    r1 = checkedListBox1.CheckedItems[i].ToString();
                if (i == 1)
                    r2 = checkedListBox1.CheckedItems[i].ToString();
                if (i == 2)
                    r3 = checkedListBox1.CheckedItems[i].ToString();
                if (i == 3)
                    r4 = checkedListBox1.CheckedItems[i].ToString();
            }


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
            else if (bunifuMaterialTextbox1.Text == null)
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
            else if (bunifuMaterialTextbox9.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Fill Age ");

            }
            else if (radioButton1.Checked == null || radioButton2.Checked == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Choose The Gender ");

            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select username from [student]", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader re = cmd.ExecuteReader();
                while (re.Read())
                {
                    if (re["username"].ToString() == bunifuMaterialTextbox1.Text)
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

                    string query = "insert into student (firstname ,lastname, age,phone,address,email,username,password,gender) Values ('" + this.bunifuMaterialTextbox3.Text + "','" + this.bunifuMaterialTextbox8.Text + "','" + this.bunifuMaterialTextbox9.Text + "','" + this.bunifuMaterialTextbox6.Text + "','" + this.bunifuMaterialTextbox7.Text + "','" + this.bunifuMaterialTextbox5.Text + "','" + this.bunifuMaterialTextbox1.Text + "','" + this.bunifuMaterialTextbox2.Text + "','" + newState + "') ";
                    SqlCommand cmd1 = new SqlCommand(query, con);
                    SqlDataReader reader;
                    try
                    {
                        //con.Open();
                        reader = cmd1.ExecuteReader();
                        
                        while (reader.Read())
                        {

                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MetroFramework.MetroMessageBox.Show(this, ex.Message);
                    }
                    
                    string q1 = "select student_id from student where username = '" + this.bunifuMaterialTextbox1.Text + "'";
                    SqlCommand cmd0 = new SqlCommand(q1, con);
                    SqlDataReader d = cmd0.ExecuteReader();
                    int index = 0;
                    while (d.Read())
                    {
                        index = int.Parse(d[0].ToString());
                    }
                    d.Close();
                    string Q = "Insert into co_st_take (student_id,course1,course2,course3,course4) Values ('" + index + "','" + r1 + "','" + r2 + "','" + r3 + "','" + r4 + "') ";
                    SqlCommand cmd2 = new SqlCommand(Q, con);
                    try
                    {
                        cmd2.ExecuteNonQuery();
                        MetroFramework.MetroMessageBox.Show(this, "\n\n\tResgister Complete  ");
                    }
                    catch (Exception ex)
                    {
                        MetroFramework.MetroMessageBox.Show(this, ex.Message);
                    }
                }
                con.Close();

            }


        }
        // Fill Checkbox for course from Database
        void cfillchecked()
        {
            string mycon = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            string queryy = "select * from Course;";
            SqlConnection con = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand(queryy, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string u = (string)reader["course_name"].ToString();
                    checkedListBox1.Items.Add(u);
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }

        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
    
    

    //MetroFramework.MetroMessageBox.Show(this, " Your ID : " +studentidcount );
}
