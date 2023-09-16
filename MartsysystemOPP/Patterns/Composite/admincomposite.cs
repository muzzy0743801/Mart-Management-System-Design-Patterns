using MartsysystemOPP.AUD;
using MartsysystemOPP.AUD.Adapter;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartsysystemOPP.Composite
{
    public class admincomposite : iusercomponent
    {
        DataGridView dgViewShow;
        MaterialSingleLineTextField Name;
        MaterialSingleLineTextField PIN;
        MaterialSingleLineTextField Contact;
        MaterialSingleLineTextField Salary;
        MaterialSingleLineTextField Address;
        MaterialSingleLineTextField Email;
        DateTime JoinDate;
        int Status;
        public static string StoreId;
       public admincomposite() { }
        public admincomposite(DataGridView dgViewShow)
        {
            this.dgViewShow = dgViewShow;
        }
        public admincomposite(MaterialSingleLineTextField Name, MaterialSingleLineTextField PIN, MaterialSingleLineTextField Contact, MaterialSingleLineTextField Salary, MaterialSingleLineTextField Address, MaterialSingleLineTextField Email, DateTime JoinDate, int Status)
        {
            this.Name = Name;
            this.PIN = PIN;
            this.Contact = Contact;
            this.Salary = Salary;
            this.Address = Address;
            this.Email = Email;
            this.JoinDate = JoinDate;
            this.Status = Status;
        }

        public void Show(iusercomponent iusr) {

            iusr.Show(iusr);
        }
        public void SaveData() {
            //this method will user parametarized constructor

            iconnection con = new ConnectionAdapter(new ConnectionAdaptee());

            string Query1 = "Insert into Cashier (Name,PIN,Contact,Salary,Address,Email,JoinDate,Status) VALUES ('" + Name.Text + "', '" + PIN.Text + "', '" + Contact.Text + "', '" + Salary.Text + "', '" + Address.Text + "',  '" + Email.Text + "', '" + JoinDate + "', '" + Status + "')";
            con.Execute_NonQuery(Query1);

            string Query2 = "Insert into Login (Username,Password,Role) VALUES ('" + Name.Text + "', '" + PIN.Text + "', '" + "Cashier" + "')";
            con.Execute_NonQuery(Query2);
                  
            MessageBox.Show("Data successfully saved!");
        }
        public void UpdateData()
        {
            iconnection con = new ConnectionAdapter(new ConnectionAdaptee());
            string Query = "UPDATE Cashier SET Name = '" + Name.Text + "', PIN =  '" + PIN.Text + "', Contact =  '" + Contact.Text + "', Salary = '" + Salary.Text + "', Address = '" + Address.Text + "',Email = '" + Email.Text + "', JoinDate = '" + JoinDate + "', Status = '" + 1 + "' WHERE Id = '" + StoreId + "'";
            con.Execute_NonQuery(Query);
            //SqlCommand cmd = new SqlCommand(Query, con.Get());
            //cmd.ExecuteNonQuery();    
            MessageBox.Show(" Data successfully updated!");
        }
        public void DeleteData()
        {
            iconnection con = new ConnectionAdapter(new ConnectionAdaptee());
            string Query = "UPDATE Cashier SET Name = '" + Name.Text + "', PIN =  '" + PIN.Text + "', Contact =  '" + Contact.Text + "', Salary = '" + Salary.Text + "', Address = '" + Address.Text + "',Email = '" + Email.Text + "', JoinDate = '" + JoinDate + "', Status = '" + 0 + "' WHERE Id = '" + StoreId + "'";

            //SqlCommand cmd = new SqlCommand(Query, con.Get());
            //cmd.ExecuteNonQuery();

            con.Execute_NonQuery(Query);
            MessageBox.Show("Data successfully Delete!");
        }
        public void DataToFeild(DataGridView dgViewShow, DataGridViewCellEventArgs e) {
            //this method will user parametarized constructor
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgViewShow.Rows[e.RowIndex];
                    StoreId = row.Cells["Id"].Value.ToString();
                    Name.Text = row.Cells["Name"].Value.ToString();
                    PIN.Text = row.Cells["PIN"].Value.ToString();
                    //txtQuantity.Text = row.Cells["Name"].Value.ToString();
                    Contact.Text = row.Cells["Contact"].Value.ToString();
                    Salary.Text = row.Cells["Salary"].Value.ToString();
                    Address.Text = row.Cells["Address"].Value.ToString();
                    Email.Text = row.Cells["Email"].Value.ToString();
                    //End
                    //dtManufactureDate.Value = row.Cells("ManufactureDate").Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void RefreshOrClear() {
            //this method will user parametarized constructor
            Name.Text = "";
            PIN.Text = "";
            Contact.Text = "";
            Salary.Text = "";
            Address.Text = "";
            Email.Text = "";
            JoinDate = DateTime.Now;
        }
        public void Required() {
            //this method will user parametarized constructor
            if (Name.Text == "" || PIN.Text == "" || Salary.Text == "" || Contact.Text == "" || Address.Text == "" || Email.Text == "")
            {
                MessageBox.Show("All Feild Required!");
            }
        }
      
        public void Logout()
        {
            Login lg = new Login();
            lg.Show();
            
        }
    }
}
