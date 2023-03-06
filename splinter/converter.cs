using System;
using System.IO;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace splinter
{
    class Converter
    {
        public static string ToBase64(string filePath)
        {
            byte[] imageArray = File.ReadAllBytes(filePath);
            string base64Image = Convert.ToBase64String(imageArray);
            return base64Image;
        }

        public BitmapImage toImg(string base64Image)
        {
            byte[] bytes = Convert.FromBase64String(base64Image);
            using (var ms = new MemoryStream(bytes))
            {
                // Create a new image object
                var image = new BitmapImage();

                // Set the image source to the memory stream
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();

               
                return image;
            }
        }

    }
}
