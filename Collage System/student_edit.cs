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
    public partial class student_edit : UserControl
    {
        public student_edit()
        {
            InitializeComponent();
            cfillchecked();
        }
        // Student Edit Information 
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
            }


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
            else
            {

                string query = "update student set email='" + this.bunifuMaterialTextbox5.Text + "',age='" + this.bunifuMaterialTextbox9.Text + "',password='" + this.bunifuMaterialTextbox2.Text + "',address='" + this.bunifuMaterialTextbox7.Text + "',phone='" + this.bunifuMaterialTextbox6.Text + "' where username ='" + this.bunifuMaterialTextbox1.Text + "' ;";

                con.Open();
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
                string Q = "update co_st_take set course1='" + r1 + "',course2='" + r2 + "',course3='" + r3 + "',course4='" + r4 + "' where student_id='"+index+"' ";
                SqlCommand cmd2 = new SqlCommand(Q, con);
                try
                {
                    cmd2.ExecuteNonQuery();
                    MetroFramework.MetroMessageBox.Show(this, "\n\n\t Edit Done  ");
                }
                catch (Exception ex)
                {
                    MetroFramework.MetroMessageBox.Show(this, ex.Message);
                }
            }
            con.Close();

        }
    
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
    }
}
