
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace Common.ImagesExtention
{

    public static class ImagesExtention
    {
        public static System.Drawing.Image GetImageFromPath(this string path, int maxWidth, int maxHeight, bool isScale = true)
        {
            Image current = new Bitmap(100, 100);
            try
            {
                string imagePath = HttpContext.Current.Server.MapPath(path);
                if (System.IO.File.Exists(imagePath))
                {
                    current = System.Drawing.Image.FromFile(imagePath);
                }
            }
            catch (Exception)
            {
                return current;
            }
            //return current;
            return current.Resize(maxWidth, maxHeight, isScale);
        }
        public static Image Resize(this Image current, int newWidth, int newHeight, bool isScale)
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
            Image canvas = new Bitmap(width, height);

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
                current.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }
    }
}
