namespace StockManager.Web.Models
{
    public class IMPORT_New_UpDate_Form_Model : BaseModel
    {
        public IMPORT_New_UpDate_Form_Model()
        {
            FunctionName = "IMPORT_NEW_UPDATE";
        }

        public string IndayForm_GridHeader { get; set; }
        public string HistoryForm_GridHeader { get; set; }
    }
}