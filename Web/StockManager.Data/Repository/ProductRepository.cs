using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using StockManager.Entity;
using StockManager.Data.Infrastructure;
using System.Data.Entity;
using Common;
using StockManager.Data.StoreProcedure;
using System.Data.SqlClient;
using System.Data;


namespace StockManager.Data.Repository
{
    public interface IProductRepository : IRepositoryBase<PRODUCT>
    {
        ResponseBase<List<PRODUCT_GROUP>> Get_Product_Groups();
    }
    public class ProductRepository : RepositoryBase<PRODUCT>, IProductRepository
    {
        private IDbSet<PRODUCT> dbset;
        public ProductRepository(IDataBaseFactory dataBaseFactory) : base(dataBaseFactory)
        {
            dbset = DataContext.Set<PRODUCT>();
        }

        public ResponseBase<List<PRODUCT_GROUP>> Get_Product_Groups()
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




