﻿using System.Web;
using System.Web.Mvc;

namespace Ioc.Ninject
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}