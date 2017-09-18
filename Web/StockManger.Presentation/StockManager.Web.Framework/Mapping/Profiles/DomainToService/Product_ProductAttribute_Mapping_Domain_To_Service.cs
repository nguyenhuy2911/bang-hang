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
    public class Product_ProductAttribute_Mapping_DTO_Domain_To_Service : DomainToServiceMappingProfile
    {
        public Product_ProductAttribute_Mapping_DTO_Domain_To_Service()
        {
            CreateMap<List<Product_ProductAttribute_Mapping>, List<Product_ProductAttribute_Mapping_DTO>>();
            CreateMap<Product_ProductAttribute_Mapping, Product_ProductAttribute_Mapping_DTO>();
        }
    }
}
