function InputControl(functionName) {
    this.base = new BaseFunction(functionName);
    this.$DIV_DATALIST = this.base.getInput("div_dataList");
    this.$BTN_NEW = this.base.getInput("btn_New");
}

function VENDOR() {
    this.$input = new InputControl(FUNCTIONENUM.VENDOR.VENDOR_LIST);
}

VENDOR.prototype = new BaseFunction(FUNCTIONENUM.VENDOR.VENDOR_LIST);

var clients = [
        { "Index": "1", "Name": 25, "Address": 1 },
        { "Index": "2", "Name": 45, "Address": 2 },
        { "Index": "3", "Name": 29, "Address": 3 },
        { "Index": "4", "Name": 56, "Address": 1 },
        { "Index": "5", "Name": 32, "Address": 3 },
];

VENDOR.prototype.bindData = function (response) {
    debugger;
    var dataList = [];
    var rowCount = 0;
    var rowOrderNo = 1;
    if (response != null && response.result != null) {
        rowCount = response.rowCount;
        dataList = response.result;
    }
    dataList = clients;
    var headers = JSON.parse(objectHeader);
    var Field = [];
    $.each(headers, function (index, objectHeader) {
        var jsGridHeader = {};

        jsGridHeader.headercss = objectHeader.CSSClass
        jsGridHeader.name = objectHeader.name;
        jsGridHeader.title = objectHeader.title;
        jsGridHeader.align = objectHeader.align;
        jsGridHeader.type = objectHeader.type;
        jsGridHeader.width = objectHeader.width;
        Field.push(jsGridHeader);
    });
    var controller = { loadData: $.noop, };
    if (dataList != null) {
        controller = {
            loadData: function (filter) {
                return {
                    data: dataList,
                    //  itemsCount: rowCount
                };
            }
        };
    }

    gridOptionObj = new jsGridOptionObj();
    gridOptionObj.RowCount = rowCount;
    gridOptionObj.Editing = false,
    gridOptionObj.Field = Field;
    gridOptionObj.Fillter = true;
    gridOptionObj.Paging = true;
    gridOptionObj.Controller = controller;
    gridOptionObj.Data = dataList;

    //gridOptionObj.PagerContainer = this.getObj("PagingContent");
    jsGridRenderWithPagingServer(this.$input.$DIV_DATALIST, gridOptionObj);
};

VENDOR.prototype.newVendor = function () {

    LoadPoupForm("/vendor-new");
}

function newVendor() {
    var module = new VENDOR();
    module.newVendor();

}
