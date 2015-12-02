using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ioc.ClaimsBasicMvc.Fillters
{
    public class IocAuthorizeAttribute : AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {

        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

        }
    }
}