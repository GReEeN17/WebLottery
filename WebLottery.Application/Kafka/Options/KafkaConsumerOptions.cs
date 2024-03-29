using Confluent.Kafka;

namespace WebLottery.Application.Kafka.Options;

public class KafkaConsumerOptions
{
    public string BootstrapServers { get; set; }
    public string GroupId { get; set; }
    public string Topic { get; set; }
    public AutoOffsetReset AutoOffsetReset { get; set; } = AutoOffsetReset.Earliest;
}