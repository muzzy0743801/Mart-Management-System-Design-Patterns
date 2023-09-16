using MartsysystemOPP.AUD;
using MartsysystemOPP.AUD.Adapter;
using MartsysystemOPP.Composite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartsysystemOPP.CashierPanel
{
    class Sales
    {
        string OrderId;
        string CustomerName;
        public string CashierName;
        string ProductName;
        string Quantity;
        string Discount;
        string Price;
        string TotalPrice;
        string GrandTotal;

        cashierleaf objcashierleaf;

        //Compositon
        public Sales()
        {
            cashierleaf objcashierleaf = new cashierleaf();
            objcashierleaf.NameOfCashier(this, CashierName);
        }

        public void SalesToCustomer(cashierleaf objcashierleaf, string OrderId, string CustomerName, string CashierName, string ProductName, string Quantity, string Discount, string Price, string TotalPrice, string GrandTotal)
        {
            this.objcashierleaf = objcashierleaf;
            this.OrderId = OrderId;
            this.CustomerName = CustomerName;

            this.CashierName = CashierName;
            objcashierleaf.CashierName = CashierName;
            this.ProductName = ProductName;
            this.Quantity = Quantity;
            this.Discount = Discount;
            this.Price = Price;
            this.TotalPrice = TotalPrice;
            this.GrandTotal = GrandTotal;
        }


        //Sales To Customer
        public void SalesToCustomer()
        {
            iconnection con = new ConnectionAdapter(new ConnectionAdaptee());
            
            string Query = "Insert into Sales (CashierName,ProductName,CustomerName,Quantity,Discount,Price,TotalPrice,Date,Time,Total) VALUES ('" + CashierName + "', '" + ProductName + "', '" + CustomerName + "', '" + Quantity + "', '" + Discount + "', '" + Price + "'  , '" + TotalPrice + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + DateTime.Now.ToShortTimeString() + "', '')";
            SqlCommand cmd = new SqlCommand(Query, con.Get()); 
            cmd.ExecuteNonQuery();
           
        }

        //GrandTotal
        public void TotalOfsales()
        {
            iconnection con = new ConnectionAdapter(new ConnectionAdaptee());

            string Query = "Insert into Sales (CashierName,ProductName,CustomerName,Quantity,Discount,Price,TotalPrice,Date,Time,Total) VALUES ('GRAND TOTAL', '', '', '', '', '', '', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '', '" + GrandTotal + "')";//jo sae
            SqlCommand cmd = new SqlCommand(Query, con.Get());
            cmd.ExecuteNonQuery();
           
        }
    }
}
