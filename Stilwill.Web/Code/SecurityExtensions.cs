using System;
using System.Globalization;
using System.Web.Mvc;

namespace Stilwill.Web.Code
{
    public static class SecurityExtensions
    {
        public static bool HasActionPermission(this HtmlHelper htmlHelper, string actionName, string controllerName)
        {
            //if the controller name is empty the ASP.NET convention is:
            //we are linking to a different controller
            var controllerToLinkTo = string.IsNullOrEmpty(controllerName)
                ? htmlHelper.ViewContext.Controller
                : GetControllerByName(htmlHelper, controllerName);

            var controllerContext = new ControllerContext(htmlHelper.ViewContext.RequestContext, controllerToLinkTo);

            var controllerDescriptor = new ReflectedControllerDescriptor(controllerToLinkTo.GetType());

            ActionDescriptor actionDescriptor = controllerDescriptor.FindAction(controllerContext, actionName);

            return ActionIsAuthorized(controllerContext, actionDescriptor);
        }


        private static bool ActionIsAuthorized(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            if (actionDescriptor == null)
                return false; // action does not exist so say yes - should we authorise this?!

            var authContext = new AuthorizationContext(controllerContext, actionDescriptor);

            // run each auth filter until on fails
            // performance could be improved by some caching
            //foreach (IAuthorizationFilter authFilter in actionDescriptor.GetFilters().AuthorizationFilters)

            var filters = FilterProviders.Providers.GetFilters(controllerContext, actionDescriptor);

            foreach (var filter in filters)
            {
                var authFilter = filter.Instance as IAuthorizationFilter;
                if (authFilter == null) continue;

                authFilter.OnAuthorization(authContext);

                if (authContext.Result != null)
                    return false;
            }

            return true;
        }

        private static ControllerBase GetControllerByName(HtmlHelper helper, string controllerName)
        {
            // Instantiate the controller and call Execute
            IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();

            IController controller = factory.CreateController(helper.ViewContext.RequestContext, controllerName);

            if (controller == null)
            {
                throw new InvalidOperationException(
                    String.Format(
                        CultureInfo.CurrentUICulture,
                        "Controller factory {0} controller {1} returned null",
                        factory.GetType(),
                        controllerName));
            }

            return (ControllerBase)controller;
        }
    }
}