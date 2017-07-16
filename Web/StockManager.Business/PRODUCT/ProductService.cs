
using AutoMapper;
using StockManager.Data.Repository;
using StockManager.Entity;
using StockManager.Entity.Service.Contract;
using System;
using System.Collections.Generic;

namespace StockManager.Business
{
    public interface IProductService
    {
        GetProducts_Response GetProducts(GetProducts_Request request);
        ResponseBase<PRODUCT> GetProduct(int id);
        ResponseBase<int> UpdateProduct(PRODUCT ProductToUpdate);
        ResponseBase<int> CreateProduct(PRODUCT Product);
        ResponseBase<int> DeleteProduct(int id);
    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository _IProductRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._IProductRepository = productRepository;
        }

        public ResponseBase<int> CreateProduct(PRODUCT Product)
        {
            throw new NotImplementedException();
        }

        public ResponseBase<int> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseBase<PRODUCT> GetProduct(int id)
        {
            throw new NotImplementedException();
        }
        public GetProducts_Response GetProducts(GetProducts_Request request)
        {           
            var response = _IProductRepository.GetAll(request.Page, x => x.Product_ID, false);
            var retData = Mapper.Map<ResponseBase<List<PRODUCT>>, GetProducts_Response>(response);           
            return retData;
        }

        public ResponseBase<int> UpdateProduct(PRODUCT ProductToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
