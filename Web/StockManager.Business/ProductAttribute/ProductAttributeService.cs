
using AutoMapper;
using StockManager.Data.Infrastructure;
using StockManager.Data.Repository;
using StockManager.Entity;
using StockManager.Entity.Service.Contract;
using System;
using System.Collections.Generic;
using Common.Enum;
using StockManager.Data.Model.Data;

namespace StockManager.Business
{
    public interface IProductAttributeService
    {
        Get_ProductAttribute_Types_Response Get_ProductAttribute_Types(Get_ProductAttribute_Types_Request request);
        Get_ProductAttributes_Response Get_ProductAttributes(Get_ProductAttributes_Resquest request);
        Get_ProductAttributes_By_ProductId_Response Get_ProductAttributes_By_ProductId(int product_Id);
    }
    public class ProductAttributeService : IProductAttributeService
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IProductAtributeRepository _IProductAtributeRepository;

        public ProductAttributeService(IUnitOfWork unitOfWork, IProductAtributeRepository productAtributeRepository)
        {
            this._IUnitOfWork = unitOfWork;
            this._IProductAtributeRepository = productAtributeRepository;
        }

        public Get_ProductAttribute_Types_Response Get_ProductAttribute_Types(Get_ProductAttribute_Types_Request request)
        {
            var data = _IProductAtributeRepository.Get_ProductAttribute_Types();
            var retData = Mapper.Map<ResponseBase<List<ProductAttribute_Type>>, Get_ProductAttribute_Types_Response>(data);
            return retData;
        }

        public Get_ProductAttributes_Response Get_ProductAttributes(Get_ProductAttributes_Resquest request)
        {
            var data = _IProductAtributeRepository.GetAll();
            var retData = Mapper.Map<ResponseBase<List<ProductAttribute>>, Get_ProductAttributes_Response>(data);
            return retData;
        }

        public Get_ProductAttributes_By_ProductId_Response Get_ProductAttributes_By_ProductId(int product_Id)
        {
          
            var data = _IProductAtributeRepository.Get_Product_Attribute_By_ProductId(product_Id);
            var retdata = Mapper.Map<ResponseBase<List<Product_ProductAttribute_Mapping>>, Get_ProductAttributes_By_ProductId_Response>(data);
            return retdata;
        }
    }
}
