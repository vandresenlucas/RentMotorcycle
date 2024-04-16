using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentMotorcicle.Repository;

namespace RentMotorcicle.Infrastructure.Providers
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RentMotorcicleContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
            services.AddScoped<DbContext, RentMotorcicleContext>();

            return services;
        }

        public static IApplicationBuilder RunMigrations(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<RentMotorcicleContext>();

            context.Database.Migrate();

            return app;
        }
    }
}
