﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace Common
{
    public static class Utility
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

        public static T convertNumber<T>(Object value)
        {
            CultureInfo ci = new CultureInfo("en-US");
            var result = (T)Convert.ChangeType(value, typeof(T), ci);
            return result;
        }

        public static string NumberToString(this Object value)
        {
            if (value != null)
            {
                return string.Format(CultureInfo.InvariantCulture, "{0:0,0}", value);
            }
            else
                return "0";

        }

        public static void SetCookie(string Key, Object Data)
        {
            string cookieString = JsonConvert.SerializeObject(Data);
            var cookie = new HttpCookie(Key, cookieString);
            cookie.Expires.AddDays(365);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static T GetDataFromCookie<T>(string Key)
        {
            var cookie = HttpContext.Current.Request.Cookies[Key];
            if (cookie != null)
            {
                var data = JsonConvert.DeserializeObject<T>(cookie.Value);
                return data;
            }
            else
                return default(T);
        }
    }
}
