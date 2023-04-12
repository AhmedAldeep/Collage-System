using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_PROJECT_17
{
    public partial class student_form_login : Form
    {
        public student_form_login()
        {
            InitializeComponent();
            timer1.Start();
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
        // Exit
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // Maxiamize
        private void Max_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }
        // Miniamize
        private void Min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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
        // Open Doctors Email Panel
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new Doctors_email());
        }
        // Open Leaders Email Panel
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new Leader_Email());
        }
        // Open Edit User Control
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new student_edit());
        }
        // Sign Out
        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {

            Collage_System cs = new Collage_System();
            cs.Show();

            student_form_login sl = new student_form_login();
            sl.Close();
        }
        // Open Course User Control
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new sign_in_course());
        }
        // Degrees Button
        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new Degress());
        }
    }
}
