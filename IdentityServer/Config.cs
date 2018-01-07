using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer
{
    public class Config
    {

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("carApi", "Car API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                //mvc Angular
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    RequireConsent = true,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris = { "http://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "carApi"
                    },
                    AllowOfflineAccess = true
                },
                new Client
                {
                    ClientId = "mvcHybrid",
                    ClientName = "MVC Client Hybrid",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    ClientSecrets =
                    {
                        //validate against the hash of the secret
                        new Secret("secret".Sha256())
                    },
                    // where to redirect to after login
                    RedirectUris = { "http://localhost:5002/signin-oidc" },
                    //with this the clients that are logged in get logged out when the logout is triggered somewhere else
                    BackChannelLogoutUri = "http://localhost:5002/signout-oidc",
                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },
                    //With allowOfflineAccess also refresh_token will be send -> there is no refresh_token when using implicit flow
                    AllowOfflineAccess =true,

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "carApi"
                    }
                },

                // OpenID Connect implicit flow client (Angular)
                new Client
                {
                    ClientId = "ng",
                    ClientName = "Angular Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    //token are send to the browser -- in the implicit flow the access_token is send as a result of the authentication
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = true,

                    RedirectUris = { "http://localhost:4427/callback" },
                    PostLogoutRedirectUris = { "http://localhost:4427/home" },
                    AllowedCorsOrigins = { "http://localhost:4427" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "carApi"
                    },
                }

            };
        }
    }
}
