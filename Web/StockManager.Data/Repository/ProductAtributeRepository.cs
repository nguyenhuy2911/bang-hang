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
    public interface IProductAtributeRepository : IRepositoryBase<ProductAttribute>
    {
        ResponseBase<List<ProductAttribute_Type>> Get_ProductAttribute_Types();
    }
    public class ProductAtributeRepository : RepositoryBase<ProductAttribute>, IProductAtributeRepository
    {
        private IDbSet<ProductAttribute> dbset;
        public ProductAtributeRepository(IDataBaseFactory dataBaseFactory) : base(dataBaseFactory)
        {
            dbset = DataContext.Set<ProductAttribute>();
        }

        public ResponseBase<List<ProductAttribute_Type>> Get_ProductAttribute_Types()
        {
            var data = dbset.GroupBy(x => new { x.Type, x.TypeName })
                            .Select(o => new ProductAttribute_Type { Type = o.Key.Type, TypeName = o.Key.TypeName })
                            .ToList();
            return new ResponseBase<List<ProductAttribute_Type>>()
            {
                Results = data,
                TotalRow = 0
            };
        }
    }
}




