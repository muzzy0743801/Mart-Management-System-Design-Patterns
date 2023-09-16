using MartsysystemOPP.AUD;
using MartsysystemOPP.AUD.Facade;
using MartsysystemOPP.MaterialSkinTheme;
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

namespace MartsysystemOPP
{
    public partial class ReportSales : MaterialSkin.Controls.MaterialForm
    {
        public ReportSales()
        {
            InitializeComponent();

            Theme theme = new Theme(this);
        }

        private void ReportSales_Load(object sender, EventArgs e)
        {

            chart1.Visible = false;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            dgViewShow.Visible = true;
            //Show
            salesreport salereport = new salesreport(dateTimePicker1, dateTimePicker2, dgViewShow);
            salereport.showsales_bydate();
          
            dgViewShow.Columns[0].Visible = false;
            dgViewShow.Columns[5].Visible = false;
            dgViewShow.Columns[8].Visible = false;

            dgViewShow.Columns[1].Width = 80;
            dgViewShow.Columns[2].Width = 80;
            dgViewShow.Columns[3].Width = 90;
            dgViewShow.Columns[4].Width = 50;
            dgViewShow.Columns[6].Width = 50;
            dgViewShow.Columns[7].Width = 80;
            dgViewShow.Columns[9].Width = 60;
            dgViewShow.Columns[10].Width = 50;
        }


        public static string a;
        public static string date_a;
        public static string b;
        public static string c;
        public static double bt;
        public static string date_bt;
        public static double ctt;
        public static string date_ctt;

        private void btnGraph_Click(object sender, EventArgs e)
        {
            dgViewShow.Visible = false;

            chart1.Visible = true;

            SqlConnection sc = new SqlConnection(@"Data Source=DESKTOP-F0H0P42\SQLEXPRESS;Initial Catalog=Mart_System;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();

            sc.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "select sum(Total) from Sales WHERE Date>=DATEADD(DAY,-1,GETDATE()) And CashierName = 'GRAND TOTAL'";
            cmd.Connection = sc;
            a = cmd.ExecuteScalar().ToString();
            sc.Close();
            //DATE
            sc.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "select date from Sales WHERE Date>=DATEADD(DAY,-1,GETDATE())";
            cmd.Connection = sc;
            date_a = cmd.ExecuteScalar().ToString();
            sc.Close();

            sc.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "select sum(Total) from Sales WHERE Date>=DATEADD(DAY,-2,GETDATE()) And CashierName = 'GRAND TOTAL'";
            cmd.Connection = sc;
            b = cmd.ExecuteScalar().ToString();
            bt = double.Parse(b) - double.Parse(a);
            sc.Close();
            //DATE
            sc.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "select date from Sales WHERE Date>=DATEADD(DAY,-2,GETDATE())";
            cmd.Connection = sc;
            date_bt = cmd.ExecuteScalar().ToString();
            sc.Close();

            sc.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "select sum(Total) from Sales WHERE Date>=DATEADD(DAY,-3,GETDATE()) And CashierName = 'GRAND TOTAL'";
            cmd.Connection = sc;
            c = cmd.ExecuteScalar().ToString();
            double ct = (bt + double.Parse(a));
            ctt = double.Parse(c) - ct;
            sc.Close();
            //DATE
            sc.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "select date from Sales WHERE Date>=DATEADD(DAY,-3,GETDATE())";
            cmd.Connection = sc;
            date_ctt = cmd.ExecuteScalar().ToString();
            sc.Close();


            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(date_ctt, ctt);
            chart1.Series[0].Points.AddXY(date_bt, bt);
            chart1.Series[0].Points.AddXY(date_a, a);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SelectMenu obj = new SelectMenu();
            this.Hide();
            obj.Show();
        }
    }
}
