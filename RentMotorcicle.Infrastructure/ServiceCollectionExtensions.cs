﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentMotorcicle.Infrastructure.Providers;
using RentMotorcicle.Infrastructure.Providers.Options;

namespace RentMotorcicle.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.RegisterDatabase(configuration);

            services.ConfigureServices();

            return services;
        }

        public static IApplicationBuilder Configure(this IApplicationBuilder app, IConfiguration configuration)
        {
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
