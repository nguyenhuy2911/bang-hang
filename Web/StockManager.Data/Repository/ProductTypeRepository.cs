using StockManager.Data.Infrastructure;
using StockManager.Entity.DataAccess;
namespace StockManager.Data.Repository
{
    public interface IProductTypeRepository : IRepositoryBase<Product_Type>
    {

    }
    public class ProductTypeRepository : RepositoryBase<Product_Type>, IProductTypeRepository
    {
        public ProductTypeRepository(IDataBaseFactory dataBaseFactory) : base(dataBaseFactory)
        {
        }
    }
}
