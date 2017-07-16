namespace StockManager.Web.Models
{
    public class IMPORT_FormList_Model : BaseModel
    {
        public IMPORT_FormList_Model()
        {
            FunctionName = "IMPORT_LIST";
        }

        public string IndayForm_GridHeader { get; set; }
        public string HistoryForm_GridHeader { get; set; }
    }
}