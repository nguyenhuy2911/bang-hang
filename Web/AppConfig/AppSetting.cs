using System;
using System.Linq;
using System.Text;
using System.Configuration;
namespace AppConfig
{
    public static class AppSetting
    {
        private static string GetConfigByKey(string key, string defaultValue)
        {
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[key]))
                return ConfigurationManager.AppSettings[key];
            else
                return defaultValue;
        }
        public static string connectionString = GetConfigByKey("ConnectionString", "");
        public static int pageSize = int.Parse(GetConfigByKey("pageSize", "10"));
        public static int pageNumSize = int.Parse(GetConfigByKey("pageSize", "10"));
    }

}
