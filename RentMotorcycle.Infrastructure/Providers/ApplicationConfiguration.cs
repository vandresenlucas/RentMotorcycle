using Microsoft.Extensions.DependencyInjection;
using RentMotorcycle.Application.Deliverymans.Services;
using RentMotorcycle.Application.RentalMotorcycles.Services;
using RentMotorcycle.Data.DeliveryManAggregate;
using RentMotorcycle.Data.MotorcycleAggregate;
using RentMotorcycle.Data.Repositories;
using RentMotorcycle.Data.UserAggregate;
using RentMotorcycle.Domain.RentalMotorcycleAggregate;
using RentMotorcycle.Domain.RentalPlansAggregate;
using RentMotorcycle.Repository.Repositories;

namespace RentMotorcycle.Infrastructure.Providers
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
            services.AddScoped<IDeliverymanRepository, DeliverymanRepository>();
            services.AddScoped<IRentalPlanRepository, RentalPlanRepository>();
            services.AddScoped<IRentalMotorcycleRepository, RentalMotorcycleRepository>();
            
            services.AddScoped<IDeliverymanService, DeliverymanService>();
            services.AddScoped<IRentalMotorcycleService, RentalMotorcycleService>();

            return services;
        }
    }
}
