var _DETAIL = null;

var DETAIL = function () {
    this.variable = {
        pageIndex: 0,
        pageSize: 10
    };
}

DETAIL.prototype = new BaseFunction("DETAIL");

DETAIL.prototype.init = function () {
    this.regisEvent();
    this.Get_Newest_Items();
}

DETAIL.prototype.regisEvent = function () {
    var $this = this;

}


DETAIL.prototype.saveItem = function () {

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
    _DETAIL = new DETAIL();
    _DETAIL.init();
});
