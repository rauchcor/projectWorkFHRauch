using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Dependencies;
using SimpleInjector;

namespace DemoSelfHostedWebApi.Dependencies
{
    public class SimpleInjectorDependencyContainer : IDependencyResolver, IDependencyRegistry
    {
        private readonly Container _container;

        public SimpleInjectorDependencyContainer(Container container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public void Dispose()
        {
            _container?.Dispose();
        }

        public IDependencyRegistry RegisterType<TInterface, TImplementation>() 
            where TInterface : class 
            where TImplementation : class, TInterface
        {
            _container.Register<TInterface, TImplementation>();
            return this;
        }

        public IDependencyRegistry RegisterType(Type interfaceType, Type implementationType)
        {
            if (interfaceType == null) throw new ArgumentNullException(nameof(interfaceType));
            if (implementationType == null) throw new ArgumentNullException(nameof(implementationType));

            _container.Register(interfaceType, implementationType);
            return this;
        }

        public IDependencyRegistry RegisterInstance<TInterface>(TInterface instance) 
            where TInterface : class
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));

            _container.RegisterSingleton<TInterface>(instance);

            return this;
        }

        public TClassRequested Resolve<TClassRequested>() 
            where TClassRequested : class
        {
            return _container.GetInstance<TClassRequested>();
        }

        public object Resolve(Type typeToResolve)
        {
            if (typeToResolve == null) throw new ArgumentNullException(nameof(typeToResolve));
            return _container.GetInstance(typeToResolve);
        }

        public IEnumerable<object> ResolveAll(Type serviceType)
        {
            if (serviceType == null) throw new ArgumentNullException(nameof(serviceType));
            return _container.GetAllInstances(serviceType);
        }
    }
}
