using StockManager.Data.Infrastructure;
using StockManager.Data.StoreProcedure;
using StockManager.Entity;
using StockManager.Entity.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace StockManager.Data.Repository
{
    public interface IProductRepository : IRepositoryBase<PRODUCT>
    {
        ResponseBase<List<PRODUCT_GROUP>> Get_Product_Groups(Product_Group_GetList_Parameter parameterObj);
        ResponseBase<List<PRODUCT>> Get_Products_By_GroupId(Product_Get_By_Product_Group_ID_Parameter parameterObj);
        ResponseBase<List<Product_GetList_By_Level1>> Product_GetList_By_Level1(Product_GetList_By_Level1_Parameter parameterObj);
        ResponseBase<List<Product_GetList_By_Level2>> Product_GetList_By_Level2(Product_GetList_By_Level2_Parameter parameterObj);
        ResponseBase<List<Product_GetList_Level2_By_Level1>> Product_GetList_Level2_By_Level1(Product_GetList_Level2_By_Level1_Parameter parameterObj);
        int Update_Product(Product_Update_Parameter parameter);
    }
    public class ProductRepository : RepositoryBase<PRODUCT>, IProductRepository
    {
        private IDbSet<PRODUCT> dbset;
        public ProductRepository(IDataBaseFactory dataBaseFactory) : base(dataBaseFactory)
        {
            dbset = DataContext.Set<PRODUCT>();
        }

        public ResponseBase<List<PRODUCT_GROUP>> Get_Product_Groups(Product_Group_GetList_Parameter parameterObj)
        {
            int rowCount = 0;
            var data = DataContext.GetListData_By_Stored<PRODUCT_GROUP, Product_Group_GetList_Parameter>(STORENAME.PRODUCT_GROUP_GetList, parameterObj, ref  rowCount);
            return new ResponseBase<List<PRODUCT_GROUP>>()
            {
                Results = data,
                TotalRow = rowCount
            };
        }

        public ResponseBase<List<PRODUCT>> Get_Products_By_GroupId(Product_Get_By_Product_Group_ID_Parameter parameterObj)
        {
            int rowCount = 0;
            var data = DataContext.GetListData_By_Stored<PRODUCT, Product_Get_By_Product_Group_ID_Parameter>(STORENAME.PRODUCT_Get_By_Product_Group_ID, parameterObj, ref rowCount);
            return new ResponseBase<List<PRODUCT>>()
            {
                Results = data,
                TotalRow = rowCount
            };
        }

        public ResponseBase<List<Product_GetList_By_Level1>> Product_GetList_By_Level1(Product_GetList_By_Level1_Parameter parameterObj)
        {
            int rowCount = 0;
            var datas = DataContext.GetListData_By_Stored<Product_GetList_By_Level1, Product_GetList_By_Level1_Parameter>(STORENAME.PRODUCT_GetList_By_Level1, parameterObj, ref rowCount);
            return new ResponseBase<List<Product_GetList_By_Level1>>()
            {
                Results = datas,
                TotalRow = rowCount
            };
        }

        public ResponseBase<List<Product_GetList_By_Level2>> Product_GetList_By_Level2(Product_GetList_By_Level2_Parameter parameterObj)
        {
            int rowCount = 0;
            var datas = DataContext.GetListData_By_Stored<Product_GetList_By_Level2, Product_GetList_By_Level2_Parameter>(STORENAME.PRODUCT_GetList_By_Level2, parameterObj, ref rowCount);
            return new ResponseBase<List<Product_GetList_By_Level2>>()
            {
                Results = datas,
                TotalRow = rowCount
            };
        }

        public ResponseBase<List<Product_GetList_Level2_By_Level1>> Product_GetList_Level2_By_Level1(Product_GetList_Level2_By_Level1_Parameter parameterObj)
        {
            int rowCount = 0;
            var datas = DataContext.GetListData_By_Stored<Product_GetList_Level2_By_Level1, Product_GetList_Level2_By_Level1_Parameter>(STORENAME.PRODUCT_GetList_Level2_By_Level1, parameterObj, ref rowCount);
            return new ResponseBase<List<Product_GetList_Level2_By_Level1>>()
            {
                Results = datas,
                TotalRow = rowCount
            };
        }


        public int Update_Product(Product_Update_Parameter parameter)
        {
            var data = this.Update_ByStore<Product_Update_Parameter>(parameter,STORENAME.PRODUCT_Update);
            return data;
        }
    }
}




