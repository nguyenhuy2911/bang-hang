using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public static class SystemUrl
    {
        public static string ThemeImage(string imageName)
        {
            return "Content/Themes/Admin/images/" + imageName;
        
        }
        public static string DomailUrl = "http://localhost:39672";
        public static string Image = "Images/";
        public static string UrlAction(string url)
        {
            return DomailUrl + "/" + url;
        }
    }
}
