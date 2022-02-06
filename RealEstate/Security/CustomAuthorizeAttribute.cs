using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using RealEstate.DataAccess;
using RealEstate.ModelBase;
using RealEstate.Models;

namespace RealEstate.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(SessionPersister.Email))
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new
                    {
                        controller = "User",
                        action = "Login"
                    }));
            else
            {
                User user = new User();
                user = UserDAL.Methods.GetByEmail(SessionPersister.Email);
                CustomPrincipal mp = new CustomPrincipal(user);
                if (!mp.IsInRole(Roles))
                    filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new
                        {
                            controller = "User",
                            action = "AuthorizationFailed"
                        }));
            }
        }
    }
}