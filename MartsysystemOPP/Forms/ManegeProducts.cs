using MartsysystemOPP.AUD;
using MartsysystemOPP.AUD.Adapter;
using MartsysystemOPP.AUD.Factory;
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
    public partial class ManegeProducts : MaterialSkin.Controls.MaterialForm
    {
        public ManegeProducts()
        {
            InitializeComponent();
            Theme theme = new Theme(this);
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            imageLocation imgL = new imageLocation();
            imgL.UpdloadImageBtn(PicImage);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dgViewShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductsClass pc = new ProductsClass();
            pc.DataToFeild(txtName, txtQuantity, txtBarcode, txtPrice, PicImage, txtDetail, dtManufactureDate.Value, dtExpireDate.Value, dgViewShow, e);

        }

        private void Products_Load(object sender, EventArgs e)
        {
            cmCategory.Items.Clear();
            cmShow.Items.Clear();
            string[] read = File.ReadAllLines("Category.txt");
            for (int i = 0; i < read.Length; i++)
            {
                cmCategory.Items.Add(read[i].ToString());
                cmShow.Items.Add(read[i].ToString());
            }
        }




        private void btnSave_Click_1(object sender, EventArgs e)
        {
            
         
            if (txtName.Text == "" || cmCategory.Text == "Select Category" || txtBarcode.Text == "" || txtPrice.Text == "" || txtDetail.Text == "" || PicImage.Image == null)
            {
                MessageBox.Show("All Feild Required!");
            }
            else
            {
                //Item Class Save Method
               
                ProductsClass itm = new ProductsClass(txtName.Text, cmCategory.Text, txtQuantity.Text, txtBarcode.Text, txtPrice.Text, txtDetail.Text, dtManufactureDate.Value, dtExpireDate.Value, 1);
                itm.SaveData(new ConnectionAdapter(new ConnectionAdaptee()));

                itm.ShowAll(dgViewShow,new ConnectionAdapter(new ConnectionAdaptee()));  //Adapter pattern implemtation

                itm.RefreshOrClear(txtName, txtQuantity, txtBarcode, txtPrice, PicImage, txtDetail, dtManufactureDate.Value, dtExpireDate.Value);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            ProductsClass itm = new ProductsClass(txtName.Text, cmCategory.Text, txtQuantity.Text, txtBarcode.Text, txtPrice.Text, txtDetail.Text, dtManufactureDate.Value, dtExpireDate.Value, 1);
            itm.UpdateData(new ConnectionAdapter(new ConnectionAdaptee()));

            //ShowData sd = new ShowData();
            itm.ShowAll(dgViewShow, new ConnectionAdapter(new ConnectionAdaptee())); //Adapter pattern implemtation

            itm.RefreshOrClear(txtName, txtQuantity, txtBarcode, txtPrice, PicImage, txtDetail, dtManufactureDate.Value, dtExpireDate.Value);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            ProductsClass itm = new ProductsClass(txtName.Text, cmCategory.Text, txtQuantity.Text, txtBarcode.Text, txtPrice.Text, txtDetail.Text, dtManufactureDate.Value, dtExpireDate.Value, 0);
            itm.DeleteData(new ConnectionAdapter(new ConnectionAdaptee()));

            itm.Show(new ConnectionAdapter(new ConnectionAdaptee()), dgViewShow);

            itm.RefreshOrClear(txtName, txtQuantity, txtBarcode, txtPrice, PicImage, txtDetail, dtManufactureDate.Value, dtExpireDate.Value);
        
        }

        private void btnUploadImage_Click_1(object sender, EventArgs e)
        {
            imageLocation imgL = new imageLocation();
            imgL.UpdloadImageBtn(PicImage);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
           
            if (cmShow.Text == "Select Category")
            {
                //Plzz Select
            }
            else
            {
                igetcategory iget = null;
                iget = catprofactory.mcatpro_factory(cmShow.Text); //factory Pattern implementation
                iget.cat_showpro(dgViewShow);
                
                int n = 70;
                dgViewShow.Columns[0].Width = n;
                dgViewShow.Columns[1].Width = 80;
                dgViewShow.Columns[2].Width = n;
                dgViewShow.Columns[3].Width = n;
                dgViewShow.Columns[4].Width = n;
                dgViewShow.Columns[5].Width = 80;
                dgViewShow.Columns[6].Width = n;
                dgViewShow.Columns[7].Width = 80;
                dgViewShow.Columns[8].Width = 80;
                dgViewShow.Columns[9].Width = 68;
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SelectMenu sl = new SelectMenu();
            sl.Show();
            this.Hide();
        }



        private void btnSearch_Click(object sender, EventArgs e)
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
    }
}
