using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApplication1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "PlayersApi",
                routeTemplate: "api/v1/{controller}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "RegistrationApi",
                routeTemplate: "api/v1/{controller}"
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
