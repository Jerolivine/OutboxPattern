using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OutboxPattern.Infrastructure.Configuration.RabbitMQ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutboxPattern.Infrastructure.Configuration
{
    public static partial class Configuration
    {
        public static void AddMassTransitWithRabbitMqTransport(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMqOptions = configuration.GetSection("RabbitMQ").Get<RabbitMQOptions>();

            services.AddMassTransit(x =>
            {
                //x.AddConsumer<MessageConsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri(rabbitMqOptions.Host), h => { });

                    cfg.ReceiveEndpoint("customer-added", e =>
                    {
                        //e.ConfigureConsumer<MessageConsumer>(context);
                    });

                });
            });
        }
    }
}
