using AutoMapper;
using Common;
using Common.Enum;
using StockManager.Data.Model.Data;
using StockManager.Data.Repository;
using StockManager.Entity;
using StockManager.Entity.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StockManager.Business
{
    public interface IUnitService
    {
        Get_Unit_Response GetUnits(Get_Unit_Request request);
    }
    public class UnitService : IUnitService
    {
        private readonly IUniRepository _IUniRepository;
        public UnitService(IUniRepository uniRepository)
        {
            this._IUniRepository = uniRepository;
        }

        public Get_Unit_Response GetUnits(Get_Unit_Request request)
        {
            var retData = new Get_Unit_Response();
            try
            {
                Expression<Func<UNIT, bool>> condition = c => true;
                if (!string.IsNullOrEmpty(request.Unit_Name))
                    condition = condition.And(c => c.Unit_Name.Equals(request.Unit_Name));
                if (request.Active == (int)ACTIVE.UNACTIVE)
                    condition = condition.And(c => c.Active.Equals(false));
                if (request.Active == (int)ACTIVE.ACTIVE)
                    condition = c => c.Active.Equals(true);

                var units = _IUniRepository.GetPage(request.Page, condition, o => o.Unit_Name);
                retData = Mapper.Map<ResponseBase<List<UNIT>>, Get_Unit_Response>(units);
                return retData;
            }
            catch (Exception ex)
            {
                retData = new Get_Unit_Response();
                return retData;
            }

        }
    }
}
