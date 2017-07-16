namespace StockManager.Web.Models
{
    public class INVENTORY_Form_Model : BaseModel
    {
        public INVENTORY_Form_Model()
        {
            FunctionName = "INVENTORY_LIST";
        }

        public string IndayForm_GridHeader { get; set; }
        public string HistoryForm_GridHeader { get; set; }
    }
}