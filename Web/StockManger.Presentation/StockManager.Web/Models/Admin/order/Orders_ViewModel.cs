using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManager.Web.Models.Admin
{
    public class Orders_ViewModel : BaseModel
    {
        public Orders_ViewModel()
        {
            GridHeader = DataTableGridHelper.GetHeaderJson<Order_Grid_Column>();
        }
        public string GridHeader { get; set; }


    }
    public class Order_Grid_Column
    {
        [TableHeader(title ="Id")]
        public string Id { get; set; }

        [TableHeader(title = "Tên khách hàng")]
        public string CustomerName { get; set; }

        [TableHeader(title = "SDT")]
        public string CustomerTel { set; get; }

        [TableHeader(title = "Tổng tiền")]
        public string OrderTotal { get; set; }

        [TableHeader(title = "Tình trạng đơn hàng")]
        public string OrderStatus { get; set; }

        [TableHeader(title = "Tình trạng shipping")]
        public string ShippingStatus { get; set; }

        [TableHeader(title = "Tình trạng thanh toán")]
        public string PaymentStatus { get; set; }

        [TableHeader(title = "Sửa / Xóa")]
        public string Action { get; set; }
    }

}