﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PlanUp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional});

            routes.MapRoute(
                name: "Movies",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Movie", action = "Index", id = UrlParameter.Optional}
            );
            routes.MapRoute(
                name: "Music",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Music", action = "Index", id = UrlParameter.Optional}
            );
            ;
        }
    }
}