using Microsoft.Extensions.DependencyInjection;

namespace RentMotorcycle.Infrastructure.Providers
{
    public static class MediatorConfiguration
    {
        public static IServiceCollection ConfigureMediatr(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("RentMotorcycle.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            return services;
        }
    }
}
