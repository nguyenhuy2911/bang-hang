using AutoMapper;
using StockManager.Entity;
using StockManager.Entity.Service.Contract;
using System.Collections.Generic;

namespace StockManager.Web.Mapping
{
    public class ServiceToWebMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ServiceToWebMappingProfile";
            }
        }

        public ServiceToWebMappingProfile()
        {
            CreateMap<ResponseBase<List<PRODUCT>>, GetProducts_Response>();
            CreateMap<PRODUCT, GetProducts_DTO_Maper>();
        }
    }
}