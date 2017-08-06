using AutoMapper;
using StockManager.Entity;
using StockManager.Entity.Service.Contract;
using System.Collections.Generic;

namespace StockManager.Web.Mapping
{
    public class ServiceToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ServiceToDomainMappingProfile";
            }
        }

        public ServiceToDomainMappingProfile()
        {
            CreateMap<CRUD_Product_Request, PRODUCT>();
            
        }
    }
}