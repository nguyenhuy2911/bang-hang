using AutoMapper;
using Common.Enum;
using StockManager.Data.Infrastructure;
using StockManager.Data.Repository;
using StockManager.Entity;
using StockManager.Entity.DataAccess;
using StockManager.Entity.Service.Contract;
using System.Collections.Generic;

namespace StockManager.Business
{
    public interface IProductType_Service
    {
        GetProductTypes_Response GetAllProductType();
        GetProductType_By_Id_Response GetProductType_By_Id(int id);
        ProductType_Attribute_Get_By_ProductType_Id_Response Get_ProductType_Attribute_By_ProductType_Id(ProductType_Attribute_Get_By_ProductType_Id_Request request);
    }
    public class ProductType_Service : IProductType_Service
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IProductTypeRepository _IProductTypeRepository;
        private readonly IProductType_AttributeRepository _IProductType_AttributeRepository;

        public ProductType_Service(IUnitOfWork unitOfWork, IProductTypeRepository productTypeRepository, IProductType_AttributeRepository productType_AttributeRepository)
        {
            this._IUnitOfWork = unitOfWork;
            this._IProductType_AttributeRepository = productType_AttributeRepository;
            this._IProductTypeRepository = productTypeRepository;
        }

        public GetProductType_By_Id_Response GetProductType_By_Id(int id)
        {
            var data = _IProductType_AttributeRepository.GetById(id);
            var retData = Mapper.Map<ResponseBase<ProductType_Attribute>, GetProductType_By_Id_Response>(data);
            return retData;
        }

        public GetProductTypes_Response GetAllProductType()
        {
            var data = _IProductTypeRepository.GetAll();
            var retData = Mapper.Map<ResponseBase<List<Product_Type>>, GetProductTypes_Response>(data);
            return retData;
        }
        public ProductType_Attribute_Get_By_ProductType_Id_Response Get_ProductType_Attribute_By_ProductType_Id(ProductType_Attribute_Get_By_ProductType_Id_Request request)
        {
            var param = Mapper.Map<ProductType_Attribute_Get_By_ProductType_Id_Request, ProductType_Attribute_Get_By_ProductType_Id_Parameter>(request);
           
            var datas = _IProductType_AttributeRepository.ProductType_Attribute_Get_By_ProductType_Id(param);
            var retData = Mapper.Map<ResponseBase<List<ProductType_Attribute_Get_By_ProductType_Id>>, ProductType_Attribute_Get_By_ProductType_Id_Response>(datas);
            if (retData != null && retData.Results != null)
                retData.StatusCode = (int)RESULT_STATUS_CODE.SUCCESS;
            else
                retData.StatusCode = (int)RESULT_STATUS_CODE.NODATA;
            return retData;
        }

    }
}
