using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Project_UI.Areas.Admin.FilterAttributes
{
    public class CheckAuth : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (!HttpContext.Current.Response.IsRequestBeingRedirected)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "action", "index" }, { "controller", "login" } });
                }
            }
     
        }
    }
}