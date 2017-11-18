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
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "NeoKiss.ReadOnly" }
                }
            };
        }
    }
}
