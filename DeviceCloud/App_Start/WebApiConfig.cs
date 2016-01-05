using DeviceCloud.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace DeviceCloud
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
              new QueryStringMapping("datatype", "json", "application/json"));

            config.Filters.Add(new ApiResultAttribute());
            config.Filters.Add(new ApiErrorHandleAttribute());
            // Web API 路由
            config.MapHttpAttributeRoutes();
            //新加的规则  
            config.Routes.MapHttpRoute(
             name: "DefaultApi2",
               routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //新加的规则  
            config.Routes.MapHttpRoute(
                name: "DefaultApi1",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
