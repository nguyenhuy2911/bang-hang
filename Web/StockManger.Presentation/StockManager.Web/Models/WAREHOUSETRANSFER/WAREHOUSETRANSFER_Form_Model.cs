namespace StockManager.Web.Models
{
    public class WAREHOUSETRANSFER_Form_Model : BaseModel
    {
        public WAREHOUSETRANSFER_Form_Model()
        {
            FunctionName = "WAREHOUSETRANSFER_LIST";
        }

        public string IndayForm_GridHeader { get; set; }
        public string HistoryForm_GridHeader { get; set; }
    }
}