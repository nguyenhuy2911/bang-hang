
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
    public interface IProductService
    {
        Get_Products_Response GetProducts(GetProducts_Request request);
        Get_Product_Groups_Response Get_Product_Groups(Get_Product_Groups_Request request);
        Get_Product_By_Id_Response Get_Product_ById(int id);
        CRUD_Product_Response UpdateProduct(CRUD_Product_Request request);
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
            var response = new CRUD_Product_Response();
            try
            {
                var product = Mapper.Map<CRUD_Product_Request, PRODUCT>(request);
                this._IProductRepository.Add(product);
                int saveStatus = this._IUnitOfWork.Commit();
                if (request.Product_Group_ID.Equals(0))
                {
                    product.Product_Group_ID = product.Product_ID;
                    this._IProductRepository.Update(product);
                    saveStatus = this._IUnitOfWork.Commit();
                }

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

        public CRUD_Product_Response UpdateProduct(CRUD_Product_Request request)
        {
            var response = new CRUD_Product_Response();
            try
            {
                var product = Mapper.Map<CRUD_Product_Request, PRODUCT>(request);
                this._IProductRepository.Update(product);

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

        public ResponseBase<int> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Get_Product_By_Id_Response Get_Product_ById(int id)
        {
            var product = _IProductRepository.GetById(id);     
            var retData = Mapper.Map<ResponseBase<PRODUCT>, Get_Product_By_Id_Response>(product);
            return retData;
        }

        public Get_Products_Response GetProducts(GetProducts_Request request)
        {
            var products = _IProductRepository.GetPage(request.Page, w => true, x => x.Product_ID);
            var retData = Mapper.Map<ResponseBase<List<PRODUCT>>, Get_Products_Response>(products);
            return retData;
        }

        public Get_Product_Groups_Response Get_Product_Groups(Get_Product_Groups_Request request)
        {
            var products = _IProductRepository.Get_Product_Groups(request.Page);           
            var retData = Mapper.Map<ResponseBase<List<PRODUCT_GROUP>>, Get_Product_Groups_Response>(products);
            return retData;
        }


    }
}
