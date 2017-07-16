namespace StockManager.Web.Models
{
    public class VENDOR_FormList_Model : BaseModel
    {
        public VENDOR_FormList_Model()
        {
            FunctionName = "VENDOR_LIST";
        }

        public string GridHeader { get; set; }
    }
}