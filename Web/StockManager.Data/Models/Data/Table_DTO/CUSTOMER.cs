using System;
using System.Collections.Generic;

namespace StockManager.Data.Model.Data
{
    public partial class CUSTOMER
    {
        public string Customer_ID { get; set; }
        public Nullable<long> OrderID { get; set; }
        public string CustomerName { get; set; }
        public string Customer_Type_ID { get; set; }
        public string Customer_Group_ID { get; set; }
        public string CustomerAddress { get; set; }
        public string Birthday { get; set; }
        public string Barcode { get; set; }
        public string Tax { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Website { get; set; }
        public string Contact { get; set; }
        public string Position { get; set; }
        public string NickYM { get; set; }
        public string NickSky { get; set; }
        public string Area { get; set; }
        public string District { get; set; }
        public string Contry { get; set; }
        public string City { get; set; }
        public string BankAccount { get; set; }
        public string BankName { get; set; }
        public Nullable<decimal> CreditLimit { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<bool> IsDebt { get; set; }
        public Nullable<bool> IsDebtDetail { get; set; }
        public Nullable<bool> IsProvider { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
