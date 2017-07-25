﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StockManager.Web.Models.PRODUCT
{
    public class Products_CRUD_ViewModel
    {
        public Products_CRUD_ViewModel()
        {

        }
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        public string Product_Name { get; set; }

        [Required(ErrorMessage = "Giá không được để trống")]
        [Range(0, 1000000, ErrorMessage = "Giá phải là số")]
        [MaxLength(1000000, ErrorMessage = "Giá phải nhỏ hơn")]
        public decimal? Sale_Price { get; set; }

        [Required(ErrorMessage = "Khối lượng không được để trống")]
        [Range(0, 1000000, ErrorMessage = "Khối lượng phải là số")]
        public string Size { get; set; }

        [Required(ErrorMessage = "Đơn vị tính không được để trống")]
        public string Unit { get; set; }

        [Required]
        public string UserID { get; set; }
        public string Description { get; set; }
    }
}