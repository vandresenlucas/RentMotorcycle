using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentMotorcycle.Infrastructure.Providers;
using RentMotorcycle.Infrastructure.Providers.Options;

namespace RentMotorcycle.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.RegisterDatabase(configuration);
            services.ConfigureRabbitMq(configuration);

            services.ConfigureServices();
            services.ConfigureMediatr();

            return services;
        }

        public static IApplicationBuilder Configure(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.AddInitialData();
            EfMigrations(app, configuration);

            return app;
        }

        private static void EfMigrations(IApplicationBuilder app, IConfiguration configuration)
        {
            var efOptions = new EfOptions();
            configuration.GetSection("Ef").Bind(efOptions);

            if (efOptions.EnableMigrations)
            {
                app.RunMigrations();
            }
        }
    }
}
