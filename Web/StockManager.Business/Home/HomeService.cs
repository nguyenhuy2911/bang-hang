using Common;
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
using System.Linq;
namespace StockManager.Business
{
    public interface IHomeService
    {
        Get_OnlineItem_GetList_Response GetItems(Get_OnlineItem_GetList_Request request);
    }
    public class HomeService : IHomeService
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IProductRepository _IProductRepository;
        private readonly IProduct_ProductAttribute_MappingRepository _IProduct_ProductAttribute_MappingRepository;

        public HomeService(IProductRepository productRepository, IProduct_ProductAttribute_MappingRepository product_ProductAttribute_MappingRepository, IUnitOfWork unitOfWork)
        {
            this._IProductRepository = productRepository;
            this._IUnitOfWork = unitOfWork;
            this._IProduct_ProductAttribute_MappingRepository = product_ProductAttribute_MappingRepository;
        }
               
        public Get_OnlineItem_GetList_Response GetItems(Get_OnlineItem_GetList_Request request)
        {
            var param = Mapper.Map<Get_OnlineItem_GetList_Request, OnlineItem_GetList_Parameter>(request);
            param.Offset = request.Page.Skip;
            param.Next = request.Page.PageSize;
            var products = _IProductRepository.Get_OnlineItem_GetList(param);
            var retData = Mapper.Map<ResponseBase<List<OnlineItem_GetList>>, Get_OnlineItem_GetList_Response>(products);
            if (retData != null && retData.Results != null)
                retData.StatusCode = (int)RESULT_STATUS_CODE.SUCCESS;
            else
                retData.StatusCode = (int)RESULT_STATUS_CODE.NODATA;
            return retData;
        }
    }
}
