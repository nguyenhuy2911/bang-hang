
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
        Get_Products_Groups_Response Get_Product_Groups(Get_Product_Groups_Request request);
        Get_Product_By_Id_Response Get_Product_ById(int id);
        Get_Products_By_GroupId_Response Get_Products_By_GroupId(Get_Products_By_GroupId_Request request);
        Product_GetList_By_Level1_Response GetProducts_By_Level1(Product_GetList_By_Level1_Request request);
        Product_GetList_By_Level2_Response GetProducts_By_Level2(Product_GetList_By_Level2_Request request);
        Product_GetList_Level2_By_Level1_Response GetProducts_Level2_By_Level1(Product_GetList_Level2_By_Level1_Request request);
        CRUD_Product_Response UpdateProduct(CRUD_Product_Request request);
        CRUD_Product_Response CreateProduct(CRUD_Product_Request request);
        ResponseBase<int> DeleteProduct(int id);
    }
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IProductRepository _IProductRepository;
        private readonly IProduct_ProductAttribute_MappingRepository _IProduct_ProductAttribute_MappingRepository;

        public ProductService(IProductRepository productRepository, IProduct_ProductAttribute_MappingRepository product_ProductAttribute_MappingRepository, IUnitOfWork unitOfWork)
        {
            this._IProductRepository = productRepository;
            this._IUnitOfWork = unitOfWork;
            this._IProduct_ProductAttribute_MappingRepository = product_ProductAttribute_MappingRepository;
        }

        public CRUD_Product_Response CreateProduct(CRUD_Product_Request request)
        {
            var response = new CRUD_Product_Response();
            try
            {
                bool _checkupdate = false;
                var product = Mapper.Map<CRUD_Product_Request, PRODUCT>(request);
                this._IProductRepository.Add(product);
                int saveStatus = this._IUnitOfWork.Commit();
                if (request.Product_Level1.Equals(0))
                {
                    product.Product_Level1 = product.Product_ID;
                    _checkupdate = true;
                }
                if (request.Product_Level2.Equals(0))
                {
                    product.Product_Level2 = product.Product_Level1;
                    _checkupdate = true;
                }
                if (_checkupdate)
                {
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
                var productParam = Mapper.Map<CRUD_Product_Request, Product_Update_Parameter>(request);
                //this._IProductRepository.Update(productParam, request.Product_ID);
                var saveStatus = this._IProductRepository.Update_Product(productParam);
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
            if (retData != null && retData.Results != null)
                retData.StatusCode = (int)RESULT_STATUS_CODE.SUCCESS;
            else
                retData.StatusCode = (int)RESULT_STATUS_CODE.NODATA;
            return retData;
        }

        public Product_GetList_Level2_By_Level1_Response GetProducts_Level2_By_Level1(Product_GetList_Level2_By_Level1_Request request)
        {
            var param = Mapper.Map<Product_GetList_Level2_By_Level1_Request, Product_GetList_Level2_By_Level1_Parameter>(request);
            param.Offset = request.Page.Skip;
            param.Next = request.Page.PageSize;
            var datas = _IProductRepository.Product_GetList_Level2_By_Level1(param);
            var retData = Mapper.Map<ResponseBase<List<Product_GetList_Level2_By_Level1>>, Product_GetList_Level2_By_Level1_Response>(datas);
            if (retData != null && retData.Results != null)
                retData.StatusCode = (int)RESULT_STATUS_CODE.SUCCESS;
            else
                retData.StatusCode = (int)RESULT_STATUS_CODE.NODATA;
            return retData;
        }

        public Product_GetList_By_Level2_Response GetProducts_By_Level2(Product_GetList_By_Level2_Request request)
        {
            var param = Mapper.Map<Product_GetList_By_Level2_Request, Product_GetList_By_Level2_Parameter>(request);
            param.Offset = request.Page.Skip;
            param.Next = request.Page.PageSize;
            var datas = _IProductRepository.Product_GetList_By_Level2(param);
            var retData = Mapper.Map<ResponseBase<List<Product_GetList_By_Level2>>, Product_GetList_By_Level2_Response>(datas);
            if(retData != null && retData.Results != null)
                retData.StatusCode = (int)RESULT_STATUS_CODE.SUCCESS;
            else
                retData.StatusCode = (int)RESULT_STATUS_CODE.NODATA;
            return retData;
        }

        public Product_GetList_By_Level1_Response GetProducts_By_Level1(Product_GetList_By_Level1_Request request)
        {
            var param = Mapper.Map<Product_GetList_By_Level1_Request, Product_GetList_By_Level1_Parameter>(request);
            param.Offset = request.Page.Skip;
            param.Next = request.Page.PageSize;
            var datas = _IProductRepository.Product_GetList_By_Level1(param);
            var retData = Mapper.Map<ResponseBase<List<Product_GetList_By_Level1>>, Product_GetList_By_Level1_Response>(datas);
            return retData;
        }

        public Get_Products_Groups_Response Get_Product_Groups(Get_Product_Groups_Request request)
        {
            var productParam = Mapper.Map<Get_Product_Groups_Request, Product_Group_GetList_Parameter>(request);
            productParam.Offset = request.Page.Skip;
            productParam.Next = request.Page.PageSize;
            var products = _IProductRepository.Get_Product_Groups(productParam);
            var retData = Mapper.Map<ResponseBase<List<PRODUCT_GROUP>>, Get_Products_Groups_Response>(products);
            if (retData != null && retData.Results != null)
                retData.StatusCode = (int)RESULT_STATUS_CODE.SUCCESS;
            else
                retData.StatusCode = (int)RESULT_STATUS_CODE.NODATA;
            return retData;
        }

        public Get_Products_By_GroupId_Response Get_Products_By_GroupId(Get_Products_By_GroupId_Request request)
        {
            var _params = new Product_Get_By_Product_Group_ID_Parameter
            {
                Product_Group_ID = request.Product_Group_ID
            };
            var data = _IProductRepository.Get_Products_By_GroupId(_params);
            var retData = Mapper.Map<ResponseBase<List<PRODUCT>>, Get_Products_By_GroupId_Response>(data);
            if(retData != null && retData.Results != null)
                retData.StatusCode = (int)RESULT_STATUS_CODE.SUCCESS;
            else
                retData.StatusCode = (int)RESULT_STATUS_CODE.NODATA;
            return retData;
        }

    }
}
