using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
  public static class Utilies
    {
        public static string getResourceString(string key)
        {
            try
            {
                string retVal = string.Empty;
                try
                {
                    var rm = new ResourceManager("Resources.Resource", Assembly.Load("App_GlobalResources"));
                    //CultureInfo.CurrentCulture
                    retVal = rm.GetString(key, new CultureInfo("vi-vn"));
                }
                catch (Exception ex)
                {
                    retVal = "";                  
                }
                return retVal;
            }
            catch (Exception ex)
            {
               
                return string.Empty;
            }
        }
    }
}
