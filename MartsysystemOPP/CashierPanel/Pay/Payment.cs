using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartsysystemOPP.CashierPanel.Pay
{
    class Payment
    {
        public static double Sbalance = 0;

        public static string BankName { get; set; }

        public static double totl { get; set; }

        public static double CustomerPay { get; set; }

        public virtual double Pay(MaterialSingleLineTextField txtCustomerPay)
        {
            return 0;
        }
    }
}
