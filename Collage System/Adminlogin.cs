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
    public partial class Adminlogin : Form
    {
        public Adminlogin()
        {
            
            InitializeComponent();
            timer1.Start();
        }
        // Exit Button
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        // Maximize Button
        private void Max_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }
        // Minimize Button
        private void Min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        // Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime data = DateTime.Now;
            this.Time_lbl.Text = data.ToString();
        }
        //Sign out 
        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            Adminlogin al = new Adminlogin();
            al.Close();
            Collage_System cs = new Collage_System();
            cs.Show();
        }
        // Open Doctor Panel
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new admin_Dr());
        }
        // Open Leader Panel 
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new admin_leader());
        }
        // Open Student Panel
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new admin_student());
        }
        // Open Change Password Panel
        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new admin_pss());
        }
        // Open Course Panel
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new admin_course());
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
    }
}
