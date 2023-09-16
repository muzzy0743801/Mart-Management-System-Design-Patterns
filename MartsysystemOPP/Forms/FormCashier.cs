using MartsysystemOPP.AUD;
using MartsysystemOPP.AUD.Adapter;
using MartsysystemOPP.AUD.Proxy;
using MartsysystemOPP.CashierPanel;
using MartsysystemOPP.CashierPanel.Calculation;
using MartsysystemOPP.CashierPanel.Pay;
using MartsysystemOPP.Composite;
using MartsysystemOPP.MaterialSkinTheme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartsysystemOPP
{
    public partial class FormCashier : MaterialSkin.Controls.MaterialForm
    {
        public FormCashier()
        {
            InitializeComponent();

            Theme theme = new Theme(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManegeProducts pr = new ManegeProducts();
            pr.Show();
            this.Hide();
        }

        public static Label bln, paym, Ttl;

        public static string DateLogout;
        public static string TimeLogout;
        public static double SalesOfProducts;
        public static double TotalAmountOfSales;
        public static string returnbacktotal;
        private void cashier_Load(object sender, EventArgs e)
        {
            label10.Text = DateTime.Now.ToShortDateString();
            label11.Text = DateTime.Now.ToShortTimeString();
            label26.Text = LoginClass.UName;

            bln = label18;
            paym = label12;
            Ttl = label8;

            cmShow.Items.Clear();
            string[] read = File.ReadAllLines("Category.txt");
            for (int i = 0; i < read.Length; i++)
            {
                cmShow.Items.Add(read[i].ToString());
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            //ItemCategory itmc = new ItemCategory(cmShow.Text);
            ProductsClass itm = new ProductsClass(cmShow.Text);
            itm.Show(new ConnectionAdapter(new ConnectionAdaptee()), dgViewShow);

            dgViewShow.Columns[0].Visible = false;
            dgViewShow.Columns[2].Visible = false;
            dgViewShow.Columns[3].Visible = false;
            dgViewShow.Columns[4].Visible = false;
            dgViewShow.Columns[5].Visible = false;
            dgViewShow.Columns[6].Visible = false;
            dgViewShow.Columns[8].Visible = false;
            dgViewShow.Columns[9].Visible = false;
            dgViewShow.Columns[10].Visible = false;
        }

        private void dgViewShow_CellContentClick_2(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            ProductsClass pc = new ProductsClass();
            pc.CPDataToFeild(txtProductName, txtPrice, PicImage, dgViewShow, e);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                
                ProductsClass pc = new ProductsClass();
                pc.SearchIt(new ConnectionAdapter(new ConnectionAdaptee()), dgViewShow, txtSearch);
            }
            else
            {
                MessageBox.Show("Enter something to search");
            }
        }

        public static int showGroupBox = 0;

        private void btnPay_Click_1(object sender, EventArgs e)
        {
            CustomerPayment cp = new CustomerPayment();
            cp.Show();
           

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            label12.Text = "";
            label18.Text = "";
            label8.Text = "";

         
            ProductsClass itm = new ProductsClass(cmShow.Text);
            itm.Show(new ConnectionAdapter(new ConnectionAdaptee()), dgViewShow);

            //proxycalculationbill billcalculate = new proxycalculationbill();

            if (txtName.Text == "" || txtProductName.Text == "" || txtPrice.Text == "" || txtQuantity.Text == "")
            {
                MessageBox.Show("All feild required!");
            }
            else
                if (txtDiscount.Text != "")
                { //


                //Update Quantity
                quantitycalculation quantity = new quantitycalculation();
                quantity.getquantity(txtPrice, txtQuantity);
                quantity.updatequantity(txtQuantity);

                //Proxy Discount Calculation
                proxycalculationbill billcalculate = new proxycalculationbill();
                label8.Text = billcalculate.billdiscount(txtPrice, txtQuantity,txtDiscount).ToString();

                label24.Text = txtDiscount.Text;

                //Sales
                cashierleaf objcashierleaf = new cashierleaf(); // set ha ab dekh update quatity ki 2 classes ha fuzul ki jo ek class bhr parhi hui ha uska kam cut paste krke calculation wali updatequantity ki class me dal
                //ok
                objcashierleaf.NameOfCashier(new Sales(), label26.Text);
                    Sales sl = new Sales();
                    sl.SalesToCustomer(objcashierleaf, label25.Text, txtName.Text, objcashierleaf.CashierName, txtProductName.Text, txtQuantity.Text, txtDiscount.Text, txtPrice.Text, calculationbill.TotalWithDiscount.ToString(), "");

                    sl.SalesToCustomer();

                    //BillIt
                    Bill bl = new Bill(txtProductName, calculationbill.TotalWithDiscount, txtQuantity);

                    SalesOfProducts += double.Parse(txtQuantity.Text);

                    TotalAmountOfSales += double.Parse(label8.Text);
                }
                else
                {
                //Update Quantity
                quantitycalculation quantity = new quantitycalculation();
                quantity.getquantity(txtPrice, txtQuantity);
                quantity.updatequantity(txtQuantity);


                   //Proxy TotalBill Calculation
                proxycalculationbill billcalculate = new proxycalculationbill();
                label8.Text = billcalculate.billtotal(txtPrice, txtQuantity).ToString();
           
                    label24.Text = 0.ToString();

                //Sales
                cashierleaf objcashierleaf = new cashierleaf();
                objcashierleaf.NameOfCashier(new Sales(), label26.Text);
                    Sales sl = new Sales();
                    sl.SalesToCustomer(objcashierleaf, label25.Text, txtName.Text, objcashierleaf.CashierName, txtProductName.Text, txtQuantity.Text, txtDiscount.Text, txtPrice.Text, (double.Parse(txtPrice.Text) * double.Parse(txtQuantity.Text)).ToString(), "");

                    sl.SalesToCustomer();


                    //BillIt 
                    Bill bl = new Bill(txtProductName, calculationbill.TotalWithoutDiscount, txtQuantity);

                    SalesOfProducts += double.Parse(txtQuantity.Text);

                    TotalAmountOfSales += double.Parse(label8.Text);
                }
            

            
        }

        private void cmShow_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DateLogout = DateTime.Now.ToString("yyyy/MM/dd");
            TimeLogout = DateTime.Now.ToShortTimeString();

            iusercomponent iuser = new cashierleaf();
            iuser.Logout();


            Login lg = new Login();
            lg.Show();
            this.Hide();
        }
    }
}
