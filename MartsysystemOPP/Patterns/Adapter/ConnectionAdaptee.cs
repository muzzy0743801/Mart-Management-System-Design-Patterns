using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartsysystemOPP.AUD.Adapter
{
    class ConnectionAdaptee
    {
        public string ConnectionString = @"Data Source=.;Initial Catalog=Mart_System;Integrated Security=True";

        public SqlConnection sc;
        public SqlConnection Get()
        {
            if (sc == null)
            {
                sc = new SqlConnection();
                sc.ConnectionString = ConnectionString;
                sc.Open();
            }

            return sc;
        }
        public int execute_NonQuery(string query)
        {
            SqlCommand myCommand = new SqlCommand(query,new ConnectionAdaptee().Get());
            DbParameter returnValue;
            returnValue = myCommand.CreateParameter();
            returnValue.Direction = ParameterDirection.ReturnValue;
            myCommand.Parameters.Add(returnValue);
            myCommand.ExecuteNonQuery();
            return Convert.ToInt32(returnValue.Value);
        }
    }
}
