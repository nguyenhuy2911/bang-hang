using Common;
using System;
using System.Collections.Generic;
using System.Data;
namespace StockManager.Data.Model.Data
{
    public class Product_Get_By_Product_Group_ID_Parameter
    {
        public Product_Get_By_Product_Group_ID_Parameter() { }

        [SqlParameterAttribute(ParameterName = "@Product_Group_ID", DbType =DbType.Int64)]
        public int Product_Group_ID { get; set; }

        [SqlParameterAttribute(ParameterName = "@Publish", DbType = DbType.Int64)]
        public int Publish { get; set; }

    }
}
