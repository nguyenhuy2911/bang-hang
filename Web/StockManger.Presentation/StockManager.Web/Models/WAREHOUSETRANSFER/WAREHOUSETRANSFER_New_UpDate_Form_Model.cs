namespace StockManager.Web.Models
{
    public class WAREHOUSETRANSFER_New_UpDate_Form_Model : BaseModel
    {
        public WAREHOUSETRANSFER_New_UpDate_Form_Model()
        {
            FunctionName = "WAREHOUSETRANSFER_NEW_UPDATE";
        }

        public string IndayForm_GridHeader { get; set; }
        public string HistoryForm_GridHeader { get; set; }
    }
}