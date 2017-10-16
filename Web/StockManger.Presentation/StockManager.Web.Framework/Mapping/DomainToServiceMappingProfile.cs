using AutoMapper;

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