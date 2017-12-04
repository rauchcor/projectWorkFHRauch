using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using BusinessLogic.Dependencies;
using BusinessLogic.Exceptions;
using BusinessLogic.ServiceAPI;


namespace Logger
{
    public class ServiceRegistration : IServiceRegistry
    {
        private readonly IConfigProvider _config;

        static ServiceRegistration()
        {
            var ensureSerilogDLL = typeof(log4net.ILog);
        }

        public ServiceRegistration(IConfigProvider config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public void RegisterServices(IDependencyRegistry container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));

            container.RegisterInstance<BusinessLogic.ServiceAPI.ILogger>(new Log4NetLogger());
        }
    }
}
