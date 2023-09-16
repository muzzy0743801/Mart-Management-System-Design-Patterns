using MartsysystemOPP.AUD;
using MartsysystemOPP.AUD.Proxy;
using MartsysystemOPP.CashierPanel.Calculation;
using MartsysystemOPP.CashierPanel.Pay;
using MartsysystemOPP.Composite;
using MartsysystemOPP.MaterialSkinTheme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartsysystemOPP.CashierPanel
{
    public partial class CustomerPayment : MaterialSkin.Controls.MaterialForm
    {
        public CustomerPayment()
        {
            InitializeComponent();
            Theme theme = new Theme(this);
        }


        private void CustomerPayment_Load(object sender, EventArgs e)
        {
            label8.Text = calculationbill.totl.ToString();
          
             
            label1.Visible = false;

            Bill bl = new Bill();
            bl.ReadBill(listBox1);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtCustomerPay.Text == "")
            {
                label1.Visible = true;
                label1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                //Insert into Total column of database sales
                Sales ds = new Sales();
                ds.SalesToCustomer(new cashierleaf(), "", "", "", "", "", "", "", "", label8.Text);
                cashierleaf objcashierleaf = new cashierleaf();
                objcashierleaf.NameOfCashier(ds, "");
                ds.TotalOfsales(); 

                ByCash pByCash = new ByCash();

                FormCashier.paym.Text = "Rs. " + pByCash.Pay(txtCustomerPay).ToString() + "/=";
                FormCashier.bln.Text = "Rs. " + pByCash.Balance(0.0, label8).ToString() + "/=";
                FormCashier.Ttl.Text = label8.Text; 

                this.Close();
               

                File.WriteAllText("BillIt.txt", "");

                calculationbill.totl = 0.00;
                FormCashier.Ttl.Text = ""; 



            }
        }

        

    }
}
