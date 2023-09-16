using MartsysystemOPP.AUD.Adapter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartsysystemOPP.AUD.Facade
{
    class salesbyuser:isalesreport
    {
        DataGridView dataGridView1;
        public salesbyuser(DataGridView dataGridView1)
        {
            this.dataGridView1 = dataGridView1;
        }
        public void showreport()
        {

            iconnection con = new ConnectionAdapter(new ConnectionAdaptee());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from cashierloginrecord";
            cmd.Connection = con.Get();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}
