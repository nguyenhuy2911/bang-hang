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
            CreateMap<CRUD_Product_Request, Product_Update_Parameter>();
            CreateMap<Get_Product_Groups_Request, Product_Group_GetList_Parameter>();
            CreateMap<CRUD_Image_Request, Images>();
            CreateMap<CRUD_Product_ProductAttribute_Mapping_Request, Product_ProductAttribute_Mapping>();
            CreateMap<Product_GetList_By_Level2_Request, Product_GetList_By_Level2_Parameter>();
            CreateMap<Product_GetList_By_Level1_Request, Product_GetList_By_Level1_Parameter>();
            CreateMap<Product_GetList_Level2_By_Level1_Request, Product_GetList_Level2_By_Level1_Parameter>();
            CreateMap<ProductType_Attribute_Get_By_ProductType_Id_Request, ProductType_Attribute_Get_By_ProductType_Id_Parameter>();
        }
    }
}