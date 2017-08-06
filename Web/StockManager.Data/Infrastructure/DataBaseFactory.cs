using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Data.Infrastructure
{
    public interface IDataBaseFactory : IDisposable
    {
        StockManagerContext Get();
    }
    public class DataBaseFactory : Disposable, IDataBaseFactory
    {
        private StockManagerContext dataContext;
        public StockManagerContext Get()
        {
            return dataContext ?? (dataContext = new StockManagerContext());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
            
        }
    }
}
