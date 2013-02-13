using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace CostMatrix.Web.Extensions
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Creates a Twitter Bootstrap menu item with active class
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="linkText"></param>
        /// <param name="actionName"></param>
        /// <param name="controllerName"></param>
        /// /// <param name="isRootLevel"></param>
        /// <returns></returns>
        public static MvcHtmlString MenuLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, bool isRootLevel = false)
        {
            var builder = new TagBuilder("li");

            var currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            var currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");

            if (controllerName == currentController && (actionName == currentAction || isRootLevel))
            {
                builder.AddCssClass("active");
            }

            builder.InnerHtml = htmlHelper.ActionLink(linkText, actionName, controllerName).ToHtmlString();

            return new MvcHtmlString(builder.ToString());
        }
    }
}