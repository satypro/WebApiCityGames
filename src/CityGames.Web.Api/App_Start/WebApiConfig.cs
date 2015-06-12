using CityGames.Common.Logging;
using CityGames.Web.Common;
using CityGames.Web.Common.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using System.Web.Http.Tracing;

namespace CityGames.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           // config.MapHttpAttributeRoutes();

            var constraintResolver = new DefaultInlineConstraintResolver();
            constraintResolver.ConstraintMap.Add("apiVersionConstraint", typeof(ApiVersionConstraint));

            config.MapHttpAttributeRoutes(constraintResolver);
            config.Services.Replace(typeof(IHttpControllerSelector), new NamespaceHttpControllerSelector(config));
            
            //Diagnostic Tracing
            config.EnableSystemDiagnosticsTracing();
            config.Services.Replace(typeof(ITraceWriter), new SimpleTraceWriter(WebContainerManager.Get<ILogManager>()));

            log4net.Config.XmlConfigurator.Configure();
           // config.Routes.MapHttpRoute(
           //    name: "FindByTaskNumberRoute",
           //    routeTemplate: "api/{controller}/{taskName}",
           //    defaults: new { taskName = RouteParameter.Optional }
           //);
        
           
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
