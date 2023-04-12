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
    public partial class add_degrees : UserControl
    {
        public add_degrees()
        {
            InitializeComponent();
            fillcombo();
            fillscombo();
        }
        // Fill Module Combo Box
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
        // Fill Student Combo Box
        void fillscombo()
        {
            string mycon = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            string queryy = "select * from student;";
            SqlConnection con = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand(queryy, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string u = (string)reader["username"].ToString();
                    comboBox2.Items.Add(u);
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        // Show Data In Textbox For ComboBox
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
                    label7.Text = name;
                    label9.Text = id; 
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }

        }
        // Show Data In Textbox For ComboBox
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mycon = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            string queryy = "select * from student where username='" + comboBox2.Text + "';";
            SqlConnection con = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand(queryy, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string id = (string)reader["student_id"].ToString();
                    label6.Visible = true;
                    label6.Text = id;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }

        }
        // ADD DEGRESS BUTTON
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            string mypath = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            SqlConnection con = new SqlConnection(mypath);
            con.Open();
            string query = "INSERT INTO Degrees (student_id,course_id,grades,doctor_id) Values ('" + label6.Text+"','"+label9.Text+"','"+bunifuMaterialTextbox5.Text+ "','" + bunifuMaterialTextbox1.Text + "')";
            SqlCommand cmd = new SqlCommand(query,con);
            SqlDataReader reader;
            try
            { 
                reader = cmd.ExecuteReader();
                MetroFramework.MetroMessageBox.Show(this, "\n\n\t Degrees Send Succefully ");
                while (reader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }

        }

        private void add_degrees_Load(object sender, EventArgs e)
        {

        }
    }
}
