var _SHOPPINGCART = null;

var SHOPPINGCART = function () {
    this.variable = {
        pageIndex: 0,
        pageSize: 10
    };
}

SHOPPINGCART.prototype = new BaseFunction("SHOPPINGCART");

SHOPPINGCART.prototype.init = function () {
    this.regisEvent();

}

SHOPPINGCART.prototype.regisEvent = function () {
    var $this = this;

}


SHOPPINGCART.prototype.addToCart = function (productId, btn) {

    $.ajax({
        type: 'POST',
        url: '/shoppingcart/add-to-cart',
        data: {
            productId: productId
        },
        dataType: 'json',
        beforeSend: function () {
          //  $("#div-crud-modal").loading();
        },
        error: function (response) {
            $("#div-crud-modal").loading("stop");
            console.log(response);
        },
        success: function (response) {
            //if (response.StatusCode != 0)
            //    showErrorMessage(response.StatusMessage, "#div-crud-modal");
            //else {
            //    showSuccessMessage(response.StatusMessage, "#div-crud-modal");
            //    $("[view-when='update']").fadeIn();
            //}
        }
    })
    .done(function (response) {
        //$("#div-crud-modal").loading("stop");

    });
}

$(function () {
    _SHOPPINGCART = new SHOPPINGCART();
    _SHOPPINGCART.init();
});
