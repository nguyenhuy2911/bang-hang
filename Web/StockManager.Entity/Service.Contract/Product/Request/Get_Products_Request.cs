namespace StockManager.Entity.Service.Contract
{
    public class GetProducts_Request : RequestBase
    {
        public GetProducts_Request()
        {
            Page = new Page();
        }
        public Page Page { get; set; }
    }
}
