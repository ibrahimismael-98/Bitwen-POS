using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

namespace Bitwen_Company
{
    public partial class Login : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Database.mdf;Integrated Security=True;Connect Timeout=30");

        public static SqlConnection con = new SqlConnection(Properties.Settings.Default.DatabaseConnectionString);

        public static string user_pass_name;
        public static string user_pass_Type;

        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 60, 60));
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
             int nLeftRect,
             int nTopRect,
             int nRightRect,
             int nBottomRect,
             int nWidthEllipse,
             int nHeightEllipse
        );

        private void login_exit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void forgot_password_LinkLable_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login_timer.Start();
        }

        Boolean merc;
        int zhmare;

        private void log_login_button_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            merc = int.TryParse(login_email.Text, out zhmare);
            if (login_email.Text == "" || login_password.Text == "")
            {
                if (login_email.Text == "")
                {
                    Interaction.Beep();
                    errorProvider1.SetError(login_email, ".تکایە خانەی ئیمەیڵ پڕبکەرەوە");
                }
                else if (login_password.Text == "")
                {
                    Interaction.Beep();
                    errorProvider1.SetError(login_password, ".تکایە خانەی وشەی نهێنی پڕبکەرەوە");
                }
            }
            else if (login_password.Text.Length < 5)
            {
                Interaction.Beep();
                errorProvider1.SetError(login_password, ".وشەی نهێنی نابێت لە ٥ پیت کەمتربێت");
            }
            else
            {
                    SqlDataAdapter sda = new SqlDataAdapter("select * from Employees where Email=N'" + login_email.Text + "' and Password=N'" + login_password.Text + "'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                        con.Open();
                        SqlCommand scom = new SqlCommand("select * from Employees where Email =N'" + login_email.Text + "' and Password =N'" + login_password.Text + "'", con);
                        SqlDataReader reader = scom.ExecuteReader();
                        reader.Read();
                        user_pass_name = reader["Employees_Name"].ToString();
                        user_pass_Type = reader["Type"].ToString();
                        con.Close();

                        Home mainform = new Home();
                        mainform.Show();
                        this.Hide();
                    }
                    else if (dt.Rows.Count != 1)
                    {
                        MessageBox.Show(".ئیمەیڵ یان وشەی نهێنی داخڵکراو هەڵەیە", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private void login_timer_Tick(object sender, EventArgs e)
        {
            Login_panel.Left += 40;
            forgot_panel.Left -= 40;
            if (forgot_panel.Left <= 770)
            {
                login_timer.Stop();
            }
        }

        //////   بەبیرهێنانەوەی وشەی نهێنی

        private void find_password_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            merc = int.TryParse(forgot_email.Text, out zhmare);
            if (forgot_name.Text == "" || forgot_phone.Text == "" || forgot_email.Text == "")
            {
                if (forgot_name.Text == "")
                {
                    Interaction.Beep();
                    errorProvider1.SetError(forgot_name, ".تکایە خانەی ناوی بە کارهێنەر پڕبکەرەوە");
                }
                else if (forgot_email.Text == "")
                {
                    Interaction.Beep();
                    errorProvider1.SetError(forgot_email, ".تکایە خانەی ئیمەیڵ پڕبکەرەوە");
                }
                else if (forgot_phone.Text == "")
                {
                    Interaction.Beep();
                    errorProvider1.SetError(forgot_phone, ".تکایە خانەی ژمارەی تەلەفۆن پڕبکەرەوە");
                }
            }
            else if (forgot_phone.Text.Length < 11)
            {
                Interaction.Beep();
                errorProvider1.SetError(forgot_phone, ".ژمارەی مۆبایل نابێت لە ١١ ژمارە کەمتربێت");
            }
            else if (merc == true)
            {
                Interaction.Beep();
                errorProvider1.SetError(forgot_phone, "خانەی ژمارەی مۆبایل مەرجە تەنها پڕبکرێتەوە بە ژمارە ");
            }

            SqlDataAdapter sda = new SqlDataAdapter("select * from Employees where Employees_Name=N'" + forgot_name.Text + "'and Phone='" + forgot_phone.Text + "'and Email=N'" + forgot_email.Text + "'and Birthday='" + birthdate_TimePicker.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                Label found_password = new Label();
                con.Open();
                SqlCommand scom = new SqlCommand("select * from Employees where Employees_Name=N'" + forgot_name.Text + "'and Phone='" + forgot_phone.Text + "'and Email=N'" + forgot_email.Text + "'and Birthday='" + birthdate_TimePicker.Text + "'", con);
                SqlDataReader reader = scom.ExecuteReader();
                reader.Read();
                found_password.Text = reader["Password"].ToString();
                MessageBox.Show( found_password.Text + " : وشەی نهێنیەکەتان بریتیە لە", "وشەی نهێنی دۆزراوە", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();

            }
            else if (dt.Rows.Count != 1 && forgot_name.Text != "" && forgot_phone.Text != "" && forgot_email.Text != "" && birthdate_TimePicker.Text != "")
            {
                MessageBox.Show(".ئەو زانیاریانەی نووسراون هەڵەن", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void forgot_login_button_Click(object sender, EventArgs e)
        {
            forgot_timer.Start();
        }

        private void forgot_timer_Tick(object sender, EventArgs e)
        {
            Login_panel.Left -= 40;
            forgot_panel.Left += 40;
            if (Login_panel.Left <= 770)
            {
                forgot_timer.Stop();
            }
        }
    }
}
