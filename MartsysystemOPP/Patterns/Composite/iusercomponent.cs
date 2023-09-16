using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartsysystemOPP.Composite
{
    public interface iusercomponent
    {
       // public abstract void Show(DataGridView dgViewShow);

        void Show(iusercomponent iuser);
        void SaveData();
        void UpdateData();
        void DeleteData();
        void DataToFeild(DataGridView dgViewShow, DataGridViewCellEventArgs e);
        void RefreshOrClear();
        void Required();
       void Logout();
    }
}
