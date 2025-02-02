﻿using PersonelMVCUI.App_Start;
using PersonelMVCUI.Filters;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PersonelMVCUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalFilters.Filters.Add(new ElmahExceptionFilter());
            GlobalFilters.Filters.Add(new HandleErrorAttribute());
        }
    }
}
