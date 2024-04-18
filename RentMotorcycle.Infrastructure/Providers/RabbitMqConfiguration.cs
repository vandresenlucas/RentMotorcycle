using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RentMotorcycle.Infrastructure.Providers
{
    public static class RabbitMqConfiguration
    {
        public static IServiceCollection ConfigureRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMassTransit(x =>
            //{
            //    x.AddConsumer<AddMotorcycleEventConsumer>();

            //    x.UsingRabbitMq((context, cfg) =>
            //    {
            //        cfg.Host(configuration.GetValue<string>("BrokerConfiguration:Host"),
            //            configuration.GetValue<ushort>("BrokerConfiguration:Port"),
            //            configuration.GetValue<string>("BrokerConfiguration:VHost"),
            //            h =>
            //            {
            //                h.Username(configuration.GetValue<string>("BrokerConfiguration:User"));
            //                h.Password(configuration.GetValue<string>("BrokerConfiguration:Password"));
            //            });

            //        cfg.Message<AddMotorcycleEvent>(it
            //            => it.SetEntityName("ms-fixed-income-investment-mq"));
            //        cfg.Publish<AddMotorcycleEvent>(e => e.ExchangeType = ExchangeType.Fanout);

            //        cfg.ReceiveEndpoint("ms-fixed-income-investment-mq", e =>
            //        {
            //            e.ConfigureConsumer<AddMotorcycleEventConsumer>(context, e => e.UseConcurrentMessageLimit(2));

            //            e.Bind("ms-fixed-income-investment-ex", it => it.RoutingKey = "fi-investment-mq");
            //            e.BindQueue = true;

            //            e.PrefetchCount = 4;

            //            e.UseMessageRetry(x => x.Incremental(3, TimeSpan.Zero, TimeSpan.FromSeconds(5)));
            //        });
            //        cfg.ConfigureEndpoints(context);
            //    });
            //});

            return services;
        }
    }
}
