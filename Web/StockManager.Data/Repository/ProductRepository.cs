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
        ResponseBase<List<PRODUCT_GROUP>> Get_Product_Groups(Page pager, Expression<Func<PRODUCT, bool>> where = null, Expression<Func<PRODUCT, object>> order = null, bool ascending = false);
    }
    public class ProductRepository : RepositoryBase<PRODUCT>, IProductRepository
    {
        private IDbSet<PRODUCT> dbset;
        public ProductRepository(IDataBaseFactory dataBaseFactory) : base(dataBaseFactory)
        {
            dbset = DataContext.Set<PRODUCT>();
        }

        public ResponseBase<List<PRODUCT_GROUP>> Get_Product_Groups(Page pager, Expression<Func<PRODUCT, bool>> where = null, Expression<Func<PRODUCT, object>> order = null, bool ascending = false)
        {            
            var data = DataContext.GetListData_By_Stored<PRODUCT_GROUP>(STORENAME.PRODUCT_GROUP_GetList).ToList();
            return new ResponseBase<List<PRODUCT_GROUP>>()
            {
                Results = data,
                TotalRow = 0
            };
        }
    }
}




