#r "nuget: CsvHelper, 27.2.1"
#r "nuget: Bogus, 34.0.2"

using System.Globalization;
using System.IO;
using Bogus;
using CsvHelper;

class FullRecord {
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string UserPhone { get; set; }

    public int SecurityServiceId { get; set; }
    public string ServiceName { get; set; }
    public string ServicePhone { get; set; }

    public int HubId { get; set; }
    public int HubUserId { get; set; }
    public int HubSecurityServiceId { get; set; }
    public string HubLocation { get; set; }

    public int NotificationId { get; set; }
    public int NotificationUserId { get; set; }
    public int NotificationSecurityServiceId { get; set; }
    public int NotificationHubId { get; set; }
    public string NotificationMessage { get; set; }

    public int SensorId { get; set; }
    public int SensorHubId { get; set; }
    public string SensorType { get; set; }
    public int? SensitivityLevel { get; set; }
    public int? SmokeDetectionLevel { get; set; }
}

var faker = new Faker("en");
var records = new List<FullRecord>();

for (int i = 1; i <= 1000; i++) {
    var user = new {
        Id = i,
        Name = faker.Name.FullName(),
        Phone = faker.Phone.PhoneNumber("+380#########")
    };

    var service = new {
        Id = i,
        Name = faker.Company.CompanyName(),
        Phone = faker.Phone.PhoneNumber("+380#########")
    };

    var hub = new {
        Id = i,
        UserId = faker.Random.Number(1, 1000),
        ServiceId = faker.Random.Number(1, 1000),
        Location = faker.Address.City()
    };

    var notification = new {
        Id = i,
        UserId = faker.Random.Number(1, 1000),
        ServiceId = faker.Random.Number(1, 1000),
        HubId = faker.Random.Number(1, 1000),
        Message = faker.Lorem.Sentence()
    };

    var isMotion = faker.Random.Bool();

    var sensor = new {
        Id = i,
        HubId = faker.Random.Number(1, 1000),
        Type = isMotion ? "Motion" : "Smoke",
        SensitivityLevel = isMotion ? faker.Random.Number(1, 100) : (int?)null,
        SmokeDetectionLevel = isMotion ? (int?)null : faker.Random.Number(1, 100)
    };

    var record = new FullRecord {
        UserId = user.Id,
        UserName = user.Name,
        UserPhone = user.Phone,

        SecurityServiceId = service.Id,
        ServiceName = service.Name,
        ServicePhone = service.Phone,

        HubId = hub.Id,
        HubUserId = hub.UserId,
        HubSecurityServiceId = hub.ServiceId,
        HubLocation = hub.Location,

        NotificationId = notification.Id,
        NotificationUserId = notification.UserId,
        NotificationSecurityServiceId = notification.ServiceId,
        NotificationHubId = notification.HubId,
        NotificationMessage = notification.Message,

        SensorId = sensor.Id,
        SensorHubId = sensor.HubId,
        SensorType = sensor.Type,
        SensitivityLevel = sensor.SensitivityLevel,
        SmokeDetectionLevel = sensor.SmokeDetectionLevel
    };
    records.Add(record);
}

var directory = Path.Combine("..", "Data");
if (!Directory.Exists(directory))
    Directory.CreateDirectory(directory);

var filePath = Path.Combine(directory, "data.csv");

using (var writer = new StreamWriter(filePath))
using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture)) {
    csv.WriteRecords(records);
}

Console.WriteLine("✅ CSV-файл створено: " + filePath);
