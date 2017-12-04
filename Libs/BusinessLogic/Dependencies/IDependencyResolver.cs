using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dependencies
{
    public interface IDependencyResolver
    {
        TClassRequested Resolve<TClassRequested>()
            where TClassRequested : class;

        Object Resolve(Type typeToResolve);

        IEnumerable<object> ResolveAll(Type serviceType);
    }
}
