﻿using System.Web;
using System.Web.Mvc;

namespace MvcApp_Megapolis_test
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}