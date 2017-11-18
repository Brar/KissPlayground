using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace AuthServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "NeoKiss",
                    DisplayName = "The NEO-KISS API",

                    Scopes =
                    {
                        new Scope()
                        {
                            Name = "NeoKiss.FullAccess",
                            DisplayName = "Full access to the NEO-KISS API"
                        },
                        new Scope()
                        {
                            Name = "NeoKiss.ReadOnly",
                            DisplayName = "Read only access to the NEO-KISS API"
                        }
                    }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "js",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris =           { "http://localhost:5003/callback.html" },
                    PostLogoutRedirectUris = { "http://localhost:5003/index.html" },
                    AllowedCorsOrigins =     { "http://localhost:5003" },

                    // scopes that client has access to
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "NeoKiss.ReadOnly"
                    }
                }
            };
        }
    }
}
