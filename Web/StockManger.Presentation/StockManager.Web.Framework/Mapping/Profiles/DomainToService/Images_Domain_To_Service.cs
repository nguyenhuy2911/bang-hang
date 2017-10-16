using StockManager.Data.Model.Data;
using StockManager.Entity;
using StockManager.Entity.Service.Contract;
using System.Collections.Generic;

namespace StockManager.Web.Framework.Mapping.Profiles.DomainToService
{
    public class Images_Domain_To_Service : DomainToServiceMappingProfile
    {
        public Images_Domain_To_Service()
        {           
            CreateMap<ResponseBase<List<Images>>, Get_Images_By_RelateId_Response>();
            CreateMap<Images, Images_DTO>();
        }
    }
}
