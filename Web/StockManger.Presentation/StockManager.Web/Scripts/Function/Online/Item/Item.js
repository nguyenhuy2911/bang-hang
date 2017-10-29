var _DETAIL = null;

var DETAIL = function () {
    this.variable = {
        pageIndex: 0,
        pageSize: 10
    };
    this.Model = new Array();
}

DETAIL.prototype = new BaseFunction("Item");

DETAIL.prototype.init = function () {
    this.regisEvent();

}


DETAIL.prototype.regisEvent = function () {
    var $this = this;
    $("div.detail-extralink .addcart-link").click(function () {
        event.preventDefault();
        if ($(this).prop('disabled') == true) {
            return false;
        }
        else
            $this.addToCart();
    })

    $("ul.color-filter a").click(function () {
        event.preventDefault();
        $this.colorChange($(this).attr("data-color-value"));
    });


}

DETAIL.prototype.setModel = function (model) {
    this.Model = JSON.parse(htmlDecode(model));
}

DETAIL.prototype.colorChange = function (value) {
    var viewItems = new Array();
    var listImgSlider = new Array();
    this.Model.List_All_Sale_Item.forEach(function (sale_Item) {
        sale_Item.ProductAttributes.forEach(function (atribute) {
            if (atribute.Id == value) {
                viewItems.push(sale_Item);
                listImgSlider = sale_Item.ListImage;
            }
        })
    });
    var sizehtml = "";
    viewItems.forEach(function (item, index) {
        item.ProductAttributes.forEach(function (attribute) {
            if (attribute.Type == 'SIZE') {
                var active = "";
                if (index == 0)
                    active = "active";
                sizehtml += '<li class="' + active + '"><a data-value="' + item.Product_ID + '" href="#">' + attribute.Name + '</a></li>';
            }
        })
    });
    $("ul.size-filter").html(sizehtml);
    $(".attr-size div.attr-title").find('span.current-size').text($("ul.size-filter li.active a").html());
    $("#tab_image").html("");
    $('#detail-item-slider').html("");
    listImgSlider.forEach(function (item, index) {
        var active = "";
        if (index == 0) {
            active = "active";
        }

        var contentSlider = '<div class="item">' +
                                             '<div class="row-fluid">' +
                                                 '<a href="#" class="thumbnail ' + active + '" data-image="../images-handle/get-image?path=' + item.Path + '&w=330&h=360" data-zoom-image="../images-handle/get-image?path=' + item.Path + '&w=530&h=560">' +
                                                     '<img src="../images-handle/get-image?path=' + item.Path + '&w=330&h=360" alt="' + item.Name + '">' +
                                                 '</a>' +
                                             '</div>' +
                                         '</div>';
        $('#detail-item-slider').data('owlCarousel').addItem(contentSlider);
        $("#tab_image").append(' <img src="../images-handle/get-image?path=' + item.Path + '&w=330&h=360" alt="' + item.Name + '">');

    });
    $('.size-filter').each(function () {
        $(this).find('a').on('click', function (event) {
            event.preventDefault();
            $(this).parent().siblings().removeClass('active');
            $(this).parent().toggleClass('active');
            $(this).parents('.attr-detail').find('.current-size').text($(this).text());
        });
    });
    detail_gallery();
    $("#detail-item-slider a.active").click();

}

DETAIL.prototype.addToCart = function () {
    var productId = $("ul.list-filter li.active a").attr("data-value");
    var quantity = $(".detail-qty .qty-val").text();
    var btn = $("div.detail-extralink .addcart-link");
    _SHOPPINGCART.addToCart(productId, quantity, btn);

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
