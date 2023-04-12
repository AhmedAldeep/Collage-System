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
    public partial class LinkDrWithCourse : UserControl
    {
        public LinkDrWithCourse()
        {
            InitializeComponent();

            fillcombod();
            fillcombo();

        }

        // Fill ComboBox1 With Course Name
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
                reader.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }

            con.Close();
        }
        // Fill ComboBox2 With Doctor Name
        void fillcombod()
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
                    comboBox2.Items.Add(u);
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
            con.Close();
        }
        // Show Course Information Into Labels For Course
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mycon = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            string queryy = "select * from Course where course_name='" + comboBox1.Text + "';";
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
                    label7.Visible = true;
                    label9.Visible = true;
                    label9.Text = id;
                    label7.Text = name;

                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
            con.Close();
        }
        // Show Course Information Into Labels For Doctor
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mycon = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            string queryy = "select * from Doctor where dr_username='" + comboBox2.Text + "';";
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
                    string name = (string)reader["dr_username"].ToString();
                    label6.Visible = true;
                    label12.Visible = true;
                    label6.Text = id;
                    label12.Text = name;

                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
            con.Close();
        }
        // Link Doctor with course
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            string mycon = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            SqlConnection conn = new SqlConnection(mycon);
            conn.Open();
            string query = "update Course set doctor_id = '" + this.label6.Text + "' where course_id ='" + label9.Text + "' ";
            SqlCommand cmd1 = new SqlCommand(query, conn);
            try
            {
                cmd1.ExecuteNonQuery();
                MetroFramework.MetroMessageBox.Show(this, "Doctor "+label12.Text+" Will Be Teach "+label7.Text+ " Module");
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
    }
}
