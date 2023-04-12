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
using System.Data.Sql;
namespace IS_PROJECT_17
{
    public partial class admin_course : UserControl
    {
        public admin_course()
        {
            InitializeComponent();
            lfillchecked();
            cfillchecked();
            fillcombo();
        }
        // Add Button
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string r1 = null;
            string r2 = null;
            string r3 = null;
            string r4 = null;
            for ( int i =0; i < checkedListBox1.CheckedItems.Count; i++)
            { 
                if(i==0)
                    r1=checkedListBox1.CheckedItems[i].ToString();
                if (i == 1)
                    r2 = checkedListBox1.CheckedItems[i].ToString();
                if (i == 2)
                    r3 = checkedListBox1.CheckedItems[i].ToString();
                if (i == 3)
                    r4 = checkedListBox1.CheckedItems[i].ToString();
            }

            /////////////
            string mycon = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            SqlConnection conn = new SqlConnection(mycon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select course_name from [Course]", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader re = cmd.ExecuteReader();
            while (re.Read())
            {
                if (re["course_name"].ToString() == bunifuMaterialTextbox1.Text)
                {
                    flag = true;
                    break;
                }
            }

            re.Close();
            if (flag == true)
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tThe Course Name is already Exist ");
            else
            {
                string query = "insert into course (course_name,course_price,course_leader) Values ('" + this.bunifuMaterialTextbox1.Text + "','" + this.bunifuMaterialTextbox3.Text + "','" + this.checkedListBox3.Text + "') ";
                SqlCommand cmd1 = new SqlCommand(query, conn);
                try
                {
                    //conn.Open();
                    cmd1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MetroFramework.MetroMessageBox.Show(this, ex.Message);
                }
                string q1 = "select course_id from course where course_name = '" + this.bunifuMaterialTextbox1.Text + "'";
                SqlCommand cmd0 = new SqlCommand(q1, conn);
                SqlDataReader d = cmd0.ExecuteReader();
                int index = 0;
                while (d.Read())
                {
                    index = int.Parse(d[0].ToString());
                }
                d.Close();
                string Q = "Insert into CoursePrerequistes (course_id,Prerequistes1,Prerequsites2,Prerequistes3,Prerequistes4) Values ('" + index + "','" + r1 + "','" + r2 + "','" + r3 + "','" + r4 + "') ";
                SqlCommand cmd2 = new SqlCommand(Q, conn);
                try
                {
                    cmd2.ExecuteNonQuery();
                    MetroFramework.MetroMessageBox.Show(this, "\n\n\tNew Course Add Succefully ");
                }
                catch (Exception ex)
                {
                    MetroFramework.MetroMessageBox.Show(this, ex.Message);
                }
            }
            conn.Close();
        }
        // Fill Checkbox For Leader from database
        void lfillchecked()
        {
            string mycon = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            string queryy = "select * from Leader;";
            SqlConnection con = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand(queryy, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string u = (string)reader["l_username"].ToString();
                    checkedListBox3.Items.Add(u);
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        // Fill ComboBox With Course Name
        void fillcombo()
        {
            string mycon = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            string queryy = "select * from course;";
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
                    comboBox1.Items.Add(u);
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }


        }
        // Fill Checkbox for course Req from Database
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
        // Edit Button
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
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
                //MessageBox.Show(checkedListBox1.CheckedItems.Count.ToString());

            }

            string mycon = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            SqlConnection conn = new SqlConnection(mycon);
            string query = "Update course set course_price='" + this.bunifuMaterialTextbox3.Text + "',course_leader='" + this.checkedListBox3.Text + "' Where course_name='" + this.bunifuMaterialTextbox1.Text + "';";
            SqlCommand cmd1 = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                cmd1.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
            string q1 = "select course_id from course where course_name = '" + this.bunifuMaterialTextbox1.Text + "'";
            SqlCommand cmd0 = new SqlCommand(q1, conn);
            SqlDataReader d = cmd0.ExecuteReader();
            int index = 0;
            while (d.Read())
            {
                index = int.Parse(d[0].ToString());
            }
            d.Close();
            string Q = "update CoursePrerequistes set Prerequistes1='" + r1 + "',Prerequsites2='" + r2 + "',Prerequistes3='" + r3 + "',Prerequistes4='" + r4 + "' where course_id='" + index + "';";
            SqlCommand cmd2 = new SqlCommand(Q, conn);
            try
            {
                cmd2.ExecuteNonQuery();
                MetroFramework.MetroMessageBox.Show(this, "\n\n\t Course Edit Succefully ");
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
            conn.Close();
        }
        // Fill Textbox by select item in combobox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mycon = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            string queryy = "select * from Course where course_name='" + comboBox1.Text + "';";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand(queryy, con);
            SqlDataReader reader;
            try
            {

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string id = (string)reader["course_id"].ToString();
                    string name = (string)reader["course_name"].ToString();
                    string price = (string)reader["course_price"].ToString();
                    string leader = (string)reader["course_leader"].ToString();

                    label8.Text = id;
                    bunifuMaterialTextbox1.Text = name;
                    bunifuMaterialTextbox3.Text = price;
                    label6.Text = leader;
                    label6.Visible = true;
                    label8.Visible = true;

                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
            con.Close();
        }
        // Delete Button
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            string mycon = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            // Take the Course Id 
            string q1 = "select course_id from course where course_name = '" + this.bunifuMaterialTextbox1.Text + "';";
            SqlCommand cmd0 = new SqlCommand(q1, con);
            SqlDataReader d = cmd0.ExecuteReader();
            int index = 0;
            while (d.Read())
            {
                index = int.Parse(d[0].ToString());
            }
            d.Close();
            // Delete Course By Course Name
            string query = "Delete from Course where course_name='" + this.bunifuMaterialTextbox1.Text + "' ;";
            SqlCommand cmd1 = new SqlCommand(query, con);
            cmd1.CommandText = query;
            cmd1.Connection = con;
            cmd1.ExecuteNonQuery();
            con.Close();
            con.Open();
            // Delete The Prerequistes For the Course Which the admin choose it From Sql
            string Q = "Delete from CoursePrerequistes where Course_ID ='" + index + "';";
            SqlCommand cmd2 = new SqlCommand(Q, con);
            cmd2.CommandText = Q;
            cmd2.Connection = con;
            cmd2.ExecuteNonQuery();
            MetroFramework.MetroMessageBox.Show(this, "\n\n\t Course " + bunifuMaterialTextbox1.Text + " Delete Succefully ");

        }

    }
}
