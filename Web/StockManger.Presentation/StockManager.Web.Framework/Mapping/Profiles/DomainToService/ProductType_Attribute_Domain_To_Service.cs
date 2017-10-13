using StockManager.Entity;
using StockManager.Entity.DataAccess;
using StockManager.Entity.Service.Contract;
using System.Collections.Generic;

namespace StockManager.Web.Framework.Mapping.Profiles.DomainToService
{
    public class ProductType_Attribute_Domain_To_Service: DomainToServiceMappingProfile
    {
        public ProductType_Attribute_Domain_To_Service()
        {
            CreateMap<ResponseBase<List<ProductType_Attribute_Get_By_ProductType_Id>>, ProductType_Attribute_Get_By_ProductType_Id_Response>();
            CreateMap<ProductType_Attribute_Get_By_ProductType_Id, ProductType_Attribute_Get_By_ProductType_Id_DTO>();
        }
        
    }
}
