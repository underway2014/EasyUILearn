using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Routing;

namespace cml.web.Filters
{
///
/// 角色认证
///
    public class VaildateLoginRoleAttribute : ActionFilterAttribute
    {
        ///
        /// 角色名称
        ///
        public string Role { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!string.IsNullOrEmpty(Role))
            {
                if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    string redirectOnSuccess = filterContext.HttpContext.Request.RawUrl;
                    string redirectUrl = string.Format("?ReturnUrl={0}", redirectOnSuccess);
                    string loginUrl = FormsAuthentication.LoginUrl + redirectUrl;
                    filterContext.HttpContext.Response.Redirect(loginUrl, true);
                }
                else
                {
                    //判断是否存在角色
                    FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                    FormsAuthenticationTicket ticket = id.Ticket;
                    string roles = ticket.UserData;
                    string[] chkRoles = this.Role.Split(',');
                    bool isAuthorized = false;
                    if (Array.IndexOf(chkRoles, roles) > -1)
                        isAuthorized = true;
                    else
                        isAuthorized = false;

                    if (!isAuthorized)
                        filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary(new { controller = "Manage", action = "AdminLogin" }));
                    //throw new UnauthorizedAccessException("你没有权限访问该页面");
                }
            }
            else
            {
                throw new InvalidOperationException("没有指定角色");
            }
        }
    }
}