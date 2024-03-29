using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;

namespace WebLottery.Application.Kafka.Services;

public class KafkaProducerService
{
    private readonly IProducer<Null, string> _producer;
    
    public KafkaProducerService(IServiceProvider serviceProvider)
    {
        var config = serviceProvider.GetRequiredService<ProducerConfig>();
        _producer = new ProducerBuilder<Null, string>(config).Build();
    }
    
    public async Task ProduceAsync(string topic, string message)
    {
        await _producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
    }
}