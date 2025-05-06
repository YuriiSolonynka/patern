using patern.Models;
using Confluent.Kafka;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace patern.OutputStrategies;

public class KafkaOutputStrategy : IOutputStrategy
{
    private readonly IProducer<Null, string> _producer;
    private readonly string _topic;

    public KafkaOutputStrategy(IConfiguration configuration)
    {
        var bootstrapServers = configuration["Kafka:BootstrapServers"] ?? "localhost:9092";
        _topic = configuration["Kafka:Topic"] ?? "crimes";

        var config = new ProducerConfig { BootstrapServers = bootstrapServers };
        _producer = new ProducerBuilder<Null, string>(config).Build();
    }

    public void Write(CrimeRecord record)
    {
        var json = JsonSerializer.Serialize(record);
        _producer.Produce(_topic, new Message<Null, string> { Value = json });
        //Console.WriteLine($"Sent to Kafka topic '{_topic}': {json}");
    }
}
