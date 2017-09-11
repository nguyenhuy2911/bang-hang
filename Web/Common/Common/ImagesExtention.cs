
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Web;
namespace Common.ImagesExtention
{

    public static class ImagesExtention
    {
        public static System.Drawing.Image GetImageFromPath(this string path, int maxWidth, int maxHeight, bool isScale = true)
        {
            Bitmap current = new Bitmap(maxWidth, maxHeight);
            try
            {
                string noImagePath = HttpContext.Current.Server.MapPath(@"~/Content/images/no-image.png");
                string imagePath = HttpContext.Current.Server.MapPath(path);
                if (System.IO.File.Exists(imagePath))
                    current = new Bitmap(imagePath);
                else
                    current = new Bitmap(noImagePath);
               
            }
            catch (Exception)
            {
                return current;
            }
            return current.Resize(maxWidth, maxHeight, isScale);
        }
        public static Image Resize(this Bitmap current, int newWidth, int newHeight, bool isScale)
        {
            int width, height;

            if (isScale)
            {
                if (current.Width > current.Height)
                {
                    width = newWidth;
                    height = Convert.ToInt32(current.Height * newHeight / (double)current.Width);
                }
                else
                {
                    width = Convert.ToInt32(current.Width * newWidth / (double)current.Height);
                    height = newHeight;
                }
            }
            else
            {
                width = newWidth;
                height = newHeight;
            }
            Bitmap canvas = new Bitmap(width, height);
           
            using (var graphics = Graphics.FromImage(canvas))
            {
                graphics.CompositingQuality = CompositingQuality.HighSpeed;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.CompositingMode = CompositingMode.SourceCopy;             
                graphics.DrawImage(current, 0, 0, width, height);
            }
           
            return canvas;
        }
        public static byte[] ToByteArray(this Image current)
        {
            using (var stream = new MemoryStream())
            {
                current.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
