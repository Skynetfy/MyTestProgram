using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ioc.ClaimsBasicMvc.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize(Roles = "dd")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (Request.IsAuthenticated)
                return RedirectToAction("Index", "Admin");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string username,string password,string returnUrl)
        {
            return Redirect(returnUrl);
        }
    }
}