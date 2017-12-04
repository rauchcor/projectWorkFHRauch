using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;

namespace BusinessLogic.DataAPI
{
    public interface IUnitOfWork : IDisposable
    {
        // TODO: add repositories as need (if certain repository needs a unit of work for roll back
        //IRepository<User> Users { get; }
    }
}
