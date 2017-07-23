var _PRODUCT = null;

function PRODUCT() { }

PRODUCT.prototype = new BaseFunction("PRODUCT");

PRODUCT.prototype.init = function () {
    this.regisEvent();
    this.getProducts();
}

PRODUCT.prototype.regisEvent = function () {
    var $this = this;
    $("#btn-new-product").click(function () {
        $this.loadCreateForm();
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

$(function () {
    _PRODUCT = new PRODUCT();
    _PRODUCT.init();
});
