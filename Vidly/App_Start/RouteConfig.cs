using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();//開起比較好的route方式 =>"AttributeRoutes"

            //MapRoute的讀取順序由上而下，因此把越詳細的MapRoute放上面，越一般MapRoute放越下面


            //routes.MapRoute(
            //    name:"MoviesByReleaseDate",
            //    url:"movies/released/{year}/{month}",
            //    defaults: new { controller = "Movies", action = "ByReleaseDate" },
            //    constraints:new { year=@"2015|2016",month = @"\d{2}" }
            //    );
            //=>這邊有缺陷:action name寫死的，如果controller那邊改了這邊不會改，所以註解之，改用AttributeRoutes

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
