using Confluent.Kafka;

namespace patern;

public class KafkaConsumerRunner
{
    public static void Run()
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            GroupId = "test-consumer-group",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        string topic = "crimes";

        using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
        {
            consumer.Subscribe(topic);
            Console.WriteLine($"[Kafka] Subscribed to topic '{topic}'");

            try
            {
                while (true)
                {
                    var cr = consumer.Consume();
                    Console.WriteLine($"Received message: {cr.Message.Value}");
                }
            }
            catch (OperationCanceledException)
            {
                consumer.Close();
            }
        }
    }
}
