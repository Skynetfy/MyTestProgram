using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ioc.OwinWebApi.Models
{
    public class AppUser : IdentityUser
    {
        public string CusField { get; set; }
    }
}