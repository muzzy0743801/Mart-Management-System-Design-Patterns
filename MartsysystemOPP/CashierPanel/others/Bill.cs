using MartsysystemOPP.CashierPanel.Calculation;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartsysystemOPP.CashierPanel
{
    class Bill
    {
        public string name {get; set; }
        public string price { get; set; }
        public string quantity { get; set; }


        public Bill()
        {
            //Default
        }

        public Bill(string Name, string Price, string Quantity)
        {
            name = Name;
            price = Price;
            quantity = Quantity;
        }

        //CustomerOrder
        public Bill(MaterialSingleLineTextField txtPName, double Price, MaterialSingleLineTextField txtQuantity)
        {
            StreamWriter sw = new StreamWriter("BillIt.txt", true);
            Bill bl = new Bill(txtPName.Text, Price.ToString(), txtQuantity.Text);
            sw.WriteLine(bl.name + "\t\t  " + bl.quantity + "\t\t  " + bl.price);
            sw.Close();
        }

        public void ReadBill(ListBox listBox1)
        {
            string[] read = File.ReadAllLines("BillIt.txt");
            listBox1.Items.Add("ProductName \t Quantity \t\t Price");
            for (int i = 0; i < read.Length; i++)
            {
                listBox1.Items.Add(read[i]);
            }
        }
    }
}
