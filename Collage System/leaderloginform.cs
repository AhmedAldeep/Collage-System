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
    public partial class leaderloginform : Form
    {
        // Check Internet Connection
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        public leaderloginform()
        {
            InitializeComponent();
        }
        // Sign Out
        private void Exitp_Click(object sender, EventArgs e)
        {
            leaderloginform al = new leaderloginform();
            al.Close();
            Collage_System cs = new Collage_System();
            cs.Show();
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
        // Up Button
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
        // Show Course List Panel
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new Course_list());
        }
        // Add , Edit ,delete Doctors
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new admin_Dr());
        }
        //Timer
        private void Time_lbl_Click(object sender, EventArgs e)
        {

            DateTime data = DateTime.Now;
            this.Time_lbl.Text = data.ToString();
        }
        // Show Doctor Email and Phone User Control
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new doc_email_forleader());
        }
        // Show Link Doctor With Course User Control
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new LinkDrWithCourse());
        }
        // Show Leader Edit Information User Control
        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new leaderedit());
        }
    }

}
