var _PRODUCT = null;
var Page = function (pageNumber, pageSize) {
    this.PageNumber = pageNumber;
    this.PageSize = pageSize;
}

var GetProducts_Request = function () {
    this.Page = new Page(0, 10);
}

var Products_CRUD_ViewModel = function () {
    this.Product_ID = 0;
    this.Product_Name = "";
    this.Sale_Price = 0;
    this.Size = 0;
    this.Unit_ID = "";
    this.Description = 0;
    this.ProductGroup_ID = 0;
}

var PRODUCT = function () {
    this.variable = {
        pageIndex: 0,
        pageSize: 10
    };
}

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
        $('#div-crud-modal').animate({
            scrollTop: 0
        }, 800);
    });



}

PRODUCT.prototype.getProducts = function () {
    var $this = this;
    var column = JSON.parse(columnGrid);
    var columnRender = [];
    $.each(column, function (index, objColumn) {
        if (objColumn.data == "Action") {
            objColumn.render = function (data, type, row, meta) {

                var $btnEdit = $("<a data-toggle='modal' data-target='#div-crud-modal'>")
                                       .addClass("btn btn-link btn-link-primary")
                                       .append('<i class="material-icons">mode_edit</i>')
                                       .attr("onclick", '_PRODUCT.loadEditForm(\'' + JSON.stringify(row) + '\')');
                var $btnDelete = $("<a>").addClass("btn btn-link btn-link-danger").append('<i class="material-icons">delete</i>');
                var $div = $("<div>").append($btnEdit).append($btnDelete);
                return $div.html();
            }
        }
        columnRender.push(objColumn);
    })
    var table = $('#product_list_item').DataTable({
        responsive: true,
        processing: true,
        serverSide: true,
        searching: false,
        columns: column,
        ajax: {
            url: '/product/get-products',
            dataType: "json",
            type: 'POST',
            data: function () {
                var request = new GetProducts_Request();
                request.Page = new Page($this.variable.pageIndex, $this.variable.pageSize);
                return request;
            },
            dataFilter: function (response) {
                var data = JSON.parse(response);
                var jsonObj = {};
                jsonObj.recordsTotal = data.TotalRow;
                jsonObj.recordsFiltered = data.TotalRow;
                jsonObj.data = data.Results;
                return JSON.stringify(jsonObj);
            }
        },

    })
    .on('page.dt', function () {
        var info = table.page.info();
        $this.variable.pageIndex = info.page;
        $this.variable.pageSize = info.length;
    });
}

PRODUCT.prototype.loadCreateForm = function () {
    $("#div-crud-modal").loading();
    $("#div-crud-modal .modal-body").html("");
    $("#div-crud-modal .modal-body").load("/product/product-create-form", function () {
        $("#div-crud-modal").loading("stop");
        $("[view-when='update']").fadeOut();
    });
}



PRODUCT.prototype.loadEditForm = function (strJsondata) {
    var data = JSON.parse(strJsondata);
    $("#div-crud-modal").loading();
    $("#div-crud-modal .modal-body").html("");
    $("#div-crud-modal .modal-body").load("/product/product-edit-form?Id=" + data.Product_ID, function () {
        $("#div-crud-modal").loading("stop");
        $("[view-when='update']").fadeIn();
    });
}

PRODUCT.prototype.getSaveProduct_RequestValue = function () {

    var obj = new Products_CRUD_ViewModel();
    var formVal = $("#frm-crud-product").serializeFormJSON();
    var editor_Description = tinymce.get('txt_Description');
    obj.Product_ID = formVal.Product_ID;
    obj.Product_Name = formVal.Product_Name;
    obj.Unit_ID = formVal.Unit_ID;
    obj.Sale_Price = Number(formVal.Sale_Price);
    obj.Size = Number(formVal.Sale_Price);
    obj.Description = htmlEncode(editor_Description.getContent());
    obj.ProductGroup_ID = formVal.ProductGroup_ID
    return obj;
}

PRODUCT.prototype.saveProduct = function () {

    var isvalidate = $("#frm-crud-product").valid();
    if (!isvalidate)
        return;
    var request = this.getSaveProduct_RequestValue();
    $.ajax({
        type: 'POST', // define the type of HTTP verb we want to use (POST for our form)
        url: '/product/product-save', // the url where we want to POST
        data: request, // our data object
        dataType: 'json', // what type of data do we expect back from the server       
        beforeSend: function () {
            $("#div-crud-modal").loading();
        },
        error: function (response) {
            $("#div-crud-modal").loading("stop");
            console.log(response);
        },
        success: function (response) {
            if (response.StatusCode != 0)
                showErrorMessage(response.StatusMessage, "#div-crud-modal");
            else {
                showSuccessMessage(response.StatusMessage, "#div-crud-modal");
                $("[view-when='update']").fadeIn();
            }


        }
    })
    .done(function (response) {
        $("#div-crud-modal").loading("stop");

    });
}

$(function () {
    _PRODUCT = new PRODUCT();
    _PRODUCT.init();
});
