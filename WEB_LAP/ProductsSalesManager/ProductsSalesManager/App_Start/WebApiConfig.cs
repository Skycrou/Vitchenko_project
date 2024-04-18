using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProductsSalesManager
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
                routeTemplate: "api/{controller}/GrossProfit={GrossProfit}~RealizationProduct={RealizationProduct}",
                defaults: new
                {
                    GrossProfit = RouteParameter.Optional,
                    RealizationProduct = RouteParameter.Optional
                }
            );
        }
    }
}
