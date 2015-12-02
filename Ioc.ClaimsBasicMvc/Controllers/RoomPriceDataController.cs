using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ioc.ClaimsBasicMvc.Models;

namespace Ioc.ClaimsBasicMvc.Controllers
{
    public class RoomPriceDataController : Controller
    {
        // GET: RoomPriceData

        [HttpGet]
        public JsonResult GetJson(string search, string sort, string order, int limit = 0, int offset = 0)
        {
            AccorOTADBEntities db = new AccorOTADBEntities();
            var list = db.OTA_RoomPriceDataCache.ToList();
            BootstrapTableEntity<OTA_RoomPriceDataCache> bList = new BootstrapTableEntity<OTA_RoomPriceDataCache>();
            bList.total = list.Count;
            bList.rows = list;
            var jsonResult = new JsonNetResult();
            jsonResult.Data = bList;
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return jsonResult;
        }
    }
}