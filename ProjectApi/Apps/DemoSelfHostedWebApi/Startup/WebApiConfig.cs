using System;
using System.Web.Http;
using BusinessLogic.ServiceAPI;
using DemoSelfHostedWebApi;
using DemoSelfHostedWebApi.Dependencies;
using Microsoft.Owin;
using Owin;
using SimpleInjector.Integration.WebApi;

namespace ProjectWorkApi
{
    public class WebApiConfig
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
