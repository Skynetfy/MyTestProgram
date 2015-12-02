﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ioc.ClaimsBasicMvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin1")]
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