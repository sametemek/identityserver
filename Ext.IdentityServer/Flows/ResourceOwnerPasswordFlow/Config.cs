using System.Collections.Generic;
using IdentityServer4.Models;

namespace Ext.IdentityServer.Flows.ResourceOwnerPasswordFlow
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            //var customProfile = new IdentityResource(
            //    name: "custom.profile",
            //    displayName: "Custom profile",
            //    claimTypes: new[] { "name", "email", });

            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                //customProfile

            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("backend.api", "Identity Server Backend Api")
                {
                    ApiSecrets =
                    {
                        new Secret("TopSecret".Sha256()),
                    }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                //new Client
                //{
                //    ClientId = "client",
                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    ClientSecrets =
                //    {
                //        new Secret("secret".Sha256())
                //    },
                //    AllowedScopes = {"api1"}
                //},
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "backend.api" }
                },
                //new Client
                //{
                //    ClientId = "mvc",
                //    ClientName = "MVC Client",
                //    AllowedGrantTypes = GrantTypes.Implicit,
                //    RedirectUris = { "http://localhost:5002/signin-oidc" },
                //    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },
                //    AllowedScopes = new List<string>
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile
                //    }
                //}
            };
        }
    }
}
