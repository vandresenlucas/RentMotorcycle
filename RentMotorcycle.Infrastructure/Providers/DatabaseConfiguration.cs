using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentMotorcycle.Data.ProfileAggregate;
using RentMotorcycle.Data.UserAggregate;
using RentMotorcycle.Domain.RentalPlansAggregate;
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

        public static IApplicationBuilder AddInitialData(this IApplicationBuilder app)
        {
            using var serviceScop = app.ApplicationServices.CreateScope();
            var context = serviceScop.ServiceProvider.GetService<RentMotorcycleContext>();
            AddInitialData(context);

            return app;
        }

        public static void AddInitialData(RentMotorcycleContext context)
        {
            context.Add(new User("admin", "admin@gmail.com", "teste", Profile.Admin, DateTime.UtcNow));
            context.Add(new RentalPlan(7, 30, DateTime.UtcNow));
            context.Add(new RentalPlan(15, 28, DateTime.UtcNow));
            context.Add(new RentalPlan(30, 22, DateTime.UtcNow));
            context.Add(new RentalPlan(45, 20, DateTime.UtcNow));
            context.Add(new RentalPlan(50, 18, DateTime.UtcNow));

            context.SaveChanges();
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
