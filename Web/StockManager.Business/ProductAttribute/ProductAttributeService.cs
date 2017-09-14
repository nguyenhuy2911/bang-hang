
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
        Get_ProductAttribute_Types_Response Get_ProductAttribute_Types(Get_Orders_Request request);        
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

        public Get_ProductAttribute_Types_Response Get_ProductAttribute_Types(Get_Orders_Request request)
        {
            var data = _IProductAtributeRepository.Get_ProductAttribute_Types();
            var retData = Mapper.Map<ResponseBase<List<ProductAttribute_Type>>, Get_ProductAttribute_Types_Response>(data);
            return retData;
        }
    }
}
