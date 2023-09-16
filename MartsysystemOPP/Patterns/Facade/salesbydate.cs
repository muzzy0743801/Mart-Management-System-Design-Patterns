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
    class salesbydate:isalesreport
    {
        DateTimePicker dtp1; DateTimePicker dtp2; DataGridView dataGridView1;
        public salesbydate(DateTimePicker dtp1, DateTimePicker dtp2, DataGridView dataGridView1)
        {
            this.dtp1 = dtp1;
            this.dtp2 = dtp2;
            this.dataGridView1 = dataGridView1;
        }
        public void showreport() {

            iconnection con = new ConnectionAdapter(new ConnectionAdaptee());
            SqlCommand cmd = new SqlCommand();
            
            cmd.CommandText = "Select * from Sales where Date between '" + dtp2.Text + "' and '" + dtp1.Text + "'";
            cmd.Connection = con.Get();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}
