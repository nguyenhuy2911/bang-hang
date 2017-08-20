using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StockManager.Data.Infrastructure
{
    public static class DatabaseExtention
    {
        private static string CamelCaseToUnderscore(string str)
        {
            return Regex.Replace(str, @"(?<!_)([A-Z])", "_$1").TrimStart('_').ToLower();
        }
        private static bool ColumnExists(this IDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private static object GetDBValue(object value, PropertyInfo field)
        {
            if (field.PropertyType == typeof(int))
                return value.ReturnZeroIfNull();
            if (field.PropertyType == typeof(string))
                return value.ReturnEmptyIfNull();
            if (field.PropertyType == typeof(bool))
                return value.ReturnNullIfDbNull();

            return value.ReturnNullIfDbNull();
        }

        public static List<T> GetListData_By_Stored<T>(this DbContext context, string storedName, params object[] parameters)
        {

            List<T> Rows = new List<T>();
            using (SqlConnection con = new SqlConnection(context.Database.Connection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(storedName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var param in parameters)
                        cmd.Parameters.Add(param);
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            var dictionary = typeof(T).GetProperties()
                                                      .ToDictionary(
                                                            field => CamelCaseToUnderscore(field.Name),
                                                            field => field.Name
                                                       );
                            while (dr.Read())
                            {
                                T tempObj = (T)Activator.CreateInstance(typeof(T));
                                foreach (var key in dictionary.Keys)
                                {
                                    var fieldName = dictionary[key];
                                    PropertyInfo propertyInfo = tempObj.GetType().GetProperty(fieldName, BindingFlags.Public | BindingFlags.Instance);
                                    if (null != propertyInfo && propertyInfo.CanWrite && dr.ColumnExists(fieldName))
                                        propertyInfo.SetValue(tempObj, GetDBValue(dr[fieldName], propertyInfo), null);
                                }
                                Rows.Add(tempObj);
                            }
                        }
                        dr.Close();
                    }
                }
            }
            return Rows;
        }


    }
}
