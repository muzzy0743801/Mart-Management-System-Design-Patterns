using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartsysystemOPP.AUD
{
     interface iconnection
    {
        SqlConnection Get();
        int Execute_NonQuery(string query);
    }
}
