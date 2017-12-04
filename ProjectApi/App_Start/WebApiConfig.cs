using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DemoSelfHostedWebApi;
using DemoSelfHostedWebApi.Dependencies;
using ProjectWorkApi;
using SimpleInjector.Integration.WebApi;

namespace ProjectApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            GlobalDependencyContainer.Configure();

            // Set dependency container / resolver
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(GlobalDependencyContainer.Instance);

            // Web API configuration and services
            // config.Filters.Add(GlobalDependencyContainer.Instance.GetInstance<FIFOAuthenticationFilter>());

            AutoMapperConfig.Configure();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            SwaggerConfig.Register(config);
        }
    }
}
