﻿var _PRODUCT = null;

var Products_CRUD_ViewModel = function () {
    this.Product_Name = "";
    this.Sale_Price = 0;
    this.Size = 0;
    this.Unit = 0;
    this.Description = 0;

}

function PRODUCT() { }

PRODUCT.prototype = new BaseFunction("PRODUCT");

PRODUCT.prototype.init = function () {
    this.regisEvent();
    this.getProducts();
    Dropzone.options.frmFileUpload = {
        paramName: "file",
        maxFilesize: 2
    };
}

PRODUCT.prototype.regisEvent = function () {
    var $this = this;



    $("#btn-new-product").click(function () {
        $this.loadCreateForm();
    });

    $("#btn_product_crud_save").click(function () {

        $("#frm-crud-product").submit();
    });



}

PRODUCT.prototype.getProducts = function () {
    var $this = this;
    $.ajax({
        type: "GET",
        url: "/product/get-products",
        data: { date: new Date() },
        dataType: "json",
        success: function (response) {
            $this.loadToDataTable(response);
        }
    });
}

PRODUCT.prototype.loadToDataTable = function (response) {

    $('#product_list_item').DataTable({
        processing: true,
        data: response.Results,
        columns: [
            { data: "Product_ID", title: "Product ID" },
            { data: "Product_Name", title: "Product Name" },
            { data: "Unit_ID", title: "Unit" },
            { data: "Quantity", title: "Quantity" }
        ],
        select: true
    });

};

PRODUCT.prototype.loadCreateForm = function () {
    $("#div-crud-modal").loading();
    $("#div-crud-modal .modal-body").html("");
    $("#div-crud-modal .modal-body").load("/product/product-create-form", function () {
        $("#div-crud-modal").loading("stop");

    });
}

PRODUCT.prototype.getSaveProduct_RequestValue = function () {
    var obj = new Products_CRUD_ViewModel();
    var formVal = $("#frm-crud-product").serializeFormJSON();
    obj.Product_Name = formVal.Product_Name;
    obj.Unit = formVal.Unit;
    obj.Sale_Price = Number(formVal.Sale_Price);
    obj.Size = Number(formVal.Sale_Price);
    obj.Description = formVal.Description;
    return obj;
}

PRODUCT.prototype.saveProduct = function () {
    debugger;
    var isvalidate = $("#frm-crud-product").valid();
    if (!isvalidate) {
        return;
    }
    var request = this.getSaveProduct_RequestValue();
  

    $.ajax({
        type: 'POST', // define the type of HTTP verb we want to use (POST for our form)
        url: '/product/product-create', // the url where we want to POST
        data: request, // our data object
        dataType: 'json', // what type of data do we expect back from the server       
        beforeSend: function () {
        },
        error: function (respone) {
            console.log(respone);
        },
        success: function (response) {
            console.log(response);
        }
    })
    .done(function (response) {
        console.log(response);

    });
}

$(function () {
    _PRODUCT = new PRODUCT();
    _PRODUCT.init();
});
