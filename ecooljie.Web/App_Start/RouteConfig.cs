using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ecooljie.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
         //   routes.MapRoute(
         //    "Admin_default",
         //    "Admin/{controller}/{action}/{id}",
         //    new { action = "Index", id = UrlParameter.Optional },
         //    new string[] { "ecooljie.Web.Areas.Admin.Controllers" }
         //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                   namespaces: new string[] { "ecooljie.Web.Controllers" }
            );          
        }
    }
}
