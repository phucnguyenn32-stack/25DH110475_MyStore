
using System.Web.Mvc;

namespace _25DH110475_MyStore.Areas.Admin.Filters
{
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            if (httpContext == null)
                return false;

            var session = httpContext.Session;

            return session != null
                && session["Username"] != null
                && session["UserRole"] != null
                && session["UserRole"].ToString() == "A";
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary
                {
                    { "area", "Admin" },
                    { "controller", "Account" },
                    { "action", "Login" }
                });
        }
    }
}
