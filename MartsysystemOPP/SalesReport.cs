using MartsysystemOPP.AUD;
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
    public partial class SalesReport : MaterialSkin.Controls.MaterialForm
    {
        public SalesReport()
        {
            InitializeComponent();
        }
        public static string a;
        public static string b;
        public static string c;
        public static double bt;
        public static double ctt;

        private void btnShow_Click(object sender, EventArgs e)
        {
            //Show
            Class_DailySales c_ds = new Class_DailySales();
            c_ds.ShowSale(new Connection(), dateTimePicker1, dgViewShow);

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

        private void SalesReport_Load(object sender, EventArgs e)
        {
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Muhmmad Nauman\Documents\mymartOpp.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand();

            sc.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "select sum(Total) from Sales WHERE Date>=DATEADD(DAY,-1,GETDATE()) And CashierName = 'GRAND TOTAL'";
            cmd.Connection = sc;

            a = cmd.ExecuteScalar().ToString();

            sc.Close();
            MessageBox.Show(a);

            sc.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "select sum(Total) from Sales WHERE Date>=DATEADD(DAY,-2,GETDATE()) And CashierName = 'GRAND TOTAL'";
            cmd.Connection = sc;

            b = cmd.ExecuteScalar().ToString();
            bt = double.Parse(b) - double.Parse(a);
            sc.Close();
            MessageBox.Show(bt.ToString());

            sc.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "select sum(Total) from Sales WHERE Date>=DATEADD(DAY,-3,GETDATE()) And CashierName = 'GRAND TOTAL'";
            cmd.Connection = sc;

            c = cmd.ExecuteScalar().ToString();
            double ct = (bt + double.Parse(a));
            ctt = double.Parse(c) - ct;
            sc.Close();
            MessageBox.Show(ctt.ToString());


            chart1.Series[0].Points.AddXY("DAY1", int.Parse(a));
            chart1.Series[0].Points.AddXY("DAY2", bt);
            chart1.Series[0].Points.AddXY("DAY3", ctt);
        }
    }
}
