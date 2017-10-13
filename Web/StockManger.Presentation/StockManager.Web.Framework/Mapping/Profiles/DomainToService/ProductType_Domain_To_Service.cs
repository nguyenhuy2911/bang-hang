using StockManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StockManager.Entity.Service.Contract;
using StockManager.Entity.DataAccess;

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
