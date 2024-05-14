using Microsoft.Extensions.DependencyInjection;

namespace PeopleManager.Sdk.Extensions
{
    public static class ServicesCollectionExtention
    {
        public static IServiceCollection AddApi(this IServiceCollection services, string api)
        {
            services.AddHttpClient("PeopleManagerApi",client =>
            {
                client.BaseAddress = new Uri(api);
            });
            services.AddScoped<IdentitySdk>();
            services.AddScoped<PeopleSdk>();
            services.AddScoped<OrganizationSdk>();
            return services;
        }
    }
}
