using MartsysystemOPP.Composite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartsysystemOPP
{
    public partial class SelectMenu : MaterialSkin.Controls.MaterialForm
    {
        public SelectMenu()
        {
            InitializeComponent();
        }

        private void select_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManegeProducts pd = new ManegeProducts();
            pd.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ManageCashier ac = new ManageCashier();
            ac.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReportSales rs = new ReportSales();
            rs.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            iusercomponent iuser = new admincomposite();
            iuser.Logout();
            this.Hide();
        }
    }
}
