using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartsysystemOPP.AUD.Facade
{
    class salesreport
    {

        private isalesreport salesbyuser;
        private isalesreport salesbydate;
        DateTimePicker dtp1; DateTimePicker dtp2; DataGridView dataGridView1;
        public salesreport(DateTimePicker dtp1, DateTimePicker dtp2, DataGridView dataGridView1)
        {
             this.dtp1 = dtp1;
            this.dtp2 = dtp2;
            this.dataGridView1 = dataGridView1;
            salesbyuser = new salesbyuser(dataGridView1);
            salesbydate = new salesbydate(dtp1,  dtp2, dataGridView1);
    }
        public salesreport(DataGridView dataGridView1)
        {
            this.dataGridView1 = dataGridView1;
            salesbyuser = new salesbyuser(dataGridView1);
        }
        public void showsales_byuser() {
            salesbyuser.showreport();
        }
        public void showsales_bydate() {
            salesbydate.showreport();
        }

    }
}
