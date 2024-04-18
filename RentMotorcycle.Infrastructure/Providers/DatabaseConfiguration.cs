using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentMotorcycle.Repository;

namespace RentMotorcycle.Infrastructure.Providers
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RentMotorcycleContext>(options => options.UseNpgsql(configuration.GetConnectionString("Default")));
            services.AddScoped<DbContext, RentMotorcycleContext>();

            return services;
        }

        public static IApplicationBuilder RunMigrations(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<RentMotorcycleContext>();

            context.Database.Migrate();

            return app;
        }
    }
}
