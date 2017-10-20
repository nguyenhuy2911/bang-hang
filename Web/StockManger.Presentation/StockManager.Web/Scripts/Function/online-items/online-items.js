var PUBLISH_STATUS = {
    ACTIVE: 1,
    NONE: 0
}
var _ONLINE_ITEMS = null;
var table_OnlineItemList;
var Page = function (pageNumber, pageSize) {
    this.PageNumber = pageNumber;
    this.PageSize = pageSize;
}

var Get_Online_Items_Model = function () {
    this.Page = new Page(0, 10);
}

var Get_Products_By_Item_Model = function () {
    this.Page = new Page(0, 10);
    this.Product_Group_ID = $("#ProductId").val();
}

var Products_CRUD_ViewModel = function () {
    this.ProductId = 0;
    this.Product_Name = "";
    this.Sale_Price = 0;
    this.Quantity = 0;
    this.Unit_ID = "";
    this.Description = 0;

}

var ONLINE_ITEMS = function () {
    this.variable = {
        pageIndex: 0,
        pageSize: 10,
        getProductByItemPageIndex: 0,
        getProductByItemPageSize: 10,
    };
    this.Online_Items_Datatables = null;
}

ONLINE_ITEMS.prototype = new BaseFunction("ONLINE_ITEMS");

ONLINE_ITEMS.prototype.init = function () {
    this.regisEvent();
    this.get_Online_Items();
}

ONLINE_ITEMS.prototype.regisEvent = function () {
    var $this = this;
    var $modal = $('#div-crud-modal');
    $("#btn_product_crud_save").click(function () {
        $("#frm-crud-product").submit();
        $('#div-crud-modal').animate({
            scrollTop: 0
        }, 800);
    });

    $modal.on('hidden.bs.modal', function (e) {
        $this.Online_Items_Datatables.draw();
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
                    var $thumnail = $("<a class='background-transparent'>").append($("<img class='img-responsive'>").attr("src", "images-handle/get-image?path=" + data + "&w=100&h=100"))
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
    $this.Online_Items_Datatables = $('#product_list_item').DataTable({
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
                var request = new Get_Online_Items_Model();
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
        var info = $this.Online_Items_Datatables.page.info();
        $this.variable.pageIndex = info.page;
        $this.variable.pageSize = info.length;
    });
}

ONLINE_ITEMS.prototype.loadEditForm = function (strJsondata) {
    var data = JSON.parse(strJsondata);
    $("#div-crud-modal").loading();
    $("#div-crud-modal .modal-body").html("");
    $("#div-crud-modal .modal-body").load("/online-items/online-item-detail?productId=" + data.ProductGroup_ID, function () {
        $("#div-crud-modal").loading("stop");
        $("[view-when='update']").fadeIn();
    });
}

ONLINE_ITEMS.prototype.get_Product_ByItem = function () {

    var $this = this;
    var column = item_By_Group_GridHeader;
    var columnRender = [];
    $.each(column, function (index, objColumn) {
        if (objColumn.data == "Publish") {
            objColumn.render = function (data, type, row, meta) {
                var $lablel = $("<label for=\'chk_" + row.Product_ID + "\'>");
                var $checkbox = $("<input id=\'chk_" + row.Product_ID + "\' type='checkbox'>")
                                   .addClass("filled-in chk-col-deep-purple")
                                   .attr("checked", row.Publish)
                                   .attr("onClick", "_ONLINE_ITEMS.updatePublish_Status(this, \'" + row.Product_ID + "\')");
                var $div = $("<div>").append($checkbox).append($lablel);
                return $div.html();
            }
        }
        if (objColumn.data == "Unit_ID") {
            objColumn.render = function (data, type, row, meta) {
                if (row.UNIT != null)
                    return row.UNIT.Unit_Name;
                else
                    return '';
            }
        }
        if (objColumn.data == "Product_Name") {
            objColumn.render = function (data, type, row, meta) {
                var html = "<label>" + data + "</label> <br />";
                var htmlColor = "";
                var htmlSize = "";
                if (row.Product_ProductAttribute_Mapping != null) {
                    row.Product_ProductAttribute_Mapping.forEach(function (item, index) {
                        if (item.ProductAttribute.Type == "COLOR") {
                            htmlColor +=
                                        "<div class='list-filter color-filter'>" +
                                                "<a title=\'" + item.ProductAttribute.Name + "\'> <span style='background:" + item.ProductAttribute.Description + "'></span> </a>" +
                                        "</div>";
                        }
                        if (item.ProductAttribute.Type == "SIZE") {
                            htmlSize +=
                                    "<div class='list-filter'>" +
                                           "<a title=\'" + item.ProductAttribute.Name + "\'> <span>" + item.ProductAttribute.Name + "</span> </a>" +
                                    "</div>";
                        }
                    })
                }
                return html + htmlColor + htmlSize;
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
            url: '/online-items/get-products-by-item',
            dataType: "JSON",
            type: 'POST',
            data: function () {
                var request = new Get_Products_By_Item_Model();
                request.Page = new Page($this.variable.getProductByItemPageIndex, $this.variable.getProductByItemPageSize);
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
        $this.variable.getProductByItemPageIndex = info.page;
        $this.variable.getProductByItemPageSize = info.length;
    });
}

ONLINE_ITEMS.prototype.getSaveItem_RequestValue = function () {
    var obj = new Products_CRUD_ViewModel();
    var formVal = $("#frm-crud-product").serializeFormJSON();
   
    obj.Product_ID = formVal.Product_ID;
    obj.Description = htmlEncode(editor_Description.getContent());
    obj.ProductId = formVal.ProductId
    return obj;
}

ONLINE_ITEMS.prototype.saveItem = function () {

    var isvalidate = $("#frm-crud-product").valid();
    if (!isvalidate)
        return;
    var request = this.getSaveItem_RequestValue();
    $.ajax({
        type: 'POST', // define the type of HTTP verb we want to use (POST for our form)
        url: '/online-items/online-item-update', // the url where we want to POST
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

ONLINE_ITEMS.prototype.updatePublish_Status = function (element, productId) {
    var _publishStatus = $(element).prop("checked") == true ? PUBLISH_STATUS.ACTIVE : PUBLISH_STATUS.NONE;
    var request = {
        productId: productId,
        publishStatus: _publishStatus
    }
    $.ajax({
        type: 'POST', // define the type of HTTP verb we want to use (POST for our form)
        url: '/online-items/online-item-update-publishstatus', // the url where we want to POST
        data: request, // our data object
        dataType: 'json', // what type of data do we expect back from the server       
        beforeSend: function () {
        },
        error: function (response) {
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

    });
}

$(function () {
    _ONLINE_ITEMS = new ONLINE_ITEMS();
    _ONLINE_ITEMS.init();
});
