using MartsysystemOPP.AUD.Adapter;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartsysystemOPP.AUD
{
    class ProductsClass
    {
        string PName;
        public string Category;
        string Quantity;
        string Barcode;
        string Price;
        string Detail;
        DateTime ManuDate;
        DateTime ExpDate;
        int Status;

        public static string StoreId;
        public static string StoreQuantity { get; set; }

        public ProductsClass()
        {
            
        }

        public ProductsClass(string Category)
        {
          
            this.Category = Category;
           
        }

        public ProductsClass(string PName, string Category, string Quantity, string Barcode, string Price, string Detail, DateTime ManuDate, DateTime ExpDate, int Status)
        {
            this.PName = PName;
            
            this.Category = Category;

            this.Quantity = Quantity;
            this.Barcode = Barcode;
            this.Price = Price;
            this.Detail = Detail;
            this.ManuDate = ManuDate;
            this.ExpDate = ExpDate;
            this.Status = Status;
        }

        public void Show(iconnection con, DataGridView dgViewShow) //for cashier search 
        {

            SqlCommand cmd = new SqlCommand("Select * from product where Category = '" + Category + "'", con.Get());
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgViewShow.DataSource = dt;
            dgViewShow.AllowUserToAddRows = false;

        }

        public void SaveData(iconnection con)
        {
           
           
            byte[] images = null;
            FileStream stream = new FileStream(imageLocation.LocationImage, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            images = brs.ReadBytes((int)stream.Length);

            string Query = "Insert into Product (Name,Category,Quantity,Barcode,Price,Image,Detail,ManufactureDate,ExpireDate,Status) VALUES ('" + PName + "', '" + Category + "' ,'" + Quantity + "', '" + Barcode + "', '" + Price + "', @images, '" + Detail + "',  '" + ManuDate + "', '" + ExpDate + "', '" + Status + "')";
            SqlCommand cmd = new SqlCommand(Query, con.Get());
            cmd.Parameters.Add(new SqlParameter("@images", images));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data successfully saved!");
        }

        public void UpdateData(iconnection con)
        {
           
            byte[] images = null;
            FileStream stream = new FileStream(imageLocation.LocationImage, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            images = brs.ReadBytes((int)stream.Length);

            string Query = "UPDATE product SET Name = '" + PName + "', Category = '" + Category + "',Quantity =  '" + Quantity + "', Barcode =  '" + Barcode + "', Price = '" + Price + "', Image = @images, Detail = '" + Detail + "',ManufactureDate = '" + ManuDate + "', ExpireDate = '" + ExpDate + "', Status = '" + 1 + "' WHERE Id = '" + ProductsClass.StoreId + "'";

            SqlCommand cmd = new SqlCommand(Query, con.Get());
            cmd.Parameters.Add(new SqlParameter("@images", images));           
            cmd.ExecuteNonQuery();
            MessageBox.Show(" Data successfully updated!");
        }

        public void DeleteData(iconnection con)
        {

            byte[] images = null;
            FileStream stream = new FileStream(imageLocation.LocationImage, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            images = brs.ReadBytes((int)stream.Length);

            string Query = "UPDATE product SET Name = '" + PName + "', Category = '" + Category +"', Barcode =  '" + Barcode + "', Price = '" + Price + "', Image = @images, Detail = '" + Detail + "',ManufactureDate = '" + ManuDate + "', ExpireDate = '" + ExpDate + "', Status = '" + 0 + "' WHERE Id = '" + ProductsClass.StoreId + "'";

            SqlCommand cmd = new SqlCommand(Query, con.Get());
            cmd.Parameters.Add(new SqlParameter("@images", images));
            cmd.ExecuteNonQuery();
            MessageBox.Show(" Data successfully Delete!");
        }

        //CPShow Data
        public void ProuctsShow(iconnection con, DataGridView dgViewShow)
        {
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select Id,Name,Quantity,Barcode,Price,Image,Detail from Product where Status = '1'";
            cmd.Connection = con.Get();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgViewShow.DataSource = dt;
            dgViewShow.AllowUserToAddRows = false;

        }

        public void CPDataToFeild(MaterialSingleLineTextField txtProductName, MaterialSingleLineTextField txtPrice, PictureBox PicImage, DataGridView dgViewShow, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgViewShow.Rows[e.RowIndex];
                    StoreId = row.Cells["Id"].Value.ToString();
                    StoreQuantity = row.Cells["Quantity"].Value.ToString();
                    txtProductName.Text = row.Cells["Name"].Value.ToString();
                    txtPrice.Text = row.Cells["Price"].Value.ToString();
                    Category = row.Cells["Category"].Value.ToString();
                    //txtQuantity.Text = row.Cells["Name"].Value.ToString();

                    //Inserting image from DataGridView to picture Box
                    var data = (Byte[])(row.Cells["Image"].Value);
                    var stream = new MemoryStream(data);
                    PicImage.Image = Image.FromStream(stream);
                    //End
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //CP ShowData End

        // ShowData
        public void ShowAll(DataGridView dgViewShow,iconnection con)
        {

            SqlCommand cmd = new SqlCommand("Select * from Product where Status = '1'",con.Get());
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgViewShow.DataSource = dt;
            dgViewShow.AllowUserToAddRows = false;
        }

        public void DataToFeild(MaterialSingleLineTextField Name, MaterialSingleLineTextField Quantity, MaterialSingleLineTextField Barcode, MaterialSingleLineTextField Price, PictureBox PicImage, MaterialSingleLineTextField Detail, DateTime ManufactureDate, DateTime ExpireDate, DataGridView dgViewShow, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgViewShow.Rows[e.RowIndex];
                    StoreId = row.Cells["Id"].Value.ToString();
                    Name.Text = row.Cells["Name"].Value.ToString();
                    Quantity.Text = row.Cells["Quantity"].Value.ToString();
                    //txtQuantity.Text = row.Cells["Name"].Value.ToString();
                    Barcode.Text = row.Cells["Barcode"].Value.ToString();
                    Price.Text = row.Cells["Price"].Value.ToString();

                    //Inserting image from DataGridView to picture Box
                    Byte[] data = (Byte[])(row.Cells["Image"].Value);
                    MemoryStream stream = new MemoryStream(data);
                    PicImage.Image = Image.FromStream(stream);
                    //End

                    Detail.Text = row.Cells["Detail"].Value.ToString();

                    //dtManufactureDate.Value = row.Cells("ManufactureDate").Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }        }

        //ShowData End

        //Search product a/c to name

        public void SearchIt(iconnection con, DataGridView dgViewShow, MaterialSingleLineTextField txtSearch)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * FROM Product where ((Name = '" + txtSearch.Text + "') AND (Status = '1'))";
            cmd.Connection = con.Get();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgViewShow.DataSource = dt;
            dgViewShow.AllowUserToAddRows = false;

        }


        //Refresh products textboxes

        public void RefreshOrClear(MaterialSingleLineTextField Name, MaterialSingleLineTextField Quantity, MaterialSingleLineTextField Barcode, MaterialSingleLineTextField Price, PictureBox Image, MaterialSingleLineTextField Detail, DateTime ManufactureDate, DateTime ExpireDate)
        {
            Name.Text = "";
            Quantity.Text = "";
            Barcode.Text = "";
            Price.Text = "";
            Image.Image = null;
            Detail.Text = "";
            ManufactureDate = DateTime.Now;
            ExpireDate = DateTime.Now;
        }

    }
}
