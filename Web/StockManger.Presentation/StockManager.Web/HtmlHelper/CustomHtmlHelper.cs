using StockManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace StockManager.Web.HtmlHelper
{
    public static class CustomHtmlHelper
    {
        public static MvcHtmlString GroupDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectList_Group> selectListGroup, object htmlAttributes)
        {
            var listItem = new List<SelectListItem>();
            foreach (var group in selectListGroup)
            {
                foreach (var item in group.Items)
                {
                    listItem.Add(
                        new SelectListItem()
                        {
                            Text = item.Text,
                            Value = item.Value,
                            Group = new SelectListGroup { Name = group.Name }
                        });
                }
            }
            var selectList = new SelectList(listItem, "Value", "Text", "Group.Name");
            return htmlHelper.DropDownListFor(expression, selectList, htmlAttributes);
        }
    }
}