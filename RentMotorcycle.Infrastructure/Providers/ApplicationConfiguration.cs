using Microsoft.Extensions.DependencyInjection;
using RentMotorcycle.Domain.UserAggregate;
using RentMotorcycle.Repository.Repositories;

namespace RentMotorcycle.Infrastructure.Providers
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
