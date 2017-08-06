using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using StockManager.Entity;
using StockManager.Data.Infrastructure;

namespace StockManager.Data.Repository
{
    public interface IProductRepository : IRepositoryBase<PRODUCT>
    {

    }
    public class ProductRepository : RepositoryBase<PRODUCT>, IProductRepository
    {
        public ProductRepository(IDataBaseFactory dataBaseFactory) : base(dataBaseFactory)
        {
        }
    }
}
