namespace StockManager.Entity.Service.Contract
{
    public class Product_GetList_By_Level2_Request : RequestBase
    {
        public Product_GetList_By_Level2_Request()
        {
            Page = new Page();
        }
        public Page Page { get; set; }
    }
}
