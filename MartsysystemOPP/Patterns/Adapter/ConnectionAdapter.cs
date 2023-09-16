using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartsysystemOPP.AUD.Adapter
{
    class ConnectionAdapter:iconnection
    {
        ConnectionAdaptee conadpte;
        public ConnectionAdapter(ConnectionAdaptee conadpte)
        {
            this.conadpte = conadpte;
        }
        public SqlConnection Get()
        {
            return conadpte.Get();

        }
        public int Execute_NonQuery(string query)
        {
            return conadpte.execute_NonQuery(query);
        }

    }
}
