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
    public partial class show_Complaint : UserControl
    {
        public show_Complaint()
        {
            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //show complaint
        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            string myconn = "Data Source=.;Initial Catalog=IS_Project_2017;Integrated Security=True";
            string sql = "SELECT text FROM Complaint where doctor_id = '"+bunifuMaterialTextbox1.Text+"'";
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
            connection.Close();
        }
    }
}
