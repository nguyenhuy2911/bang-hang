﻿using StockManager.Entity.Service.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockManager.Web.Models.Admin
{
    public class Products_CRUD_ViewModel
    {
        public Products_CRUD_ViewModel()
        {
            UnitList = new List<SelectListItem>();           
        }


        public int Product_ID { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        public string Product_Name { get; set; }

        [Required(ErrorMessage = "Giá không được để trống")]
        [Range(0, 99999999, ErrorMessage = "Giá phải là số")]
        //  [MaxLength(1000000, ErrorMessage = "Giá phải nhỏ hơn 1,000,000")]
        public string Sale_Price { get; set; }

        [Required(ErrorMessage = "Giá không được để trống")]
        [Range(0, 99999999, ErrorMessage = "Giá phải là số")]
        //  [MaxLength(1000000, ErrorMessage = "Giá phải nhỏ hơn 1,000,000")]
        public string Org_Price { get; set; }

        [Required(ErrorMessage = "Khối lượng không được để trống")]
        [Range(0, 99999999, ErrorMessage = "Khối lượng phải là số")]
        public string Quantity { get; set; }

        [Required(ErrorMessage = "Đơn vị tính không được để trống")]
        public string Unit_ID { get; set; }

        [Required(ErrorMessage = "Chọn sản phẩm gốc")]
        public int Product_Group_ID { get; set; }

        [Required(ErrorMessage = "Chọn loại sản phẩm")]
        public int Product_Type_ID { get; set; }
        public string Description { get; set; }
        public string ListImgJson { get; set; }
        public List<SelectListItem> UnitList { get; set; }
        public SelectList Product_Group_List { get; set; }
        public List<SelectListItem> Product_Type_List { get; set; }
        public List<Get_ProductAttribute_Types_DTO> AtributeType_List { get; set; }

    }
}