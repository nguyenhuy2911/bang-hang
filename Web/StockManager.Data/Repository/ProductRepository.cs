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

namespace StockManager.Data.Repository
{
    public interface IProductRepository : IRepositoryBase<PRODUCT>
    {
        ResponseBase<List<PRODUCT>> Get_Product_Groups(Page pager, Expression<Func<PRODUCT, bool>> where = null, Expression<Func<PRODUCT, object>> order = null, bool ascending = false);
    }
    public class ProductRepository : RepositoryBase<PRODUCT>, IProductRepository
    {
        private IDbSet<PRODUCT> dbset;
        public ProductRepository(IDataBaseFactory dataBaseFactory) : base(dataBaseFactory)
        {
            dbset = DataContext.Set<PRODUCT>();
        }

        public ResponseBase<List<PRODUCT>> Get_Product_Groups(Page pager, Expression<Func<PRODUCT, bool>> where = null, Expression<Func<PRODUCT, object>> order = null, bool ascending = false)
        {

            var query = dbset;
            if (where != null)
                query.Where(where);

            query.GroupBy(x => x.Product_Group_ID);
            var totalRow = where != null ? query.Count(where) : query.Count();

            if (order != null)
                query.SortBy(order, ascending);
            if (pager?.PageSize != 0 || pager?.PageNumber != 0)
                query.Take(pager.PageSize).Skip(pager.Skip);
            var result = query.ToList();

            return
                new ResponseBase<List<PRODUCT>>()
                {
                    Results = result,
                    TotalRow = totalRow
                };
        }

    }
}




