using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Dependencies;

namespace Dependencies
{
    public class SimpleInjectorDependencyContainer : IDependencyContainer
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IDependencyContainer RegisterType<TInterface, TImplementation>() where TInterface : class where TImplementation : class, TInterface
        {
            throw new NotImplementedException();
        }

        public IDependencyContainer RegisterType(Type interfaceType, Type implementationType)
        {
            throw new NotImplementedException();
        }

        public IDependencyContainer RegisterInstance<TInterface>(TInterface instance) where TInterface : class
        {
            throw new NotImplementedException();
        }

        public TClassRequested Resolve<TClassRequested>() where TClassRequested : class
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type typeToResolve)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> ResolveAll(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IDependencyContainer GetChildContainer()
        {
            throw new NotImplementedException();
        }
    }
}
