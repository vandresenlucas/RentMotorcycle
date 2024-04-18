using Microsoft.Extensions.DependencyInjection;
using RentMotorcicle.Domain.UserAggregate;
using RentMotorcicle.Repository.Repositories;

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
