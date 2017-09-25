var _HOME = null;

var HOME = function () {
    this.variable = {
        pageIndex: 0,
        pageSize: 10
    };
}

HOME.prototype = new BaseFunction("HOME");

HOME.prototype.init = function () {
    this.regisEvent();
    this.Get_Newest_Items();
}

HOME.prototype.regisEvent = function () {
    var $this = this;

}

HOME.prototype.Get_Newest_Items = function () {
    var $this = this;
    $.ajax({
        type: "POST",
        url: "/get-newest-items",
        dataType: "json",
        beforeSend: function () {
            $(".div-newest-items").html("")
        },
        success: function (response) {
            var item = "";
            if (response != null && response.Results != null) {
                $.each(response.Results, function (index, Obj) {
                    var image = "images-handle/get-image?path=" + Obj.ImagePath + "&w=275&h=356";
                    item += '<div class="col-lg-2 col-md-4 col-sm-6 col-xs-12">' +
										'<div class="item-pro-color">' +
											'<div class="product-thumb">' +
												'<a href="/detail" class="product-thumb-link">' +
													'<img data-color="black" class="active" src="' + image + '" alt="">' +

												'</a>' +
                                                '<a href="/home/quick-view" class="quickview-link plus fancybox.iframe"><span>Xem nhanh</span></a>' +
                                            '</div>' +
                                                '<div class="product-info">' +
                                                    '<div class="list-color">' +
                                                        '<a href="#" data-color="black" style="background:#404040"></a>' +
                                                        '<a href="#" data-color="purple" style="background:#ff8ff8"></a>' +
                                                        '<a href="#" data-color="blue" style="background:#868fff"></a>' +
                                                        '<a href="#" data-color="cyan" style="background:#80e6ff"></a>' +
                                                    '</div>' +
                                                    '<h3 class="product-title"><a href="/detail">' + Obj.ProductGroup_Name + '</a></h3>' +
                                                    '<div class="product-price">' +
                                                        '<ins><span>$360.00</span></ins>' +
                                                        '<del><span>$400.00</span></del>' +
                                                    '</div>' +
                                                    '<div class="product-extra-link">' +
                                                        '<a href="#" class="addcart-link"><i class="fa fa-shopping-basket" aria-hidden="true"></i><span>Add to Cart</span></a>' +
                                                        '<a href="#" class="wishlist-link"><i class="fa fa-heart" aria-hidden="true"></i><span>Wishlist</span></a>' +
                                                        '<a href="#" class="compare-link"><i class="fa fa-refresh" aria-hidden="true"></i><span>Compare</span></a>' +
                                                    '</div>' +
                                                '</div>' +
                                            '</div>' +
                                        '</div>';                   
                });
                if (item.length>0) {
                    item += '<div class="col-lg-2 col-md-4 col-sm-6 col-xs-12">' +
											'<div class="product-thumb">' +
												'<a href="/product" class="product-thumb-link see-more">' +
                                                    '<i class="material-icons">add</i>' +
                                                '</a>' +
                                            '</div>' +
                                     '</div>';
                }
                
                $(".div-newest-items").append(item);
            }
        }
    });
}

HOME.prototype.get_Product_ByItem = function () {

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
                                   .attr("onClick", "_HOME.updatePublish_Status(this, \'" + row.Product_ID + "\')");
                var $div = $("<div>").append($checkbox).append($lablel);
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
            url: '/online-items/get-product-by-item',
            dataType: "JSON",
            type: 'POST',
            data: function () {
                var request = new Get_Products_By_GroupId_Request();
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

HOME.prototype.saveItem = function () {

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

$(function () {
    _HOME = new HOME();
    _HOME.init();
});
