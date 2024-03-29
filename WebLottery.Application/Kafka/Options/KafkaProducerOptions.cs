using Confluent.Kafka;

namespace WebLottery.Application.Kafka.Options;

public class KafkaProducerOptions
{
    public string BootstrapServers { get; set; }
    public SecurityProtocol SecurityProtocol { get; set; } = SecurityProtocol.SaslSsl;
    public SaslMechanism SaslMechanism { get; set; } = SaslMechanism.Plain;
    public string SaslUsername { get; set; }
    public string SaslPassword { get; set; }
}