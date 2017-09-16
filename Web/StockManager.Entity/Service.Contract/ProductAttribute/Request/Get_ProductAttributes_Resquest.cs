namespace StockManager.Entity.Service.Contract
{
    public class Get_ProductAttributes_Resquest : RequestBase
    {
        public Get_ProductAttributes_Resquest()
        {
            Page = new Page();
        }
        public Page Page { get; set; }
    }
}
