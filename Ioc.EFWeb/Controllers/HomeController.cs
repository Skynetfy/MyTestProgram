using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ioc.EFWeb.Models;
using System.Web.Mvc.Filters;

namespace Ioc.EFWeb.Controllers
{
    public class HomeController : Controller
    {
        [BasicAuthenticate]
        public ActionResult Index()
        {
            using (Model1 db = new Model1())
            {
                var f = db.OTA_RoomPriceDataCache.ToList();
            }
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