using Common;
using System;
using System.Collections.Generic;
using System.Data;
namespace StockManager.Data.Model.Data
{
    public class Product_Update_Parameter
    {
        public Product_Update_Parameter() { }

        [SqlParameterAttribute(ParameterName = "@Product_ID", DbType =DbType.Int64)]
        public int Product_ID { get; set; }

        [SqlParameterAttribute(ParameterName = "@Product_Name", DbType = DbType.String)]
        public string Product_Name { get; set; }

        [SqlParameterAttribute(ParameterName = "@Sale_Price", DbType = DbType.Double)]
        public decimal? Sale_Price { get; set; }

        [SqlParameterAttribute(ParameterName = "@Org_Price", DbType = DbType.Double)]
        public decimal? Org_Price { get; set; }

        [SqlParameterAttribute(ParameterName = "@Quantity", DbType = DbType.Double)]
        public decimal? Quantity { get; set; }

        [SqlParameterAttribute(ParameterName = "@Unit_ID", DbType = DbType.String)]
        public string Unit_ID { get; set; }

        [SqlParameterAttribute(ParameterName = "@Product_Group_ID", DbType = DbType.String)]
        public int? Product_Group_ID { get; set; }

        [SqlParameterAttribute(ParameterName = "@Product_Type_ID", DbType = DbType.Int64)]
        public int? Product_Type_ID { get; set; }

        [SqlParameterAttribute(ParameterName = "@Product_Level1", DbType = DbType.Int64)]
        public int? Product_Level1 { get; set; }

        [SqlParameterAttribute(ParameterName = "@Product_Level2", DbType = DbType.Int64)]
        public int? Product_Level2 { get; set; }

        [SqlParameterAttribute(ParameterName = "@Product_Level3", DbType = DbType.Int64)]
        public int? Product_Leve3 { get; set; }

        [SqlParameterAttribute(ParameterName = "@Description", DbType = DbType.String)]
        public string Description { get; set; }

        [SqlParameterAttribute(ParameterName = "@Publish", DbType = DbType.Boolean)]
        public int? Publish { get; set; }

        [SqlParameterAttribute(ParameterName = "@Active", DbType = DbType.Boolean)]
        public int? Active { get; set; }

    }
}
