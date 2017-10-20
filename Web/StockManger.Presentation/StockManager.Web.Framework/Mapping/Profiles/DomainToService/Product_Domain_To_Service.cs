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
    public class Product_Domain_To_Service : DomainToServiceMappingProfile
    {
        public Product_Domain_To_Service()
        {
            CreateMap<ResponseBase<List<PRODUCT>>, Get_Products_Response>();
            CreateMap<PRODUCT, Get_Products_DTO>();
            CreateMap<PRODUCT, Product_DTO>();
            
            CreateMap<ResponseBase<PRODUCT>, Get_Product_By_Id_Response>();

            CreateMap<ResponseBase<List<PRODUCT>>, Get_Products_By_GroupId_Response>();
            CreateMap<ResponseBase<List<PRODUCT_GROUP>>, Get_Product_Groups_Response>();
            CreateMap<PRODUCT_GROUP, Product_Group_DTO>();

            CreateMap<ResponseBase<List<Product_GetList_By_GroupId>>, Get_Products_By_GroupId_Response>();
            CreateMap<Product_GetList_By_GroupId, Get_Products_By_GroupId_DTO>();

            CreateMap<ResponseBase<List<OnlineItem_GetList>>, Get_OnlineItem_GetList_Response>();
            CreateMap<OnlineItem_GetList, OnlineItem_GetList_DTO>();
        }
    }
}
