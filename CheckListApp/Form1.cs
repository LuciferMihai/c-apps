using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckListApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button_login_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button_login_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button_register_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button_register_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label_help.Visible = true;
            pictureBox_close_help.Visible = true;
            pictureBox_close_help.BringToFront();
        }

        public static bool ok_out_hi = false, ok_in_hi = true, ok_in_welcome = true, ok_out_welcome = false;
        int[] targetColor = { 255, 255, 255 }; //white
        public static bool ok_premium;

        private void pictureBox_close_help_Click(object sender, EventArgs e)
        {
            pictureBox_close_help.Visible = false;
            label_help.Visible = false;
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (textbox_password_login.Text == "" || textBox_username_login.Text == "")
            {
                label_complete_fields.Visible = true;
            }
            else
            {
                label_complete_fields.Visible = false;
                label_loading.Visible = true;
                label_loading.BringToFront();
                timer2.Start();
            }
        }
        public static int counter = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            label_welcome.BringToFront();
            label_hi_fadein.BringToFront();
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            counter++; 
            label_point1.BringToFront(); label_point2.BringToFront(); label_point3.BringToFront();
            if (label_point1.Visible && label_point2.Visible && label_point3.Visible)
            {
                label_point1.Visible = false;
                label_point2.Visible = false;
                label_point3.Visible = false;
            }
            else if (label_point1.Visible && label_point2.Visible && !label_point3.Visible)
            {
                label_point3.Visible = true;
            }
            else if (label_point1.Visible && !label_point2.Visible && !label_point3.Visible)
            {
                label_point2.Visible = true;
            }
            else if (!label_point1.Visible && !label_point2.Visible && !label_point3.Visible) label_point1.Visible = true;
            if(counter%10==0)
            {
                label_loading.Visible = false;
                label_point1.Visible = false;
                label_point2.Visible = false;
                label_point3.Visible = false;
                timer2.Stop();
            }
        }

        private void label_returntologin_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void label_returntologin_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button_signin_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button_signin_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button_clear_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button_clear_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void checkBox_tc_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void checkBox_tc_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox_free_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            label_free_present.BackColor = Color.LimeGreen;
            label_free_present.ForeColor = Color.White;
        }

        private void pictureBox_free_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            label_free_present.BackColor = Color.White;
            label_free_present.ForeColor = Color.Black;
        }

        private void pictureBox_premium_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            label_premium_present.BackColor = Color.Maroon;
            label_premium_present.ForeColor = Color.White;
        }

        private void pictureBox_premium_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            label_premium_present.BackColor = Color.White;
            label_premium_present.ForeColor = Color.Black;
        }

        private void pictureBox_premium_Click(object sender, EventArgs e)
        {
            ok_premium = true;

            string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\stanl\source\repos\checkliapp\checkliapp\Database1.mdf;Integrated Security=True";
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                SqlCommand sqlcmd = new SqlCommand("UserAdd", sqlCon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@FirstName", textBox_register_firstname.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@LastName", textBox_register_lastname.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@Email", textBox_register_email.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@Username", textBox_register_username.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@Password", textBox_register_password.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@Premium", 1);
                sqlcmd.ExecuteNonQuery();

                MessageBox.Show("Your account have been created with successfully. You will receive and email");
                sqlCon.Close();
            }
        }

        private void pictureBox_free_Click(object sender, EventArgs e)
        {
            ok_premium = false;
        }

        private void button_signin_Click(object sender, EventArgs e)
        {
            if (!checkBox_tc.Checked||textBox_register_firstname.Text == "" || textBox_register_lastname.Text == "" || textBox_register_password.Text == "" || textBox_register_username.Text == "" || textBox_register_email.Text == "")
            {
                MessageBox.Show("                        Please complete all fields,\r\n   read the terms and conditions and check the box.");
            }
            else
            {
                label_choosepremium.Visible = true;
                label_choosepremium.BringToFront();
                pictureBox_free.Visible = true;
                pictureBox_free.BringToFront();
                pictureBox_premium.Visible = true;
                pictureBox_premium.BringToFront();
                label_free_present.Visible = true;
                label_free_present.BringToFront();
                label_premium_present.Visible = true;
                label_premium_present.BringToFront();
                label_editfields.Visible = true;
                label_editfields.BringToFront();
            }
        }

        private void label_editfields_Click(object sender, EventArgs e)
        {
            label_choosepremium.Visible = false;
            pictureBox_free.Visible = false;
            pictureBox_premium.Visible = false;
            label_free_present.Visible = false;
            label_premium_present.Visible = false;
            label_editfields.Visible = false;
        }

        private void label_editfields_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            label_editfields.BackColor = Color.Snow;
        }

        private void label_editfields_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            label_editfields.BackColor = Color.White;
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_register_firstname.Text = "";
            textBox_register_lastname.Text = "";
            textBox_register_email.Text = "";
            textBox_register_password.Text = "";
            textBox_register_username.Text = "";
            checkBox_tc.Checked = false;
        }

        //dark orange 255,140,0
        int[] fadeRGB = new int[3];
        private void timer1_Tick(object sender, EventArgs e)
        {
            fadeIn();
        }
        void fadeIn()
        {
            if (ok_in_hi)
            {
                fadeRGB[0] = label_hi_fadein.ForeColor.R;
                fadeRGB[1] = label_hi_fadein.ForeColor.G;
                fadeRGB[2] = label_hi_fadein.ForeColor.B;

                if (fadeRGB[0] > targetColor[0]) fadeRGB[0]--;
                else if (fadeRGB[0] < targetColor[0]) fadeRGB[0]++;
                if (fadeRGB[1] > targetColor[1]) fadeRGB[1]--;
                else if (fadeRGB[1] < targetColor[1]) fadeRGB[1]++;
                if (fadeRGB[2] > targetColor[2]) fadeRGB[2]--;
                else if (fadeRGB[2] < targetColor[2]) fadeRGB[2]++;
                if (fadeRGB[0] == targetColor[0] && fadeRGB[1] == targetColor[1] && fadeRGB[2] == targetColor[2])
                {
                    ok_out_hi = true;
                    ok_in_hi = false;
                }
                label_hi_fadein.ForeColor = Color.FromArgb(fadeRGB[0], fadeRGB[1], fadeRGB[2]);
            }
            if (ok_out_hi)
            {
                fadeRGB[0] = label_hi_fadein.ForeColor.R;
                fadeRGB[1] = label_hi_fadein.ForeColor.G;
                fadeRGB[2] = label_hi_fadein.ForeColor.B;

                if (fadeRGB[0] > 255) fadeRGB[0]--;
                else if (fadeRGB[0] < 255) fadeRGB[0]++;
                if (fadeRGB[1] > 140) fadeRGB[1]--;
                else if (fadeRGB[1] < 140) fadeRGB[1]++;
                if (fadeRGB[2] > 0) fadeRGB[2]--;
                else if (fadeRGB[2] < 0) fadeRGB[2]++;
                if (fadeRGB[0] == 255 && fadeRGB[1] == 140 && fadeRGB[2] == 0)
                {
                    label_hi_fadein.Visible = false;
                    label_welcome.BringToFront();
                    ok_out_hi = false;
                }
                label_hi_fadein.ForeColor = Color.FromArgb(fadeRGB[0], fadeRGB[1], fadeRGB[2]);
            }
            if (!ok_in_hi && !ok_out_hi)
            {
                label_welcome.Visible = true;
                if (ok_in_welcome)
                {
                    fadeRGB[0] = label_welcome.ForeColor.R;
                    fadeRGB[1] = label_welcome.ForeColor.G;
                    fadeRGB[2] = label_welcome.ForeColor.B;

                    if (fadeRGB[0] > targetColor[0]) fadeRGB[0]--;
                    else if (fadeRGB[0] < targetColor[0]) fadeRGB[0]++;
                    if (fadeRGB[1] > targetColor[1]) fadeRGB[1]--;
                    else if (fadeRGB[1] < targetColor[1]) fadeRGB[1]++;
                    if (fadeRGB[2] > targetColor[2]) fadeRGB[2]--;
                    else if (fadeRGB[2] < targetColor[2]) fadeRGB[2]++;
                    if (fadeRGB[0] == targetColor[0] && fadeRGB[1] == targetColor[1] && fadeRGB[2] == targetColor[2])
                    {
                        ok_out_welcome = true;
                        ok_in_welcome = false;
                    }
                    label_welcome.ForeColor = Color.FromArgb(fadeRGB[0], fadeRGB[1], fadeRGB[2]);
                }
                if (ok_out_welcome)
                {
                    fadeRGB[0] = label_welcome.ForeColor.R;
                    fadeRGB[1] = label_welcome.ForeColor.G;
                    fadeRGB[2] = label_welcome.ForeColor.B;

                    if (fadeRGB[0] > 255) fadeRGB[0]--;
                    else if (fadeRGB[0] < 255) fadeRGB[0]++;
                    if (fadeRGB[1] > 140) fadeRGB[1]--;
                    else if (fadeRGB[1] < 140) fadeRGB[1]++;
                    if (fadeRGB[2] > 0) fadeRGB[2]--;
                    else if (fadeRGB[2] < 0) fadeRGB[2]++;
                    if (fadeRGB[0] == 255 && fadeRGB[1] == 140 && fadeRGB[2] == 0)
                    {
                        timer1.Stop();
                        label_welcome.Visible = false;
                        ok_out_welcome = false;
                    }
                    label_welcome.ForeColor = Color.FromArgb(fadeRGB[0], fadeRGB[1], fadeRGB[2]);
                }
            }
        }
    }
}
