using MartsysystemOPP.AUD.Adapter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartsysystemOPP.AUD.Factory
{
    public class catelectronic : igetcategory
    {
        
        string cat_id;
        public catelectronic(string cat_id)
        {
            this.cat_id = cat_id;
        }
        public void cat_showpro(DataGridView dgViewShow)
        {

            iconnection con = new ConnectionAdapter(new ConnectionAdaptee());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from product where Category = '" + cat_id + "'";
            cmd.Connection = con.Get();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgViewShow.DataSource = dt;
            dgViewShow.AllowUserToAddRows = false;

        }
    }
}
