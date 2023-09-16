using MartsysystemOPP.CashierPanel;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartsysystemOPP.MaterialSkinTheme
{
    class Theme
    {
        public Theme()
        {
            //Default
        }

        public Theme(ManegeProducts objProducts) // Parameterized Constructor
        {
            MaterialSkinManager skinManager;
            skinManager = MaterialSkinManager.Instance;
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.AddFormToManage(objProducts);
            skinManager.ColorScheme = new ColorScheme(Primary.Green500, Primary.Green900, Primary.Green100, Accent.Green700, TextShade.WHITE);
        }

        public Theme(Login objLogin) // Parameterized Constructor
        {
            MaterialSkinManager skinManager;
            skinManager = MaterialSkinManager.Instance;
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.AddFormToManage(objLogin);
            skinManager.ColorScheme = new ColorScheme(Primary.Green500, Primary.Green900, Primary.Green100, Accent.Green700, TextShade.WHITE);
        }

        public Theme(FormCashier objCashier) // Parameterized Constructor
        {
            MaterialSkinManager skinManager;
            skinManager = MaterialSkinManager.Instance;
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.AddFormToManage(objCashier);
            skinManager.ColorScheme = new ColorScheme(Primary.Green500, Primary.Green900, Primary.Green100, Accent.Green700, TextShade.WHITE);
        }

        public Theme(CustomerPayment objcp) // Parameterized Constructor
        {
            MaterialSkinManager skinManager;
            skinManager = MaterialSkinManager.Instance;
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.AddFormToManage(objcp);
            skinManager.ColorScheme = new ColorScheme(Primary.Green500, Primary.Green900, Primary.Green100, Accent.Green700, TextShade.BLACK);
        }

        //public Theme(PaymentByCheque obpbc) // Parameterized Constructor
        //{
        //    MaterialSkinManager skinManager;
        //    skinManager = MaterialSkinManager.Instance;
        //    skinManager.Theme = MaterialSkinManager.Themes.DARK;
        //    skinManager.AddFormToManage(obpbc);
        //    skinManager.ColorScheme = new ColorScheme(Primary.Green500, Primary.Green900, Primary.Green100, Accent.Green700, TextShade.BLACK);
        //}

        public Theme(ManageCashier ac) // Parameterized Constructor
        {
            MaterialSkinManager skinManager;
            skinManager = MaterialSkinManager.Instance;
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.AddFormToManage(ac);
            skinManager.ColorScheme = new ColorScheme(Primary.Green500, Primary.Green900, Primary.Green100, Accent.Green700, TextShade.BLACK);
        }

        public Theme(ReportSales sr) // Parameterized Constructor
        {
            MaterialSkinManager skinManager;
            skinManager = MaterialSkinManager.Instance;
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.AddFormToManage(sr);
            skinManager.ColorScheme = new ColorScheme(Primary.Green500, Primary.Green900, Primary.Green100, Accent.Green700, TextShade.BLACK);
        }
    }
}
