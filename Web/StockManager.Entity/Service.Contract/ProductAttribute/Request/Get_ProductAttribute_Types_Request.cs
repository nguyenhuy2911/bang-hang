namespace StockManager.Entity.Service.Contract
{
    public class Get_ProductAttribute_Types_Request : RequestBase
    {
        public Get_ProductAttribute_Types_Request()
        {
            Page = new Page();
        }
        public Page Page { get; set; }
    }
}
