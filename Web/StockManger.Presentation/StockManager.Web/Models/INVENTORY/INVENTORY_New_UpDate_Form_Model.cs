namespace StockManager.Web.Models
{
    public class INVENTORY_New_UpDate_Form_Model : BaseModel
    {
        public INVENTORY_New_UpDate_Form_Model()
        {
            FunctionName = "INVENTORY_NEW_UPDATE";
        }

        public string IndayForm_GridHeader { get; set; }
        public string HistoryForm_GridHeader { get; set; }
    }
}