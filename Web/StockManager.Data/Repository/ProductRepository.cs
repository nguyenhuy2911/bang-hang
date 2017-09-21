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

        public int Update_Product(Product_Update_Parameter parameter)
        {
            var data = this.Update_ByStore<Product_Update_Parameter>(parameter,STORENAME.PRODUCT_Update);
            return data;
        }
    }
}




