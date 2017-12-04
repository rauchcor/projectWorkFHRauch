using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BusinessLogic.Dependencies;
using BusinessLogic.ServiceAPI;

namespace MongoDataAccess
{
    public class ServiceRegistration : IServiceRegistry
    {
        private readonly IConfigProvider _config;

        public ServiceRegistration(IConfigProvider config)
        {
            if (config == null) throw new ArgumentNullException(nameof(config));
            _config = config;
        }

        public void RegisterServices(IDependencyRegistry container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));

            // TODO: Register Repositories
        }
    }
}
