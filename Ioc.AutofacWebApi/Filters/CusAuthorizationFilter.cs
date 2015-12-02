using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Ioc.AutofacWebApi.Filters
{
    public class CusAuthorizationFilter : IAuthorizationFilter, IAuthenticationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {

        }

        public void OnAuthentication(AuthenticationContext filterContext)
        {

        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {

        }
    }
}