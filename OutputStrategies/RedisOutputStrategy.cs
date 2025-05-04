using patern.Models;
using StackExchange.Redis;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace patern.OutputStrategies;

public class RedisOutputStrategy : IOutputStrategy
{
    private readonly IDatabase _db;

    public RedisOutputStrategy(IConfiguration configuration)
    {
        var connectionString = configuration["Redis:ConnectionString"] ?? "localhost";
        var redis = ConnectionMultiplexer.Connect(connectionString);
        _db = redis.GetDatabase();
    }

    public void Write(CrimeRecord record)
    {
        var json = JsonSerializer.Serialize(record);
        _db.ListRightPush("crimes", json);
    }
}
