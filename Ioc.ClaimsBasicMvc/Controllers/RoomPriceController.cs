using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ioc.ClaimsBasicMvc.Models;
using Newtonsoft.Json;

namespace Ioc.ClaimsBasicMvc.Controllers
{
    public class RoomPriceController : ApiController
    {

        public string Get()
        {
            return "values";
        }

        [HttpGet]
        public HttpResponseMessage GetJson(string order,string sort)
        {
            AccorOTADBEntities db = new AccorOTADBEntities();
            var list = db.OTA_RoomPriceDataCache.ToList();
            BootstrapTableEntity<OTA_RoomPriceDataCache> bList = new BootstrapTableEntity<OTA_RoomPriceDataCache>();
            bList.total = list.Count;
            bList.rows = list;
            string json = JsonConvert.SerializeObject(bList, Formatting.Indented);
            db.Dispose();
            return new HttpResponseMessage { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json") };
        }


    }
}
