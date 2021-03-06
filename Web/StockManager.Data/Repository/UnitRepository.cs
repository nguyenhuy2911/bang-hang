﻿using StockManager.Data.Infrastructure;
using StockManager.Data.Model.Data;
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
