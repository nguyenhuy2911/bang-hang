

namespace StockManager.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataBaseFactory databaseFactory;
        private StockManagerContext dataContext;

        public UnitOfWork(IDataBaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected StockManagerContext DataContext
        {
            get { return dataContext ?? (dataContext = databaseFactory.Get()); }
        }

        public int Commit()
        {
            return DataContext.Commit();
        }
    }
}
