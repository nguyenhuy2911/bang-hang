var _ONLINE_ITEMS = null;
var Page = function (pageNumber, pageSize) {
    this.PageNumber = pageNumber;
    this.PageSize = pageSize;
}

var Get_Product_Groups_Request = function () {
    this.Page = new Page(0, 10);
}

var Get_Products_By_GroupId_Request = function () {
    this.Page = new Page(0, 10);
    this.Product_Group_ID = $("#ProductGroup_ID").val();
}


var Products_CRUD_ViewModel = function () {
    this.Product_ID = 0;
    this.Product_Name = "";
    this.Sale_Price = 0;
    this.Quantity = 0;
    this.Unit_ID = "";
    this.Description = 0;
    this.ProductGroup_ID = 0;
}

var ONLINE_ITEMS = function () {
    this.variable = {
        pageIndex: 0,
        pageSize: 10
    };
}

ONLINE_ITEMS.prototype = new BaseFunction("ONLINE_ITEMS");

ONLINE_ITEMS.prototype.init = function () {
    this.regisEvent();
    this.get_Online_Items();
}

ONLINE_ITEMS.prototype.regisEvent = function () {
    var $this = this;
    $("#btn_product_crud_save").click(function () {
        $("#frm-crud-product").submit();
        $('#div-crud-modal').animate({
            scrollTop: 0
        }, 800);
    });



}

ONLINE_ITEMS.prototype.get_Online_Items = function () {
    var $this = this;
    var column = JSON.parse(columnGrid);
    var columnRender = [];
    $.each(column, function (index, objColumn) {
        if (objColumn.data == "ImagePath") {
            objColumn.render = function (data, type, row, meta) {
                if (data != null && data != '') {
                    var $thumnail = $("<a class='background-transparent'>").append($("<img class='img-responsive'>").attr("src", "images/get-images?path=" + data + "&w=100&h=100"))
                    var $div = $("<div>").append($thumnail);
                    return $div.html();
                }
                else
                    return '';
            }
        }
        if (objColumn.data == "Action") {
            objColumn.render = function (data, type, row, meta) {

                var $btnEdit = $("<a data-toggle='modal' data-target='#div-crud-modal'>")
                                       .addClass("btn btn-link btn-link-primary")
                                       .append('<i class="material-icons">mode_edit</i>')
                                       .attr("onclick", '_ONLINE_ITEMS.loadEditForm(\'' + JSON.stringify(row) + '\')');
                var $div = $("<div>").append($btnEdit);
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
        autoWidth: false,
        columns: column,
        ajax: {
            url: '/online-items/get-online-items',
            dataType: "JSON",
            type: 'POST',
            data: function () {
                var request = new Get_Product_Groups_Request();
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

ONLINE_ITEMS.prototype.loadEditForm = function (strJsondata) {
    var data = JSON.parse(strJsondata);
    $("#div-crud-modal").loading();
    $("#div-crud-modal .modal-body").html("");
    $("#div-crud-modal .modal-body").load("/online-items/online-item-detail?groupId=" + data.ProductGroup_ID, function () {
        $("#div-crud-modal").loading("stop");
        $("[view-when='update']").fadeIn();
    });
}

ONLINE_ITEMS.prototype.get_Items_By_Group = function () {
  
    var $this = this;
    var column = item_By_Group_GridHeader;
    var columnRender = [];
    $.each(column, function (index, objColumn) {       
        if (objColumn.data == "Action") {
            objColumn.render = function (data, type, row, meta) {

                var $btnEdit = $("<a data-toggle='modal' data-target='#div-crud-modal'>")
                                       .addClass("btn btn-link btn-link-primary")
                                       .append('<i class="material-icons">mode_edit</i>')
                                       .attr("onclick", '_ONLINE_ITEMS.loadEditForm(\'' + JSON.stringify(row) + '\')');
                var $div = $("<div>").append($btnEdit);
                return $div.html();
            }
        }
        columnRender.push(objColumn);
    })
    var table = $('table#list_item_by_group').DataTable({
        responsive: true,
        processing: true,
        serverSide: true,
        searching: false,
        autoWidth: false,
        columns: column,
        ajax: {
            url: '/online-items/get-items-by-group',
            dataType: "JSON",
            type: 'POST',
            data: function () {
                var request = new Get_Products_By_GroupId_Request();
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


ONLINE_ITEMS.prototype.getSaveProduct_RequestValue = function () {

    var obj = new Products_CRUD_ViewModel();
    var formVal = $("#frm-crud-product").serializeFormJSON();
    var editor_Description = tinymce.get('txt_Description');
    obj.Product_ID = formVal.Product_ID;
    obj.Product_Name = formVal.Product_Name;
    obj.Unit_ID = formVal.Unit_ID;
    obj.Sale_Price = Number(formVal.Sale_Price);
    obj.Quantity = Number(formVal.Quantity);
    obj.Description = htmlEncode(editor_Description.getContent());
    obj.ProductGroup_ID = formVal.ProductGroup_ID
    return obj;
}

ONLINE_ITEMS.prototype.getItem_Image_RequestValue = function () {
    var obj = {};
    obj.Product_Id = $("#ProductGroup_ID").val();
    obj.Product_Name = $("#Product_Name").val();
    return obj;
}

ONLINE_ITEMS.prototype.saveProduct = function () {

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
    _ONLINE_ITEMS = new ONLINE_ITEMS();
    _ONLINE_ITEMS.init();
});
