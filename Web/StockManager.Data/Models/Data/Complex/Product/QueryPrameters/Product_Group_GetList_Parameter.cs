using Common;
using System;
using System.Collections.Generic;
using System.Data;
namespace StockManager.Data.Model.Data
{
    public class Product_Group_GetList_Parameter
    {
        public Product_Group_GetList_Parameter() { }

        [SqlParameterAttribute(ParameterName = "@Offset", DbType =DbType.Int64)]
        public int Offset { get; set; }

        [SqlParameterAttribute(ParameterName = "@Next", DbType = DbType.Int64)]
        public int Next { get; set; }
    }
}
