using MartsysystemOPP.AUD;
using MartsysystemOPP.AUD.Facade;
using MartsysystemOPP.Composite;
using MartsysystemOPP.MaterialSkinTheme;
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
    public partial class ManageCashier : MaterialSkin.Controls.MaterialForm
    {
        public ManageCashier()
        {
            InitializeComponent();
            Theme theme = new Theme(this);
        }
        //CashierClass clcshr = new CashierClass();

        iusercomponent admincheck = new admincomposite();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            iusercomponent iuser = new cashierleaf(dgViewShow);
            iusercomponent adminadd = new admincomposite(txtName, txtPIN, txtContact, txtSalary, txtAddress, txtEmail, dtpJoinDate.Value, 1);
            adminadd.Required();

            adminadd.SaveData();

            admincheck.Show(iuser);

            adminadd.RefreshOrClear();

            Random r = new Random();
            int a = r.Next(1000, 9999);
            txtPIN.Text = a.ToString();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            iusercomponent iuser = new cashierleaf(dgViewShow);
            iusercomponent adminupdate = new admincomposite(txtName, txtPIN, txtContact, txtSalary, txtAddress, txtEmail, dtpJoinDate.Value, 1);
            adminupdate.UpdateData();

            admincheck.Show(iuser);

            adminupdate.RefreshOrClear();

            Random r = new Random();
            int a = r.Next(1000, 9999);
            txtPIN.Text = a.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            iusercomponent iuser = new cashierleaf(dgViewShow);
            iusercomponent admindelete = new admincomposite(txtName, txtPIN, txtContact, txtSalary, txtAddress, txtEmail, dtpJoinDate.Value, 1);
            admindelete.DeleteData();

            admincheck.Show(iuser);

            admindelete.RefreshOrClear();

            Random r = new Random();
            int a = r.Next(1000, 9999);
            txtPIN.Text = a.ToString();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            iusercomponent iuser = new cashierleaf(dgViewShow);
            iusercomponent admin = new admincomposite();
            admin.Show(iuser);
            
        }

        private void dgViewShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            iusercomponent admindatatofiled = new admincomposite(txtName, txtPIN, txtContact, txtSalary, txtAddress, txtEmail, dtpJoinDate.Value, 1);
            admindatatofiled.DataToFeild(dgViewShow, e);

        }

        private void AddCashier_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            int a = r.Next(1000, 9999);
            txtPIN.Text = a.ToString();
            txtPIN.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SelectMenu sc = new SelectMenu();
            sc.Show();
            this.Hide();
        }

        private void btnCRecord_Click(object sender, EventArgs e)
        {
            salesreport salereport = new salesreport(dgViewShow);
            salereport.showsales_byuser();
           
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
