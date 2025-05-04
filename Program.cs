using System.Globalization;
using CsvHelper;
using Microsoft.Extensions.Configuration;
using patern.Models;
using patern.OutputStrategies;
using System;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();


string selectedStrategy = config["OutputStrategy"];


var outputType = config["OutputStrategy"] ?? "Console";
IOutputStrategy strategy = outputType switch
{
    "Console" => new ConsoleOutputStrategy(),
    "Redis" => new RedisOutputStrategy(config),
    "Kafka" => new KafkaOutputStrategy(config),
    _ => throw new Exception("Invalid output strategy in config")
};


var context = new OutputContext(strategy);

string path = "Crimes_data.csv";
using var reader = new StreamReader(path);
using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

var records = csv.GetRecords<CrimeRecord>();
foreach (var record in records.Take(100))
{
    context.Write(record);
}
