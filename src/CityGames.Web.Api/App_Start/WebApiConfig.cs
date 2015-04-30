﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CityGames.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

           // config.Routes.MapHttpRoute(
           //    name: "FindByTaskNumberRoute",
           //    routeTemplate: "api/{controller}/{taskName}",
           //    defaults: new { taskName = RouteParameter.Optional }
           //);
        
           
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
