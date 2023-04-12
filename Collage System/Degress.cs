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
    public partial class Degress : UserControl
    {
        public Degress()
        {
            InitializeComponent();
            fillcombo();
        }
        
        // To Send Complaint
        private void label8_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = true;
            bunifuFlatButton5.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mycon = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            //string queryy = "select * from Course where course_name='" + comboBox1.Text + "';";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            string q1 = "select course_id from course where course_name = '" + this.comboBox1.Text + "'";
            SqlCommand cmd0 = new SqlCommand(q1, con);
            SqlDataReader d = cmd0.ExecuteReader();
            int index = 0;
            while (d.Read())
            {
                index = int.Parse(d[0].ToString());
                label3.Visible = true;
                label3.Text = index.ToString();
            }
            d.Close();

            string q11 = "select grades from Degrees where course_id = '" + index + "' and student_id='"+ this.bunifuMaterialTextbox1.Text + "' ";
            SqlCommand cmd02 = new SqlCommand(q11, con);
            SqlDataReader dd = cmd02.ExecuteReader();
            int index2 = 0;
            while (dd.Read())
            {
                index2 = int.Parse(dd[0].ToString());
                label6.Visible = true;
                label6.Text = index2.ToString();
            }
            dd.Close();

            string q12 = "select doctor_id from Degrees where course_id = '" + index + "' and student_id='" + this.bunifuMaterialTextbox1.Text + "' ";
            SqlCommand cmd22 = new SqlCommand(q12, con);
            SqlDataReader d2 = cmd22.ExecuteReader();
            int index22 = 0;
            while (d2.Read())
            {
                index22 = int.Parse(d2[0].ToString());
                label10.Visible = true;
                label10.Text = index22.ToString();
            }
            d2.Close();
        }
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
        }
        // Complaint Button
        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            string mycon = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            string q1 = "INSERT INTO Complaint (text,doctor_id) values ('" + richTextBox1.Text+"','"+label10.Text+"')";
            SqlCommand cmd0 = new SqlCommand(q1, con);
            SqlDataReader d = cmd0.ExecuteReader();
            int index = 0;
            while (d.Read())
            {
            }
            d.Close();
            MetroFramework.MetroMessageBox.Show(this, "Complaint Send Succefully");

        }
    }
    
}
