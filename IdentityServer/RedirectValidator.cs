using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace IdentityServer
{
    public class RedirectValidator : IRedirectUriValidator
    {
        // allows arbitrary redirect URIs - only for demo purposes. NEVER USE IN PRODUCTION
        public Task<bool> IsPostLogoutRedirectUriValidAsync(string requestedUri, Client client)
        {
            return Task.FromResult(true);
        }

        public Task<bool> IsRedirectUriValidAsync(string requestedUri, Client client)
        {
            return Task.FromResult(true);
        }
    }
}
