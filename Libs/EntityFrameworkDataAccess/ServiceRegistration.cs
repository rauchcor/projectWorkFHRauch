using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BusinessLogic.Dependencies;
using BusinessLogic.ServiceAPI;
using EntityFrameworkDataAccess.Repositories;
using BusinessLogic.DataAPI;
using BusinessLogic.Models;
using BusinessLogic.Services;

namespace EntityFrameworkDataAccess
{
    public class ServiceRegistration : IServiceRegistry
    {
        static ServiceRegistration()
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        private readonly IConfigProvider _config;

        public ServiceRegistration(IConfigProvider config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public void RegisterServices(IDependencyRegistry container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));


        }
    }
}
