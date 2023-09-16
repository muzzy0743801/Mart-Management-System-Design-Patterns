using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartsysystemOPP.AUD
{
    class imageLocation
    {
        public static string LocationImage;

        public string UpdloadImageBtn(PictureBox PicImage)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            opendlg.Filter = "Image only. |*.jpg; *.jpeg; *.png;";
            if ((opendlg.ShowDialog()) == DialogResult.OK)
            {
                LocationImage = opendlg.FileName.ToString();
                PicImage.ImageLocation = LocationImage;
                return LocationImage;
            }
            return LocationImage;
        }
    }
}
