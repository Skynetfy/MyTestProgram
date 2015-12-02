using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ioc.Business;
using Ioc.Data.NHibernate;
using HZLogger.NLogWrapper;

namespace Ioc.WebUI.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {

           HZLogger.NLogWrapper.HZLogger.Debug("Debuging Info.");
           HZLogger.NLogWrapper.HZLogger.Info("Info Info");
           HZLogger.NLogWrapper.HZLogger.Trace("Trace Info");
           HZLogger.NLogWrapper.HZLogger.Warn("Warn Info");
           HZLogger.NLogWrapper.HZLogger.Fatal("Fatel Info");
           HZLogger.NLogWrapper.HZLogger.Error("Error Message");
            UserProfileBusiness business = new UserProfileBusiness();
            var r = business.GeUserProfileList(x => true);
            return View();
        }
    }
}