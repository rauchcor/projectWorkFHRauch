using BusinessLogic.Dependencies;
using BusinessLogic.ServiceAPI;
using ProjectApi;
using ProjectApi.Dependencies;
using SimpleInjector;

namespace DemoSelfHostedWebApi.Dependencies
{
    public class GlobalDependencyContainer
    {
        private static Container _instance;

        public static Container Instance =>
            _instance ?? (_instance = new Container());

        public static void Configure()
        {
            var container = new SimpleInjectorDependencyContainer(Instance);
            Instance.RegisterSingleton<IDependencyResolver>(container);
            var configProvider = new WebConfigProvider();
            container.RegisterType<IConfigProvider, WebConfigProvider>();

            new BusinessLogic.Dependencies.ServiceRegistration().RegisterServices(container);
            new Logger.ServiceRegistration(configProvider).RegisterServices(container);
           

            Instance.Verify();
        }
    }
}