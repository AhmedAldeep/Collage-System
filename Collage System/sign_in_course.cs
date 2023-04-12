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
    public partial class sign_in_course : UserControl
    {
        public sign_in_course()
        {
            InitializeComponent();
            fillcombo();
        }
        string courseName = string.Empty;
        // Show Course Information Into Labels And DataGridView
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mycon = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            string queryy = "select * from Course where course_name='" + comboBox1.Text + "';";
            courseName = comboBox1.Text;
            SqlConnection con = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand(queryy, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string id = (string)reader["course_id"].ToString();
                    string name = (string)reader["course_name"].ToString();
                    string price = (string)reader["course_price"].ToString();
                    string leader = (string)reader["course_leader"].ToString();
                    label5.Visible = true;
                    label7.Visible = true;
                    label9.Visible = true;
                    label10.Visible = true;
                    label11.Visible = true;
                    label5.Text = id;
                    label7.Text = name;
                    label9.Text = price;
                    label11.Text = leader;

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
            con.Close();
            //Show Data In Data Grid View
            string myconn = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            string sql = "SELECT * FROM CoursePrerequistes where Course_id = '" + label5.Text + "' ";
            SqlConnection connection = new SqlConnection(myconn);
            connection.Open();
            SqlCommand s = new SqlCommand(sql, connection);
            SqlDataAdapter sa = new SqlDataAdapter(s);
            DataTable da = new DataTable();
            sa.Fill(da);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = da;
            SqlCommandBuilder sb = new SqlCommandBuilder(sa);
            dataGridView1.DataSource = bsource;
            sa.Update(da);

            // Doctor Data Grid View
            string myconnn = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            string sqll = "SELECT doctor_id FROM Course where Course_id = '" + label5.Text + "' ";
            SqlConnection connectionn = new SqlConnection(myconnn);
            SqlCommand cmd0 = new SqlCommand(sqll, connectionn);
            connectionn.Open();
            SqlDataReader d = cmd0.ExecuteReader();
            int index = 0;
            while (d.Read())
            {
                index = int.Parse(d[0].ToString());
            }
            d.Close();
            connectionn.Close();
            string sql2 = "SELECT dr_id,dr_fname,dr_lname,dr_email from doctor where dr_id = '" + index + "'";
            SqlConnection connectionnn = new SqlConnection(myconnn);
            connectionnn.Open();
            SqlCommand ss = new SqlCommand(sql2, connectionnn);
            SqlDataAdapter saa = new SqlDataAdapter(ss);
            DataTable daa = new DataTable();
            saa.Fill(daa);
            BindingSource bbsource = new BindingSource();
            bbsource.DataSource = daa;
            SqlCommandBuilder sbb = new SqlCommandBuilder(saa);
            dataGridView2.DataSource = bbsource;
            saa.Update(daa);


        }
        // Fill Combo Box With Course Name
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
        // SIGN UP IN NEW COURSE
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            string p1 = null, p2 = null, p3 = null, p4 = null;
            string c1 = null, c2 = null, c3 = null, c4 = null;
            string idd = label5.Text;
            string s_u = bunifuMaterialTextbox1.Text;
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True");
            con.Open();
            string query = "select student_id from student where username = '" + this.bunifuMaterialTextbox1.Text + "'";
            SqlCommand cmd0 = new SqlCommand(query, con);
            SqlDataReader d = cmd0.ExecuteReader();
            int index = 0;
            while (d.Read())
            {
                index = int.Parse(d[0].ToString());
            }
            d.Close();
            string q1 = "select course1 , course2 , course3 ,course4 from co_st_take where student_id = '" + index + "'";
            SqlCommand cmd = new SqlCommand(q1, con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // student courses
                c1 = (string)reader["course1"].ToString();
                c2 = (string)reader["course2"].ToString();
                c3 = (string)reader["course3"].ToString();
                c4 = (string)reader["course4"].ToString();

            }
            reader.Close();
                string q11 = "select * from CoursePrerequistes where Course_ID = '" + label5.Text + "'";
                SqlCommand cmd2 = new SqlCommand(q11, con);
                SqlDataReader reader2;
                reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    // requirements courses
                    p1 = (string)reader2[1].ToString();
                    p2 = (string)reader2[2].ToString();
                    p3 = (string)reader2[3].ToString();
                    p4 = (string)reader2[4].ToString();

                }
            /*int counter = 0;
            if (p1 == c1 || p1 == c2 || p1 == c3 || p1 == c4)
            {
                counter++;
            }*/

            int count = 0;
            if (c1 != string.Empty && p1 != string.Empty)
            {
                if (c1 == p1)
                {
                    count++;
                }
            }
            if (c1 != string.Empty && p2 != string.Empty)
            {
                if (c1 == p2)
                {
                    count++;
                }
            }
            if (c1 != string.Empty && p3 != string.Empty)
            {
                if (c1 == p3)
                {
                    count++;
                }
            }

            if (c1 != string.Empty && p4 != string.Empty)
            {
                if (c1 == p4)
                {
                    count++;
                }
            }
            // C1 FINISH C2 STRAT
            if (c2 != string.Empty && p1 != string.Empty)
            {
                if (c2 == p1)
                {
                    count++;
                }
            }

            if (c2 != string.Empty && p2 != string.Empty)
            {
                if (c2 == p2)
                {
                    count++;
                }
            }

            if (c2 != string.Empty && p3 != string.Empty)
            {
                if (c2 == p3)
                {
                    count++;
                }
            }

            if (c2 != string.Empty && p4 != string.Empty)
            {
                if (c2 == p4)
                {
                    count++;
                }
            }
            // C2 FINISH C3 STRAT

            if (c3 != string.Empty && p1 != string.Empty)
            {
                if (c3 == p1)
                {
                    count++;
                }
            }

            if (c3 != string.Empty && p2 != string.Empty)
            {
                if (c3 == p2)
                {
                    count++;
                }
            }

            if (c3 != string.Empty && p3 != string.Empty)
            {
                if (c3 == p3)
                {
                    count++;
                }
            }

            if (c3 != string.Empty && p4 != string.Empty)
            {
                if (c3 == p4)
                {
                    count++;
                }
            }
            // C3 FINISH C4 STRAT

            if (c4 != string.Empty && p1 != string.Empty)
            {
                if (c4 == p1)
                {
                    count++;
                }
            }

            if (c4 != string.Empty && p2 != string.Empty)
            {
                if (c4 == p2)
                {
                    count++;
                }
            }

            if (c4 != string.Empty && p3 != string.Empty)
            {
                if (c4 == p3)
                {
                    count++;
                }
            }

            if (c4 != string.Empty && p4 != string.Empty)
            {
                if (c4 == p4)
                {
                    count++;
                }
            }
            reader2.Close();
            // Know The Number Of Course Requirements
            int count1 = 0;
            if(p1!= string.Empty)
            {
                count1++;
            }
            if (p2 != string.Empty)
            {
                count1++;
            }
            if (p3 != string.Empty)
            {
                count1++;
            }
            if (p4 != string.Empty)
            {
                count1++;
            }

            if (count == (count1))
            {
                    string q21 = "insert into student_course (student_id ,course_id) values ('" + index + "','" + label5.Text+"') ";
                    SqlCommand cmd21 = new SqlCommand(q21, con);
                    SqlDataReader reader21;
                    reader21 = cmd21.ExecuteReader();
                    
            

                MetroFramework.MetroMessageBox.Show(this, "\n\n\tSIGN IN " + label7.Text + "DONE");
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tThis course needs some requirements If you wish to participate in this course you must study these requirements ");
            }


        }

        private void sign_in_course_Load(object sender, EventArgs e)
        {

        }
    }
}
