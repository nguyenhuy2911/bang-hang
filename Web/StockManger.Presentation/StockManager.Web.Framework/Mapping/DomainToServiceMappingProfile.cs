using AutoMapper;
using StockManager.Entity;
using StockManager.Entity.DataAccess;
using StockManager.Entity.Service.Contract;
using System.Collections.Generic;

namespace StockManager.Web.Framework.Mapping
{
    public class DomainToServiceMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToServiceMappingProfile";
            }
        }

        public DomainToServiceMappingProfile()
        {
            CreateMap<ResponseBase<List<PRODUCT>>, Get_Products_Response>();
            CreateMap<ResponseBase<List<PRODUCT>>, Get_Product_Groups_Response>();
            CreateMap<ResponseBase<PRODUCT>, Get_Product_By_Id_Response>();
            CreateMap<PRODUCT, Get_Products_DTO_Maper>();
            CreateMap<ResponseBase<List<UNIT>>, Get_Unit_Response>();
            CreateMap<UNIT, Get_Unit_DTO>();
            CreateMap<ResponseBase<List<PRODUCT_GROUP>>, Get_Product_Groups_Response>();
            CreateMap<PRODUCT_GROUP, Get_Product_Groups_DTO>();
            CreateMap<ResponseBase<List< StockManager.Entity.DataAccess.Images>>, Get_Images_By_RelateId_Response>();
            CreateMap<StockManager.Entity.DataAccess.Images, Images_DTO>();
        }
    }
}