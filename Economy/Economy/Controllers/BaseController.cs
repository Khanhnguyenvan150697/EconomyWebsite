using Economy.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Economy.Common.Admin;
using System.Web.Routing;

namespace Economy.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (AdminLogin)Session[CommonConstantAdmin.ADMIN_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "LoginAdmin", action = "Login"}));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}