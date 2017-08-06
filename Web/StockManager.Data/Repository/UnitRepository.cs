using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManager.Entity;
using System.Linq.Expressions;
using StockManager.Data.Infrastructure;

namespace StockManager.Data.Repository
{
    public interface IUniRepository : IRepositoryBase<UNIT>
    {
        
    }
    public class UnitRepository : RepositoryBase<UNIT>, IUniRepository
    {
        public UnitRepository(IDataBaseFactory dataBaseFactory) : base(dataBaseFactory)
        {
        }

        
    }
}
