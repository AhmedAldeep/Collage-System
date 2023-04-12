using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Web;
using System.Data.SqlClient;

namespace IS_PROJECT_17
{
    public partial class doctor_loginform : Form
    {
        // Check Internet Connection
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        public doctor_loginform()
        {
            InitializeComponent();
            timer1.Start();
        }
        // Exit
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // Maximize
        private void Max_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }
        // Minimize
        private void Min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        // UP Button
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == true)
            {
                panel3.Visible = false;
                pictureBox11.Visible = false;
                pictureBox10.Visible = true;
            }
            else
            {
                panel3.Visible = true;
            }
        }
        // Down Button
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == false)
            {
                panel3.Visible = true;
                pictureBox11.Visible = true;
                pictureBox10.Visible = false;
            }
            else
            {
                panel3.Visible = false;
            }
        }
        // Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime data = DateTime.Now;
            this.Time_lbl.Text = data.ToString();
        }
        // Sign Out
        private void Exitp_Click(object sender, EventArgs e)
        {
            doctor_loginform al = new doctor_loginform();
            al.Close();
            Collage_System cs = new Collage_System();
            cs.Show();
        }
        // Show Course List Panel
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new Course_list());
        }
        // Add Student
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new admin_student());
        }
        // Show Leader Email
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new d_leaderemail());
        }
        // Edit Doctor Information
        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new doctoredit());
        }
        // Complaint Button
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new show_Complaint());
        }
        // Add Degrees
        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new add_degrees());
        }
    }
}
