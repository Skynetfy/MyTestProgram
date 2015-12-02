using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using OAuth;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.MicrosoftAccount;

namespace Ioc.EFWeb
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class OAuthAuthenticateAttribute : FilterAttribute, IAuthenticationFilter, IActionFilter
    {
        public const string CookieName = "AccessToken";
        public string CaptureTokenUri { get; private set; }

        public OAuthAuthenticateAttribute(string captureTokenUri)
        {
            CaptureTokenUri = captureTokenUri;
        }

        //public Task AuthenticateAsync(AuthenticationContext filterContext, CancellationToken cancellationToken)
        //{
        //    return Task.FromResult<object>(null);
        //}

        //public Task ChallengeAsync(AuthenticationChallengeContext filterContext, CancellationToken cancellationToken)
        //{
        //    string accessToken;
        //    if(filterContext.HttpContext.Request)
        //}

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
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