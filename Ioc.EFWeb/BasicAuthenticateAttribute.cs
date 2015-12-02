using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Ioc.EFWeb
{
    public class BasicAuthenticateAttribute : FilterAttribute, IAuthenticationFilter
    {

        public const string AuthorizationHeaderName = "Authorization";
        public const string WwwAuthenticationHeaderName = "WWW-Authenticate";
        public const string BasicAuthenticationScheme = "Basic";

        private static Dictionary<string, string> userAccounters;

        static BasicAuthenticateAttribute()
        {
            userAccounters = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            userAccounters.Add("Foo", "Password");
            userAccounters.Add("Bar", "Password");
            userAccounters.Add("Baz", "Password");
        }

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            IPrincipal user;

            string sessionid = filterContext.HttpContext.Session.SessionID;

            if (CheckIsAuthented(filterContext, out user))
            {
                filterContext.Principal = user;
            }
            else
            {
                string parameter = string.Format("realm=\"{0}\"", filterContext.RequestContext.HttpContext.Request.Url.DnsSafeHost);
                AuthenticationHeaderValue challenge = new AuthenticationHeaderValue(BasicAuthenticationScheme, parameter);
                filterContext.HttpContext.Response.Headers[WwwAuthenticationHeaderName] = challenge.ToString();
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }


        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {

        }

        protected virtual bool CheckIsAuthented(AuthenticationContext filterContext, out IPrincipal user)
        {
            user = filterContext.Principal;

            if (user != null && user.Identity.IsAuthenticated)
                return true;

            string rawValue = filterContext.RequestContext.HttpContext.Request.Headers[AuthorizationHeaderName];

            if (!string.IsNullOrEmpty(rawValue))
            {
                string[] split = rawValue.Split(' ');
                if (split.Length == 2)
                {
                    var token = new AuthenticationHeaderValue(split[0], split[1]);

                    if (token.Scheme == BasicAuthenticationScheme)
                    {
                        string credential = Encoding.Default.GetString(Convert.FromBase64String(token.Parameter));
                        string[] split_ = credential.Split(':');
                        if (split_.Length == 2)
                        {
                            string userName = split[0];
                            string password;

                            if (userAccounters.TryGetValue(userName, out password))
                            {
                                if (password == split[1])
                                {
                                    GenericIdentity identity = new GenericIdentity(userName);
                                    user = new GenericPrincipal(identity, new string[0]);
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}