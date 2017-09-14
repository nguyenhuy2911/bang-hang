using AutoMapper;
using StockManager.Entity;
using StockManager.Entity.DataAccess;
using StockManager.Entity.Service.Contract;
using System.Collections.Generic;

namespace StockManager.Web.Framework.Mapping
{
    public abstract class DomainToServiceMappingProfile : Profile
    {
        private readonly string _profileName;
        public override string ProfileName
        {
            get
            {
                return _profileName;
            }
        }
        protected DomainToServiceMappingProfile()
        {
            _profileName = "DomainToServiceMappingProfile";
        }

        
    }
}