using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Ioc.AutofacWebApi2.Models;

namespace Ioc.AutofacWebApi2.Controllers
{
    public class HomeController : Controller
    {
        [Authenticate]
        public ActionResult Index()
        {
            Response.Write(string.Format("Controller.User： {0}<br/>", this.User.Identity.Name));
            Response.Write(string.Format("HttpContext.User： {0}<br/>", this.ControllerContext.HttpContext.User.Identity.Name));
            Response.Write(string.Format("Thread.CurrentPrincipal： {0}", Thread.CurrentPrincipal.Identity.Name));
            ViewBag.Title = "Home Page";
            var db = new AccorOTADBEntities();
            var q = db.OTA_RoomPriceDataCache.ToList();

            return View();
        }
    }
}
