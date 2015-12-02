using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Ajax.Utilities;
using System.Security.Claims;
using System.Web.Http;

namespace Ioc.ClaimsBasicMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            
        }

        protected void Application_AuthenticateRequest()
        {
            var clainms = new List<Claim>();
            clainms.Add(new Claim(ClaimTypes.Name,"Jerry Zhang"));
            clainms.Add(new Claim(ClaimTypes.Role,"admin"));
            var identity = new ClaimsIdentity(clainms,"myClainms");
            //identity.IsAuthenticated = false;

            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            HttpContext.Current.User = principal;
        }
    }
}
