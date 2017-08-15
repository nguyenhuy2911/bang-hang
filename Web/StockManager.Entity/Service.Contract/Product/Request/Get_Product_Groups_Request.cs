namespace StockManager.Entity.Service.Contract
{
    public class Get_Product_Groups_Request : RequestBase
    {
        public Get_Product_Groups_Request()
        {
            Page = new Page();
        }
        public Page Page { get; set; }
    }
}
