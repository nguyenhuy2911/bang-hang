
namespace StockManager.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
