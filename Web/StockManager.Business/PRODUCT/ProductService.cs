﻿
using AutoMapper;
using StockManager.Data.Infrastructure;
using StockManager.Data.Repository;
using StockManager.Entity;
using StockManager.Entity.Service.Contract;
using System;
using System.Collections.Generic;
using Common.Enum;
using StockManager.Data.Model.Data;
using System.Linq.Expressions;
using Common;
using System.Linq;
namespace StockManager.Business
{
    public interface IProductService
    {
        Get_Products_Response GetProducts(GetProducts_Request request);
        Get_Product_Groups_Response Get_Product_Groups(Get_Product_Groups_Request request);
        Get_Product_By_Id_Response Get_Product_ById(int id);
        Get_Products_Response Get_Products_By_GroupId(Get_Products_By_GroupId_Request request);
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
                var product = Mapper.Map<CRUD_Product_Request, PRODUCT>(request);
                this._IProductRepository.Add(product);
                int saveStatus = this._IUnitOfWork.Commit();
                if (request.Product_Group_ID == 0)
                    product.Product_Group_ID = product.Product_ID;

                this._IProductRepository.Update(product);
                saveStatus = this._IUnitOfWork.Commit();
                var data = Mapper.Map<PRODUCT, Product_DTO>(product);
                if (saveStatus > 0)
                {
                    response.StatusCode = (int)RESULT_STATUS_CODE.SUCCESS;
                    response.Results = data;
                }

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
                var product = this._IProductRepository.GetById(request.Product_ID)?.Results;
                if (product != null)
                {
                    if (request.Product_Group_ID == 0)
                        request.Product_Group_ID = product.Product_Group_ID;
                    if (request.Unit_ID == "")
                        request.Unit_ID = product.Unit_ID;
                }
                

                var productParam = Mapper.Map<CRUD_Product_Request, Product_Update_Parameter>(request);
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
            var products = _IProductRepository.Get_Products(request.Page);

            var retData = Mapper.Map<ResponseBase<List<PRODUCT>>, Get_Products_Response>(products);
            if (retData != null && retData.Results != null)
                retData.StatusCode = (int)RESULT_STATUS_CODE.SUCCESS;
            else
                retData.StatusCode = (int)RESULT_STATUS_CODE.NODATA;
            return retData;
        }

        public Get_Product_Groups_Response Get_Product_Groups(Get_Product_Groups_Request request)
        {
            var productParam = Mapper.Map<Get_Product_Groups_Request, Product_Group_GetList_Parameter>(request);
            productParam.Offset = request.Page.Skip;
            productParam.Next = request.Page.PageSize;
            var products = _IProductRepository.Get_Product_Groups(productParam);
            var retData = Mapper.Map<ResponseBase<List<PRODUCT_GROUP>>, Get_Product_Groups_Response>(products);
            if (retData != null && retData.Results != null)
                retData.StatusCode = (int)RESULT_STATUS_CODE.SUCCESS;
            else
                retData.StatusCode = (int)RESULT_STATUS_CODE.NODATA;
            return retData;
        }

        public Get_Products_Response Get_Products_By_GroupId(Get_Products_By_GroupId_Request request)
        {

            // var _params = Mapper.Map<Get_Products_By_GroupId_Request, Product_Get_By_Product_Group_ID_Parameter>(request);
            // param.Offset = request.Page.Skip;
            // param.Next = request.Page.PageSize;
            //var data = _IProductRepository.Get_Products_By_GroupId(_params);
            Expression<Func<PRODUCT, bool>> condition = c => true;
            if (!string.IsNullOrEmpty(request.Product_Group_ID.ToString()))
                condition = condition.And(c => c.Product_Group_ID == request.Product_Group_ID);
            if (request.Publish == (int)ACTIVE.ACTIVE)
                condition = condition.And(c => c.Publish == true);
            if (request.Publish == (int)ACTIVE.UNACTIVE)
                condition = condition.And(c => c.Publish == false);

            var data = _IProductRepository.GetPage(request.Page, condition, o => o.Product_ID, false);
            var retData = Mapper.Map<ResponseBase<List<PRODUCT>>, Get_Products_Response>(data);


            if (retData != null && retData.Results != null)
            {
                retData.StatusCode = (int)RESULT_STATUS_CODE.SUCCESS;
                retData.Results.ForEach(x => {
                    x.ProductAttributes = x.Product_ProductAttribute_Mapping.Select(o => o.ProductAttribute).ToList();
                });
            }
            else
                retData.StatusCode = (int)RESULT_STATUS_CODE.NODATA;
            return retData;
        }

    }
}
