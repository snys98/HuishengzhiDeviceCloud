using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DeviceCloud.Areas.Admin
{
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var result = httpContext.Session["sysadmin"] != null;
            if (!result)
                httpContext.Response.StatusCode = 403;
            return result;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (filterContext.HttpContext.Response.StatusCode == 403)
            {
               //RouteCollection routeValue=  new RouteCollection();
               // routeValue.Add(new)
                //routeValue.Add("Area","Admin");
                //string url = UrlHelper.GenerateUrl(null, "Login", "User", null,  {  }, filterContext.RequestContext, false);
                filterContext.Result = new RedirectResult("~/Admin/User/Login");
            }
        }
    }
}