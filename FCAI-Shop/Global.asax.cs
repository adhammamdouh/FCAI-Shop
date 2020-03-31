﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FCAI_Shop
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Server.MapPath("~/App_Data/"));

            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            /*GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
                 .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
             GlobalConfiguration.Configuration.Formatters
                 .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);*/
        }
    }
}
