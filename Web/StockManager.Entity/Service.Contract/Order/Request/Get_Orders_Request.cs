namespace StockManager.Entity.Service.Contract
{
    public class Get_Orders_Request : RequestBase
    {
        public Get_Orders_Request()
        {
            Page = new Page();
        }
        public Page Page { get; set; }
    }
}
