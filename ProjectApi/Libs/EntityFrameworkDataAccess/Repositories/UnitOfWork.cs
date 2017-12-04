using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DataAPI;
using BusinessLogic.Dependencies;
using BusinessLogic.Models;

namespace EntityFrameworkDataAccess.Repositories
{
    
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public EntityFrameworkUnitOfWork(/*IProvideDbContext<FIFOContext> contextProvider, */IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory ?? throw new ArgumentNullException(nameof(repositoryFactory));
        }

        private TRepository GetRepository<TRepository>(ref TRepository variable)
            where TRepository : class
        {
            if (variable != null)
                return variable;

            //variable = _repositoryFactory.CreateRepository<TRepository>(_contextProvider);
            return variable;
        }

        public int Complete()
        {
            return 1; //_context.SaveChanges();
        }

        public void Dispose()
        {
            //_context.Dispose();
        }
    }
}
