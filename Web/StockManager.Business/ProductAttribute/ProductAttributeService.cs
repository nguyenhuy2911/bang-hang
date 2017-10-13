
using AutoMapper;
using StockManager.Data.Infrastructure;
using StockManager.Data.Repository;
using StockManager.Entity;
using StockManager.Entity.Service.Contract;
using System;
using System.Collections.Generic;
using Common.Enum;
using StockManager.Entity.DataAccess;

namespace StockManager.Business
{
    public interface IProductAttributeService
    {
        Get_ProductAttribute_Types_Response Get_ProductAttribute_Types(Get_ProductAttribute_Types_Request request);
        Get_ProductAttributes_Response Get_ProductAttributes(Get_ProductAttributes_Resquest request);
    }
    public class ProductAttributeService : IProductAttributeService
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IProductAtributeRepository _IProductAtributeRepository;

        public ProductAttributeService( IUnitOfWork unitOfWork , IProductAtributeRepository productAtributeRepository)
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
    }
}
