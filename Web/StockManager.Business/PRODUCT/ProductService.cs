
using AutoMapper;
using StockManager.Data.Infrastructure;
using StockManager.Data.Repository;
using StockManager.Entity;
using StockManager.Entity.Service.Contract;
using System;
using System.Collections.Generic;

namespace StockManager.Business
{
    public interface IProductService
    {
        Get_Products_Response GetProducts(GetProducts_Request request);
        ResponseBase<PRODUCT> GetProduct(int id);
        ResponseBase<int> UpdateProduct(PRODUCT ProductToUpdate);
        CRUD_Product_Response CreateProduct(CRUD_Product_Request request);
        ResponseBase<int> DeleteProduct(int id);
    }
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IProductRepository _IProductRepository;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this._IProductRepository = productRepository;
            this._IUnitOfWork = unitOfWork;
        }

        public CRUD_Product_Response CreateProduct(CRUD_Product_Request request)
        {
            var requestMap = Mapper.Map<CRUD_Product_Request, PRODUCT>(request);
            this._IProductRepository.Add(requestMap);
            this._IUnitOfWork.Commit();
            return new CRUD_Product_Response();
        }

        public ResponseBase<int> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseBase<PRODUCT> GetProduct(int id)
        {
            throw new NotImplementedException();
        }
        public Get_Products_Response GetProducts(GetProducts_Request request)
        {           
            var products = _IProductRepository.GetAll(request.Page, x => x.Product_ID, false);
            var retData = Mapper.Map<ResponseBase<List<PRODUCT>>, Get_Products_Response>(products);           
            return retData;
        }

        public ResponseBase<int> UpdateProduct(PRODUCT ProductToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
