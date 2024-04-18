using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AnalysisManager
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/lastYear={sales_ofLastYear}~" +
                "NewYear={sales_ofNewYear}",
                defaults: new { sales_ofLastYear = RouteParameter.Optional, 
                    sales_ofNewYear = RouteParameter.Optional
                }
            );
        }
    }
}
