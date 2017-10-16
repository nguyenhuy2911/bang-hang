namespace StockManager.Entity.Service.Contract
{
    public class Get_Products_By_GroupId_Request : RequestBase
    {
        public Get_Products_By_GroupId_Request()
        {
            Page = new Page();
        }
        public Page Page { get; set; }
        public int Product_Group_ID { get; set; }
        public int Publish { get; set; }
    }
}
