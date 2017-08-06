namespace StockManager.Entity.Service.Contract
{
    public class Get_Unit_Request : RequestBase
    {
        public Get_Unit_Request()
        {
            Page = new Page();
            Active = -1;
        }
        public Page Page { get; set; }
        public string Unit_Name { get; set; }
        public int Active { get; set; }
    }
}
