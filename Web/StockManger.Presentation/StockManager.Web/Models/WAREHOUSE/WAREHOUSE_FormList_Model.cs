namespace StockManager.Web.Models
{
    public class WAREHOUSE_FormList_Model : BaseModel
    {
        public WAREHOUSE_FormList_Model()
        {
            FunctionName = "WAREHOUSE_LIST";
        }

        public string GridHeader { get; set; }
    }
}