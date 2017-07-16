function InputControl(functionName) {
    this.base = new BaseFunction(functionName);
    this.$DIV_DATALIST_INDAY = this.base.getInput("div_dataList");
    this.$DIV_DATALIST_HISTORY = this.base.getInput("div_dataListHistory");
    this.$BTN_NEW = this.base.getInput("btn_New");
}

function IMPORT() {

    this.$input = new InputControl(FUNCTIONENUM.IMPORT.IMPORT_LIST);
}

IMPORT.prototype = new BaseFunction(FUNCTIONENUM.IMPORT.IMPORT_LIST);

var clients = [
        { "Index": "1", "FromWareHouse": 25, "ToWareHouse": 1, "CreateDate": "29/11/2016", Status: "<lable class='text-success'><strong>Succses</strong></lable>", Action: "<button class='btn btn-danger'><i class='fa fa-trash-o fa-lg'></i>Hủy</button>" },
        { "Index": "2", "FromWareHouse": 45, "ToWareHouse": 2, "CreateDate": "29/11/2016", Status: "<lable class='text-success'><strong>Succses</strong></lable>", Action: "<button class='btn btn-danger'><i class='fa fa-trash-o fa-lg'></i>Hủy</button>" },
        { "Index": "3", "FromWareHouse": 29, "ToWareHouse": 3, "CreateDate": "29/11/2016", Status: "<lable class='text-success'><strong>Succses</strong></lable>", Action: "<button class='btn btn-danger'><i class='fa fa-trash-o fa-lg' ></i>Hủy</button>" },
        { "Index": "4", "FromWareHouse": 56, "ToWareHouse": 1, "CreateDate": "29/11/2016", Status: "<lable class='text-success'><strong>Succses</strong></lable>", Action: "<button class='btn btn-danger'><i class='fa fa-trash-o fa-lg' ></i>Hủy</button>" },
        { "Index": "5", "FromWareHouse": 32, "ToWareHouse": 3, "CreateDate": "29/11/2016", Status: "<lable class='text-success'><strong>Succses</strong></lable>", Action: "<button class='btn btn-danger'><i class='fa fa-trash-o fa-lg' ></i>Hủy</button>" },
];

IMPORT.prototype.bindData_Inday = function (response) {
    var dataList = [];
    var rowCount = 0;
    var rowOrderNo = 1;
    if (response != null && response.result != null) {
        rowCount = response.rowCount;
        dataList = response.result;
    }
    dataList = clients;
    var headers = JSON.parse(object_IndayForm_GridHeader);
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
    jsGridRenderWithPagingServer(this.$input.$DIV_DATALIST_INDAY, gridOptionObj);
};

IMPORT.prototype.bindData_History = function (response) {
    var dataList = [];
    var rowCount = 0;
    var rowOrderNo = 1;
    if (response != null && response.result != null) {
        rowCount = response.rowCount;
        dataList = response.result;
    }
    dataList = clients;
    var headers = JSON.parse(object_HistoryForm_GridHeader);
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
    jsGridRenderWithPagingServer(this.$input.$DIV_DATALIST_HISTORY, gridOptionObj);
};


IMPORT.prototype.newImportForm = function () {

   window.location.href= "/import-new-form";
}

function newImportForm() {
    var module = new IMPORT();
    module.newImportForm();

}
