using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ioc.Spring.NET.Models;

namespace Ioc.Spring.NET.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (AccorOTADBEntities db = new AccorOTADBEntities())
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