using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartsysystemOPP.AUD.Factory
{
   public class catprofactory
    {
        static public igetcategory mcatpro_factory(string cChoice)
        {
            igetcategory ObjSelector = null;

            switch (cChoice)
            {
                case "Electronic":
                    ObjSelector = new catelectronic(cChoice);
                    break;
                case "Drink":
                    ObjSelector = new catdrink(cChoice);
                    break;
                case "Food":
                    ObjSelector = new catfood(cChoice);
                    break;
                default:
                    ObjSelector = new catothers(cChoice);
                    break;
            }
            return ObjSelector;

        }
    }
}
