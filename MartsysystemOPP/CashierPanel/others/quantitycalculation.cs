using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialSkin.Controls;
using System.Windows.Forms;
using MartsysystemOPP.AUD;
using MartsysystemOPP.AUD.Adapter;
using System.Data.SqlClient;

namespace MartsysystemOPP.CashierPanel.Calculation
{
    class quantitycalculation
    {
      public static double QUpdate;
       public double getquantity(MaterialSingleLineTextField txtPrice,MaterialSingleLineTextField txtQuantity)
        {
            QUpdate = double.Parse(ProductsClass.StoreQuantity) - double.Parse(txtQuantity.Text);
            return QUpdate;
        }

        public void updatequantity(MaterialSingleLineTextField Quantity)
        {
            iconnection con = new ConnectionAdapter(new ConnectionAdaptee());
            SqlCommand cmd = new SqlCommand();

            string Query = "UPDATE Product SET Quantity = '" + quantitycalculation.QUpdate + "' WHERE Id = '" + ProductsClass.StoreId + "'";
            cmd = new SqlCommand(Query, con.Get());
            cmd.ExecuteNonQuery();
           
        }
    }
}
