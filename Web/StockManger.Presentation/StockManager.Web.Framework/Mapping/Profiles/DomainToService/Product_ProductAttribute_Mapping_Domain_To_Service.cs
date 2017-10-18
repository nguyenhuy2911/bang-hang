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
    public class Product_ProductAttribute_Mapping_Domain_To_Service : DomainToServiceMappingProfile
    {
        public Product_ProductAttribute_Mapping_Domain_To_Service()
        {           
            CreateMap<ResponseBase<List<Product_ProductAttribute_Mapping>>, Get_ProductAttributes_By_ProductId_Response>();
            CreateMap<Product_ProductAttribute_Mapping, Get_ProductAttributes_By_ProductId>();
            CreateMap<Product_ProductAttribute_Mapping, Product_ProductAttribute_Mapping_DTO>();
        }
    }
}
