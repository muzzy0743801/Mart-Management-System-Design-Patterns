using MartsysystemOPP.AUD;
using MartsysystemOPP.AUD.Adapter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartsysystemOPP
{
    class LoginClass
    {
        public static string UName;
      
       
        public void Login(string Username, string Password)
        {
            UName = Username;

            iconnection con = new ConnectionAdapter(new ConnectionAdaptee());

            SqlDataAdapter sda = new SqlDataAdapter("Select Role from Login where Username = '" + Username + "' and Password = '" + Password + "'", con.Get());

            DataTable dt = new DataTable();
            sda.Fill(dt);

            try
            {
                if (Username == "" || Password == "")
                {
                    MessageBox.Show("Fill all fields");
                }

                else if (dt.Rows[0][0].ToString() == "Admin")
                {
                    MessageBox.Show("Login Successful as " + Username);

                    SelectMenu sl = new SelectMenu();
                    sl.Show();
                    
                  
                }

                else if (dt.Rows[0][0].ToString() == "Cashier")
                {
                    MessageBox.Show("Login Successful as " + Username);
                    FormCashier fcshr = new FormCashier();
                    fcshr.Show();
                   
                }
            }

            catch (Exception)
            {

                MessageBox.Show("Wrong Username or password");
                Login lgfm = new Login();
                lgfm.Show();
                
            }


        }



    
    }
}
