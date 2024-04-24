using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentMotorcycle.Application.Motorcycles.MessageBroker;
using RentMotorcycle.Application.RentalMotorcycles.MessageBroker;

namespace RentMotorcycle.Infrastructure.Providers
{
    public static class RabbitMqConfiguration
    {
        public static IServiceCollection ConfigureRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<AddMotorcycleEventConsumer>();
                x.AddConsumer<AddRentalMotorcycleConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration.GetValue<string>("BrokerConfiguration:Host"),
                        configuration.GetValue<ushort>("BrokerConfiguration:Port"),
                        configuration.GetValue<string>("BrokerConfiguration:VHost"),
                        h =>
                        {
                            h.Username(configuration.GetValue<string>("BrokerConfiguration:User"));
                            h.Password(configuration.GetValue<string>("BrokerConfiguration:Password"));
                        });

                    cfg.ReceiveEndpoint("re-rent-motorcycle", e =>
                    {
                        e.ConfigureConsumer<AddMotorcycleEventConsumer>(context, e => e.UseConcurrentMessageLimit(2));
                        e.ConfigureConsumer<AddRentalMotorcycleConsumer>(context, e => e.UseConcurrentMessageLimit(2));

                        e.Bind("b-rent-motorcycle", it => it.RoutingKey = "rk-rent-motorcycle");
                        e.BindQueue = true;

                        e.PrefetchCount = 4;

                        e.UseMessageRetry(x => x.Incremental(3, TimeSpan.Zero, TimeSpan.FromSeconds(5)));
                    });
                    cfg.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}
