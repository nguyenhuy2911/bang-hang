using Common;
using System;
using System.Collections.Generic;
using System.Data;
namespace StockManager.Data.Model.Data
{
    public class Product_GetList_Level2_By_Level1_Parameter
    {
        public Product_GetList_Level2_By_Level1_Parameter() { }

        [SqlParameterAttribute(ParameterName = "@Product_Level1_Id", DbType = DbType.Int64)]
        public int Product_Level1_Id { get; set; }

        [SqlParameterAttribute(ParameterName = "@Offset", DbType =DbType.Int64)]
        public int Offset { get; set; }

        [SqlParameterAttribute(ParameterName = "@Next", DbType = DbType.Int64)]
        public int Next { get; set; }
    }
}
