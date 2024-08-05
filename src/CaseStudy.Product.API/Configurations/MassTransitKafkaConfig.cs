using CaseStudy.Product.Domain.Models;
using MassTransit;

namespace CaseStudy.Product.API.Configurations;

public static class MassTransitKafkaConfig
{
    public static IServiceCollection AddMassTransitKafkaConfig(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddMassTransit(x =>
        {
            var topicName = configuration.GetSection("Kafka:TopicName").Value;
            var brokerServer = configuration.GetSection("Kafka:BrokeServer").Value;

            x.UsingInMemory((context, cfg) => { cfg.ConfigureEndpoints(context); });

            x.AddRider(rider =>
            {
                rider.AddProducer<ProductEntity>(topicName);
                rider.UsingKafka((context, k) => { k.Host(brokerServer); });
            });
        });

        return services;
    }
}


