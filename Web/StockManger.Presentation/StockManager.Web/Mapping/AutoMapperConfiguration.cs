using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManager.Web.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToServiceMappingProfile>();
                x.AddProfile<ServiceToDomainMappingProfile>();
            });
        }
    }
}