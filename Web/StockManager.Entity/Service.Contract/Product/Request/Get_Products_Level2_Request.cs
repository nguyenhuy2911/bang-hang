namespace StockManager.Entity.Service.Contract
{
    public class Get_Products_Level2_Request : RequestBase
    {
        public Get_Products_Level2_Request()
        {
            Page = new Page();
        }
        public Page Page { get; set; }
    }
}
