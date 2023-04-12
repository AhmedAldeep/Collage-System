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
    public partial class Collage_System : Form
    {
        // Check Internet Connection
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        public Collage_System()
        {
            InitializeComponent();
            timer1.Start();
        }
        // Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime data = DateTime.Now;
            this.Time_lbl.Text = data.ToString();
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
        // Exit Button
        private void Exitp_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
        // Show Student Login Panel
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        { 
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new Student_login());
        }
        // Show Student Resgister Panel
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new Student_Resgister());
        }
        // Show Doctor Panel
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            { 
                ctrl.Dispose();
            }
            panel1.Controls.Add(new Doctor_login());
        }
        // Show Leader Panel
        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new Leader_login());
        }
        // Show Admin Panel
        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new Admin_login());
        }
        // Open Facebook Page 
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            int desc;
            if (InternetGetConnectedState(out desc, 0))
            {
                System.Diagnostics.Process.Start("https://www.facebook.com/fciseg");

            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Please Connect To Internet");
            }
        }
        // Open Google Page
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            int desc;
            if (InternetGetConnectedState(out desc, 0))
            {
                System.Diagnostics.Process.Start("http://cis.asu.edu.eg/");

            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Please Connect To Internet");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
