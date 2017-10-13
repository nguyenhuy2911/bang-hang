using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Data.StoreProcedure
{
    public static class STORENAME
    {
        public static string PRODUCT_GROUP_GetList = "PRODUCT_GROUP_GetList";
        public static string PRODUCT_Update = "PRODUCT_Update";
        public static string PRODUCT_Get_By_Product_Group_ID = "PRODUCT_Get_By_Product_Group_ID";
        public static string PRODUCT_GetList_By_Level2 = "PRODUCT_GetList_By_Level2";
        public static string PRODUCT_GetList_By_Level1 = "PRODUCT_GetList_By_Level1";
        public static string PRODUCT_GetList_Level2_By_Level1 = "PRODUCT_GetList_Level2_By_Level1";
        public static string ProductType_Attribute_Get_By_ProductType_Id = "ProductType_Attribute_Get_By_ProductType_Id";

    }
}
