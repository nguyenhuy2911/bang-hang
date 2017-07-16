using System;
using System.Collections.Generic;

namespace StockManager.Entity
{
    public partial class EMPLOYEE
    {
        public string Employee_ID { get; set; }
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public string Employee_Name { get; set; }
        public string Alias { get; set; }
        public Nullable<bool> Sex { get; set; }
        public string Address { get; set; }
        public string Country_ID { get; set; }
        public string H_Tel { get; set; }
        public string O_Tel { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public Nullable<int> Married { get; set; }
        public string Position_ID { get; set; }
        public string JobTitle_ID { get; set; }
        public string Branch_ID { get; set; }
        public string Department_ID { get; set; }
        public string Team_ID { get; set; }
        public string PersonalTax_ID { get; set; }
        public string City_ID { get; set; }
        public string District_ID { get; set; }
        public string Manager_ID { get; set; }
        public Nullable<int> EmployeeType { get; set; }
        public Nullable<decimal> BasicSalary { get; set; }
        public Nullable<decimal> Advance { get; set; }
        public Nullable<decimal> AdvanceOther { get; set; }
        public Nullable<decimal> Commission { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> ProfitRate { get; set; }
        public Nullable<bool> IsPublic { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string OwnerID { get; set; }
        public string Description { get; set; }
        public Nullable<long> Sorted { get; set; }
        public bool Active { get; set; }
    }
}
