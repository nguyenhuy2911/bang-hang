using AutoMapper;
using StockManager.Entity.DataAccess;
using StockManager.Entity.Service.Contract;

namespace StockManager.Web.Framework.Mapping
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
            CreateMap<CRUD_Image_Request, Images>();

        }
    }
}