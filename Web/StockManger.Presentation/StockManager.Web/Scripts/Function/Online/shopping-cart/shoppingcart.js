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


SHOPPINGCART.prototype.addToCart = function (productId, quantity, btn) {
    $.ajax({
        type: 'POST',
        url: '/shoppingcart/add-to-cart',
        data: {
            productId: productId,
            quantity: quantity
        },
        dataType: 'json',
        beforeSend: function () {
            $(btn).button('loading');
        },
        error: function (response) {
            console.log("error: ");
            console.log(response);
        },
        success: function (response) {

        }
    })
    .done(function (response) {
       $(btn).button('reset');
    });
}

$(function () {
    _SHOPPINGCART = new SHOPPINGCART();
    _SHOPPINGCART.init();
});
