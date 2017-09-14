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
    public class Images_Domain_To_Service : DomainToServiceMappingProfile
    {
        public Images_Domain_To_Service()
        {           
            CreateMap<ResponseBase<List<StockManager.Entity.DataAccess.Images>>, Get_Images_By_RelateId_Response>();
            CreateMap<StockManager.Entity.DataAccess.Images, Images_DTO>();
        }
    }
}
