using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartsysystemOPP.AUD.Proxy
{
    class proxycalculationbill:icalculationbill
    {
        private calculationbill calculationbill;
        public double billtotal(MaterialSingleLineTextField txtPrice, MaterialSingleLineTextField txtQuantity)
        {
            if (calculationbill == null)
                calculationbill = new calculationbill();
            
           
                return calculationbill.billtotal(txtPrice,txtQuantity);
        }
        public double billdiscount(MaterialSingleLineTextField txtPrice, MaterialSingleLineTextField txtQuantity, MaterialSingleLineTextField txtDiscount)
        {
            if (calculationbill == null)
                calculationbill = new calculationbill();
            //form k code me isy b usi trha call krwa
            //ok

            return calculationbill.billdiscount(txtPrice, txtQuantity,txtDiscount);
        }
    }
}
