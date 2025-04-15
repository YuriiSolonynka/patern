using patern.Services.Interface;
using CsvHelper;
using System.Globalization;
using patern.Models;
using Microsoft.EntityFrameworkCore;

namespace patern.Services;
public class CsvImportService : ICsvImportService
{
    private readonly ApplicationContext _context;
    private static bool _dataAlreadyImported = false;

    public CsvImportService(ApplicationContext context)
    {
        _context = context;
    }

    public bool ImportData()
    {
        if (_dataAlreadyImported)
            return false;

        _context.SmokeSensors.RemoveRange(_context.SmokeSensors);
        _context.MotionSensors.RemoveRange(_context.MotionSensors);
        _context.Notifications.RemoveRange(_context.Notifications);
        _context.Hubs.RemoveRange(_context.Hubs);
        _context.SecurityServices.RemoveRange(_context.SecurityServices);
        _context.Users.RemoveRange(_context.Users);
        _context.SaveChanges();

        using var reader = new StreamReader(Path.Combine("Data", "data.csv"));
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<FullRecord>().ToList();

        var users = new Dictionary<int, User>();
        var services = new Dictionary<int, SecurityService>();
        var hubs = new Dictionary<int, Hub>();
        var sensors = new Dictionary<int, Sensor>();
        var notifs = new Dictionary<int, Notification>();

        foreach (var r in records)
        {
            if (!users.ContainsKey(r.UserId))
            {
                users[r.UserId] = new User
                {
                    Id = r.UserId,
                    Name = r.UserName,
                    PhoneNumber = r.UserPhone
                };
            }

            if (!services.ContainsKey(r.SecurityServiceId))
            {
                services[r.SecurityServiceId] = new SecurityService
                {
                    Id = r.SecurityServiceId,
                    ServiceName = r.ServiceName,
                    ContactNumber = r.ServicePhone
                };
            }

            if (!hubs.ContainsKey(r.HubId))
            {
                hubs[r.HubId] = new Hub
                {
                    Id = r.HubId,
                    UserId = r.HubUserId,
                    SecurityServiceId = r.HubSecurityServiceId,
                    Location = r.HubLocation
                };
            }

            if (r.SensorType == "Motion" && !sensors.ContainsKey(r.SensorId))
            {
                sensors[r.SensorId] = new MotionSensor
                {
                    Id = r.SensorId,
                    HubId = r.SensorHubId,
                    SensorType = r.SensorType,
                    SensitivityLevel = r.SensitivityLevel ?? 0
                };
            }

            if (r.SensorType == "Smoke" && !sensors.ContainsKey(r.SensorId))
            {
                sensors[r.SensorId] = new SmokeSensor
                {
                    Id = r.SensorId,
                    HubId = r.SensorHubId,
                    SensorType = r.SensorType,
                    SmokeLevel = r.SmokeDetectionLevel ?? 0
                };
            }

            if (!notifs.ContainsKey(r.NotificationId))
            {
                notifs[r.NotificationId] = new Notification
                {
                    Id = r.NotificationId,
                    UserId = r.NotificationUserId,
                    SecurityServiceId = r.NotificationSecurityServiceId,
                    HubId = r.NotificationHubId,
                    Message = r.NotificationMessage
                };
            }
        }

        using var transaction = _context.Database.BeginTransaction();

        try
        {
            _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [Users] ON");
            _context.Users.AddRange(users.Values);
            _context.SaveChanges();
            _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [Users] OFF");

            _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [SecurityServices] ON");
            _context.SecurityServices.AddRange(services.Values);
            _context.SaveChanges();
            _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [SecurityServices] OFF");

            _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [Hubs] ON");
            _context.Hubs.AddRange(hubs.Values);
            _context.SaveChanges();
            _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [Hubs] OFF");

            _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [Sensors] ON");
            _context.Sensors.AddRange(sensors.Values);
            _context.SaveChanges();
            _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [Sensors] OFF");

            _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [Notifications] ON");
            _context.Notifications.AddRange(notifs.Values);
            _context.SaveChanges();
            _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [Notifications] OFF");

            transaction.Commit();
            _dataAlreadyImported = true;
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ SaveChanges failed: " + ex.Message);
            if (ex.InnerException != null)
                Console.WriteLine("🔍 Inner: " + ex.InnerException.Message);
            throw;
        }
    }
}
