
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
    public interface IOrderService
    {
        Get_Orders_Response GetOrders(Get_Orders_Request request);
        //Get_Product_By_Id_Response Get_Order_ById(int id);
        //CRUD_Product_Response UpdateOrder(CRUD_Product_Request request);
        //CRUD_Product_Response CreateOrder(CRUD_Product_Request request);
        //ResponseBase<int> DeleteOrder(int id);
    }
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IOrderRepository _IOrderRepository;

        public OrderService( IUnitOfWork unitOfWork ,IOrderRepository orderRepository)
        {           
            this._IUnitOfWork = unitOfWork;
            this._IOrderRepository = orderRepository;
        }

        public Get_Orders_Response GetOrders(Get_Orders_Request request)
        {
            var data = _IOrderRepository.GetPage(request.Page, w => true, x => x.Id);
            var retData = Mapper.Map<ResponseBase<List<Order>>, Get_Orders_Response>(data);
            return retData;
        }
    }
}
