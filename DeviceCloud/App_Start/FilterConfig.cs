﻿using DeviceCloud.Common;
using System.Web;
using System.Web.Mvc;

namespace DeviceCloud
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
           filters.Add(new HandleErrorAttribute());
        }
    }
}
