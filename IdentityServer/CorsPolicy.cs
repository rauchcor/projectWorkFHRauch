using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Services;

namespace IdentityServer
{
    public class CorsPolicy : ICorsPolicyService
    {
        // allows arbitrary CORS origins - only for demo purposes. NEVER USE IN PRODUCTION
        public Task<bool> IsOriginAllowedAsync(string origin)
        {
            return Task.FromResult(true);
        }
    }
}
