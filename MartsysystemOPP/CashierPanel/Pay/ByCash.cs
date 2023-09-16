using MartsysystemOPP.AUD.Proxy;
using MartsysystemOPP.CashierPanel.Calculation;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartsysystemOPP.CashierPanel.Pay
{
    class ByCash : Payment
    {
        private double balance = Sbalance;

        public double Balance(double balance, Label label8)
        {
            try
            {
                this.balance = balance;
                balance = CustomerPay - calculationbill.totl;
                return balance;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }


        public override double Pay(MaterialSingleLineTextField txtCustomerPay)
        {
            try
            {
                CustomerPay = double.Parse(txtCustomerPay.Text);
                return CustomerPay;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }
    }
}
