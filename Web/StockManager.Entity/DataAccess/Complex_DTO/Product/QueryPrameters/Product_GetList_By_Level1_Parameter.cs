using Common;
using System;
using System.Collections.Generic;
using System.Data;
namespace StockManager.Entity.DataAccess
{
    public class Product_GetList_By_Level1_Parameter
    {
        public Product_GetList_By_Level1_Parameter() { }

        [SqlParameterAttribute(ParameterName = "@Offset", DbType =DbType.Int64)]
        public int Offset { get; set; }

        [SqlParameterAttribute(ParameterName = "@Next", DbType = DbType.Int64)]
        public int Next { get; set; }
    }
}
