namespace StockManager.Entity.Service.Contract
{
    public class Product_GetList_By_Level1_Request : RequestBase
    {
        public Product_GetList_By_Level1_Request()
        {
            Page = new Page();
        }
        public Page Page { get; set; }
    }
}
