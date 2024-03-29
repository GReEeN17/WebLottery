using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;

namespace WebLottery.Application.Kafka.Services;

public class KafkaConsumerService
{
    private readonly IConsumer<Ignore, string> _consumer;
    
    public KafkaConsumerService(IServiceProvider serviceProvider)
    {
        var config = serviceProvider.GetRequiredService<ConsumerConfig>();
        _consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        _consumer.Subscribe("registration_topic");
    }  
    
    public async Task<string> ConsumeAsync()
    {
        var consumeResult = await Task.Run(() => _consumer.Consume(CancellationToken.None));
        return consumeResult.Message.Value;
    }
}