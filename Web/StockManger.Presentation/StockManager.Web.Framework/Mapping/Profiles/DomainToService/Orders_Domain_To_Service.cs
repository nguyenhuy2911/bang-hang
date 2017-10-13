using StockManager.Entity;
using StockManager.Entity.DataAccess;
using StockManager.Entity.Service.Contract;
using System.Collections.Generic;

namespace StockManager.Web.Framework.Mapping.Profiles.DomainToService
{
    public class Orders_Domain_To_Service : DomainToServiceMappingProfile
    {
        public Orders_Domain_To_Service()
        {           
            CreateMap<ResponseBase<List<Order>>, Get_Orders_Response>();
            CreateMap<Order, Order_DTO>();
        }
    }
}
