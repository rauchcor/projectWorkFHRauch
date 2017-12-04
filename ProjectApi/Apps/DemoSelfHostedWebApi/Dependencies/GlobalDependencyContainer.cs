using BusinessLogic.Dependencies;
using BusinessLogic.ServiceAPI;
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

            container.RegisterType<IConfigProvider, AppConfigProvider>();
            new BusinessLogic.Dependencies.ServiceRegistration().RegisterServices(container);
            new Logger.ServiceRegistration(new AppConfigProvider()).RegisterServices(container);

            // TODO: Register all Services, Repositories, etc.
            // ...

            Instance.Verify();
        }
    }
}