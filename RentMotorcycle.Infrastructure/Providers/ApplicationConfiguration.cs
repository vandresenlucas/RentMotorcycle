using Microsoft.Extensions.DependencyInjection;
using RentMotorcycle.Data.MotorcycleAggregate;
using RentMotorcycle.Domain.UserAggregate;
using RentMotorcycle.Repository.Repositories;

namespace RentMotorcycle.Infrastructure.Providers
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();

            return services;
        }
    }
}
