﻿using StockManager.Entity;
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
    public class ProductAttribute_Domain_To_Service : DomainToServiceMappingProfile
    {
        public ProductAttribute_Domain_To_Service()
        {           
            CreateMap<ResponseBase<List<ProductAttribute>>, Get_ProductAttribute_Types_Response>();
            CreateMap<ProductAttribute_Type, Get_ProductAttribute_Types_DTO>();
        }
    }
}