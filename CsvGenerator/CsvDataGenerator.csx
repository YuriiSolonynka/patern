#r "nuget: CsvHelper, 27.2.1"
#r "nuget: Bogus, 34.0.2"

using System.Globalization;
using System.IO;
using Bogus;
using CsvHelper;

class User {
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
}

class SecurityService {
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
}

class Hub {
    public int Id { get; set; }
    public int UserId { get; set; }
    public int SecurityServiceId { get; set; }
    public string Location { get; set; }
}

class MotionSensor {
    public int Id { get; set; }
    public int HubId { get; set; }
    public int SensitivityLevel { get; set; }
}

class SmokeSensor {
    public int Id { get; set; }
    public int HubId { get; set; }
    public int SmokeDetectionLevel { get; set; }
}

class Notification {
    public int Id { get; set; }
    public int UserId { get; set; }
    public int SecurityServiceId { get; set; }
    public int HubId { get; set; }
    public string Message { get; set; }
}

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

    public int MotionSensorId { get; set; }
    public int MotionSensorHubId { get; set; }
    public int SensitivityLevel { get; set; }

    public int SmokeSensorId { get; set; }
    public int SmokeSensorHubId { get; set; }
    public int SmokeDetectionLevel { get; set; }

}

var faker = new Faker("en");

var records = new List<FullRecord>();

for (int i = 1; i <= 1000; i++) {
    var user = new User {
        Id = i,
        Name = faker.Name.FullName(),
        PhoneNumber = faker.Phone.PhoneNumber("+380#########")
    };

    var service = new SecurityService {
        Id = i,
        Name = faker.Company.CompanyName(),
        PhoneNumber = faker.Phone.PhoneNumber("+380#########")
    };

    var hub = new Hub {
        Id = i,
        UserId = faker.Random.Number(1, 1000),
        SecurityServiceId = faker.Random.Number(1, 1000),
        Location = faker.Address.City()
    };

    var notification = new Notification {
        Id = i,
        UserId = faker.Random.Number(1, 1000),
        SecurityServiceId = faker.Random.Number(1, 1000),
        HubId = faker.Random.Number(1, 1000),
        Message = faker.Lorem.Sentence()
    };

    var motionSensor = new MotionSensor {
        Id = i,
        HubId = faker.Random.Number(1, 1000),
        SensitivityLevel = faker.Random.Number(1, 100)
    };

    var smokeSensor = new SmokeSensor {
        Id = i,
        HubId = faker.Random.Number(1, 1000),
        SmokeDetectionLevel = faker.Random.Number(1, 100)
    };


    records.Add(new FullRecord {
        UserId = user.Id,
        UserName = user.Name,
        UserPhone = user.PhoneNumber,

        SecurityServiceId = service.Id,
        ServiceName = service.Name,
        ServicePhone = service.PhoneNumber,

        HubId = hub.Id,
        HubUserId = hub.UserId,
        HubSecurityServiceId = hub.SecurityServiceId,
        HubLocation = hub.Location,
        
        NotificationId = notification.Id,
        NotificationUserId = notification.UserId,
        NotificationSecurityServiceId = notification.SecurityServiceId,
        NotificationHubId = notification.HubId,
        NotificationMessage = notification.Message,

        MotionSensorId = motionSensor.Id,
        MotionSensorHubId = motionSensor.HubId,
        SensitivityLevel = motionSensor.SensitivityLevel,

        SmokeSensorId = smokeSensor.Id,
        SmokeSensorHubId = smokeSensor.HubId,
        SmokeDetectionLevel = smokeSensor.SmokeDetectionLevel,
    });
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
