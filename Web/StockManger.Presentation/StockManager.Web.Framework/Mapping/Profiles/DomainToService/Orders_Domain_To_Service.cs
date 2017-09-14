using StockManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StockManager.Entity.Service.Contract;
using StockManager.Entity.DataAccess;

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
