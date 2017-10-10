namespace StockManager.Entity.Service.Contract
{
    public class Product_GetList_Level2_By_Level1_Request : RequestBase
    {
        public Product_GetList_Level2_By_Level1_Request()
        {
            Page = new Page();
        }
        public Page Page { get; set; }
        public int Product_Level1_Id { get; set; }
    }
}
