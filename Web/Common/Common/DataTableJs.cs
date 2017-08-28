﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class DataTableGridHelper
    {
        public static string GetHeaderJson<T>()
        {
            Type t = typeof(T);
            List<TableHeaderAttribute> data = new List<TableHeaderAttribute>();
            PropertyInfo[] properties = t.GetProperties();
            if (properties != null)
            {
                foreach (var property in properties)
                {
                    var tableHeader = property?.GetCustomAttribute<TableHeaderAttribute>(true);
                    if (tableHeader != null)
                    {
                        tableHeader.data = tableHeader.data ?? property.Name;
                        data.Add(tableHeader);
                    }
                }
            }
            return JsonConvert.SerializeObject(data);
        }
    }
    public class TableHeaderAttribute : Attribute
    {
        public string data { get; set; }
        public string title { get; set; }
    }

}