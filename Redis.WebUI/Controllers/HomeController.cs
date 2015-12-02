using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Redis.IDAL;
using Redis.Entities;

namespace Redis.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ICustomerRepository CustomerRepository { get; set; }

        public IOrderRepository OrderRepository { get; set; }

        public ActionResult Index()
        {
            //var customer = new Customer()
            //{
            //    Id=Guid.NewGuid(),
            //    Name = "Skynet"
            //};
            //var result = CustomerRepository.Store(customer);
            //ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult SignalR()
        {
            return View();
        }
    }
}
