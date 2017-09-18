
using AutoMapper;
using StockManager.Data.Infrastructure;
using StockManager.Data.Repository;
using StockManager.Entity;
using StockManager.Entity.Service.Contract;
using System;
using System.Collections.Generic;
using Common.Enum;
using StockManager.Entity.DataAccess;
using System.Linq;

namespace StockManager.Business
{
    public interface IProduct_ProductAttribute_MappingService
    {
        CRUD_Product_ProductAttribute_Mapping_Response CreateProduct_ProductAttribute_Mapping(CRUD_Product_ProductAttribute_Mapping_Request request);
    }
    public class Product_ProductAttribute_MappingService : IProduct_ProductAttribute_MappingService
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IProduct_ProductAttribute_MappingRepository _IProduct_ProductAttribute_MappingRepository;

        public Product_ProductAttribute_MappingService(IUnitOfWork unitOfWork, IProduct_ProductAttribute_MappingRepository product_ProductAttribute_MappingRepository)
        {
            this._IUnitOfWork = unitOfWork;
            this._IProduct_ProductAttribute_MappingRepository = product_ProductAttribute_MappingRepository;
        }

        public CRUD_Product_ProductAttribute_Mapping_Response CreateProduct_ProductAttribute_Mapping(CRUD_Product_ProductAttribute_Mapping_Request request)
        {
            var response = new CRUD_Product_ProductAttribute_Mapping_Response();
            try
            {
                var deleteDatas = _IProduct_ProductAttribute_MappingRepository.GetPage(new Page(), o => o.ProductId.Equals(request.ProductId) && request.Type.Equals(request.Type), o=>o.Id)?.Results;
                if (deleteDatas != null)
                {
                    deleteDatas.ForEach(x =>
                    {
                        _IProduct_ProductAttribute_MappingRepository.Delete(x.Id);
                    });                   
                }
                var createData = Mapper.Map<CRUD_Product_ProductAttribute_Mapping_Request, Product_ProductAttribute_Mapping>(request);
                _IProduct_ProductAttribute_MappingRepository.Add(createData);
                int saveStatus = this._IUnitOfWork.Commit();
                if (saveStatus > 0)
                    response.StatusCode = (int)RESULT_STATUS_CODE.SUCCESS;
                else
                    response.StatusCode = (int)RESULT_STATUS_CODE.DATABASE_ERROR;
            }
            catch (Exception ex)
            {

                response.StatusCode = (int)RESULT_STATUS_CODE.SYSTEM_ERROR;
                response.StatusMessage = ex.ToString();
            }
            return response;
        }
    }
}
