using MassTransit;
using OutboxPattern.Constants.Constants;
using OutboxPattern.Consumer.Consumers;
using OutboxPattern.Infrastructure.Configuration.RabbitMQ.Model;

namespace OutboxPattern.API.Extensions.Configuration
{
    public static partial class Configuration
    {
        public static void AddMassTransitWithRabbitMqTransport(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMqOptions = configuration.GetSection("RabbitMQ").Get<RabbitMQOptions>();

            services.AddMassTransit(x =>
            {
                x.AddConsumer<CustomerAddedConsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri(rabbitMqOptions.Host), h => { });

                    cfg.ReceiveEndpoint(ExchangeNameConstants.EXCHANGE_CUSTOMER_ADDED, e =>
                    {
                        e.ConfigureConsumer<CustomerAddedConsumer>(context);
                    });

                });
            });
        }
    }
}
