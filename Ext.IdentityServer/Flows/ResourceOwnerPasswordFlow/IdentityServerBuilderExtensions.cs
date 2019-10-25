using Ext.IdentityServer.Flows.CustomUserRepo;
using Microsoft.Extensions.DependencyInjection;

namespace Ext.IdentityServer.Flows.ResourceOwnerPasswordFlow
{
    public static class IdentityServerBuilderResourceOwnerPasswordExtensions
    {
        public static IIdentityServerBuilder AddResourceOwnerPasswordFlow(this IIdentityServerBuilder builder)
        {
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            builder.AddDeveloperSigningCredential();
            builder.AddInMemoryIdentityResources(Config.GetIdentityResources());
            builder.AddInMemoryApiResources(Config.GetApis());
            builder.AddInMemoryClients(Config.GetClients());
            builder.AddProfileService<CustomProfileService>();
            builder.AddResourceOwnerValidator<CustomResourceOwnerPasswordValidator>();

            return builder;
        }
    }
}
