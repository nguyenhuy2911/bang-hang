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
    this.Org_Price = 0;
    this.Quantity = 0;
    this.Unit_ID = "";
    this.Description = 0;
    this.ProductGroup_ID = 0;
    this.Product_Level1 = 0;
    this.Product_Level2 = 0;
}

var Product_ProductAttribute_Mapping_Model = function () {
    this.Id = 0;
    this.ProductId = 0;
    this.ProductAttributeId = 0;
    this.Type = "";

}

var PRODUCT = function () {
    this.variable = {
        pageIndex: 0,
        pageSize: 10
    };
    this.Product_DataTables = null;
}

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

    $("#btn_product_crud_save").click(function () {
        $("#frm-crud-product").submit();
        $('#div-crud-modal').animate({
            scrollTop: 0
        }, 800);
    });

    $(".rad-product-attribute").click(function () {
        _PRODUCT.addProductAtribute(this);
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
    $this.Product_DataTables = $('#product_list_item').DataTable({
        responsive: true,
        processing: true,
        serverSide: true,
        searching: false,
        autoWidth: false,
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
        var info = $this.Product_DataTables.page.info();
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
    $.ajax({
        type: 'POST',
        url: '/product/product-edit-form',
        data: data,
        beforeSend: function () {
            $("#div-crud-modal").loading();
            $("#div-crud-modal .modal-body").html("");
        },
        error: function (response) {
            console.log(response);
        },
        success: function (html) {

            $("#div-crud-modal .modal-body").html(html);
            $("#div-crud-modal").loading("stop");
            $("[view-when='update']").fadeIn();
        }
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
    obj.Org_Price = Number(formVal.Org_Price);
    obj.Quantity = Number(formVal.Quantity);
    obj.Product_Group_ID = formVal.Product_Group_ID;
    obj.Product_Type_ID = formVal.Product_Type_ID;    
    obj.Description = htmlEncode(editor_Description.getContent());
    return obj;
}

PRODUCT.prototype.saveProduct = function () {
    var $this = this;
    var isvalidate = $("#frm-crud-product").valid();
    if (!isvalidate)
        return;
    var request = this.getSaveProduct_RequestValue();
    $.ajax({
        type: 'POST',
        url: '/product/product-save',
        data: request,
        dataType: 'json',
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
                if (request.Product_ID == 0) {
                    $("input#Product_ID").val(response.Results.Product_ID)
                }
                $this.Product_DataTables.draw();
                $("[view-when='update']").fadeIn();
            }
        }
    })
    .done(function (response) {
        $("#div-crud-modal").loading("stop");

    });
}

PRODUCT.prototype.getProduct_ProductAttribute_Mapping_RequestValue = function (selector) {

    var obj = new Product_ProductAttribute_Mapping_Model();
    obj.ProductAttributeId = $(selector).val();
    obj.ProductId = $("#Product_ID").val();
    obj.Type = $(selector).attr("data-type");
    return obj;
}

PRODUCT.prototype.addProductAtribute = function (selector) {

    var request = this.getProduct_ProductAttribute_Mapping_RequestValue(selector);
    $.ajax({
        type: 'POST',
        url: '/product/add-product-atribute',
        data: request,
        dataType: 'json',
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
            }


        }
    });

}


PRODUCT.prototype.Get_Attributes_By_ProductType = function () {
    var product_Type_Id = $("#Product_Type_ID").val() == "" ? 0 : $("#Product_Type_ID").val();
    var productId = $("input#Product_ID").val();
    $.ajax({
        type: 'POST',
        url: '/product/get-attributes-by-product-type',
        data: {
            product_Type_Id: product_Type_Id,
            productId: productId
        },
        dataType: 'json',
        beforeSend: function () {
        },
        error: function (response) {
            console.log(response);
        },
        success: function (datas) {
            
            if (datas == null) {
                return;
            }
            $("#div_attribute").html("");
            var html = "";
            $.each(datas, function (index, obj) {
                var attributeHtml = "";
                $.each(obj.ProductAttributes, function (_, attribute) {
                    var checked = attribute.IsSelected ? "checked='checked'" : "";
                    attributeHtml +=
                       '<input name=\'' + attribute.Type + '\' class="with-gap radio-col-pink rad-product-attribute" type="radio" id="radio_' + attribute.Type + '_' + attribute.Id + '" value="' + attribute.Id + '" data-productid="0" data-type="' + attribute.Type + '" onchange="_PRODUCT.addProductAtribute(this);" ' + checked + ' />' +
                       '<label for="radio_' + attribute.Type + '_' + attribute.Id + '">' + attribute.Name + '</label>';
                });
                html =
                   '<div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">' +
                       '<h2 class="card-inside-title">' + obj.TypeName + '</h2>' +
                           '<div class="demo-radio-button">' +
                                   attributeHtml +
                           '</div>' +
                   '</div>';
                $("#div_attribute").append(html);
            });

        }
    });
}

PRODUCT.prototype.getItem_Image_RequestValue = function () {
    var obj = {};
    obj.Product_Id = $("#Product_ID").val();
    obj.Product_Name = $("#Product_Name").val();
    return obj;
}

$(function () {
    _PRODUCT = new PRODUCT();
    _PRODUCT.init();
});
