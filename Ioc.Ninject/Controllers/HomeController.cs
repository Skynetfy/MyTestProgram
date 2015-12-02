using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ioc.Serivce;
using Ninject;

namespace Ioc.Ninject.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userSerivice;

        public HomeController(IUserService userSerivice)
        {
            this._userSerivice = userSerivice;
        }

        public ActionResult Index()
        {
            var user = _userSerivice.GetUsers();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}