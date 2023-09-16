using MartsysystemOPP.AUD;
using MartsysystemOPP.AUD.Adapter;
using MartsysystemOPP.CashierPanel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartsysystemOPP.Composite
{
    class cashierleaf:iusercomponent
    {
        public string CashierName { get; set; }

        Sales objSales;

        public DataGridView dgViewShow;
        public cashierleaf(DataGridView dgViewShow)
        {
            this.dgViewShow =  dgViewShow;
        }
       
        public cashierleaf()
        { }
        public void NameOfCashier(Sales objSales, string CashierName)
        {
            this.objSales = objSales;
            this.CashierName = CashierName;
        }
        public  void Show(iusercomponent iuser) {
                iconnection con = new ConnectionAdapter(new ConnectionAdaptee());
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * from Cashier where Status = '1'";
                cmd.Connection = con.Get();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                this.dgViewShow.DataSource = dt;
                this.dgViewShow.AllowUserToAddRows = false;
            }
        public  void SaveData() { /*No Implementation*/ }
        public  void UpdateData() { /*No Implementation*/ }
        public  void DeleteData() { /*No Implementation*/ }
        public  void DataToFeild(DataGridView dgViewShow, DataGridViewCellEventArgs e) { /*No Implementation*/ }
        public  void RefreshOrClear() { /*No Implementation*/ }
        public  void Required() { /*No Implementation*/ }
        public  void Logout()
        {
            iconnection con = new ConnectionAdapter(new ConnectionAdaptee());
            string Query = "Insert into CashierLoginRecord (CashierName,LoginDate,LoginTime,LogoutDate,LogoutTime,SalesOfProduct,TotalOfSales) VALUES ('" + Login.StoreUsername + "', '" + Login.DateLogin + "' ,'" + Login.TimeLogin + "', '" + FormCashier.DateLogout + "', '" + FormCashier.TimeLogout + "',  '" + FormCashier.SalesOfProducts + "',  '" + FormCashier.TotalAmountOfSales + "')";
           SqlCommand cmd = new SqlCommand(Query,con.Get());
            cmd.ExecuteNonQuery();
        }
    }
}
