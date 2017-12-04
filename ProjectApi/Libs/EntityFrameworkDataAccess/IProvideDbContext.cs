using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDataAccess
{
    public interface IProvideDbContext<TContext>
        where TContext : DbContext
    {
        TContext GetContext();
    }
}
