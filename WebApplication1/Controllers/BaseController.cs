using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = Session["PK_iMaTK"];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    System.Web.Routing.RouteValueDictionary(new { controller = "login", action = "index" })
                    );
            }
            base.OnActionExecuting(filterContext);
        }
    }
}