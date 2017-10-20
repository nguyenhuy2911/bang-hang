using Common;
using System;
using System.Collections.Generic;
using System.Data;
namespace StockManager.Data.Model.Data
{
    public class OnlineItem_GetList_Parameter
    {
        public OnlineItem_GetList_Parameter() { }

        [SqlParameterAttribute(ParameterName = "@Offset", DbType =DbType.Int64)]
        public int Offset { get; set; }

        [SqlParameterAttribute(ParameterName = "@Next", DbType = DbType.Int64)]
        public int Next { get; set; }

        [SqlParameterAttribute(ParameterName = "@Publish", DbType = DbType.Int64)]
        public int Publish { get; set; }
    }
}
