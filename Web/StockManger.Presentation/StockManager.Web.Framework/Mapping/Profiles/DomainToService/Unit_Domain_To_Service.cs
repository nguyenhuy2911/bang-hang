using StockManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StockManager.Entity.Service.Contract;
using StockManager.Data.Model.Data;

namespace StockManager.Web.Framework.Mapping.Profiles.DomainToService
{
    public class Unit_Domain_To_Service : DomainToServiceMappingProfile
    {
        public Unit_Domain_To_Service()
        {
            CreateMap<ResponseBase<List<UNIT>>, Get_Unit_Response>();
            CreateMap<UNIT, Get_Unit_DTO>();
        }
    }
}
