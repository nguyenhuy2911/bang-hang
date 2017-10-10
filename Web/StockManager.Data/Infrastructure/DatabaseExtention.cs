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
using Common;
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

        private static bool ColumnExists(this DataTable table, string columnName)
        {
            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (table.Columns[i].ColumnName.Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
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

        public static List<TSource> GetListData_By_Stored<TSource, TParameter>(this DbContext context, string storedName, TParameter parameterObj, ref int rowCount)
        {

            List<TSource> Rows = new List<TSource>();
            var _parameters = new List<SqlParameter>();
            var parametersObjProp = parameterObj.GetType().GetProperties();
            foreach (var paramProp in parametersObjProp)
            {
                var paramProp_CustomAttribute = paramProp?.GetCustomAttribute<SqlParameterAttribute>(true);
                if (paramProp_CustomAttribute != null)
                {
                    SqlParameter sqlParam = new SqlParameter(paramProp_CustomAttribute.ParameterName, parameterObj.GetPropValue(paramProp.Name));
                    sqlParam.DbType = paramProp_CustomAttribute.DbType;
                    if (paramProp_CustomAttribute.IsOutput)
                        sqlParam.Direction = ParameterDirection.Output;
                    _parameters.Add(sqlParam);
                }
            }
            using (SqlConnection con = new SqlConnection(context.Database.Connection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(storedName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var param in _parameters)
                        cmd.Parameters.Add(param);
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            var dictionary = typeof(TSource).GetProperties()
                                                      .ToDictionary(
                                                            field => CamelCaseToUnderscore(field.Name),
                                                            field => field.Name
                                                       );
                            while (dr.Read())
                            {
                                TSource tempObj = (TSource)Activator.CreateInstance(typeof(TSource));
                                foreach (var key in dictionary.Keys)
                                {
                                    var fieldName = dictionary[key];
                                    PropertyInfo propertyInfo = tempObj.GetType().GetProperty(fieldName, BindingFlags.Public | BindingFlags.Instance);
                                    if (null != propertyInfo && propertyInfo.CanWrite && dr.ColumnExists(fieldName))
                                        propertyInfo.SetValue(tempObj, GetDBValue(dr[fieldName], propertyInfo), null);

                                    if (dr.ColumnExists("RowCount"))                                    
                                        rowCount = int.Parse( dr["RowCount"].ToString());    
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

        public static int UpdateData_By_Stored<TParameters>(this DbContext context, string storedName, TParameters parametersObj)
        {
            var data = 0;
            var parameters = new List<SqlParameter>();
            try
            {
                // Prameters
                var parametersObjProp = parametersObj.GetType().GetProperties();
                foreach (var paramProp in parametersObjProp)
                {
                    var paramProp_CustomAttribute = paramProp?.GetCustomAttribute<SqlParameterAttribute>(true);
                    if (paramProp_CustomAttribute != null)
                    {
                        SqlParameter sqlParam = new SqlParameter(paramProp_CustomAttribute.ParameterName, parametersObj.GetPropValue(paramProp.Name));
                        sqlParam.DbType = paramProp_CustomAttribute.DbType;
                        if (paramProp_CustomAttribute.IsOutput)
                            sqlParam.Direction = ParameterDirection.Output;
                        parameters.Add(sqlParam);
                    }
                }

                using (SqlConnection con = new SqlConnection(context.Database.Connection.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(storedName, con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (var param in parameters)
                            cmd.Parameters.Add(param);
                        con.Open();
                        int updateSuccess = cmd.ExecuteNonQuery();
                        data = updateSuccess;
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {

                return 0;
            }
            return data;
            //DataSet ds = new DataSet("ListTable");
            //  SqlDataAdapter da = new SqlDataAdapter();
            // da.SelectCommand = cmd;
            //   da.Fill(ds);
        }

    }
}
