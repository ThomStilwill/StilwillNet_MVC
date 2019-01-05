using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Stilwill.Web.Code
{
    public static class MenuUtil
    {
        public static MvcHtmlString AuthorizeActionLink(this HtmlHelper helper, string linkText, string actionName, string controllerName, object routeValues, object htmlAttributes)
        {
            return helper.HasActionPermission(actionName, controllerName) ? helper.ActionLink(linkText, actionName, controllerName, routeValues, htmlAttributes) : MvcHtmlString.Empty;
        }

        public static MvcHtmlString AuthorizeActionLink(this HtmlHelper helper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return helper.HasActionPermission(actionName, controllerName) ? helper.ActionLink(linkText, actionName, controllerName, routeValues, htmlAttributes) : MvcHtmlString.Empty;
        }

        public static MvcHtmlString AuthorizeAction(this HtmlHelper helper, string actionName, string controllerName, object routeValues)
        {
            return helper.HasActionPermission(actionName, controllerName) ? helper.Action(actionName, controllerName, routeValues) : MvcHtmlString.Empty;
        }

    }
}