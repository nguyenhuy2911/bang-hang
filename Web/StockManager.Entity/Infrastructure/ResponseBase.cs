namespace StockManager.Entity
{
    public class ResponseBase<T>
    {
        public ResponseBase()
        {
            TotalRow = 0;
            StatusCode = -1;
        }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public T Results { get; set; }
        public int TotalRow { get; set; }
        
    }
}
