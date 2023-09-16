using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartsysystemOPP.AUD.Proxy
{
    class calculationbill:icalculationbill
    {
        public static double totl { get; set; }

        public static double TotalWithDiscount { get; set; }

        public static double TotalWithoutDiscount { get; set; }

        public static double QUpdate { get; set; }
        public calculationbill()
        {
            //Default
           
        }
   
        public double billdiscount(MaterialSingleLineTextField txtPrice, MaterialSingleLineTextField txtQuantity, MaterialSingleLineTextField txtDiscount)
        {
            TotalWithDiscount = ((double.Parse(txtPrice.Text) * double.Parse(txtQuantity.Text)) - ((double.Parse(txtPrice.Text) * double.Parse(txtQuantity.Text)) * (double.Parse(txtDiscount.Text) / 100)));
            totl = totl + TotalWithDiscount;
            return totl;
        }

        public double billtotal(MaterialSingleLineTextField txtPrice, MaterialSingleLineTextField txtQuantity)
        {
            TotalWithoutDiscount = double.Parse(txtPrice.Text) * double.Parse(txtQuantity.Text);
            totl = totl + TotalWithoutDiscount;
            return totl;
        }
    }
}
