using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class GridColumn
    {
        public GridColumn()
        {
            align = JsGridColAlign.center.ToString();
            type = JsGridColType.text.ToString();
            name = "";
            title = "";
            CSSClass = "jsgridHeaderTable";           
            width = "50";

        }
        public string name { get; set; }
        public string type { get; set; }
        public string width { get; set; }
        public string title { get; set; }
        public string align { get; set; }

        public string CSSClass { get; set; }

    }

    public enum JsGridColType
    {
        text,
        number,
        control,
        select,
        checkbox,
        textarea
    }

    public enum JsGridColAlign
    {
        center,
        left,
        right
    }


}
