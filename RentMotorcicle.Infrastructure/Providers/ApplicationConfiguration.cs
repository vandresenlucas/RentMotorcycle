using Microsoft.Extensions.DependencyInjection;
using RentMotorcicle.Repository;

namespace RentMotorcicle.Infrastructure.Providers
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
