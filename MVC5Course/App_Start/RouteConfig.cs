using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC5Course
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
           //忽略的路由
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            //要執行的指向
            //controller 要參考的controller名稱
            //action 要參考該controller中的方法名稱

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
