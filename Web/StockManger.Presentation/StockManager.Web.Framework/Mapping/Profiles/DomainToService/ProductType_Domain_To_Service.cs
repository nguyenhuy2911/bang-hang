using StockManager.Data.Model.Data;
using StockManager.Entity;
using StockManager.Entity.Service.Contract;
using System.Collections.Generic;

namespace StockManager.Web.Framework.Mapping.Profiles.DomainToService
{
    public class ProductType_Domain_To_Service : DomainToServiceMappingProfile
    {
        public ProductType_Domain_To_Service()
        {
            CreateMap<ResponseBase<List<Product_Type>>, GetProductTypes_Response>();
            CreateMap<Product_Type, GetProductTypes_DTO>();
            CreateMap<ResponseBase<ProductType_Attribute>, GetProductType_By_Id_Response>();
            CreateMap<ProductType_Attribute, GetProductType_By_Id_DTO>();
        }
    }
}
