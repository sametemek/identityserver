using Ext.IdentityServer.Flows.CustomUserRepo;
using Microsoft.Extensions.DependencyInjection;

namespace Ext.IdentityServer.Flows.ImplicitFlow
{
    public static class IdentityServerBuilderImplicitFlowExtensions
    {
        public static IIdentityServerBuilder AddImplicitFlow(this IIdentityServerBuilder builder)
        {
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            builder.AddDeveloperSigningCredential();
            builder.AddInMemoryIdentityResources(ImplicitFlowConfig.GetIdentityResources());
            builder.AddInMemoryApiResources(ImplicitFlowConfig.GetApis());
            builder.AddInMemoryClients(ImplicitFlowConfig.GetClients());

            return builder;
        }
    }
}
