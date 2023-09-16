using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MartsysystemOPP.MaterialSkinTheme;

namespace MartsysystemOPP
{
    public partial class Login : MaterialSkin.Controls.MaterialForm
    {
        public Login()
        {
            InitializeComponent();

            Theme theme = new Theme(this);
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public static string StoreUsername;
        public static string DateLogin;
        public static string TimeLogin;

       
        private void materialRaisedButton1_Click(object sender, EventArgs e) //login btn
        {
            //Accounts accCashier = new CashierLogin();
            //accCashier.Login(new AUD.Connection(), txtUsername.Text, txtPassword.Text);

            LoginClass lg = new LoginClass();
            lg.Login(txtUsername.Text, txtPassword.Text);
            this.Hide();

            //CashierRecord
            StoreUsername = txtUsername.Text;
            DateLogin = DateTime.Now.ToString("yyyy/MM/dd");
            TimeLogin = DateTime.Now.ToShortTimeString();


        }

       
        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static int c = 0;
        

        private void smShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cmShowPass.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }

           
        }

      
    }
}
