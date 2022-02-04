using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Windows.Forms;

//$- si2dev -$//

namespace Bitwen_Company
{
    public partial class Home : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Database.mdf;Integrated Security=True;Connect Timeout=30");

        public static SqlConnection con = new SqlConnection(Properties.Settings.Default.DatabaseConnectionString);

        public Home()
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

        private void EXIT_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void MINIMIZE_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public void view()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Products order by Id", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            user_product_datagridview.DataSource = dt;
            user_product_datagridview.Refresh();
            admin_product_datagridview.DataSource = dt;
            admin_product_datagridview.Refresh();
        }

        string Type_of_account = Login.user_pass_Type;
        string user_pass_name = Login.user_pass_name;

        private void Main_Load(object sender, EventArgs e)
        {
            visible();
            Main_Panel.Visible = true;

            time_now.Start();
            Singin_user_lable.Text = user_pass_name;
            if (Type_of_account == "بەکارهێنەر")
            {
                user_product_datagridview.Visible = true;
                admin_product_datagridview.Visible = false;
                selled_list_button.Visible = false;
            }
            if (Type_of_account == "بەڕێوبەر")
            {
                user_product_datagridview.Visible = false;
                admin_product_datagridview.Visible = true;
            }

        }

        private void User_button_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(" ئەتانەوێت حیسابی " + Login.user_pass_name + " دابخەن ؟ ", "دەرچوون", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (dr == DialogResult.Yes)
            {
                Login retuern_login = new Login();
                retuern_login.Show();
                this.Hide();
            }
        }

        private void time_now_Tick(object sender, EventArgs e)
        {
            time_lable.Text = DateTime.Now.ToString("h:mm:ss tt");   // time
            date_label.Text = DateTime.Now.ToString("yyyy/MM/dd");   // date
            sell_date_TextBox.Text = DateTime.Now.ToString("yyyy/MM/dd hh:mm tt");   // data and time
            switch (DateTime.Today.DayOfWeek.ToString()) // week
            {
                case "Friday":
                    Week_label.Text = "هەینی";
                    break;

                case "Saturday":
                    Week_label.Text = "شەممە";
                    break;

                case "Sunday":
                    Week_label.Text = "یەک شەممە";
                    break;

                case "Monday":
                    Week_label.Text = "دوو شەممە";
                    break;

                case "Tuesday":
                    Week_label.Text = "سێ شەممە";
                    break;

                case "Wednesday":
                    Week_label.Text = "چوار شەممە";
                    break;

                case "Thursday":
                    Week_label.Text = "پێنج شەممە";
                    break;
                default:
                    Week_label.Text = ".هەڵە ڕوویداوە";
                    break;
            }
        }

        public void visible()
        {
            menuStrip.Visible = false;
            Main_Panel.Visible = false;
            sell_panel.Visible = false;
            Products_panel.Visible = false;
            depts_panel.Visible = false;
            costomer_panel.Visible = false;
            return_panel.Visible = false;
            retake_panel.Visible = false;
            broken_panel.Visible = false;
            dashbord_panel.Visible = false;
            Employees_panel.Visible = false;
            data_panel.Visible = false;
            company_panel.Visible = false;
            spend_panel.Visible = false;
            refix_panel.Visible = false;
            order_panel.Visible = false;
            sell_cash_panel.Visible = false;
            sell_dept_Panel.Visible = false;
            selled_list_panel.Visible = false;
            add_panel.Visible = false;
        }

        private void sell_button_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'allDataSet.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.allDataSet.Customer);
            visible();
            menuStrip.Visible = true;
            sell_panel.Visible = true;

            SqlDataAdapter adp = new SqlDataAdapter("select * from Products order by Id", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            select_product_DataGridView.DataSource = dt;
            select_product_DataGridView.Refresh();
        }

        private void Products_button_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'allDataSet.Companies' table. You can move, or remove it, as needed.
            this.companiesTableAdapter.Fill(this.allDataSet.Companies);
            // TODO: This line of code loads data into the 'allDataSet.Warranties' table. You can move, or remove it, as needed.
            this.warrantiesTableAdapter.Fill(this.allDataSet.Warranties);
            // TODO: This line of code loads data into the 'allDataSet.Colors' table. You can move, or remove it, as needed.
            this.colorsTableAdapter.Fill(this.allDataSet.Colors);
            // TODO: This line of code loads data into the 'allDataSet.Countries' table. You can move, or remove it, as needed.
            this.countriesTableAdapter.Fill(this.allDataSet.Countries);
            // TODO: This line of code loads data into the 'allDataSet.Brands' table. You can move, or remove it, as needed.
            this.brandsTableAdapter.Fill(this.allDataSet.Brands);
            // TODO: This line of code loads data into the 'allDataSet.Categories' table. You can move, or remove it, as needed.
            this.categoriesTableAdapter.Fill(this.allDataSet.Categories);
            // TODO: This line of code loads data into the 'allDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.allDataSet.Products);
            view();
            visible();
            menuStrip.Visible = true;
            Products_panel.Visible = true;
        }

        private void depts_button_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'allDataSet.Depts' table. You can move, or remove it, as needed.
            this.deptsTableAdapter.Fill(this.allDataSet.Depts);
            // TODO: This line of code loads data into the 'allDataSet.Depts_detali' table. You can move, or remove it, as needed.
            this.depts_detaliTableAdapter.Fill(this.allDataSet.Depts_detali);
            reback_debt_Panel.Visible = false;
            dept_detali_Panel.Visible = false;
            visible();
            menuStrip.Visible = true;
            depts_panel.Visible = true;
        }

        private void costomer_button_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'allDataSet.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.allDataSet.Customer);
            visible();
            menuStrip.Visible = true;
            costomer_panel.Visible = true;
        }

        //Remember
        private void return_button_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'allDataSet.Reminders' table. You can move, or remove it, as needed.
            this.remindersTableAdapter.Fill(this.allDataSet.Reminders);
            visible();
            menuStrip.Visible = true;
            return_panel.Visible = true;
        }

        private void retake_button_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'allDataSet.Selleds' table. You can move, or remove it, as needed.
            this.selledsTableAdapter.Fill(this.allDataSet.Selleds);
            reback_Panel.Visible = false;
            visible();
            menuStrip.Visible = true;
            retake_panel.Visible = true;
        }

        private void broken_button_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'allDataSet.Broken' table. You can move, or remove it, as needed.
            this.brokenTableAdapter.Fill(this.allDataSet.Broken);
            // TODO: This line of code loads data into the 'allDataSet.Categories' table. You can move, or remove it, as needed.
            this.categoriesTableAdapter.Fill(this.allDataSet.Categories);
            broken_money_Panel.Visible = false;
            count_broken_Panel.Visible = false;
            visible();
            menuStrip.Visible = true;
            broken_panel.Visible = true;
        }

        private void order_button_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'allDataSet.Old_order_list' table. You can move, or remove it, as needed.
            this.old_order_listTableAdapter.Fill(this.allDataSet.Old_order_list);
            // TODO: This line of code loads data into the 'allDataSet.Order_list' table. You can move, or remove it, as needed.
            this.order_listTableAdapter.Fill(this.allDataSet.Order_list);
            visible();
            seller_name_Panel.Visible = false;
            sum_order_list_Panel.Visible = false;
            menuStrip.Visible = true;
            order_panel.Visible = true;
            old_order_list_Panel.Visible = false;
            order_list_Panel.Visible = true;
        }

        private void refix_button_Click(object sender, EventArgs e)
        {
            if (Type_of_account == "بەڕێوبەر")
            {
                visible();
                product_print_Panel.Visible = false;
                prient_product_panel_Button.Visible = false;
                menuStrip.Visible = true;
                refix_panel.Visible = true;


                SqlCommand cmd = new SqlCommand("select TABLE_NAME FROM INFORMATION_SCHEMA.TABLES", con);  //بۆ نیشاندان و دەرخستنی سەرجەم ناوی خشتەکانی ناو داتابەیس بەکاردێت 
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                // dr بەپێی ژمارەی داتانی ناو while خولانەوەی 
                while (dr.Read())  //dr خوێندنەوەی داتاکانی ناو 
                {
                    tables_ComboBox.Items.Add(dr["TABLE_NAME"]);  // tables_ComboBox بۆ ناو  dr ی ناو  TABLE_NAME داخڵ کردنی 
                }

                con.Close();
            }
            else
            {
                MessageBox.Show(".جۆری هەژمارەکەت ڕێگەپێدراو نیە بۆ بەکارهێنانی ئەم خزمەتگوزاریە", "بەداخەوە", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void spend_button_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'allDataSet.Spend' table. You can move, or remove it, as needed.
            this.spendTableAdapter.Fill(this.allDataSet.Spend);

            if (Type_of_account == "بەکارهێنەر")
            {
                spend_search_TextBox1.Visible = false;
            }

            if (Type_of_account == "بەکارهێنەر")
            {
                SqlDataAdapter sa = new SqlDataAdapter("select * from Spend where Seller like N'%" + user_pass_name + "%'", con);
                DataTable dt = new DataTable();
                sa.Fill(dt);
                spend_DataGridView.DataSource = dt;
                spend_DataGridView.Refresh();
            }

            visible();
            menuStrip.Visible = true;
            spend_panel.Visible = true;
        }

        private void company_button_Click(object sender, EventArgs e)
        {
            if (Type_of_account == "بەڕێوبەر")
            {
                // TODO: This line of code loads data into the 'allDataSet.Companies_detail' table. You can move, or remove it, as needed.
                this.companies_detailTableAdapter.Fill(this.allDataSet.Companies_detail);
                // TODO: This line of code loads data into the 'allDataSet.Companies' table. You can move, or remove it, as needed.
                this.companiesTableAdapter.Fill(this.allDataSet.Companies);

                SqlDataAdapter adp = new SqlDataAdapter("select * from Companies order by ID", con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                companies_DataGridView.DataSource = dt;
                companies_DataGridView.Refresh();

                add_company_dept_Panel.Visible = false;
                subtract_company_dept_Panel.Visible = false;
                company_detail_Panel.Visible = false;

                visible();
                menuStrip.Visible = true;
                company_panel.Visible = true;
            }
            else
            {
                MessageBox.Show(".جۆری هەژمارەکەت ڕێگەپێدراو نیە بۆ بەکارهێنانی ئەم خزمەتگوزاریە", "بەداخەوە", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void data_button_Click(object sender, EventArgs e)
        {
            //visible();
            //menuStrip.Visible = true;
            //data_panel.Visible = true;
            MessageBox.Show(".ئەم خزمەتگوزاریە بەردەست نیە", "بەداخەوە", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Employees_button_Click(object sender, EventArgs e)
        {
            if (Type_of_account == "بەڕێوبەر")
            {
                // TODO: This line of code loads data into the 'allDataSet.Employees' table. You can move, or remove it, as needed.
                this.employeesTableAdapter.Fill(this.allDataSet.Employees);
                visible();
                menuStrip.Visible = true;
                Employees_panel.Visible = true;
                user_upadet_Button3.Enabled = false;
                user_delete_Button.Enabled = false;
            }
            else
            {
                MessageBox.Show(".جۆری هەژمارەکەت ڕێگەپێدراو نیە بۆ بەکارهێنانی ئەم خزمەتگوزاریە", "بەداخەوە", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dashbord_button_Click(object sender, EventArgs e)
        {
            if (Type_of_account == "بەڕێوبەر")
            {
                visible();
                dashbord_panel.Visible = true;
            try
            {
                con.Open();
                SqlDataAdapter sql_customer = new SqlDataAdapter("select * from Customer", con);
                DataTable dt_customer = new DataTable();
                sql_customer.Fill(dt_customer);
                con.Close();
                customer_num.Text = dt_customer.Rows.Count.ToString();

                con.Open();
                SqlDataAdapter sql_new_order = new SqlDataAdapter("select * from Order_list", con);
                DataTable dt_new_order = new DataTable();
                sql_new_order.Fill(dt_new_order);
                con.Close();
                new_order_num.Text = dt_new_order.Rows.Count.ToString();

                con.Open();
                SqlDataAdapter sql_rimander = new SqlDataAdapter("select * from Reminders", con);
                DataTable dt_rimander = new DataTable();
                sql_rimander.Fill(dt_rimander);
                con.Close();
                rimander_num.Text = dt_rimander.Rows.Count.ToString();

                con.Open();
                SqlDataAdapter sql_broken = new SqlDataAdapter("select * from Broken", con);
                DataTable dt_broken = new DataTable();
                sql_broken.Fill(dt_broken);
                con.Close();
                broken_num.Text = dt_broken.Rows.Count.ToString();

                con.Open();
                SqlDataAdapter sql_employws = new SqlDataAdapter("select * from Employees", con);
                DataTable dt_employws = new DataTable();
                sql_employws.Fill(dt_employws);
                con.Close();
                employws_num.Text = dt_employws.Rows.Count.ToString();

                con.Open();
                SqlDataAdapter sql_dept = new SqlDataAdapter("select * from Depts", con);
                DataTable dt_dept = new DataTable();
                sql_dept.Fill(dt_dept);
                con.Close();
                dept_num.Text = dt_dept.Rows.Count.ToString();

                con.Open();
                SqlDataAdapter sql_selleds = new SqlDataAdapter("select * from Selleds", con);
                DataTable dt_selleds = new DataTable();
                sql_selleds.Fill(dt_selleds);
                con.Close();
                selleds_num.Text = dt_selleds.Rows.Count.ToString();

                con.Open();
                SqlCommand sql_product = new SqlCommand("select sum(Piece) from Products", con);
                SqlDataReader reader_product = sql_product.ExecuteReader();
                reader_product.Read();
                product_num.Text = reader_product[0].ToString();
                con.Close();

                con.Open();
                SqlDataAdapter sql_modeles = new SqlDataAdapter("select * from Products", con);
                DataTable dt_modeles = new DataTable();
                sql_modeles.Fill(dt_modeles);
                con.Close();
                modeles_cum.Text = dt_modeles.Rows.Count.ToString();

                con.Open();
                SqlDataAdapter sql_brand = new SqlDataAdapter("select * from Brands", con);
                DataTable dt_brand = new DataTable();
                sql_brand.Fill(dt_brand);
                con.Close();
                brand_num.Text = dt_brand.Rows.Count.ToString();

                con.Open();
                SqlDataAdapter sql_company = new SqlDataAdapter("select * from Companies", con);
                DataTable dt_company = new DataTable();
                sql_company.Fill(dt_company);
                con.Close();
                company_num.Text = dt_company.Rows.Count.ToString();

                con.Open();
                SqlCommand sql_dept_dolar = new SqlCommand("select sum(Dolar) from Depts", con);
                SqlDataReader reader_dept_dolar = sql_dept_dolar.ExecuteReader();
                reader_dept_dolar.Read();
                dept_dolar_sum.Text = reader_dept_dolar[0].ToString();
                con.Close();

                con.Open();
                SqlCommand sql_dept_dinar = new SqlCommand("select sum(Dinar) from Depts", con);
                SqlDataReader reader_dept_dinar = sql_dept_dinar.ExecuteReader();
                reader_dept_dinar.Read();
                dept_dinar.Text = reader_dept_dinar[0].ToString();
                con.Close();

                con.Open();
                SqlCommand sql_product_dolar = new SqlCommand("select (sum([Buying_price_dolar]*[Piece])) from Products", con);
                SqlDataReader reader_product_dolar = sql_product_dolar.ExecuteReader();
                reader_product_dolar.Read();
                product_dolar.Text = reader_product_dolar[0].ToString();
                con.Close();

                con.Open();
                SqlCommand sql_product_dinar = new SqlCommand("select (sum([Buying_price_dinar]*[Piece])) from Products", con);
                SqlDataReader reader_product_dinar = sql_product_dinar.ExecuteReader();
                reader_product_dinar.Read();
                product_dinar.Text = reader_product_dinar[0].ToString();
                con.Close();

                con.Open();
                SqlCommand sql_company_dolar_dept = new SqlCommand("select sum(Dolar) from Companies", con);
                SqlDataReader reader_company_dolar_dept = sql_company_dolar_dept.ExecuteReader();
                reader_company_dolar_dept.Read();
                company_dolar_dept.Text = reader_company_dolar_dept[0].ToString();
                con.Close();

                con.Open();
                SqlCommand sql_company_dinar_dept = new SqlCommand("select sum(Dinar) from Companies", con);
                SqlDataReader reader_company_dinar_dept = sql_company_dinar_dept.ExecuteReader();
                reader_company_dinar_dept.Read();
                company_dinar_dept.Text = reader_company_dinar_dept[0].ToString();
                con.Close();

                con.Open();
                SqlCommand sql_spend_dolar = new SqlCommand("select sum(Dolar) from Spend", con);
                SqlDataReader reader_spend_dolar = sql_spend_dolar.ExecuteReader();
                reader_spend_dolar.Read();
                spend_dolar.Text = reader_spend_dolar[0].ToString();
                con.Close();

                con.Open();
                SqlCommand sql_spend_dinar = new SqlCommand("select sum(Dinar) from Spend", con);
                SqlDataReader reader_spend_dinar = sql_spend_dinar.ExecuteReader();
                reader_spend_dinar.Read();
                spend_dinar.Text = reader_spend_dinar[0].ToString();
                con.Close();

                con.Open();
                SqlCommand sql_Dolar = new SqlCommand("select sum(Total_dolar) from Selleds", con);
                SqlDataReader reader_Dolar = sql_Dolar.ExecuteReader();
                reader_Dolar.Read();
                money_dolar.Text = reader_Dolar[0].ToString();
                con.Close();

                con.Open();
                SqlCommand sql_Dinar = new SqlCommand("select sum(Total_dinar) from Selleds", con);
                SqlDataReader reader_Dinar = sql_Dinar.ExecuteReader();
                reader_Dinar.Read();
                money_dinar.Text = reader_Dinar[0].ToString();
                con.Close();


                //chart
                con.Open();
                SqlCommand sql_m1 = new SqlCommand("select count(*) from Selleds where [Date] between '2021/01/01 00:00 AM' and '2021/02/1 00:00 AM'", con);
                SqlDataReader reader_m1 = sql_m1.ExecuteReader();
                reader_m1.Read();
                int selles_month_1 = Convert.ToInt32(reader_m1[0]);
                con.Close();

                con.Open();
                SqlCommand sql_m2 = new SqlCommand("select count(*) from Selleds where [Date] between '2021/02/01 00:00 AM' and '2021/03/1 00:00 AM'", con);
                SqlDataReader reader_m2 = sql_m2.ExecuteReader();
                reader_m2.Read();
                int selles_month_2 = Convert.ToInt32(reader_m2[0]);
                con.Close();

                con.Open();
                SqlCommand sql_m3 = new SqlCommand("select count(*) from Selleds where [Date] between '2021/03/01 00:00 AM' and '2021/04/1 00:00 AM'", con);
                SqlDataReader reader_m3 = sql_m3.ExecuteReader();
                reader_m3.Read();
                int selles_month_3 = Convert.ToInt32(reader_m3[0]);
                con.Close();

                con.Open();
                SqlCommand sql_m4 = new SqlCommand("select count(*) from Selleds where [Date] between '2021/04/01 00:00 AM' and '2021/05/1 00:00 AM'", con);
                SqlDataReader reader_m4 = sql_m4.ExecuteReader();
                reader_m4.Read();
                int selles_month_4 = Convert.ToInt32(reader_m4[0]);
                con.Close();

                con.Open();
                SqlCommand sql_m5 = new SqlCommand("select count(*) from Selleds where [Date] between '2021/05/01 00:00 AM' and '2021/06/1 00:00 AM'", con);
                SqlDataReader reader_m5 = sql_m5.ExecuteReader();
                reader_m5.Read();
                int selles_month_5 = Convert.ToInt32(reader_m5[0]);
                con.Close();

                con.Open();
                SqlCommand sql_m6 = new SqlCommand("select count(*) from Selleds where [Date] between '2021/06/01 00:00 AM' and '2021/07/1 00:00 AM'", con);
                SqlDataReader reader_m6 = sql_m6.ExecuteReader();
                reader_m6.Read();
                int selles_month_6 = Convert.ToInt32(reader_m6[0]);
                con.Close();

                con.Open();
                SqlCommand sql_m7 = new SqlCommand("select count(*) from Selleds where [Date] between '2021/07/01 00:00 AM' and '2021/08/1 00:00 AM'", con);
                SqlDataReader reader_m7 = sql_m7.ExecuteReader();
                reader_m7.Read();
                int selles_month_7 = Convert.ToInt32(reader_m7[0]);
                con.Close();

                con.Open();
                SqlCommand sql_m8 = new SqlCommand("select count(*) from Selleds where [Date] between '2021/08/01 00:00 AM' and '2021/09/1 00:00 AM'", con);
                SqlDataReader reader_m8 = sql_m8.ExecuteReader();
                reader_m8.Read();
                int selles_month_8 = Convert.ToInt32(reader_m8[0]);
                con.Close();

                con.Open();
                SqlCommand sql_m9 = new SqlCommand("select count(*) from Selleds where [Date] between '2021/09/01 00:00 AM' and '2021/10/1 00:00 AM'", con);
                SqlDataReader reader_m9 = sql_m9.ExecuteReader();
                reader_m9.Read();
                int selles_month_9 = Convert.ToInt32(reader_m9[0]);
                con.Close();

                con.Open();
                SqlCommand sql_m10 = new SqlCommand("select count(*) from Selleds where [Date] between '2021/10/01 00:00 AM' and '2021/11/1 00:00 AM'", con);
                SqlDataReader reader_m10 = sql_m10.ExecuteReader();
                reader_m10.Read();
                int selles_month_10 = Convert.ToInt32(reader_m10[0]);
                con.Close();

                con.Open();
                SqlCommand sql_m11 = new SqlCommand("select count(*) from Selleds where [Date] between '2021/11/01 00:00 AM' and '2021/12/1 00:00 AM'", con);
                SqlDataReader reader_m11 = sql_m11.ExecuteReader();
                reader_m11.Read();
                int selles_month_11 = Convert.ToInt32(reader_m11[0]);
                con.Close();

                con.Open();
                SqlCommand sql_m12 = new SqlCommand("select count(*) from Selleds where [Date] between '2021/12/01 00:00 AM' and '2021/12/31 00:00 AM'", con);
                SqlDataReader reader_m12 = sql_m12.ExecuteReader();
                reader_m12.Read();
                int selles_month_12 = Convert.ToInt32(reader_m12[0]);
                con.Close();

                chart1.Series["فرۆشتن"].Points.AddXY("مانگی ١", selles_month_1);
                chart1.Series["فرۆشتن"].Points.AddXY("مانگی ٢", selles_month_2);
                chart1.Series["فرۆشتن"].Points.AddXY("مانگی ٣", selles_month_3);
                chart1.Series["فرۆشتن"].Points.AddXY("مانگی ٤", selles_month_4);
                chart1.Series["فرۆشتن"].Points.AddXY("مانگی ٥", selles_month_5);
                chart1.Series["فرۆشتن"].Points.AddXY("مانگی ٦", selles_month_6);
                chart1.Series["فرۆشتن"].Points.AddXY("مانگی ٧", selles_month_7);
                chart1.Series["فرۆشتن"].Points.AddXY("مانگی ٨", selles_month_8);
                chart1.Series["فرۆشتن"].Points.AddXY("مانگی ٩", selles_month_9);
                chart1.Series["فرۆشتن"].Points.AddXY("مانگی ١٠", selles_month_10);
                chart1.Series["فرۆشتن"].Points.AddXY("مانگی ١١", selles_month_11);
                chart1.Series["فرۆشتن"].Points.AddXY("مانگی ١٢", selles_month_12);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            }
            else
            {
                MessageBox.Show(".جۆری هەژمارەکەت ڕێگەپێدراو نیە بۆ بەکارهێنانی ئەم خزمەتگوزاریە", "بەداخەوە", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void سەرەتاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visible();
            Main_Panel.Visible = true;
        }

        //# products
        private void ara_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Products where Id like '%" + user_products_search.Text + "%' or Model like N'%" + user_products_search.Text + "%' or Brand like N'%" + user_products_search.Text + "%' or Properties like N'%" + user_products_search.Text + "%' or Company_name like N'%" + user_products_search.Text + "%' or Category like N'%" + user_products_search.Text + "%' order by Id", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            user_product_datagridview.DataSource = dt;
            user_product_datagridview.Refresh();
            admin_product_datagridview.DataSource = dt;
            admin_product_datagridview.Refresh();
        }

        private void user_products_insert_Click(object sender, EventArgs e)
        {
            if (Type_of_account == "بەکارهێنەر")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into Products(Category,Model,Brand,Country,Piece,Properties,Size,Color,Warranty,Store_date,Note,Company_name) " +
                    "values(N'" + user_product_datagridview.CurrentRow.Cells[1].Value.ToString() + "','" +
                    user_product_datagridview.CurrentRow.Cells[2].Value.ToString() + "',N'" +
                    user_product_datagridview.CurrentRow.Cells[3].Value.ToString() + "',N'" +
                    user_product_datagridview.CurrentRow.Cells[4].Value.ToString() + "','" +
                    user_product_datagridview.CurrentRow.Cells[5].Value.ToString() + "',N'" +
                    user_product_datagridview.CurrentRow.Cells[6].Value.ToString() + "',N'" +
                    user_product_datagridview.CurrentRow.Cells[9].Value.ToString() + "',N'" +
                    user_product_datagridview.CurrentRow.Cells[10].Value.ToString() + "',N'" +
                    user_product_datagridview.CurrentRow.Cells[11].Value.ToString() + "','" +
                    Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy")) + "',N'" +
                    user_product_datagridview.CurrentRow.Cells[13].Value.ToString() + "',N'" +
                    user_product_datagridview.CurrentRow.Cells[14].Value.ToString() + "')", con);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    view();
                    Interaction.Beep();
                    user_product_datagridview.FirstDisplayedScrollingRowIndex = user_product_datagridview.RowCount - 1;  // بۆ بردنەخوارەوە
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message.ToString() + " : هەڵە یەک هەیە لە داخڵکردنەکەدا کە بریتیە لە ");
                }
            }
            if (Type_of_account == "بەڕێوبەر")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into Products(Category,Model,Brand,Country,Piece,Properties,Size,Color,Warranty,Buying_price_dolar,Buying_price_dinar,Selling_price_dolar,Selling_price_dinar,Store_date,Note,Company_name) " +
                        "values(N'" + admin_product_datagridview.CurrentRow.Cells[1].Value.ToString() + "','" +
                        admin_product_datagridview.CurrentRow.Cells[2].Value.ToString() + "',N'" +
                        admin_product_datagridview.CurrentRow.Cells[3].Value.ToString() + "',N'" +
                        admin_product_datagridview.CurrentRow.Cells[4].Value.ToString() + "','" +
                        admin_product_datagridview.CurrentRow.Cells[5].Value.ToString() + "',N'" +
                        admin_product_datagridview.CurrentRow.Cells[6].Value.ToString() + "',N'" +
                        admin_product_datagridview.CurrentRow.Cells[7].Value.ToString() + "',N'" +
                        admin_product_datagridview.CurrentRow.Cells[8].Value.ToString() + "',N'" +
                        admin_product_datagridview.CurrentRow.Cells[9].Value.ToString() + "','" +
                        admin_product_datagridview.CurrentRow.Cells[10].Value.ToString() + "','" +
                        admin_product_datagridview.CurrentRow.Cells[11].Value.ToString() + "','" +
                        admin_product_datagridview.CurrentRow.Cells[12].Value.ToString() + "','" +
                        admin_product_datagridview.CurrentRow.Cells[13].Value.ToString() + "','" +
                        Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy")) + "',N'" +
                        admin_product_datagridview.CurrentRow.Cells[15].Value.ToString() + "',N'" +
                        admin_product_datagridview.CurrentRow.Cells[16].Value.ToString() + "')", con);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    view();
                    Interaction.Beep();
                    admin_product_datagridview.FirstDisplayedScrollingRowIndex = admin_product_datagridview.RowCount - 1;  // بۆ بردنەخوارەوە
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message.ToString() + " : هەڵە یەک هەیە لە داخڵکردنەکەدا کە بریتیە لە ");
                }
            }
        }

        private void user_product_update_Click(object sender, EventArgs e)
        {
            if (Type_of_account == "بەکارهێنەر")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update Products set " +
                        "Category=N'" + user_product_datagridview.CurrentRow.Cells[1].Value.ToString() + "'," +
                        "Model='" + user_product_datagridview.CurrentRow.Cells[2].Value.ToString() + "'," +
                        "Brand=N'" + user_product_datagridview.CurrentRow.Cells[3].Value.ToString() + "'," +
                        "Country=N'" + user_product_datagridview.CurrentRow.Cells[4].Value.ToString() + "'," +
                        "Piece='" + user_product_datagridview.CurrentRow.Cells[5].Value.ToString() + "'," +
                        "Properties=N'" + user_product_datagridview.CurrentRow.Cells[6].Value.ToString() + "'," +
                        "Size=N'" + user_product_datagridview.CurrentRow.Cells[9].Value.ToString() + "'," +
                        "Color=N'" + user_product_datagridview.CurrentRow.Cells[10].Value.ToString() + "'," +
                        "Warranty=N'" + user_product_datagridview.CurrentRow.Cells[11].Value.ToString() + "'," +
                        "Store_date='" + Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy")) + "'," +
                        "Note=N'" + user_product_datagridview.CurrentRow.Cells[13].Value.ToString() + "'," +
                        "Company_name=N'" + user_product_datagridview.CurrentRow.Cells[14].Value.ToString() + "'" +
                        "where ID='" + user_product_datagridview.CurrentRow.Cells[0].Value.ToString() + "'", con);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    view();
                    Interaction.Beep();
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message.ToString() + " : هەڵە یەک هەیە لە نوێ کردنەوەکەدا کە بریتیە لە ");
                }
            }
            if (Type_of_account == "بەڕێوبەر")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update Products set " +
                    "Category=N'" + admin_product_datagridview.CurrentRow.Cells[1].Value.ToString() + "'," +
                    "Model='" + admin_product_datagridview.CurrentRow.Cells[2].Value.ToString() + "'," +
                    "Brand=N'" + admin_product_datagridview.CurrentRow.Cells[3].Value.ToString() + "'," +
                    "Country=N'" + admin_product_datagridview.CurrentRow.Cells[4].Value.ToString() + "'," +
                    "Piece='" + admin_product_datagridview.CurrentRow.Cells[5].Value.ToString() + "'," +
                    "Properties=N'" + admin_product_datagridview.CurrentRow.Cells[6].Value.ToString() + "'," +
                    "Buying_price_dolar='" + Convert.ToInt32(admin_product_datagridview.CurrentRow.Cells[7].Value) + "'," +
                    "Buying_price_dinar='" + Convert.ToInt64(admin_product_datagridview.CurrentRow.Cells[8].Value) + "'," +
                    "Selling_price_dolar='" + Convert.ToInt32(admin_product_datagridview.CurrentRow.Cells[9].Value) + "'," +
                    "Selling_price_dinar='" + Convert.ToInt64(admin_product_datagridview.CurrentRow.Cells[10].Value) + "'," +
                    "Size=N'" + admin_product_datagridview.CurrentRow.Cells[11].Value.ToString() + "'," +
                    "Color=N'" + admin_product_datagridview.CurrentRow.Cells[12].Value.ToString() + "'," +
                    "Warranty=N'" + admin_product_datagridview.CurrentRow.Cells[13].Value.ToString() + "'," +
                    "Store_date='" + Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy")) + "'," +
                    "Note=N'" + admin_product_datagridview.CurrentRow.Cells[15].Value.ToString() + "'," +
                    "Company_name=N'" + admin_product_datagridview.CurrentRow.Cells[16].Value.ToString() + "'" +
                    "where ID='" + admin_product_datagridview.CurrentRow.Cells[0].Value.ToString() + "'", con);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    view();
                    Interaction.Beep();
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message.ToString() + " : هەڵە یەک هەیە لە نوێ کردنەوەکەدا کە بریتیە لە ");
                }
            }
        }

        private void user_product_refresh_Click(object sender, EventArgs e)
        {
            view();
            user_products_search.Text = "";
            Interaction.Beep();
        }
        private void addsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (adds_ComboBox.SelectedItem.ToString() == "جۆر")
            {
                ager = "catagory";
                change_datagridview.DataSource = allDataSet.Categories;
                allDataSet.Categories.DefaultView.Sort = "id";
                add_name_textbox.PlaceholderText = "ناوی جۆر";
                add_label.Text = "زیادکردنی جۆر";
            }
            else if (adds_ComboBox.SelectedItem.ToString() == "مارکە")
            {
                ager = "brand";
                change_datagridview.DataSource = allDataSet.Brands;
                allDataSet.Brands.DefaultView.Sort = "id";
                add_name_textbox.PlaceholderText = "ناوی مارکە";
                add_label.Text = "زیادکردنی مارکە";
            }
            else if (adds_ComboBox.SelectedItem.ToString() == "وڵات")
            {
                ager = "country";
                change_datagridview.DataSource = allDataSet.Countries;
                allDataSet.Countries.DefaultView.Sort = "id";
                add_name_textbox.PlaceholderText = "ناوی وڵات";
                add_label.Text = "زیادکردنی وڵات";
            }
            else if (adds_ComboBox.SelectedItem.ToString() == "ڕەنگ")
            {
                ager = "color";
                change_datagridview.DataSource = allDataSet.Colors;
                allDataSet.Colors.DefaultView.Sort = "id";
                add_name_textbox.PlaceholderText = "ناوی ڕەنگ";
                add_label.Text = "زیادکردنی ڕەنگ";
            }
            else if (adds_ComboBox.SelectedItem.ToString() == "گرەنتی")
            {
                ager = "warranty";
                change_datagridview.DataSource = allDataSet.Warranties;
                allDataSet.Warranties.DefaultView.Sort = "id";
                add_name_textbox.PlaceholderText = "ماوەی گرەنتی";
                add_label.Text = "زیادکردنی گرەنتی";
            }
            else if (adds_ComboBox.SelectedItem.ToString() == "کۆمپانیا")
            {
                ager = "company";
                change_datagridview.DataSource = allDataSet.Companies;
                allDataSet.Companies.DefaultView.Sort = "id";
                add_name_textbox.PlaceholderText = "ناوی کۆمپانیا";
                add_label.Text = "زیادکردنی کۆمپانیا";
            }
        }

        string ager = "";
        private void adds_button_Click(object sender, EventArgs e)
        {
            add_panel.Visible = true;
        }

        private void close_user_add_catagory_button_Click(object sender, EventArgs e)
        {
            add_panel.Visible = false;
        }

        private void add_catagory_button_Click(object sender, EventArgs e)
        {
            switch (ager)
            {
                case "catagory":

                    if (add_name_textbox.TextLength != 0)
                    {

                        try
                        {
                            SqlCommand cmd = new SqlCommand("insert into Categories(Categories_name) values(N'" + add_name_textbox.Text + "')", con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                            SqlDataAdapter sa = new SqlDataAdapter("select * from Categories order by id", con);
                            DataTable dt = new DataTable();
                            sa.Fill(dt);
                            Interaction.Beep();
                            change_datagridview.DataSource = dt;
                            change_datagridview.Refresh();
                            add_name_textbox.Text = "";
                            view();
                            MessageBox.Show(".زیادکردنەکە بە سەرکەوتوویی ئەنجامدرا", "زیادکرا");
                        }
                        catch (Exception ex)
                        {
                            con.Close();
                            MessageBox.Show(ex.Message.ToString() + " : هەڵە یەک هەیە لە داخڵکردنەکەدا کە بریتیە لە ");
                        }
                    }
                    else
                    {
                        MessageBox.Show(".خانەی ناوی جۆر بەتاڵە. تکایە پڕی بکەرەوە", "! ئاگاداربە");
                    }
                    break;

                case "brand":
                    if (add_name_textbox.TextLength != 0)
                    {

                        try
                        {
                            SqlCommand cmd = new SqlCommand("insert into brands(Brand) values(N'" + add_name_textbox.Text + "')", con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                            SqlDataAdapter sa = new SqlDataAdapter("select * from brands order by id", con);
                            DataTable dt = new DataTable();
                            sa.Fill(dt);
                            Interaction.Beep();
                            change_datagridview.DataSource = dt;
                            change_datagridview.Refresh();
                            add_name_textbox.Text = "";
                            view();
                            MessageBox.Show(".زیادکردنەکە بە سەرکەوتوویی ئەنجامدرا", "زیادکرا");
                        }
                        catch (Exception ex)
                        {
                            con.Close();
                            MessageBox.Show(ex.Message.ToString() + " : هەڵە یەک هەیە لە داخڵکردنەکەدا کە بریتیە لە ");
                        }
                    }
                    else
                    {
                        MessageBox.Show(".خانەی ناوی مارکە بەتاڵە. تکایە پڕی بکەرەوە", "! ئاگاداربە");
                    }
                    break;

                case "country":
                    if (add_name_textbox.TextLength != 0)
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand("insert into Countries(CONTRY) values(N'" + add_name_textbox.Text + "')", con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                            SqlDataAdapter sa = new SqlDataAdapter("select * from Countries order by id", con);
                            DataTable dt = new DataTable();
                            sa.Fill(dt);
                            Interaction.Beep();
                            change_datagridview.DataSource = dt;
                            change_datagridview.Refresh();
                            add_name_textbox.Text = "";
                            view();
                            MessageBox.Show(".زیادکردنەکە بە سەرکەوتوویی ئەنجامدرا", "زیادکرا");
                        }
                        catch (Exception ex)
                        {
                            con.Close();
                            MessageBox.Show(ex.Message.ToString() + " : هەڵە یەک هەیە لە داخڵکردنەکەدا کە بریتیە لە ");
                        }
                    }
                    else
                    {
                        MessageBox.Show(".خانەی ناوی وڵات بەتاڵە. تکایە پڕی بکەرەوە", "! ئاگاداربە");
                    }
                    break;

                case "color":
                    if (add_name_textbox.TextLength != 0)
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand("insert into Colors(COLOR) values(N'" + add_name_textbox.Text + "')", con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                            SqlDataAdapter sa = new SqlDataAdapter("select * from Colors order by id", con);
                            DataTable dt = new DataTable();
                            sa.Fill(dt);
                            Interaction.Beep();
                            change_datagridview.DataSource = dt;
                            change_datagridview.Refresh();
                            add_name_textbox.Text = "";
                            view();
                            MessageBox.Show(".زیادکردنەکە بە سەرکەوتوویی ئەنجامدرا", "زیادکرا");
                        }
                        catch (Exception ex)
                        {
                            con.Close();
                            MessageBox.Show(ex.Message.ToString() + " : هەڵە یەک هەیە لە داخڵکردنەکەدا کە بریتیە لە ");
                        }
                    }
                    else
                    {
                        MessageBox.Show(".خانەی ناوی ڕەنگ بەتاڵە. تکایە پڕی بکەرەوە", "! ئاگاداربە");
                    }
                    break;

                case "warranty":
                    if (add_name_textbox.TextLength != 0)
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand("insert into Warranties(Warranty) values(N'" + add_name_textbox.Text + "')", con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                            SqlDataAdapter sa = new SqlDataAdapter("select * from Warranties order by id", con);
                            DataTable dt = new DataTable();
                            sa.Fill(dt);
                            Interaction.Beep();
                            change_datagridview.DataSource = dt;
                            change_datagridview.Refresh();
                            user_product_datagridview.DataSource = allDataSet.Products;
                            user_product_datagridview.Refresh();
                            add_name_textbox.Text = "";
                            view();
                            MessageBox.Show(".زیادکردنەکە بە سەرکەوتوویی ئەنجامدرا", "زیادکرا");
                        }
                        catch (Exception ex)
                        {
                            con.Close();
                            MessageBox.Show(ex.Message.ToString() + " : هەڵە یەک هەیە لە داخڵکردنەکەدا کە بریتیە لە ");
                        }
                    }
                    else
                    {
                        MessageBox.Show(".خانەی ماوەی گرەنتی بەتاڵە. تکایە پڕی بکەرەوە", "! ئاگاداربە");
                    }
                    break;

                case "company":
                    if (add_name_textbox.TextLength != 0)
                    {

                        try
                        {
                            SqlCommand cmd = new SqlCommand("insert into Companies(COMPANY) values(N'" + add_name_textbox.Text + "')", con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                            SqlDataAdapter sa = new SqlDataAdapter("select * from Companies order by id", con);
                            DataTable dt = new DataTable();
                            sa.Fill(dt);
                            Interaction.Beep();
                            change_datagridview.DataSource = dt;
                            change_datagridview.Refresh();
                            add_name_textbox.Text = "";
                            view();
                            MessageBox.Show(".زیادکردنەکە بە سەرکەوتوویی ئەنجامدرا", "زیادکرا");
                        }
                        catch (Exception ex)
                        {
                            con.Close();
                            MessageBox.Show(ex.Message.ToString() + " : هەڵە یەک هەیە لە داخڵکردنەکەدا کە بریتیە لە ");
                        }
                    }
                    else
                    {
                        MessageBox.Show(".خانەی ناوی کۆمپانیا بەتاڵە. تکایە پڕی بکەرەوە", "! ئاگاداربە");
                    }
                    break;
                default:
                    MessageBox.Show(".هەڵە ڕوویداوە", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

        }

        //sell

        public void count()
        {
            try
            {
                int total_dolar = 0;
                int total_dinar = 0;
                for (int i = 0; i < selected_products_DataGridView.Rows.Count; i++)
                {
                    try
                    {
                        int Piece = Convert.ToInt32(selected_products_DataGridView.Rows[i].Cells[6].Value);
                        int dolar_price = Convert.ToInt32(selected_products_DataGridView.Rows[i].Cells[8].Value);
                        total_dolar += dolar_price * Piece;
                        int dinar_price = Convert.ToInt32(selected_products_DataGridView.Rows[i].Cells[9].Value);
                        total_dinar += dinar_price * Piece;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        break;
                    }

                }
                total_dolarTextBox1.Text = total_dolar.ToString();
                total_dinar_TextBox.Text = total_dinar.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void pass_data_from_product_to_list()
        {
            string[] row = { ""
            ,select_product_DataGridView.CurrentRow.Cells[1].Value.ToString(),
            select_product_DataGridView.CurrentRow.Cells[2].Value.ToString(),
            select_product_DataGridView.CurrentRow.Cells[3].Value.ToString(),
            select_product_DataGridView.CurrentRow.Cells[4].Value.ToString(),
            select_product_DataGridView.CurrentRow.Cells[5].Value.ToString(),
            1.ToString(),
            select_product_DataGridView.CurrentRow.Cells[7].Value.ToString(),
            select_product_DataGridView.CurrentRow.Cells[8].Value.ToString(),
            select_product_DataGridView.CurrentRow.Cells[9].Value.ToString(),
            select_product_DataGridView.CurrentRow.Cells[10].Value.ToString(),
            select_product_DataGridView.CurrentRow.Cells[11].Value.ToString(),
            select_product_DataGridView.CurrentRow.Cells[12].Value.ToString() };
            selected_products_DataGridView.Rows.Add(row);
        }

        private void model_TextBox1_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Products where ID like '%" + model_TextBox1.Text + "%' or Model like N'%" + model_TextBox1.Text + "%' or Brand like N'%" + model_TextBox1.Text + "%' or Properties like N'%" + model_TextBox1.Text + "%' or Company_name like N'%" + model_TextBox1.Text + "%' or Category like N'%" + model_TextBox1.Text + "%' order by ID", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            select_product_DataGridView.DataSource = dt;
            select_product_DataGridView.Refresh();
        }

        private void select_product_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int[] id_list = new int[50];
            Boolean marj = true;
            if (e.ColumnIndex == 0)
            {
                if (selected_products_DataGridView.Rows.Count != 0)
                {
                    for (int i = 0; i < selected_products_DataGridView.Rows.Count; i++)
                    {
                        id_list[i] = Convert.ToInt32(selected_products_DataGridView.Rows[i].Cells[1].Value);
                        int id_product = Convert.ToInt32(select_product_DataGridView.CurrentRow.Cells[1].Value);
                        if (id_list[i] == id_product)
                        {
                            MessageBox.Show("ئەم کەلوپەلە لە لیستی کەلوپەلە دیاریکراوەکان بوونی هەیە. لەبەر ئەم هۆیە ناتوانیت زیادی بکەی", "!ئاگاداربە", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            marj = false;
                            break;
                        }
                    }
                    if (marj == true)
                    {
                        int picec_product = Convert.ToInt32(select_product_DataGridView.CurrentRow.Cells[6].Value);
                        if (picec_product < 1)
                        {
                            MessageBox.Show(".ئەم کەلوپەلە نەماوە", "!ئاگاداربە", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            pass_data_from_product_to_list();    // function
                        }
                    }
                }
                else
                {
                    int picec_product = Convert.ToInt32(select_product_DataGridView.CurrentRow.Cells[6].Value);
                    if (picec_product < 1)
                    {
                        MessageBox.Show(".ئەم کەلوپەلە نەماوە", "!ئاگاداربە", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        pass_data_from_product_to_list();    // function
                    }
                }

                count(); //function
            }
        }

        private void selected_products_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (selected_products_DataGridView.Rows.Count != 0)
                {
                    selected_products_DataGridView.Rows.RemoveAt(selected_products_DataGridView.CurrentCell.RowIndex);
                }

                count(); //function
            }
        }

        private void selected_products_DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (selected_products_DataGridView.Columns[e.ColumnIndex].Name == "PIECE_LIST")
                {
                    int picec_product = Convert.ToInt32(select_product_DataGridView.CurrentRow.Cells[6].Value);
                    int picec_list = Convert.ToInt32(selected_products_DataGridView.CurrentRow.Cells[6].Value);
                    if (picec_product < picec_list)
                    {
                        MessageBox.Show(" لەم کەلوپەلە تەنها " + picec_product + " دانە ماوە ", "!ئاگاداربە", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        selected_products_DataGridView.CurrentRow.Cells[6].Value = picec_product;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            count(); //function
        }

        private void cash_sell_Button_Click(object sender, EventArgs e)
        {
            if (selected_products_DataGridView.RowCount > 0)
            {
                try
                {
                    for (int i = 0; i < selected_products_DataGridView.RowCount; i++)
                    {
                        string[] row = {
                        selected_products_DataGridView.Rows[i].Cells[1].Value.ToString(),
                        selected_products_DataGridView.Rows[i].Cells[2].Value.ToString(),
                        selected_products_DataGridView.Rows[i].Cells[3].Value.ToString(),
                        selected_products_DataGridView.Rows[i].Cells[4].Value.ToString(),
                        selected_products_DataGridView.Rows[i].Cells[6].Value.ToString(),
                        selected_products_DataGridView.Rows[i].Cells[7].Value.ToString(),
                        selected_products_DataGridView.Rows[i].Cells[8].Value.ToString(),
                        selected_products_DataGridView.Rows[i].Cells[9].Value.ToString(),
                        selected_products_DataGridView.Rows[i].Cells[10].Value.ToString(),
                        selected_products_DataGridView.Rows[i].Cells[11].Value.ToString(),
                        selected_products_DataGridView.Rows[i].Cells[12].Value.ToString() };
                        list_DataGridView.Rows.Add(row);
                    }
                    total_dolar_textbox.Text = total_dolarTextBox1.Text;
                    total_dinarTextBox.Text = total_dinar_TextBox.Text;
                    seller_name.Text = user_pass_name;

                    dept_sell_Button.Enabled = false;
                    cash_sell_Button.Enabled = false;
                    sell_cash_panel.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else
            {
                MessageBox.Show("هیچ کەلوپەلێک دیاری نەکراوە بۆ فرۆشتن", "!ئاگادەربە", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void close_cash_panel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("دڵنیای لە داخستنی پەڕەی فرۆشتنی کاش", "داخستن", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                dept_sell_Button.Enabled = true;
                cash_sell_Button.Enabled = true;
                sell_cash_panel.Visible = false;
                list_DataGridView.Rows.Clear();

            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string wating_geting;
            if (take.Checked == true)
            {
                wating_geting = "وەرنەگیراوە";
            }
            else
            {
                wating_geting = "وەرگیراوە";
            }
            try
            {
                SqlCommand sqc = new SqlCommand("delete Selled_bill", con);
                con.Open();
                sqc.ExecuteNonQuery();
                con.Close();

                for (int i = 0; i < list_DataGridView.RowCount; i++)
                {
                    try
                    {
                        int total_dolar = 0;
                        total_dolar = Convert.ToInt32(selected_products_DataGridView.Rows[i].Cells[8].Value) * Convert.ToInt32(selected_products_DataGridView.Rows[i].Cells[6].Value);
                        int total_dinar = 0;
                        total_dinar = Convert.ToInt32(selected_products_DataGridView.Rows[i].Cells[9].Value) * Convert.ToInt32(selected_products_DataGridView.Rows[i].Cells[6].Value);

                        SqlCommand cmd = new SqlCommand("insert into Selled_bill(id,Customer,Phone,Address,Cash,Total_dolar,Total_dinar,Waiting_to_geting,Product_ID,Category,Brand,Model,Piece,Properties,price_dolar,price_dinar,Size,Color,Warranty,Seller) " +
                        "values('" + i + "',N'" +
                        name_textbox.Text + "',N'" +
                        phone_textbox.Text + "',N'" +
                        address_textbox.Text + "',N'" +
                        "فرۆشتن بە کاش" + "','" +
                        total_dolar_textbox.Text + "','" +
                        total_dinarTextBox.Text + "',N'" +
                        wating_geting.ToString() + "','" +
                        list_DataGridView.Rows[i].Cells[0].Value.ToString() + "',N'" +
                        list_DataGridView.Rows[i].Cells[1].Value.ToString() + "',N'" +
                        list_DataGridView.Rows[i].Cells[2].Value.ToString() + "','" +
                        list_DataGridView.Rows[i].Cells[3].Value.ToString() + "','" +
                        list_DataGridView.Rows[i].Cells[4].Value.ToString() + "',N'" +
                        list_DataGridView.Rows[i].Cells[5].Value.ToString() + "','" +
                        list_DataGridView.Rows[i].Cells[6].Value.ToString() + "','" +
                        list_DataGridView.Rows[i].Cells[7].Value.ToString() + "',N'" +
                        list_DataGridView.Rows[i].Cells[8].Value.ToString() + "',N'" +
                        list_DataGridView.Rows[i].Cells[9].Value.ToString() + "',N'" +
                        list_DataGridView.Rows[i].Cells[10].Value.ToString() + "',N'" +
                        seller_name.Text + "')", con);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        //ADD IN SELLEDS
                        SqlCommand sqlcmd = new SqlCommand("insert into Selleds(Customer,Phone,Address,Cash,Total_dolar,Cost_take_dolar,Total_dinar,Cost_take_dinar,Waiting_to_geting,Product_ID,Category,Brand,Model,Properties,Piece,Seller,Date) " +
                        "values(N'" + name_textbox.Text + "',N'" +
                        phone_textbox.Text + "',N'" +
                        address_textbox.Text + "',N'" +
                        "فرۆشتن بە کاش" + "','" +
                        list_DataGridView.Rows[i].Cells[6].Value.ToString() + "','" +
                        list_DataGridView.Rows[i].Cells[6].Value.ToString() + "','" +
                        list_DataGridView.Rows[i].Cells[7].Value.ToString() + "','" +
                        list_DataGridView.Rows[i].Cells[7].Value.ToString() + "',N'" +
                        wating_geting.ToString() + "','" +
                        list_DataGridView.Rows[i].Cells[0].Value.ToString() + "',N'" +
                        list_DataGridView.Rows[i].Cells[1].Value.ToString() + "',N'" +
                        list_DataGridView.Rows[i].Cells[2].Value.ToString() + "','" +
                        list_DataGridView.Rows[i].Cells[3].Value.ToString() + "',N'" +
                        list_DataGridView.Rows[i].Cells[5].Value.ToString() + "','" +
                        list_DataGridView.Rows[i].Cells[4].Value.ToString() + "',N'" +
                        seller_name.Text + "','" +
                        sell_date_TextBox.Text + "')", con);

                        con.Open();
                        sqlcmd.ExecuteNonQuery();
                        con.Close();

                        //ADD IN ORDER
                        if (Type_of_account == "بەکارهێنەر")
                        {
                            SqlCommand sqlcmdo = new SqlCommand("insert into Order_list(SubCategory,Customer,Phone,Total_dolar,Total_dinar,Product_ID,Category,Brand,Model,Properties,Piece,Date,Seller) " +
                            "values(N'" + "فرۆشتن بە کاش" + "',N'" +
                            name_textbox.Text + "',N'" +
                            phone_textbox.Text + "','" +
                            list_DataGridView.Rows[i].Cells[6].Value.ToString() + "','" +
                            list_DataGridView.Rows[i].Cells[7].Value.ToString() + "','" +
                            list_DataGridView.Rows[i].Cells[0].Value.ToString() + "',N'" +
                            list_DataGridView.Rows[i].Cells[1].Value.ToString() + "',N'" +
                            list_DataGridView.Rows[i].Cells[2].Value.ToString() + "','" +
                            list_DataGridView.Rows[i].Cells[3].Value.ToString() + "',N'" +
                            list_DataGridView.Rows[i].Cells[5].Value.ToString() + "','" +
                            list_DataGridView.Rows[i].Cells[4].Value.ToString() + "','" +
                            sell_date_TextBox.Text + "',N'" +
                            seller_name.Text + "')", con);

                            con.Open();
                            sqlcmdo.ExecuteNonQuery();
                            con.Close();
                        }

                        con.Open();
                        SqlCommand scom = new SqlCommand("select * from Products where Id ='" + list_DataGridView.Rows[i].Cells[0].Value + "'", con);
                        SqlDataReader reader = scom.ExecuteReader();
                        reader.Read();
                        int selected_product_piece = Convert.ToInt32(reader["Piece"]);
                        con.Close();

                        int selled_piece = selected_product_piece - Convert.ToInt32(list_DataGridView.Rows[i].Cells[4].Value);
                        SqlCommand cmds = new SqlCommand("update Products set Piece=" + selled_piece + "where Id='" + list_DataGridView.Rows[i].Cells[0].Value + "'", con);

                        con.Open();
                        cmds.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        MessageBox.Show(ex.ToString());
                        break;
                    }
                }
                selected_products_DataGridView.Rows.Clear();
                list_DataGridView.Rows.Clear();
                name_textbox.Text = null;
                phone_textbox.Text = null;
                address_textbox.Text = "چوارقوڕنە";
                take.Checked = false;
                total_dolarTextBox1.Text = null;
                total_dinar_TextBox.Text = null;
                dept_sell_Button.Enabled = true;
                cash_sell_Button.Enabled = true;
                total_dolarTextBox1.Text = null;
                total_dinar_TextBox.Text = null;
                sell_cash_panel.Hide();

                SqlDataAdapter sqld = new SqlDataAdapter("select * from Selled_bill", con);
                DataSet datareport = new DataSet();
                sqld.Fill(datareport, "Selled_bill");

                cash_selled_bill_CrystalReport my = new cash_selled_bill_CrystalReport();
                my.SetDataSource(datareport);
                print_cash_bill p_c_b = new print_cash_bill();
                p_c_b.cash_crystalReportViewer.ReportSource = my;
                p_c_b.ShowDialog();

                SqlDataAdapter dp = new SqlDataAdapter("select * from Products order by Id", con);
                DataTable dtp = new DataTable();
                dp.Fill(dtp);
                select_product_DataGridView.DataSource = dtp;
                select_product_DataGridView.Refresh();

                SqlDataAdapter adp = new SqlDataAdapter("select * from Selleds", con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                selled_DataGridView1.DataSource = dt;
                selled_DataGridView1.Refresh();

                if (Type_of_account == "بەکارهێنەر")
                {
                    SqlDataAdapter sqlo = new SqlDataAdapter("select * from Order_list", con);
                    DataTable dto = new DataTable();
                    sqlo.Fill(dto);
                    order_list_DataGridView.DataSource = dto;
                    order_list_DataGridView.Refresh();
                }
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message.ToString() + " : هەڵە یەک هەیە لە فرۆشتنەکەدا کە بریتیە لە ");
            }
        }

        private void selled_search_textbox_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Selleds where ID like '%" + selled_search_textbox.Text + "%' or Customer like N'%" + selled_search_textbox.Text + "%' or Phone like N'%" + selled_search_textbox.Text + "%' or Product_ID like '%" + selled_search_textbox.Text + "%' or Category like N'%" + selled_search_textbox.Text + "%' or Brand like N'%" + selled_search_textbox.Text + "%' or Model like '%" + selled_search_textbox.Text + "%'", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            selled_DataGridView1.DataSource = dt;
            selled_DataGridView1.Refresh();
        }

        private void selled_list_button_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'allDataSet.Selleds' table. You can move, or remove it, as needed.
                this.selledsTableAdapter.Fill(this.allDataSet.Selleds);

                selled_list_panel.Visible = true;
                selled_list_button.Visible = false;
                menuStrip.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void close_selled_list_Click_1(object sender, EventArgs e)
        {
            selled_list_panel.Visible = false;
            selled_list_button.Visible = true;
            menuStrip.Enabled = true;
        }

        //dept sell
        private void name_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (name_comboBox.SelectedItem != null)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from Customer where ID ='" + name_comboBox.SelectedValue.ToString() + "'", con);
                    DataTable dt = new DataTable();
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        dept_phone_TextBox.Text = dr[2].ToString();
                        dept_addres_TextBox.Text = dr[4].ToString();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void dept_add_name_Button_Click(object sender, EventArgs e)
        {
            visible();
            costomer_panel.Visible = true;
            go_back_to_sell_Button.Visible = true;
        }

        private void go_back_to_sell_Button_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter sqld = new SqlDataAdapter("select * from Customer", con);
                DataTable dt = new DataTable();
                sqld.Fill(dt);

                name_comboBox.DataSource = null;
                name_comboBox.DataSource = dt;
                name_comboBox.DisplayMember = "Customer_Name";
                name_comboBox.ValueMember = "ID";
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.ToString());
            }

            visible();
            go_back_to_sell_Button.Visible = false;
            menuStrip.Visible = true;
            sell_panel.Visible = true;
            sell_dept_Panel.Visible = true;
        }

        private void close_dept_sell_Button_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("دڵنیای لە داخستنی پەڕەی فرۆشتنی بە قەرز", "داخستن", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                dept_sell_Button.Enabled = true;
                cash_sell_Button.Enabled = true;
                sell_dept_Panel.Visible = false;
                dept_list_DataGridView.Rows.Clear();
                name_comboBox.SelectedItem = null;
            }
        }

        private void dept_sell_Button_Click(object sender, EventArgs e)
        {
            name_comboBox.SelectedItem = null;
            if (selected_products_DataGridView.RowCount > 0)
            {
                try
                {
                    for (int i = 0; i < selected_products_DataGridView.RowCount; i++)
                    {
                        int total_dolar = 0;
                        total_dolar = Convert.ToInt32(selected_products_DataGridView.Rows[i].Cells[8].Value) * Convert.ToInt32(selected_products_DataGridView.Rows[i].Cells[6].Value);
                        int total_dinar = 0;
                        total_dinar = Convert.ToInt32(selected_products_DataGridView.Rows[i].Cells[9].Value) * Convert.ToInt32(selected_products_DataGridView.Rows[i].Cells[6].Value);

                        string[] row = {
                        selected_products_DataGridView.Rows[i].Cells[1].Value.ToString(),
                        selected_products_DataGridView.Rows[i].Cells[2].Value.ToString(),
                        selected_products_DataGridView.Rows[i].Cells[3].Value.ToString(),
                        selected_products_DataGridView.Rows[i].Cells[4].Value.ToString(),
                        selected_products_DataGridView.Rows[i].Cells[6].Value.ToString(),
                        selected_products_DataGridView.Rows[i].Cells[7].Value.ToString(),
                        total_dolar.ToString(),
                        "0",
                        total_dolar.ToString(),
                        total_dinar.ToString(),
                        "0",
                        total_dinar.ToString(),
                        selected_products_DataGridView.Rows[i].Cells[10].Value.ToString(),
                        selected_products_DataGridView.Rows[i].Cells[11].Value.ToString(),
                        selected_products_DataGridView.Rows[i].Cells[12].Value.ToString() };

                        dept_list_DataGridView.Rows.Add(row);
                    }

                    dept_total_dolar_TextBox.Text = total_dolarTextBox1.Text;
                    dept_remainder_dolar_TextBox.Text = total_dolarTextBox1.Text;
                    dept_total_dinar_TextBox.Text = total_dinar_TextBox.Text;
                    dept_remainder_dinar_TextBox.Text = total_dinar_TextBox.Text;
                    dept_seller_TextBox.Text = user_pass_name;
                    dept_date_TextBox.Text = sell_date_TextBox.Text;

                    dept_sell_Button.Enabled = false;
                    cash_sell_Button.Enabled = false;
                    sell_dept_Panel.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else
            {
                MessageBox.Show("هیچ کەلوپەلێک دیاری نەکراوە بۆ فرۆشتن", "!ئاگادەربە", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dept_take_dolar_TextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dept_take_dolar_TextBox.TextLength != 0 && dept_take_dinar_TextBox.TextLength != 0)
                {
                    dept_remainder_dolar_TextBox.Text = (Convert.ToInt32(dept_total_dolar_TextBox.Text) - Convert.ToInt32(dept_take_dolar_TextBox.Text)).ToString();
                    dept_remainder_dinar_TextBox.Text = (Convert.ToInt32(dept_total_dinar_TextBox.Text) - Convert.ToInt32(dept_take_dinar_TextBox.Text)).ToString();
                    if (dept_list_DataGridView.RowCount == 1)
                    {
                        dept_list_DataGridView.Rows[0].Cells[7].Value = dept_take_dolar_TextBox.Text;
                        dept_list_DataGridView.Rows[0].Cells[10].Value = dept_take_dinar_TextBox.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void sell_dept_Button_Click(object sender, EventArgs e)
        {
            string wating_geting;
            if (dept_take_CheckBox.Checked == true)
            {
                wating_geting = "وەرنەگیراوە";
            }
            else
            {
                wating_geting = "وەرگیراوە";
            }
            try
            {
                SqlCommand sqc = new SqlCommand("delete Selled_bill", con);
                con.Open();
                sqc.ExecuteNonQuery();
                con.Close();

                for (int i = 0; i < dept_list_DataGridView.RowCount; i++)
                {
                    try
                    {
                        SqlCommand cmd_b = new SqlCommand("insert into Selled_bill(id,Customer,Phone,Address,Cash,Total_dolar,Cost_take_dolar,Remainder_dolar,Total_dinar,Cost_take_dinar,Remainder_dinar,Waiting_to_geting,Product_ID,Category,Brand,Model,Piece,Properties,price_dolar,price_dinar,Size,Color,Warranty,Seller) " +
                        "values('" + i + "',N'" +
                        name_comboBox.Text + "',N'" +
                        dept_phone_TextBox.Text + "',N'" +
                        dept_addres_TextBox.Text + "',N'" +
                        "فرۆشتن بە قەرز" + "','" +
                        dept_total_dolar_TextBox.Text + "','" +
                        dept_take_dolar_TextBox.Text + "','" +
                        dept_remainder_dolar_TextBox.Text + "','" +
                        dept_total_dinar_TextBox.Text + "','" +
                        dept_take_dinar_TextBox.Text + "','" +
                        dept_remainder_dinar_TextBox.Text + "',N'" +
                        wating_geting.ToString() + "','" +
                        dept_list_DataGridView.Rows[i].Cells[0].Value.ToString() + "',N'" +
                        dept_list_DataGridView.Rows[i].Cells[1].Value.ToString() + "',N'" +
                        dept_list_DataGridView.Rows[i].Cells[2].Value.ToString() + "','" +
                        dept_list_DataGridView.Rows[i].Cells[3].Value.ToString() + "','" +
                        dept_list_DataGridView.Rows[i].Cells[4].Value.ToString() + "',N'" +
                        dept_list_DataGridView.Rows[i].Cells[5].Value.ToString() + "','" +
                        dept_list_DataGridView.Rows[i].Cells[6].Value.ToString() + "','" +
                        dept_list_DataGridView.Rows[i].Cells[9].Value.ToString() + "',N'" +
                        dept_list_DataGridView.Rows[i].Cells[12].Value.ToString() + "',N'" +
                        dept_list_DataGridView.Rows[i].Cells[13].Value.ToString() + "',N'" +
                        dept_list_DataGridView.Rows[i].Cells[14].Value.ToString() + "',N'" +
                        dept_seller_TextBox.Text + "')", con);

                        con.Open();
                        cmd_b.ExecuteNonQuery();
                        con.Close();

                        //ADD IN SELLEDS
                        SqlCommand sqlcmd = new SqlCommand("insert into Selleds(Customer,Phone,Address,Cash,Total_dolar,Total_dinar,Waiting_to_geting,Product_ID,Category,Brand,Model,Properties,Piece,Seller,Date) " +
                        "values(N'" + name_comboBox.Text + "',N'" +
                        dept_phone_TextBox.Text + "',N'" +
                        dept_addres_TextBox.Text + "',N'" +
                        "فرۆشتن بە قەرز" + "','" +
                        dept_list_DataGridView.Rows[i].Cells[6].Value.ToString() + "','" +
                        dept_list_DataGridView.Rows[i].Cells[9].Value.ToString() + "',N'" +
                        wating_geting.ToString() + "','" +
                        dept_list_DataGridView.Rows[i].Cells[0].Value.ToString() + "',N'" +
                        dept_list_DataGridView.Rows[i].Cells[1].Value.ToString() + "',N'" +
                        dept_list_DataGridView.Rows[i].Cells[2].Value.ToString() + "','" +
                        dept_list_DataGridView.Rows[i].Cells[3].Value.ToString() + "',N'" +
                        dept_list_DataGridView.Rows[i].Cells[5].Value.ToString() + "','" +
                        dept_list_DataGridView.Rows[i].Cells[4].Value.ToString() + "',N'" +
                        dept_seller_TextBox.Text + "','" +
                        dept_date_TextBox.Text + "')", con);

                        con.Open();
                        sqlcmd.ExecuteNonQuery();
                        con.Close();

                        //ADD IN DEPTS
                        SqlCommand sqlcmdd = new SqlCommand("insert into Depts(Customer_Name,Phone,Dolar,Dinar,Sell_ID,Product_ID,Category,Brand,Date,Seller) " +
                        "values(N'" + name_comboBox.Text + "',N'" +
                        dept_phone_TextBox.Text + "','" +
                        dept_list_DataGridView.Rows[i].Cells[8].Value.ToString() + "','" +
                        dept_list_DataGridView.Rows[i].Cells[11].Value.ToString() + "','" +
                        dept_list_DataGridView.Rows[i].Cells[4].Value.ToString() + "','" +
                        dept_list_DataGridView.Rows[i].Cells[0].Value.ToString() + "',N'" +
                        dept_list_DataGridView.Rows[i].Cells[1].Value.ToString() + "',N'" +
                        dept_list_DataGridView.Rows[i].Cells[2].Value.ToString() + "','" +
                        dept_date_TextBox.Text + "',N'" +
                        dept_seller_TextBox.Text + "')", con);

                        con.Open();
                        sqlcmdd.ExecuteNonQuery();
                        con.Close();

                        //ADD IN ORDER
                        if (Type_of_account == "بەکارهێنەر")
                        {
                            SqlCommand sqlcmdo = new SqlCommand("insert into Order_list(SubCategory,Customer,Phone,Total_dolar,Cost_take_dolar,remainder_dolar,Total_dinar,Cost_take_dinar,remainder_dinar,Product_ID,Category,Brand,Model,Properties,Piece,Date,Seller) " +
                            "values(N'" + "فرۆشتن بە قەرز" + "',N'" +
                            name_comboBox.Text + "',N'" +
                            dept_phone_TextBox.Text + "','" +
                            dept_list_DataGridView.Rows[i].Cells[6].Value.ToString() + "','" +
                            dept_list_DataGridView.Rows[i].Cells[7].Value.ToString() + "','" +
                            dept_list_DataGridView.Rows[i].Cells[8].Value.ToString() + "','" +
                            dept_list_DataGridView.Rows[i].Cells[9].Value.ToString() + "','" +
                            dept_list_DataGridView.Rows[i].Cells[10].Value.ToString() + "','" +
                            dept_list_DataGridView.Rows[i].Cells[11].Value.ToString() + "','" +
                            dept_list_DataGridView.Rows[i].Cells[0].Value.ToString() + "',N'" +
                            dept_list_DataGridView.Rows[i].Cells[1].Value.ToString() + "',N'" +
                            dept_list_DataGridView.Rows[i].Cells[2].Value.ToString() + "','" +
                            dept_list_DataGridView.Rows[i].Cells[3].Value.ToString() + "',N'" +
                            dept_list_DataGridView.Rows[i].Cells[5].Value.ToString() + "','" +
                            dept_list_DataGridView.Rows[i].Cells[4].Value.ToString() + "','" +
                            dept_date_TextBox.Text + "',N'" +
                            dept_seller_TextBox.Text + "')", con);

                            con.Open();
                            sqlcmdo.ExecuteNonQuery();
                            con.Close();

                            con.Open();
                            SqlCommand scom = new SqlCommand("select * from Products where Id ='" + dept_list_DataGridView.Rows[i].Cells[0].Value + "'", con);
                            SqlDataReader reader = scom.ExecuteReader();
                            reader.Read();
                            int selected_product_piece = Convert.ToInt32(reader["Piece"]);
                            con.Close();

                            int selled_piece = selected_product_piece - Convert.ToInt32(dept_list_DataGridView.Rows[i].Cells[4].Value);
                            SqlCommand cmd = new SqlCommand("update Products set Piece=" + selled_piece + "where Id='" + dept_list_DataGridView.Rows[i].Cells[0].Value + "'", con);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        break;
                    }
                }
                selected_products_DataGridView.Rows.Clear();
                dept_list_DataGridView.Rows.Clear();
                name_comboBox.SelectedItem = null;
                dept_phone_TextBox.Text = null;
                dept_addres_TextBox.Text = "چوارقوڕنە";
                dept_take_CheckBox.Checked = false;
                dept_total_dolar_TextBox.Text = null;
                dept_take_dolar_TextBox.Text = null;
                dept_remainder_dolar_TextBox.Text = null;
                dept_total_dinar_TextBox.Text = null;
                dept_take_dinar_TextBox.Text = null;
                dept_remainder_dinar_TextBox.Text = null;
                dept_sell_Button.Enabled = true;
                cash_sell_Button.Enabled = true;
                total_dolarTextBox1.Text = null;
                total_dinar_TextBox.Text = null;
                sell_dept_Panel.Hide();

                SqlDataAdapter sqld = new SqlDataAdapter("select * from Selled_bill", con);
                DataSet datareport = new DataSet();
                sqld.Fill(datareport, "Selled_bill");

                cash_selled_bill_CrystalReport my = new cash_selled_bill_CrystalReport();
                my.SetDataSource(datareport);
                print_cash_bill p_c_b = new print_cash_bill();
                p_c_b.cash_crystalReportViewer.ReportSource = my;
                p_c_b.ShowDialog();

                SqlDataAdapter dp = new SqlDataAdapter("select * from Products order by Id", con);
                DataTable dtp = new DataTable();
                dp.Fill(dtp);
                select_product_DataGridView.DataSource = dtp;
                select_product_DataGridView.Refresh();

                SqlDataAdapter adp = new SqlDataAdapter("select * from Selleds", con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                selled_DataGridView1.DataSource = dt;
                selled_DataGridView1.Refresh();

                SqlDataAdapter add = new SqlDataAdapter("select * from Depts", con);
                DataTable dtd = new DataTable();
                add.Fill(dtd);
                depts_list_DataGridView.DataSource = dtd;
                depts_list_DataGridView.Refresh();

                if (Type_of_account == "بەکارهێنەر")
                {
                    SqlDataAdapter sqlo = new SqlDataAdapter("select * from Order_list", con);
                    DataTable dto = new DataTable();
                    sqlo.Fill(dto);
                    order_list_DataGridView.DataSource = dto;
                    order_list_DataGridView.Refresh();
                }
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message.ToString() + " : هەڵە یەک هەیە لە فرۆشتنەکەدا کە بریتیە لە ");
            }
        }

        private void dept_list_DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int take_total_all_dolar = 0;
                int take_total_all_dinar = 0;
                for (int i = 0; i < dept_list_DataGridView.RowCount; i++)
                {
                    take_total_all_dolar += Convert.ToInt32(dept_list_DataGridView.Rows[i].Cells[7].Value);
                    take_total_all_dinar += Convert.ToInt32(dept_list_DataGridView.Rows[i].Cells[10].Value);
                }


                if (dept_list_DataGridView.Columns[e.ColumnIndex].Name == "Column3")
                {
                    if (take_total_all_dolar < Convert.ToInt32(dept_list_DataGridView.CurrentRow.Cells[7].Value))
                    {
                        MessageBox.Show("بڕی وەرگیراوی دۆلار لە لیستەکەدا گەورەترە لە سەرجەمی بڕی وەرگیراوی دۆلار", "!ئاگاداربە", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    int total_dolar = Convert.ToInt32(dept_list_DataGridView.CurrentRow.Cells[6].Value);
                    int take_dolar = Convert.ToInt32(dept_list_DataGridView.CurrentRow.Cells[7].Value);
                    if (take_dolar <= total_dolar)
                    {
                        dept_list_DataGridView.CurrentRow.Cells[8].Value = (total_dolar - take_dolar);
                    }
                    else
                    {
                        MessageBox.Show("بڕی وەرگیراوی دۆلار گەورەترە لە سەرجەمی دۆلار", "!ئاگاداربە", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (dept_list_DataGridView.Columns[e.ColumnIndex].Name == "Column5")
                {
                    if (take_total_all_dinar < Convert.ToInt32(dept_list_DataGridView.CurrentRow.Cells[10].Value))
                    {
                        MessageBox.Show("بڕی وەرگیراوی دینار لە لیستەکەدا گەورەترە لە سەرجەمی بڕی وەرگیراوی دینار", "!ئاگاداربە", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    int total_dinar = Convert.ToInt32(dept_list_DataGridView.CurrentRow.Cells[9].Value);
                    int take_dinar = Convert.ToInt32(dept_list_DataGridView.CurrentRow.Cells[10].Value);
                    if (take_dinar <= total_dinar)
                    {
                        dept_list_DataGridView.CurrentRow.Cells[11].Value = (total_dinar - take_dinar);
                    }
                    else
                    {
                        MessageBox.Show("بڕی وەرگیراوی دینار گەورەترە لە سەرجەمی دینار", "!ئاگاداربە", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //costomers
        private void costomer_insert_Button_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Customer(Customer_Name,Phone,Phone2,Addres,Type,Wrrantor,Wrrantor_phone,Note,Date,Seller) " +
                "values(N'" + costomer_DataGridView3.CurrentRow.Cells[1].Value.ToString() + "',N'" +
                costomer_DataGridView3.CurrentRow.Cells[2].Value.ToString() + "',N'" +
                costomer_DataGridView3.CurrentRow.Cells[3].Value.ToString() + "',N'" +
                costomer_DataGridView3.CurrentRow.Cells[4].Value.ToString() + "',N'" +
                costomer_DataGridView3.CurrentRow.Cells[5].Value.ToString() + "',N'" +
                costomer_DataGridView3.CurrentRow.Cells[6].Value.ToString() + "',N'" +
                costomer_DataGridView3.CurrentRow.Cells[7].Value.ToString() + "',N'" +
                costomer_DataGridView3.CurrentRow.Cells[8].Value.ToString() + "','" +
                date_label.Text + "',N'" +
                seller_name.Text + "')", con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            SqlDataAdapter sa = new SqlDataAdapter("select * from Customer", con);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            costomer_DataGridView3.DataSource = dt;
            costomer_DataGridView3.FirstDisplayedScrollingRowIndex = costomer_DataGridView3.RowCount - 1;
            Interaction.Beep();
        }

        private void costomer_search_TextBox2_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Customer where ID like '%" + costomer_search_TextBox2.Text + "%' or Name like N'%" + costomer_search_TextBox2.Text + "%' or Phone like N'%" + costomer_search_TextBox2.Text + "%' or Phone2 like N'%" + costomer_search_TextBox2.Text + "%' or Wrrantor like N'%" + costomer_search_TextBox2.Text + "%' or Wrrantor_phone like N'%" + costomer_search_TextBox2.Text + "%'", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            costomer_DataGridView3.DataSource = dt;
            costomer_DataGridView3.Refresh();
        }

        private void costomer_update_Button_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("update Customer set " +
                "Customer_Name=N'" + costomer_DataGridView3.CurrentRow.Cells[1].Value.ToString() + "'," +
                "Phone=N'" + costomer_DataGridView3.CurrentRow.Cells[2].Value.ToString() + "'," +
                "Phone2=N'" + costomer_DataGridView3.CurrentRow.Cells[3].Value.ToString() + "'," +
                "Addres=N'" + costomer_DataGridView3.CurrentRow.Cells[4].Value.ToString() + "'," +
                "Type=N'" + costomer_DataGridView3.CurrentRow.Cells[5].Value.ToString() + "'," +
                "Wrrantor=N'" + costomer_DataGridView3.CurrentRow.Cells[6].Value.ToString() + "'," +
                "Wrrantor_phone=N'" + costomer_DataGridView3.CurrentRow.Cells[7].Value.ToString() + "'," +
                "Note=N'" + costomer_DataGridView3.CurrentRow.Cells[8].Value.ToString() + "'," +
                "Seller=N'" + seller_name.Text + "'" +
                "where ID='" + costomer_DataGridView3.CurrentRow.Cells[0].Value.ToString() + "'", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                SqlDataAdapter sa = new SqlDataAdapter("select * from Customer", con);
                DataTable dt = new DataTable();
                sa.Fill(dt);
                costomer_DataGridView3.DataSource = dt;
                costomer_DataGridView3.FirstDisplayedScrollingRowIndex = costomer_DataGridView3.RowCount - 1;
                Interaction.Beep();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void costomer_refresh_Button_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sa = new SqlDataAdapter("select * from Customer", con);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            costomer_DataGridView3.DataSource = dt;
            costomer_DataGridView3.Refresh();
            Interaction.Beep();
        }

        //order_list
        private void order_list_search_TextBox_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Order_list where ID like '%" + order_list_search_TextBox.Text + "%' or SubCategory like N'%" + order_list_search_TextBox.Text + "%' or Customer like N'%" + order_list_search_TextBox.Text + "%' or Phone like N'%" + order_list_search_TextBox.Text + "%' or Product_ID like '%" + order_list_search_TextBox.Text + "%' or Category like N'%" + order_list_search_TextBox.Text + "%' or Brand like N'%" + order_list_search_TextBox.Text + "%' or Model like '%" + order_list_search_TextBox.Text + "%' or Date like N'%" + order_list_search_TextBox.Text + "%' or Seller like N'%" + order_list_search_TextBox.Text + "%'", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            order_list_DataGridView.DataSource = dt;
            order_list_DataGridView.Refresh();
        }

        private void order_list_DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (order_list_DataGridView.Columns[e.ColumnIndex].Name == "Cost_take_dolar")
                {
                    int total_dolar = Convert.ToInt32(order_list_DataGridView.CurrentRow.Cells[4].Value);
                    int take_dolar = Convert.ToInt32(order_list_DataGridView.CurrentRow.Cells[5].Value);
                    int total_dinar = Convert.ToInt32(order_list_DataGridView.CurrentRow.Cells[7].Value);
                    int take_dinar = Convert.ToInt32(order_list_DataGridView.CurrentRow.Cells[8].Value);

                    if (total_dolar < take_dolar)
                    {
                        order_list_DataGridView.CurrentRow.Cells[6].Value = total_dolar - take_dolar;
                        order_list_DataGridView.CurrentRow.Cells[9].Value = total_dinar - take_dinar;
                    }
                    else
                    {
                        MessageBox.Show("بڕی وەرگیراو گەورەترە لە سەرجەم", "!ئاگاداربە", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void sum_Button_Click(object sender, EventArgs e)
        {
            if (Type_of_account == "بەکارهێنەر")
            {
                pass_order_list_to_old_order_listButton.Enabled = false;
            }

            if (order_list_DataGridView.RowCount != 0)
            {
                try
                {
                    SqlDataAdapter sqls = new SqlDataAdapter("select DISTINCT seller from Order_list", con);
                    DataTable dts = new DataTable();
                    sqls.Fill(dts);

                    seller_name_ComboBox.DataSource = null;
                    seller_name_ComboBox.DataSource = dts;
                    seller_name_ComboBox.DisplayMember = "seller";
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.ToString());
                }

                seller_name_Panel.Visible = true;
                sum_order_list_Panel.Visible = false;
                order_list_DataGridView.Enabled = false;
                sum_Button.Enabled = false;
                old_order_list_Button5.Enabled = false;
                refresh_order_listButton4.Enabled = false;
                update_order_list_Button.Enabled = false;
                order_list_search_TextBox.Enabled = false;
                menuStrip.Enabled = false;
            }
            else
            {
                MessageBox.Show(".هیچ تۆمارێک لە لیستی ئەنجامدراوەکان نەدۆزرایەوە", "ببورە");
            }
        }

        public void close_order_list()
        {
            seller_name_Panel.Visible = false;
            sum_order_list_Panel.Visible = false;
            order_list_DataGridView.Enabled = true;
            sum_Button.Enabled = true;
            old_order_list_Button5.Enabled = true;
            refresh_order_listButton4.Enabled = true;
            update_order_list_Button.Enabled = true;
            order_list_search_TextBox.Enabled = true;
            menuStrip.Enabled = true;
        }

        private void close_sum_order_list_Button_Click(object sender, EventArgs e)
        {
            close_order_list();
        }

        private void close_user_name_Button_Click(object sender, EventArgs e)
        {
            close_order_list();
        }

        private void seller_name_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            seller_name_Panel.Visible = false;
            int total_dolar_order = 0;
            int total_dinar_order = 0;
            int sell_cash = 0, sell_dept = 0, r_dept = 0, r_take = 0, take_m = 0, spend = 0, more = 0;
            try
            {
                if (seller_name_ComboBox.SelectedItem != null)
                {
                    SqlCommand cmd = new SqlCommand("select * from Order_list where Seller like N'%" + seller_name_ComboBox.Text + "%'", con);
                    DataTable dt = new DataTable();
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr[1].ToString() == "فرۆشتن بە کاش")
                        {
                            total_dolar_order += Convert.ToInt32(dr[5]);
                            total_dinar_order += Convert.ToInt32(dr[8]);
                            sell_cash += 1;
                        }
                        if (dr[1].ToString() == "فرۆشتن بە قەرز")
                        {
                            total_dolar_order += Convert.ToInt32(dr[5]);
                            total_dinar_order += Convert.ToInt32(dr[8]);
                            sell_dept += 1;
                        }
                        else if (dr[1].ToString() == "گێڕانەوەی قەرز")
                        {
                            total_dolar_order += Convert.ToInt32(dr[5]);
                            total_dinar_order += Convert.ToInt32(dr[8]);
                            r_dept += 1;
                        }
                        else if (dr[1].ToString() == "گەڕاندنەوە")
                        {
                            total_dolar_order -= Convert.ToInt32(dr[4]);
                            total_dinar_order -= Convert.ToInt32(dr[7]);
                            r_take += 1;
                        }
                        else if (dr[1].ToString() == "وەرگرتنی پارە")
                        {
                            total_dolar_order += Convert.ToInt32(dr[5]);
                            total_dinar_order += Convert.ToInt32(dr[8]);
                            take_m += 1;
                        }
                        else if (dr[1].ToString() == "سەرفکردن")
                        {
                            total_dolar_order -= Convert.ToInt32(dr[4]);
                            total_dinar_order -= Convert.ToInt32(dr[7]);
                            spend += 1;
                        }
                        else if (dr[1].ToString() == "هتد")
                        {
                            more += 1;
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }

            total_dolar_order_TextBox.Text = total_dolar_order.ToString();
            total_dinar_order_TextBox.Text = total_dinar_order.ToString();
            sell_cash_label.Text = sell_cash.ToString();
            sell_dept_label.Text = sell_dept.ToString();
            r_dept_label.Text = r_dept.ToString();
            r_take_label.Text = r_take.ToString();
            take_m_label.Text = take_m.ToString();
            spend_label.Text = spend.ToString();
            total_label.Text = (sell_cash + sell_dept + r_dept + r_take + take_m + spend + more).ToString();
            selected_employes.Text = seller_name_ComboBox.Text;
            sum_order_list_Panel.Visible = true;
            order_list_DataGridView.Enabled = false;
            sum_Button.Enabled = false;
            old_order_list_Button5.Enabled = false;
            refresh_order_listButton4.Enabled = false;
            update_order_list_Button.Enabled = false;
            order_list_search_TextBox.Enabled = false;
            menuStrip.Enabled = false;
        }

        private void pass_order_list_to_old_order_listButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("دڵنیای لە گواستنەوەی داتاکانی ناو لیستی ئەنجامدراو بۆ ناو لیستی کۆن", "گواستنەوە", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (seller_name_ComboBox.SelectedItem != null)
                    {
                        SqlCommand cmdi = new SqlCommand("select * from Order_list where Seller like N'%" + seller_name_ComboBox.Text + "%'", con);
                        DataTable dti = new DataTable();
                        con.Open();
                        cmdi.ExecuteNonQuery();
                        con.Close();

                        SqlDataAdapter da = new SqlDataAdapter(cmdi);
                        da.Fill(dti);
                        foreach (DataRow dri in dti.Rows)
                        {
                            SqlCommand cmdwi = new SqlCommand("insert into Old_order_list (SubCategory,Customer,Phone,Total_dolar,Cost_take_dolar,remainder_dolar,Total_dinar,Cost_take_dinar,remainder_dinar,Product_ID,Category,Brand,Model,Properties,Piece,Note,Date,Seller) " +
                                "values(N'" + dri[1].ToString() + "',N'" +
                                dri[2].ToString() + "',N'" +
                                dri[3].ToString() + "','" +
                                dri[4] + "','" +
                                dri[5] + "','" +
                                dri[6] + "','" +
                                dri[7] + "','" +
                                dri[8] + "','" +
                                dri[9] + "','" +
                                dri[10] + "',N'" +
                                dri[11].ToString() + "',N'" +
                                dri[12].ToString() + "','" +
                                dri[13] + "',N'" +
                                dri[14].ToString() + "','" +
                                dri[15] + "',N'" +
                                dri[16].ToString() + "',N'" +
                                dri[17].ToString() + "',N'" +
                                dri[18].ToString() + "')", con);

                            SqlCommand sqc = new SqlCommand("delete Order_list where ID = " + dri[0], con);
                            con.Open();
                            cmdwi.ExecuteNonQuery();
                            sqc.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    SqlDataAdapter sqld = new SqlDataAdapter("select * from Order_list", con);
                    DataTable dt = new DataTable();
                    sqld.Fill(dt);
                    order_list_DataGridView.DataSource = dt;
                    order_list_DataGridView.Refresh();

                    SqlDataAdapter sa = new SqlDataAdapter("select * from Old_order_list", con);
                    DataTable dt_old = new DataTable();
                    sa.Fill(dt_old);
                    old_order_list_DataGridView.DataSource = dt_old;
                    old_order_list_DataGridView.Refresh();
                    close_order_list();

                    MessageBox.Show("سەرجەم داتاکانی لیستی ئەنجامدراوەکان کە لە لایەن " + seller_name_ComboBox.Text + " ئەنجامدرابوون خرایە لیستی کۆن");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    con.Close();
                }
            }
        }

        private void update_order_list_Button_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Order_list set " +
            "SubCategory=N'" + order_list_DataGridView.CurrentRow.Cells[1].Value.ToString() + "'," +
            "Customer=N'" + order_list_DataGridView.CurrentRow.Cells[2].Value.ToString() + "'," +
            "Phone=N'" + order_list_DataGridView.CurrentRow.Cells[3].Value.ToString() + "'," +
            "Total_dolar='" + order_list_DataGridView.CurrentRow.Cells[4].Value.ToString() + "'," +
            "Cost_take_dolar='" + order_list_DataGridView.CurrentRow.Cells[5].Value.ToString() + "'," +
            "remainder_dolar='" + order_list_DataGridView.CurrentRow.Cells[6].Value.ToString() + "'," +
            "Total_dinar='" + order_list_DataGridView.CurrentRow.Cells[7].Value.ToString() + "'," +
            "Cost_take_dinar='" + order_list_DataGridView.CurrentRow.Cells[8].Value.ToString() + "'," +
            "remainder_dinar='" + order_list_DataGridView.CurrentRow.Cells[9].Value.ToString() + "'," +
            "Note=N'" + order_list_DataGridView.CurrentRow.Cells[16].Value.ToString() + "'" +
            "where ID='" + order_list_DataGridView.CurrentRow.Cells[0].Value.ToString() + "'", con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter sa = new SqlDataAdapter("select * from Order_list", con);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            order_list_DataGridView.DataSource = dt;
            order_list_DataGridView.Refresh();
            Interaction.Beep();
        }

        private void refresh_order_listButton4_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqld = new SqlDataAdapter("select * from Order_list", con);
            DataTable dt = new DataTable();
            sqld.Fill(dt);
            order_list_DataGridView.DataSource = dt;
            order_list_DataGridView.Refresh();
        }

        private void old_order_list_Button5_Click(object sender, EventArgs e)
        {
            old_order_list_Panel.Visible = true;
            order_list_Panel.Visible = false;
            menuStrip.Visible = false;
        }

        private void go_back_order_Button_Click(object sender, EventArgs e)
        {
            old_order_list_Panel.Visible = false;
            order_list_Panel.Visible = true;
            menuStrip.Visible = true;
        }

        private void old_order_list_search_TextBox_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Old_order_list where ID like '%" + old_order_list_search_TextBox.Text + "%' or SubCategory like N'%" + old_order_list_search_TextBox.Text + "%' or Customer like N'%" + old_order_list_search_TextBox.Text + "%' or Phone like N'%" + old_order_list_search_TextBox.Text + "%' or Product_ID like '%" + old_order_list_search_TextBox.Text + "%' or Category like N'%" + old_order_list_search_TextBox.Text + "%' or Brand like N'%" + old_order_list_search_TextBox.Text + "%' or Model like '%" + old_order_list_search_TextBox.Text + "%' or Date like N'%" + old_order_list_search_TextBox.Text + "%' or Seller like N'%" + old_order_list_search_TextBox.Text + "%'", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            old_order_list_DataGridView.DataSource = dt;
            old_order_list_DataGridView.Refresh();
        }

        // Employees
        private void user_name_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (user_name_ComboBox.SelectedItem != null)
                {
                    SqlCommand cmd = new SqlCommand("select * from Employees where ID ='" + user_name_ComboBox.SelectedValue.ToString() + "'", con);
                    DataTable dt = new DataTable();
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        user_name_TextBox.Text = dr[1].ToString();
                        user_type_ComboBox.Text = dr[6].ToString();
                        user_email_TextBox.Text = dr[2].ToString();
                        user_password_TextBox.Text = dr[3].ToString();
                        user_birthday_DateTimePicker.Value = Convert.ToDateTime(dr[4]);
                        user_phone_TextBox.Text = dr[5].ToString();
                    }
                    con.Close();
                    user_upadet_Button3.Enabled = true;
                    user_delete_Button.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void user_upadet_Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (user_password_TextBox.Text.Length < 5)
                {
                    Interaction.Beep();
                    errorProvider1.SetError(user_password_TextBox, ".وشەی نهێنی نابێت لە ٥ پیت کەمتربێت");
                }
                else if (user_phone_TextBox.Text.Length < 11)
                {
                    Interaction.Beep();
                    errorProvider1.SetError(user_phone_TextBox, ".ژمارەی تەلەفۆنەکەت هەڵەیە");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("update Employees set " +
                    "Employees_Name=N'" + user_name_TextBox.Text + "'," +
                    "Type=N'" + user_type_ComboBox.Text + "'," +
                    "Email='" + user_email_TextBox.Text + "'," +
                    "Password='" + user_password_TextBox.Text + "'," +
                    "Birthday='" + user_birthday_DateTimePicker.Value + "'," +
                    "Phone='" + user_phone_TextBox.Text + "'" +
                    "where ID='" + user_name_ComboBox.SelectedValue.ToString() + "'", con);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show(".نوێکردنەوەکە بە سەرکەوتووی ئەنجامدرا");
                }
                user_name_ComboBox.SelectedItem = null;
                user_name_TextBox.Text = null;
                user_type_ComboBox.SelectedItem = null;
                user_email_TextBox.Text = null;
                user_password_TextBox.Text = null;
                user_phone_TextBox.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void user_add_Button_Click(object sender, EventArgs e)
        {
            user_name_ComboBox.SelectedItem = null;
            try
            {
                if (user_password_TextBox.Text.Length < 5)
                {
                    Interaction.Beep();
                    errorProvider1.SetError(user_password_TextBox, ".وشەی نهێنی نابێت لە ٥ پیت کەمتربێت");
                }
                else if (user_phone_TextBox.Text.Length < 11)
                {
                    Interaction.Beep();
                    errorProvider1.SetError(user_phone_TextBox, ".ژمارەی تەلەفۆنەکەت هەڵەیە");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("insert into Employees(Employees_Name,Type,Email,Password,Birthday,Phone) " +
                    "values(N'" + user_name_TextBox.Text + "',N'" +
                    user_type_ComboBox.Text + "','" +
                    user_email_TextBox.Text + "','" +
                    user_password_TextBox.Text + "','" +
                    user_birthday_DateTimePicker.Value + "','" +
                    user_phone_TextBox.Text + "')", con);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    SqlDataAdapter sqld = new SqlDataAdapter("select * from Employees", con);
                    DataTable dt = new DataTable();
                    sqld.Fill(dt);

                    user_name_ComboBox.DataSource = null;
                    user_name_ComboBox.DataSource = dt;
                    user_name_ComboBox.DisplayMember = "Employees_Name";
                    user_name_ComboBox.ValueMember = "ID";

                    MessageBox.Show(".زیادکردنەکە بە سەرکەوتووی ئەنجامدرا");
                    user_name_ComboBox.SelectedItem = null;
                    user_name_TextBox.Text = null;
                    user_type_ComboBox.SelectedItem = null;
                    user_email_TextBox.Text = null;
                    user_password_TextBox.Text = null;
                    user_phone_TextBox.Text = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void user_delete_Button_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(".دڵنیای لە سڕینەوەی بەکارهێنەری دیاریکراو", "سڕینەوە", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    SqlCommand sqc = new SqlCommand("delete Employees where ID = " + user_name_ComboBox.SelectedValue.ToString(), con);
                    con.Open();
                    sqc.ExecuteNonQuery();
                    con.Close();

                    SqlDataAdapter sqld = new SqlDataAdapter("select * from Employees", con);
                    DataTable dt = new DataTable();
                    sqld.Fill(dt);

                    user_name_ComboBox.DataSource = null;
                    user_name_ComboBox.DataSource = dt;
                    user_name_ComboBox.DisplayMember = "Employees_Name";
                    user_name_ComboBox.ValueMember = "ID";

                    MessageBox.Show(".سڕینەوەکە بە سەرکەوتووی ئەنجامدرا");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        //depts
        private void depts_search_TextBox_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Depts where ID like '%" + depts_search_TextBox.Text + "%' or Customer_Name like N'%" + depts_search_TextBox.Text + "%' or Phone like N'%" + depts_search_TextBox.Text + "%' or Product_ID like '%" + depts_search_TextBox.Text + "%' or Category like N'%" + depts_search_TextBox.Text + "%' or Brand like N'%" + depts_search_TextBox.Text + "%' or Note like N'%" + depts_search_TextBox.Text + "%' or Date like '%" + depts_search_TextBox.Text + "%' or Seller like N'%" + depts_search_TextBox.Text + "%'", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            depts_list_DataGridView.DataSource = dt;
            depts_list_DataGridView.Refresh();
        }

        string get_id;
        private void depts_list_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            take_cost_reback_dolar_TextBox.ReadOnly = false;
            take_cost_reback_dinar_TextBox.ReadOnly = false;
            reback_remainder__dolar_TextBox.Text = "0";
            take_cost_reback_dolar_TextBox.Text = "0";
            reback_remainder_dinar_TextBox.Text = "0";
            take_cost_reback_dinar_TextBox.Text = "0";

            if (e.ColumnIndex == 0)
            {
                get_id = depts_list_DataGridView.CurrentRow.Cells[2].Value.ToString();
                selected_dept_name_label.Text = depts_list_DataGridView.CurrentRow.Cells[3].Value.ToString();
                dept_total_dolarTextBox.Text = depts_list_DataGridView.CurrentRow.Cells[5].Value.ToString();
                dept_total_dinarTextBox.Text = depts_list_DataGridView.CurrentRow.Cells[6].Value.ToString();
                reback_remainder__dolar_TextBox.Text = depts_list_DataGridView.CurrentRow.Cells[5].Value.ToString();
                reback_remainder_dinar_TextBox.Text = depts_list_DataGridView.CurrentRow.Cells[6].Value.ToString();

                if (dept_total_dolarTextBox.Text == "0")
                {
                    take_cost_reback_dolar_TextBox.ReadOnly = true;
                }
                else if (dept_total_dinarTextBox.Text == "0")
                {
                    take_cost_reback_dinar_TextBox.ReadOnly = true;
                }
                reback_debt_Panel.Visible = true;
                menuStrip.Enabled = false;
                depts_search_TextBox.Enabled = false;
                depts_list_DataGridView.Enabled = false;
            }
            if (e.ColumnIndex == 1)
            {
                dept_id_label.Text = depts_list_DataGridView.CurrentRow.Cells[2].Value.ToString();
                dept_detli_name_label.Text = depts_list_DataGridView.CurrentRow.Cells[3].Value.ToString();
                dept_detli_phone_label.Text = depts_list_DataGridView.CurrentRow.Cells[4].Value.ToString();
                try
                {
                    SqlDataAdapter sa = new SqlDataAdapter("select * from Depts_detali where ID = " + depts_list_DataGridView.CurrentRow.Cells[2].Value.ToString() + "order by ID_detali", con);
                    DataTable dt = new DataTable();
                    sa.Fill(dt);
                    dept_detli_DataGridView.DataSource = dt;
                    dept_detli_DataGridView.Refresh();

                    if (dept_detli_DataGridView.RowCount >= 1)
                    {
                        dept_detli_total_dolar_TextBox.Text = depts_list_DataGridView.CurrentRow.Cells[5].Value.ToString();
                        dept_detli_total_dinar_TextBox.Text = depts_list_DataGridView.CurrentRow.Cells[6].Value.ToString();
                        dept_detali_Panel.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("هیچ گەڕانەوەیەکی قەرزی کەسی دیاری کراو نەدۆزرایەوە", "ببورە", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void take_cost_reback_TextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (take_cost_reback_dolar_TextBox.Text.Length != 0 && take_cost_reback_dinar_TextBox.TextLength != 0)
                {
                    if (Convert.ToInt32(dept_total_dolarTextBox.Text) >= Convert.ToInt32(take_cost_reback_dolar_TextBox.Text))
                    {
                        if (Convert.ToInt32(dept_total_dinarTextBox.Text) >= Convert.ToInt32(take_cost_reback_dinar_TextBox.Text))
                        {
                            try
                            {
                                reback_remainder__dolar_TextBox.Text = (Convert.ToInt32(dept_total_dolarTextBox.Text) - Convert.ToInt32(take_cost_reback_dolar_TextBox.Text)).ToString();
                                reback_remainder_dinar_TextBox.Text = (Convert.ToInt32(dept_total_dinarTextBox.Text) - Convert.ToInt32(take_cost_reback_dinar_TextBox.Text)).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                        else
                        {
                            MessageBox.Show("بڕی وەرگیراوی دینار زیاترە لە کۆی گشتی دینار", "!ئاگاداربە", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("بڕی وەرگیراوی دۆلار زیاترە لە کۆی گشتی دۆلار", "!ئاگاداربە", MessageBoxButtons.OK);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void close_reback_dept()
        {
            reback_debt_Panel.Visible = false;
            take_cost_reback_dolar_TextBox.ReadOnly = false;
            take_cost_reback_dinar_TextBox.ReadOnly = false;
            menuStrip.Enabled = true;
            depts_search_TextBox.Enabled = true;
            depts_list_DataGridView.Enabled = true;
        }

        private void close_reback_dept_Button_Click(object sender, EventArgs e)
        {
            close_reback_dept();
        }

        private void retake_money_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(dept_total_dolarTextBox.Text) >= Convert.ToInt32(take_cost_reback_dolar_TextBox.Text))
                {
                    if (Convert.ToInt32(dept_total_dinarTextBox.Text) >= Convert.ToInt32(take_cost_reback_dinar_TextBox.Text))
                    {
                        try
                        {
                            if (reback_remainder__dolar_TextBox.Text == "0" && reback_remainder_dinar_TextBox.Text == "0")
                            {
                                DialogResult dr = MessageBox.Show(".قەرزەکە سفر کرا، دڵنیای لە سڕینەوەی تۆماری قەرزی دیاریکراو", "سڕینەوە", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (dr == DialogResult.Yes)
                                {
                                    try
                                    {
                                        SqlCommand cmd = new SqlCommand("update Depts set " +
                                        "Dolar='" + reback_remainder__dolar_TextBox.Text + "'," +
                                        "Dinar='" + reback_remainder_dinar_TextBox.Text + "'" +
                                        "where ID='" + get_id + "'", con);

                                        int NUMBER_DETAIL = 0;
                                        try
                                        {
                                            SqlCommand cmdDD = new SqlCommand("select * from Depts_detali where ID ='" + depts_list_DataGridView.CurrentRow.Cells[2].Value.ToString() + "'", con);
                                            DataTable dtDD = new DataTable();
                                            con.Open();
                                            cmdDD.ExecuteNonQuery();
                                            con.Close();
                                            SqlDataAdapter daD = new SqlDataAdapter(cmdDD);
                                            daD.Fill(dtDD);
                                            foreach (DataRow drD in dtDD.Rows)
                                            {
                                                NUMBER_DETAIL += 1;
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.ToString());
                                        }

                                        SqlCommand sqlcmdd = new SqlCommand("insert into Depts_detali (ID,ID_detali,Customer_Name,Phone,Dolar,Dinar,Product_ID,Sell_ID,Category,Brand,Date,Seller) " +
                                        "values('" + depts_list_DataGridView.CurrentRow.Cells[2].Value.ToString() + "','" +
                                        NUMBER_DETAIL + "',N'" +
                                        depts_list_DataGridView.CurrentRow.Cells[3].Value.ToString() + "',N'" +
                                        depts_list_DataGridView.CurrentRow.Cells[4].Value.ToString() + "','" +
                                        depts_list_DataGridView.CurrentRow.Cells[5].Value.ToString() + "','" +
                                        depts_list_DataGridView.CurrentRow.Cells[6].Value.ToString() + "','" +
                                        depts_list_DataGridView.CurrentRow.Cells[7].Value.ToString() + "','" +
                                        depts_list_DataGridView.CurrentRow.Cells[8].Value.ToString() + "',N'" +
                                        depts_list_DataGridView.CurrentRow.Cells[9].Value.ToString() + "',N'" +
                                        depts_list_DataGridView.CurrentRow.Cells[10].Value.ToString() + "','" +
                                        date_label.Text + "',N'" +
                                        user_pass_name + "')", con);

                                        con.Open();
                                        sqlcmdd.ExecuteNonQuery();
                                        cmd.ExecuteNonQuery();
                                        con.Close();

                                        SqlCommand cmdD = new SqlCommand("select * from Depts_detali where ID ='" + depts_list_DataGridView.CurrentRow.Cells[2].Value.ToString() + "'", con);
                                        DataTable dtD = new DataTable();
                                        con.Open();
                                        cmdD.ExecuteNonQuery();
                                        con.Close();
                                        SqlDataAdapter da = new SqlDataAdapter(cmdD);
                                        da.Fill(dtD);
                                        foreach (DataRow drD in dtD.Rows)
                                        {

                                            SqlCommand sqlcmddb = new SqlCommand("insert into Dept_bill (ID_dept,ID_detali,Customer_Name,Phone,Dolar,remainder_dolar,Dinar,remainder_dinar,Product_ID,Sell_ID,Category,Brand,Date,Seller) " +
                                            "values('" + drD[0] + "','" +
                                            drD[1] + "',N'" +
                                            drD[2] + "',N'" +
                                            drD[3] + "','" +
                                            drD[4] + "','" +
                                            reback_remainder__dolar_TextBox.Text + "','" +
                                            drD[5] + "','" +
                                            reback_remainder_dinar_TextBox.Text + "','" +
                                            drD[6] + "','" +
                                            drD[7] + "',N'" +
                                            drD[8] + "',N'" +
                                            drD[9] + "','" +
                                            drD[10] + "',N'" +
                                            user_pass_name + "')", con);
                                            con.Open();
                                            sqlcmddb.ExecuteNonQuery();
                                            con.Close();

                                        }

                                        SqlDataAdapter sqld = new SqlDataAdapter("select * from Dept_bill order by ID_detali", con);
                                        DataSet ds = new DataSet();
                                        sqld.Fill(ds, "Dept_bill");

                                        dept_CrystalReport dept_bill = new dept_CrystalReport();
                                        dept_bill.SetDataSource(ds);
                                        print_cash_bill p_c_b = new print_cash_bill();
                                        p_c_b.cash_crystalReportViewer.ReportSource = dept_bill;
                                        p_c_b.ShowDialog();

                                        SqlCommand sqcD = new SqlCommand("delete Dept_bill", con);
                                        con.Open();
                                        sqcD.ExecuteNonQuery();
                                        con.Close();

                                        SqlCommand sqc = new SqlCommand("delete Depts where ID = " + get_id, con);
                                        SqlCommand sqc_d = new SqlCommand("delete Depts_detali where ID = " + get_id, con);

                                        con.Open();
                                        sqc.ExecuteNonQuery();
                                        sqc_d.ExecuteNonQuery();
                                        con.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.ToString());
                                    }
                                }
                            }
                            else
                            {
                                SqlCommand cmd = new SqlCommand("update Depts set " +
                                "Dolar='" + reback_remainder__dolar_TextBox.Text + "'," +
                                "Dinar='" + reback_remainder_dinar_TextBox.Text + "'" +
                                "where ID='" + get_id + "'", con);

                                int NUMBER_DETAIL = 0;
                                try
                                {
                                    SqlCommand cmdD = new SqlCommand("select * from Depts_detali where ID ='" + depts_list_DataGridView.CurrentRow.Cells[2].Value.ToString() + "'", con);
                                    DataTable dtD = new DataTable();
                                    con.Open();
                                    cmdD.ExecuteNonQuery();
                                    con.Close();
                                    SqlDataAdapter da = new SqlDataAdapter(cmdD);
                                    da.Fill(dtD);
                                    foreach (DataRow dr in dtD.Rows)
                                    {
                                        NUMBER_DETAIL += 1;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }

                                SqlCommand sqlcmdd = new SqlCommand("insert into Depts_detali (ID,ID_detali,Customer_Name,Phone,Dolar,Dinar,Product_ID,Sell_ID,Category,Brand,Date,Seller) " +
                                "values('" + depts_list_DataGridView.CurrentRow.Cells[2].Value.ToString() + "','" +
                                NUMBER_DETAIL + "',N'" +
                                depts_list_DataGridView.CurrentRow.Cells[3].Value.ToString() + "',N'" +
                                depts_list_DataGridView.CurrentRow.Cells[4].Value.ToString() + "','" +
                                depts_list_DataGridView.CurrentRow.Cells[5].Value.ToString() + "','" +
                                depts_list_DataGridView.CurrentRow.Cells[6].Value.ToString() + "','" +
                                depts_list_DataGridView.CurrentRow.Cells[7].Value.ToString() + "','" +
                                depts_list_DataGridView.CurrentRow.Cells[8].Value.ToString() + "',N'" +
                                depts_list_DataGridView.CurrentRow.Cells[9].Value.ToString() + "',N'" +
                                depts_list_DataGridView.CurrentRow.Cells[10].Value.ToString() + "','" +
                                date_label.Text + "',N'" +
                                user_pass_name + "')", con);

                                con.Open();
                                sqlcmdd.ExecuteNonQuery();
                                cmd.ExecuteNonQuery();
                                con.Close();

                                try
                                {
                                    SqlCommand cmdD = new SqlCommand("select * from Depts_detali where ID ='" + depts_list_DataGridView.CurrentRow.Cells[2].Value.ToString() + "'", con);
                                    DataTable dtD = new DataTable();
                                    con.Open();
                                    cmdD.ExecuteNonQuery();
                                    con.Close();
                                    SqlDataAdapter da = new SqlDataAdapter(cmdD);
                                    da.Fill(dtD);
                                    foreach (DataRow dr in dtD.Rows)
                                    {

                                        SqlCommand sqlcmddb = new SqlCommand("insert into Dept_bill (ID_dept,ID_detali,Customer_Name,Phone,Dolar,remainder_dolar,Dinar,remainder_dinar,Product_ID,Sell_ID,Category,Brand,Date,Seller) " +
                                        "values('" + dr[0] + "','" +
                                        dr[1] + "',N'" +
                                        dr[2] + "',N'" +
                                        dr[3] + "','" +
                                        dr[4] + "','" +
                                        reback_remainder__dolar_TextBox.Text + "','" +
                                        dr[5] + "','" +
                                        reback_remainder_dinar_TextBox.Text + "','" +
                                        dr[6] + "','" +
                                        dr[7] + "',N'" +
                                        dr[8] + "',N'" +
                                        dr[9] + "','" +
                                        dr[10] + "',N'" +
                                        user_pass_name + "')", con);
                                        con.Open();
                                        sqlcmddb.ExecuteNonQuery();
                                        con.Close();

                                    }

                                    SqlDataAdapter sqld = new SqlDataAdapter("select * from Dept_bill order by ID_detali", con);
                                    DataSet ds = new DataSet();
                                    sqld.Fill(ds, "Dept_bill");

                                    dept_CrystalReport dept_bill = new dept_CrystalReport();
                                    dept_bill.SetDataSource(ds);
                                    print_cash_bill p_c_b = new print_cash_bill();
                                    p_c_b.cash_crystalReportViewer.ReportSource = dept_bill;
                                    p_c_b.ShowDialog();

                                    SqlCommand sqc = new SqlCommand("delete Dept_bill", con);
                                    con.Open();
                                    sqc.ExecuteNonQuery();
                                    con.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                            }

                            SqlDataAdapter sa = new SqlDataAdapter("select * from Depts", con);
                            DataTable dt = new DataTable();
                            sa.Fill(dt);
                            depts_list_DataGridView.DataSource = dt;
                            depts_list_DataGridView.Refresh();
                            close_reback_dept();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("بڕی وەرگیراوی دینار زیاترە لە کۆی گشتی دینار", "!ئاگاداربە", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("بڕی وەرگیراوی دۆلار زیاترە لە کۆی گشتی دۆلار", "!ئاگاداربە", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void close_dept_detli_Button_Click(object sender, EventArgs e)
        {
            dept_detali_Panel.Visible = false;
        }

        //Broken
        private void brpken_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                try
                {
                    SqlCommand sqli = new SqlCommand("insert into Broken (Customer,Phone,Money,Note,Category,Brand,Warranty,com_date,Seller) " +
                    "values(N'" + broken_DataGridView.CurrentRow.Cells[4].Value.ToString() + "',N'" +
                    broken_DataGridView.CurrentRow.Cells[5].Value.ToString() + "','" +
                    0 + "',N'" +
                    broken_DataGridView.CurrentRow.Cells[7].Value.ToString() + "',N'" +
                    broken_DataGridView.CurrentRow.Cells[8].Value.ToString() + "',N'" +
                    broken_DataGridView.CurrentRow.Cells[9].Value.ToString() + "',N'" +
                    broken_DataGridView.CurrentRow.Cells[10].Value.ToString() + "','" +
                    date_label.Text + "',N'" +
                    user_pass_name + "')", con);

                    con.Open();
                    sqli.ExecuteNonQuery();
                    con.Close();

                    SqlDataAdapter sa = new SqlDataAdapter("select * from Broken", con);
                    DataTable dt = new DataTable();
                    sa.Fill(dt);
                    broken_DataGridView.DataSource = dt;
                    broken_DataGridView.Refresh();

                    Interaction.Beep();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    con.Close();
                }
            }
            else if (e.ColumnIndex == 1)
            {
                if (broken_DataGridView.CurrentRow.Cells[3].Value.ToString() != null)
                {
                    count_broken_Panel.Visible = true;
                    total_broken_TextBox.Text = broken_DataGridView.CurrentRow.Cells[6].Value.ToString();
                }
                else
                {
                    MessageBox.Show(".خانەی دیاریکراو بەتاڵە", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.ColumnIndex == 2)
            {
                if (broken_DataGridView.CurrentRow.Cells[7].Value.ToString() != null)
                {
                    try
                    {
                        broken_money_Panel.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show(".خانەی دیاریکراو بەتاڵە", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void close_broken_money_Button_Click(object sender, EventArgs e)
        {
            broken_money_Panel.Visible = false;
        }

        private void update_broken_money_Button_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("update Broken set " +
                "Money='" + money_TextBox.Text + "'" +
                "where ID='" + broken_DataGridView.CurrentRow.Cells[3].Value.ToString() + "'", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                broken_money_Panel.Visible = false;

                SqlDataAdapter sa = new SqlDataAdapter("select * from Broken", con);
                DataTable dt = new DataTable();
                sa.Fill(dt);
                broken_DataGridView.DataSource = dt;
                broken_DataGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
        }

        private void take_broken_TextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (take_broken_TextBox.Text.Length != 0)
                {
                    if (Convert.ToInt32(total_broken_TextBox.Text) >= Convert.ToInt32(take_broken_TextBox.Text))
                    {

                        try
                        {
                            remainder_brokrn_TextBox.Text = (Convert.ToInt32(total_broken_TextBox.Text) - Convert.ToInt32(take_broken_TextBox.Text)).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("بڕی وەرگیراو زیاترە لە کۆی گشتی", "!ئاگاداربە", MessageBoxButtons.OK);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void count_broken_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (with_dept_CheckBox.Checked == true)
                {
                    SqlCommand sqlcmdd = new SqlCommand("insert into Depts(Customer_Name,Phone,Dolar,Dinar,Note,Category,Brand,Date,Seller) " +
                    "values(N'" + broken_DataGridView.CurrentRow.Cells[4].Value.ToString() + "',N'" +
                    broken_DataGridView.CurrentRow.Cells[5].Value.ToString() + "','" +
                    0 + "',N'" +
                    remainder_brokrn_TextBox.Text + "',N'" +
                    broken_DataGridView.CurrentRow.Cells[7].Value.ToString() + "',N'" +
                    broken_DataGridView.CurrentRow.Cells[8].Value.ToString() + "',N'" +
                    broken_DataGridView.CurrentRow.Cells[9].Value.ToString() + "','" +
                    date_label.Text + "',N'" +
                    user_pass_name + "')", con);

                    con.Open();
                    sqlcmdd.ExecuteNonQuery();
                    con.Close();

                    SqlDataAdapter add = new SqlDataAdapter("select * from Depts", con);
                    DataTable dtd = new DataTable();
                    add.Fill(dtd);
                    depts_list_DataGridView.DataSource = dtd;
                    depts_list_DataGridView.Refresh();
                }

                if (Type_of_account == "بەکارهێنەر")
                {
                    SqlCommand sqlcmdo = new SqlCommand("insert into Order_list(SubCategory,Customer,Phone,Total_dolar,Cost_take_dolar,remainder_dolar,Total_dinar,Cost_take_dinar,remainder_dinar,Product_ID,Category,Brand,Model,Properties,Piece,Date,Seller,Note) " +
                    "values(N'" + "وەرگرتنی پارە" + "',N'" +
                    broken_DataGridView.CurrentRow.Cells[4].Value.ToString() + "',N'" +
                    broken_DataGridView.CurrentRow.Cells[5].Value.ToString() + "','" +
                    0 + "','" +
                    0 + "','" +
                    0 + "','" +
                    broken_DataGridView.CurrentRow.Cells[6].Value.ToString() + "','" +
                    take_broken_TextBox.Text + "','" +
                    remainder_brokrn_TextBox.Text + "','" +
                    0 + "',N'" +
                    broken_DataGridView.CurrentRow.Cells[8].Value.ToString() + "',N'" +
                    broken_DataGridView.CurrentRow.Cells[9].Value.ToString() + "','" +
                    "" + "','" +
                    "" + "','" +
                    1 + "','" +
                    date_label.Text + "',N'" +
                    user_pass_name + "',N'" +
                    broken_DataGridView.CurrentRow.Cells[7].Value.ToString() + "')", con);

                    con.Open();
                    sqlcmdo.ExecuteNonQuery();
                    con.Close();

                    SqlDataAdapter sqlo = new SqlDataAdapter("select * from Order_list", con);
                    DataTable dto = new DataTable();
                    sqlo.Fill(dto);
                    order_list_DataGridView.DataSource = dto;
                    order_list_DataGridView.Refresh();
                }

                SqlCommand sqld = new SqlCommand("delete Broken where ID = " + broken_DataGridView.CurrentRow.Cells[3].Value.ToString(), con);
                con.Open();
                sqld.ExecuteNonQuery();
                con.Close();

                SqlDataAdapter sa = new SqlDataAdapter("select * from Broken", con);
                DataTable dt = new DataTable();
                sa.Fill(dt);
                broken_DataGridView.DataSource = dt;
                broken_DataGridView.Refresh();
                count_broken_Panel.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
        }

        private void close_count_broken_Button_Click(object sender, EventArgs e)
        {
            count_broken_Panel.Visible = false;
        }

        //retake product
        private void rtake_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                reback_Panel.Visible = true;
            }
        }

        private void reback_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (Type_of_account == "بەکارهێنەر")
                {
                    SqlCommand sqlcmdo = new SqlCommand("insert into Order_list(SubCategory,Customer,Phone,Total_dolar,Total_dinar,Product_ID,Category,Brand,Model,Properties,Piece,Date,Seller) " +
                    "values(N'" + "گەڕاندنەوە" + "',N'" +
                    rtake_DataGridView.CurrentRow.Cells[2].Value.ToString() + "',N'" +
                    rtake_DataGridView.CurrentRow.Cells[3].Value.ToString() + "','" +
                    reback_dolar_TextBox.Text + "','" +
                    reback_dinar_TextBox.Text + "','" +
                    rtake_DataGridView.CurrentRow.Cells[9].Value.ToString() + "',N'" +
                    rtake_DataGridView.CurrentRow.Cells[10].Value.ToString() + "',N'" +
                    rtake_DataGridView.CurrentRow.Cells[11].Value.ToString() + "','" +
                    rtake_DataGridView.CurrentRow.Cells[12].Value.ToString() + "',N'" +
                    rtake_DataGridView.CurrentRow.Cells[13].Value.ToString() + "','" +
                    rtake_DataGridView.CurrentRow.Cells[14].Value.ToString() + "','" +
                    date_label.Text + "',N'" +
                    user_pass_name + "')", con);

                    con.Open();
                    sqlcmdo.ExecuteNonQuery();
                    con.Close();

                    SqlDataAdapter sqlo = new SqlDataAdapter("select * from Order_list", con);
                    DataTable dto = new DataTable();
                    sqlo.Fill(dto);
                    order_list_DataGridView.DataSource = dto;
                    order_list_DataGridView.Refresh();
                }

                con.Open();
                SqlCommand scom = new SqlCommand("select * from Products where Id ='" + rtake_DataGridView.CurrentRow.Cells[9].Value + "'", con);
                SqlDataReader reader = scom.ExecuteReader();
                reader.Read();
                int selected_product_piece = Convert.ToInt32(reader["Piece"]);
                con.Close();

                int selled_piece = selected_product_piece + Convert.ToInt32(rtake_DataGridView.CurrentRow.Cells[14].Value);
                SqlCommand cmd = new SqlCommand("update Products set Piece=" + selled_piece + "where Id='" + rtake_DataGridView.CurrentRow.Cells[9].Value + "'", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                SqlCommand sqld = new SqlCommand("delete Selleds where ID = " + rtake_DataGridView.CurrentRow.Cells[1].Value.ToString(), con);
                con.Open();
                sqld.ExecuteNonQuery();
                con.Close();

                SqlDataAdapter sa = new SqlDataAdapter("select * from Selleds", con);
                DataTable dt = new DataTable();
                sa.Fill(dt);
                rtake_DataGridView.DataSource = dt;
                rtake_DataGridView.Refresh();
                reback_Panel.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
        }

        private void close_reback_Button_Click(object sender, EventArgs e)
        {
            reback_Panel.Visible = false;
        }

        private void reback_search_TextBox_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Selleds where ID like '%" + reback_search_TextBox.Text + "%' or Customer like N'%" + reback_search_TextBox.Text + "%' or Phone like N'%" + reback_search_TextBox.Text + "%' or Product_ID like '%" + reback_search_TextBox.Text + "%' or Category like N'%" + reback_search_TextBox.Text + "%' or Brand like N'%" + reback_search_TextBox.Text + "%' or Model like '%" + reback_search_TextBox.Text + "%'", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            rtake_DataGridView.DataSource = dt;
            rtake_DataGridView.Refresh();
        }

        //Reminders
        private void Reminder_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    SqlCommand sqli = new SqlCommand("insert into Reminders (Reminder,Date,Seller) " +
                    "values(N'" + Reminder_DataGridView.CurrentRow.Cells[3].Value.ToString() + "','" +
                    date_label.Text + "',N'" +
                    user_pass_name + "')", con);

                    con.Open();
                    sqli.ExecuteNonQuery();
                    con.Close();

                    Interaction.Beep();
                }
                else if (e.ColumnIndex == 1)
                {
                    DialogResult dr = MessageBox.Show(".دڵنیای لە سڕینەوەی بیرخەرەوەی دیاریکراو", "سڕینەوە", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        if (Reminder_DataGridView.CurrentRow.Cells[2].Value.ToString() != null)
                        {
                            SqlCommand sqld = new SqlCommand("delete Reminders where ID = " + Reminder_DataGridView.CurrentRow.Cells[2].Value.ToString(), con);

                            con.Open();
                            sqld.ExecuteNonQuery();
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show(".خانەی دیاریکراو بەتاڵە", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                SqlDataAdapter sa = new SqlDataAdapter("select * from Reminders", con);
                DataTable dt = new DataTable();
                sa.Fill(dt);
                Reminder_DataGridView.DataSource = dt;
                Reminder_DataGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
        }

        private void Reminder_search_TextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("select * from Reminders where ID like '%" + Reminder_search_TextBox.Text + "%' or Reminder like N'%" + Reminder_search_TextBox.Text + "%' or Date like '%" + Reminder_search_TextBox.Text + "%' or Seller like N'%" + Reminder_search_TextBox.Text + "%'", con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                Reminder_DataGridView.DataSource = dt;
                Reminder_DataGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void spend_DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    if (Type_of_account == "بەکارهێنەر")
                    {
                        SqlCommand sqlcmdo = new SqlCommand("insert into Order_list(SubCategory,Customer,Phone,Total_dolar,Total_dinar,Date,Seller) " +
                        "values(N'" + "سەرفکردن" + "',N'" +
                        spend_DataGridView.CurrentRow.Cells[5].Value.ToString() + "',N'" +
                        spend_DataGridView.CurrentRow.Cells[6].Value.ToString() + "','" +
                        spend_DataGridView.CurrentRow.Cells[3].Value.ToString() + "','" +
                        spend_DataGridView.CurrentRow.Cells[4].Value.ToString() + "','" +
                        date_label.Text + "',N'" +
                        user_pass_name + "')", con);

                        con.Open();
                        sqlcmdo.ExecuteNonQuery();
                        con.Close();

                        SqlDataAdapter sqlo = new SqlDataAdapter("select * from Order_list", con);
                        DataTable dto = new DataTable();
                        sqlo.Fill(dto);
                        order_list_DataGridView.DataSource = dto;
                        order_list_DataGridView.Refresh();
                    }

                    SqlCommand sqli = new SqlCommand("insert into Spend (Dolar,Dinar,Taker,Phone,Detali,Seller,Date) " +
                    "values('" + spend_DataGridView.CurrentRow.Cells[3].Value.ToString() + "','" +
                    spend_DataGridView.CurrentRow.Cells[4].Value.ToString() + "',N'" +
                    spend_DataGridView.CurrentRow.Cells[5].Value.ToString() + "',N'" +
                    spend_DataGridView.CurrentRow.Cells[6].Value.ToString() + "',N'" +
                    spend_DataGridView.CurrentRow.Cells[7].Value.ToString() + "',N'" +
                    user_pass_name + "','" +
                    date_label.Text + "')", con);

                    con.Open();
                    sqli.ExecuteNonQuery();
                    con.Close();

                    Interaction.Beep();
                }
                else if (e.ColumnIndex == 1)
                {
                    DialogResult dr = MessageBox.Show(".دڵنیای لە سڕینەوەی خەرجی دیاریکراو", "سڕینەوە", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        if (spend_DataGridView.CurrentRow.Cells[2].Value.ToString() != null)
                        {
                            SqlCommand sqld = new SqlCommand("delete Spend where ID = " + spend_DataGridView.CurrentRow.Cells[2].Value.ToString(), con);

                            con.Open();
                            sqld.ExecuteNonQuery();
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show(".خانەی دیاریکراو بەتاڵە", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                if (Type_of_account == "بەڕێوبەر")
                {
                    SqlDataAdapter sa = new SqlDataAdapter("select * from Spend", con);
                    DataTable dt = new DataTable();
                    sa.Fill(dt);
                    spend_DataGridView.DataSource = dt;
                    spend_DataGridView.Refresh();
                }
                if (Type_of_account == "بەکارهێنەر")
                {
                    SqlDataAdapter sa = new SqlDataAdapter("select * from Spend where  Seller like N'%" + user_pass_name + "%'", con);
                    DataTable dt = new DataTable();
                    sa.Fill(dt);
                    spend_DataGridView.DataSource = dt;
                    spend_DataGridView.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
        }

        private void spend_search_TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Type_of_account == "بەڕێوبەر")
                {
                    SqlDataAdapter adp = new SqlDataAdapter("select * from Spend where ID like '%" + spend_search_TextBox1.Text + "%' or Taker like N'%" + spend_search_TextBox1.Text + "%' or Phone like N'%" + spend_search_TextBox1.Text + "%' or Detali like N'%" + spend_search_TextBox1.Text + "%' or Date like '%" + spend_search_TextBox1.Text + "%' or Seller like N'%" + spend_search_TextBox1.Text + "%'", con);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    spend_DataGridView.DataSource = dt;
                    spend_DataGridView.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Company
        private void insert_company_Button_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sqlcmdo = new SqlCommand("insert into Companies (COMPANY,Owner_name,Phone,Addres,Dolar,Dinar,Date) " +
                "values(N'" + companies_DataGridView.CurrentRow.Cells[4].Value.ToString() + "',N'" +
                companies_DataGridView.CurrentRow.Cells[7].Value.ToString() + "',N'" +
                companies_DataGridView.CurrentRow.Cells[8].Value.ToString() + "',N'" +
                companies_DataGridView.CurrentRow.Cells[9].Value.ToString() + "','" +
                companies_DataGridView.CurrentRow.Cells[5].Value.ToString() + "','" +
                companies_DataGridView.CurrentRow.Cells[6].Value.ToString() + "','" +
                date_label.Text + "')", con);

                con.Open();
                sqlcmdo.ExecuteNonQuery();
                con.Close();

                SqlDataAdapter adp = new SqlDataAdapter("select * from Companies order by ID", con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                companies_DataGridView.DataSource = dt;
                companies_DataGridView.Refresh();

                Interaction.Beep();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void update_company_Button_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("update Companies set " +
                "COMPANY=N'" + companies_DataGridView.CurrentRow.Cells[4].Value.ToString() + "'," +
                "Owner_name=N'" + companies_DataGridView.CurrentRow.Cells[7].Value.ToString() + "'," +
                "Phone=N'" + companies_DataGridView.CurrentRow.Cells[8].Value.ToString() + "'," +
                "Addres=N'" + companies_DataGridView.CurrentRow.Cells[9].Value.ToString() + "'," +
                "Dolar='" + companies_DataGridView.CurrentRow.Cells[5].Value.ToString() + "'," +
                "Dinar='" + companies_DataGridView.CurrentRow.Cells[6].Value.ToString() + "'," +
                "Date='" + date_label.Text + "'" +
                "where ID='" + companies_DataGridView.CurrentRow.Cells[3].Value.ToString() + "'", con);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                SqlDataAdapter adp = new SqlDataAdapter("select * from Companies order by ID", con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                companies_DataGridView.DataSource = dt;
                companies_DataGridView.Refresh();

                Interaction.Beep();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void delete_company_Button_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show(".دڵنیای لە سڕینەوەی کۆمپانیای دیاریکراو", "سڕینەوە", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (companies_DataGridView.CurrentRow.Cells[3].Value.ToString() != null)
                    {
                        SqlCommand sqld = new SqlCommand("delete Companies where ID = " + companies_DataGridView.CurrentRow.Cells[3].Value.ToString(), con);
                        con.Open();
                        sqld.ExecuteNonQuery();
                        con.Close();

                        SqlDataAdapter adp = new SqlDataAdapter("select * from Companies order by ID", con);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        companies_DataGridView.DataSource = dt;
                        companies_DataGridView.Refresh();
                    }
                    else
                    {
                        MessageBox.Show(".خانەی دیاریکراو بەتاڵە", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void company_search_TextBox_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Companies where ID like '%" + company_search_TextBox.Text + "%' or COMPANY like N'%" + company_search_TextBox.Text + "%' or Owner_name like N'%" + company_search_TextBox.Text + "%' or Phone like N'%" + company_search_TextBox.Text + "%' or Addres like N'%" + company_search_TextBox.Text + "%' order by ID", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            companies_DataGridView.DataSource = dt;
            companies_DataGridView.Refresh();
        }

        private void companies_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                sellected_company_name_label.Text = companies_DataGridView.CurrentRow.Cells[4].Value.ToString();
                old_dept_dolar_TextBox.Text = companies_DataGridView.CurrentRow.Cells[5].Value.ToString();
                old_dept_dinar_TextBox.Text = companies_DataGridView.CurrentRow.Cells[6].Value.ToString();
                total_company_dolar_dept_TextBox.Text = companies_DataGridView.CurrentRow.Cells[5].Value.ToString();
                total_company_dinar_dept_TextBox.Text = companies_DataGridView.CurrentRow.Cells[6].Value.ToString();

                add_company_dept_Panel.Visible = true;
                menuStrip.Enabled = false;
                company_search_TextBox.Enabled = false;
                companies_DataGridView.Enabled = false;
            }
            if (e.ColumnIndex == 1)
            {
                sellected_company_name_sub_label.Text = companies_DataGridView.CurrentRow.Cells[4].Value.ToString();
                total_dept_company_dolar_TextBox.Text = companies_DataGridView.CurrentRow.Cells[5].Value.ToString();
                remanide_dolar_TextBox1.Text = companies_DataGridView.CurrentRow.Cells[5].Value.ToString();
                total_dept_company_dinar_TextBox.Text = companies_DataGridView.CurrentRow.Cells[6].Value.ToString();
                remanide_dinar_TextBox1.Text = companies_DataGridView.CurrentRow.Cells[6].Value.ToString();

                subtract_company_dept_Panel.Visible = true;
                menuStrip.Enabled = false;
                company_search_TextBox.Enabled = false;
                companies_DataGridView.Enabled = false;
            }
            if (e.ColumnIndex == 2)
            {
                try
                {
                    SqlDataAdapter sa = new SqlDataAdapter("select * from Companies_detail where ID = " + companies_DataGridView.CurrentRow.Cells[3].Value.ToString() + "order by ID_detali", con);
                    DataTable dt = new DataTable();
                    sa.Fill(dt);
                    company_detail_DataGridView.DataSource = dt;
                    company_detail_DataGridView.Refresh();

                    if (company_detail_DataGridView.RowCount >= 1)
                    {
                        sellected_company_detail_label.Text = companies_DataGridView.CurrentRow.Cells[4].Value.ToString();
                        company_detli_total_dolar_TextBox.Text = companies_DataGridView.CurrentRow.Cells[5].Value.ToString();
                        company_detli_total_dinar_TextBox.Text = companies_DataGridView.CurrentRow.Cells[6].Value.ToString();
                        company_detail_Panel.Visible = true;
                        menuStrip.Enabled = false;
                        company_search_TextBox.Enabled = false;
                        companies_DataGridView.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("هیچ وردەکاریەکی کۆمپانیایی دیاری کراو نەدۆزرایەوە", "ببورە", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void add_dolar_TextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (add_dolar_TextBox.Text.Length != 0 && add_dinar_TextBox.TextLength != 0)
                {
                    total_company_dolar_dept_TextBox.Text = (Convert.ToInt32(add_dolar_TextBox.Text) + Convert.ToInt32(old_dept_dolar_TextBox.Text)).ToString();
                    total_company_dinar_dept_TextBox.Text = (Convert.ToInt32(add_dinar_TextBox.Text) + Convert.ToInt32(old_dept_dinar_TextBox.Text)).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void close_add_company_dept_Button_Click(object sender, EventArgs e)
        {
            add_company_dept_Panel.Visible = false;
            menuStrip.Enabled = true;
            company_search_TextBox.Enabled = true;
            companies_DataGridView.Enabled = true;
        }

        private void add_company_dept_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int NUMBER_DETAIL = 0;
                SqlCommand cmdDD = new SqlCommand("select * from Companies_detail where ID ='" + companies_DataGridView.CurrentRow.Cells[3].Value.ToString() + "'", con);
                DataTable dtDD = new DataTable();
                con.Open();
                cmdDD.ExecuteNonQuery();
                con.Close();
                SqlDataAdapter daD = new SqlDataAdapter(cmdDD);
                daD.Fill(dtDD);
                foreach (DataRow drD in dtDD.Rows)
                {
                    NUMBER_DETAIL += 1;
                }

                SqlCommand sqlcmdo = new SqlCommand("insert into Companies_detail (ID,ID_detali,Type_detali,Dolar,Update_dolar,remainder_dolar,Dinar,Update_dinar,remainder_dinar,Date) " +
                "values('" + companies_DataGridView.CurrentRow.Cells[3].Value.ToString() + "','" +
                NUMBER_DETAIL + "',N'" +
                "زیادکردنی قەرز" + "','" +
                old_dept_dolar_TextBox.Text + "','" +
                add_dolar_TextBox.Text + "','" +
                total_company_dolar_dept_TextBox.Text + "','" +
                old_dept_dinar_TextBox.Text + "','" +
                add_dinar_TextBox.Text + "','" +
                total_company_dinar_dept_TextBox.Text + "','" +
                date_label.Text + "')", con);

                con.Open();
                sqlcmdo.ExecuteNonQuery();
                con.Close();

                SqlCommand cmd = new SqlCommand("update Companies set " +
                "Dolar='" + total_company_dolar_dept_TextBox.Text + "'," +
                "Dinar='" + total_company_dinar_dept_TextBox.Text + "'," +
                "Date='" + date_label.Text + "'" +
                "where ID='" + companies_DataGridView.CurrentRow.Cells[3].Value.ToString() + "'", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                SqlDataAdapter adp = new SqlDataAdapter("select * from Companies order by ID", con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                companies_DataGridView.DataSource = dt;
                companies_DataGridView.Refresh();

                add_company_dept_Panel.Visible = false;
                menuStrip.Enabled = true;
                company_search_TextBox.Enabled = true;
                companies_DataGridView.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void close_subtract_Button_Click(object sender, EventArgs e)
        {
            subtract_company_dept_Panel.Visible = false;
            menuStrip.Enabled = true;
            company_search_TextBox.Enabled = true;
            companies_DataGridView.Enabled = true;
        }

        private void subtract_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int NUMBER_DETAIL = 0;
                SqlCommand cmdDD = new SqlCommand("select * from Companies_detail where ID ='" + companies_DataGridView.CurrentRow.Cells[3].Value.ToString() + "'", con);
                DataTable dtDD = new DataTable();
                con.Open();
                cmdDD.ExecuteNonQuery();
                con.Close();
                SqlDataAdapter daD = new SqlDataAdapter(cmdDD);
                daD.Fill(dtDD);
                foreach (DataRow drD in dtDD.Rows)
                {
                    NUMBER_DETAIL += 1;
                }

                SqlCommand sqlcmdo = new SqlCommand("insert into Companies_detail (ID,ID_detali,Type_detali,Dolar,Update_dolar,remainder_dolar,Dinar,Update_dinar,remainder_dinar,Date) " +
                "values('" + companies_DataGridView.CurrentRow.Cells[3].Value.ToString() + "','" +
                NUMBER_DETAIL + "',N'" +
                "دانەوەی قەرز" + "','" +
                total_dept_company_dolar_TextBox.Text + "','" +
                subtract_dolar_TextBox.Text + "','" +
                remanide_dolar_TextBox1.Text + "','" +
                total_dept_company_dinar_TextBox.Text + "','" +
                subtract_dinar_TextBox.Text + "','" +
                remanide_dinar_TextBox1.Text + "','" +
                date_label.Text + "')", con);

                con.Open();
                sqlcmdo.ExecuteNonQuery();
                con.Close();

                SqlCommand cmd = new SqlCommand("update Companies set " +
                "Dolar='" + remanide_dolar_TextBox1.Text + "'," +
                "Dinar='" + remanide_dinar_TextBox1.Text + "'," +
                "Date='" + date_label.Text + "'" +
                "where ID='" + companies_DataGridView.CurrentRow.Cells[3].Value.ToString() + "'", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                SqlDataAdapter adp = new SqlDataAdapter("select * from Companies order by ID", con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                companies_DataGridView.DataSource = dt;
                companies_DataGridView.Refresh();

                subtract_company_dept_Panel.Visible = false;
                menuStrip.Enabled = true;
                company_search_TextBox.Enabled = true;
                companies_DataGridView.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void subtract_dolar_TextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (subtract_dolar_TextBox.Text.Length != 0 && subtract_dinar_TextBox.TextLength != 0)
                {
                    remanide_dolar_TextBox1.Text = ( Convert.ToInt32(total_dept_company_dolar_TextBox.Text) - Convert.ToInt32(subtract_dolar_TextBox.Text)).ToString();
                    remanide_dinar_TextBox1.Text = ( Convert.ToInt32(total_dept_company_dinar_TextBox.Text) - Convert.ToInt32(subtract_dinar_TextBox.Text)).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void close_company_detail_Button1_Click(object sender, EventArgs e)
        {
            company_detail_Panel.Visible = false;
            menuStrip.Enabled = true;
            company_search_TextBox.Enabled = true;
            companies_DataGridView.Enabled = true;
        }

        //print
        private void tables_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            zanyari(tables_ComboBox.SelectedItem.ToString());
            if (tables_ComboBox.SelectedItem.ToString()== "Products")
            {
                prient_product_panel_Button.Visible = true;
            }
            else
            {
                prient_product_panel_Button.Visible = false;
            }
        }

        // zanyari فەنکشنی  
        public void zanyari(string tableName)
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from " + "[" + tableName + "]", con); 
            DataTable dt = new DataTable();
            adp.Fill(dt);
            tables_DataGridView.DataSource = dt;
            tables_DataGridView.Refresh();
        }

        private void dgv2exel_Button_Click(object sender, EventArgs e)
        {
            if (tables_DataGridView.Rows.Count > 0)
            {

                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Exported from gridview";
                for (int i = 1; i < tables_DataGridView.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = tables_DataGridView.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < tables_DataGridView.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < tables_DataGridView.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = tables_DataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }
                // save the application  
                //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
        }

        private void prient_product_panel_Button_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into Print_Products (Id,Category,Model,Brand,Properties,Size,Color,Warranty,Selling_price_dolar,Selling_price_dinar) " +
                 "values('" + tables_DataGridView.CurrentRow.Cells[0].Value.ToString() + "',N'" +
                 tables_DataGridView.CurrentRow.Cells[1].Value.ToString() + "','" +
                 tables_DataGridView.CurrentRow.Cells[2].Value.ToString() + "',N'" +
                 tables_DataGridView.CurrentRow.Cells[3].Value.ToString() + "',N'" +
                 tables_DataGridView.CurrentRow.Cells[6].Value.ToString() + "',N'" +
                 tables_DataGridView.CurrentRow.Cells[11].Value.ToString() + "',N'" +
                 tables_DataGridView.CurrentRow.Cells[12].Value.ToString() + "',N'" +
                 tables_DataGridView.CurrentRow.Cells[13].Value.ToString() + "','" +
                 tables_DataGridView.CurrentRow.Cells[9].Value.ToString() + "','" +
                 tables_DataGridView.CurrentRow.Cells[10].Value.ToString() + "')", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                SqlDataAdapter sqlp = new SqlDataAdapter("select * from Print_Products", con);
                DataSet dsp = new DataSet();
                sqlp.Fill(dsp, "Print_Products");

                Product_CrystalReport flyer = new Product_CrystalReport();
                flyer.SetDataSource(dsp);
                product_crystalReportViewer.ReportSource = flyer;

                product_print_Panel.Visible = true;
                prient_product_panel_Button.Enabled = false;

                SqlCommand sqc = new SqlCommand("delete Print_Products", con);
                con.Open();
                sqc.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void close_product_print_Button_Click(object sender, EventArgs e)
        {
            prient_product_panel_Button.Enabled = true;
            product_print_Panel.Visible = false;
        }
    }
}
