using AutoMapper;
using StockManager.Data.Model.Data;
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

            CreateMap<CRUD_Product_Request, Product_Update_Parameter>();

            CreateMap<Get_Product_Groups_Request, Product_Group_GetList_Parameter>();

            CreateMap<CRUD_Image_Request, Images>();

            CreateMap<CRUD_Product_ProductAttribute_Mapping_Request, Product_ProductAttribute_Mapping>();
            

            CreateMap<ProductType_Attribute_Get_By_ProductType_Id_Request, ProductType_Attribute_Get_By_ProductType_Id_Parameter>();

            CreateMap<Get_Products_By_GroupId_Request, Product_Get_By_Product_Group_ID_Parameter>();

            CreateMap<Get_OnlineItem_GetList_Request, OnlineItem_GetList_Parameter>();
        }
    }
}