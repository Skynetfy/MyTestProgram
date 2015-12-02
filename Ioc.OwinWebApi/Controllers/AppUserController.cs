using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Ioc.OwinWebApi.Code.OwinLogin;
using Ioc.OwinWebApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Ioc.OwinWebApi.Controllers
{
    public class AppUserController : Controller
    {
        private AppUserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        // GET: AppUser
        [Authorize]
        public ActionResult Index()
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var identity1 = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var claims1 = identity1.Claims;
            var ctx = HttpContext.GetOwinContext();
            ClaimsPrincipal user = ctx.Authentication.User;
            IEnumerable<Claim> claims2 = user.Claims;
            //AuthenticationManager.SignOut();
            //var user = UserManager.Users;

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (Request.IsAuthenticated)
                return RedirectToAction("Index", "AppUser");
            return View();
        }


        private AppUser CheckUser(string username, string password)
        {
            List<AppUser> Users = new List<AppUser>()
            {
                new AppUser()
                {
                    UserName= "skynet",
                    PasswordHash = "123456"
                },
                new AppUser() {
                    UserName= "skynet1",
                    PasswordHash = "12345678"
                }
            };

            var user = new AppUser
            {
                UserName = username,
                PasswordHash = password
            };
            bool bl = false;
            Users.ForEach(x =>
            {
                if (x.UserName.Equals(user.UserName) && x.PasswordHash.Equals(x.PasswordHash))
                    bl = true;
            });
            if (bl)
                return user;
            else
                return null;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(string username, string password, string returnUrl)
        {
            AppUser user = CheckUser(username, password);
            //AppUser user = await UserManager.FindAsync(username, password);
            if (user == null)
            {
                ModelState.AddModelError("", "无效的用户名或密码");
            }
            else
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                //claims.Add(new Claim(ClaimTypes.Email, user.Email));
                claims.Add(new Claim(ClaimTypes.Role, "administrator"));
                var claimsIdentity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                //  var claimsIdentity =
                //await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = false }, claimsIdentity);
                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
            }
            return View("Index");
            //return Redirect(returnUrl);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(string username, string password, string email, string cfield)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = username, Email = email, CusField = cfield };
                //传入Password并转换成PasswordHash
                IdentityResult result = await UserManager.CreateAsync(user,
                    password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                //AddErrorsFromResult(result);
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            AppUser user = await UserManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await UserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                return View("Error", result.Errors);
            }
            return View("Error", new[] { "User Not Found" });
        }

    }
}