using System;

namespace StockManager.Entity.Service.Contract
{
    public class Unit_DTO
    {
        public string Unit_ID { get; set; }
        public string Unit_Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
