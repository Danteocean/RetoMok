using RetoMok.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RetoMok
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.MessageHandlers.Add(new TokenValidationHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
