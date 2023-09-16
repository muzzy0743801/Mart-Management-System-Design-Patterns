using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartsysystemOPP.AUD.Proxy
{
    public interface icalculationbill
    {
        double billdiscount(MaterialSingleLineTextField txtPrice, MaterialSingleLineTextField txtQuantity, MaterialSingleLineTextField txtDiscount);
        double billtotal(MaterialSingleLineTextField txtPrice, MaterialSingleLineTextField txtQuantity);

    }
}
