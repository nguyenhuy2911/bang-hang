function InputControl(functionName) {
    this.base = new BaseFunction(functionName);
    this.$DIV_DATALIST_INDAY = this.base.getInput("div_dataList");
    this.$DIV_DATALIST_HISTORY = this.base.getInput("div_dataListHistory");
    this.$BTN_NEW = this.base.getInput("btn_New");
}

function IMPORTNEW() {

    this.$input = new InputControl(FUNCTIONENUM.IMPORT.IMPORT_LIST);
}

IMPORTNEW.prototype = new BaseFunction(FUNCTIONENUM.IMPORT.IMPORT_LIST);


