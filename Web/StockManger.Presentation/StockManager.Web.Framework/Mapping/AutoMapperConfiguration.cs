using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManager.Web.Framework.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                var profileTypes = typeof(DomainToServiceMappingProfile).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(DomainToServiceMappingProfile)));
                foreach (var type in profileTypes)
                {
                    x.AddProfile((DomainToServiceMappingProfile)Activator.CreateInstance(type));
                }              
                x.AddProfile<ServiceToDomainMappingProfile>();
            });
        }
    }
}