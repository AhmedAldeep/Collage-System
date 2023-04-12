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
    public partial class Course_list : UserControl
    {
        public Course_list()
        {
            InitializeComponent();
            fillcombo();
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
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        // Show Course Information Into Labels And DataGridView
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
                    dataGridView1.Visible = true;
                    dataGridView2.Visible = true;
                    
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
            
            con.Close();
            
            //Show the Data In module Table In Data Grid View (1)
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
            con.Close();
            //Show the Data In Doctor Table In Data Grid View (2)
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

            string sql2 = "SELECT dr_id,dr_fname,dr_lname,dr_email from doctor where dr_id = '"+index+"'";
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
    }
}
