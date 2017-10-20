namespace StockManager.Entity.Service.Contract
{
    public class Get_OnlineItem_GetList_Request : RequestBase
    {
        public Get_OnlineItem_GetList_Request()
        {
            Page = new Page();
        }
        public Page Page { get; set; }

        public int Publish { get; set; }

    }
}
