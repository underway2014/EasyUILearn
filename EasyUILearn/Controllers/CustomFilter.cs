using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.Web.Routing;
namespace EasyUILearn.Controllers
{
    public class CustomFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

          //if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            if(HttpContext.Current.Session["userName"] == null)
            {
                filterContext.HttpContext.Response.Redirect("/User/Login",false);


                //filterContext.Result = new RedirectToRouteResult("Default",
                //    new RouteValueDictionary(new { controller = "User", action = "Login" }));
            }
        }
    }
}