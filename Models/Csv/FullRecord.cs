public class FullRecord
{
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

    public int SensorId { get; set; }
    public string SensorType { get; set; }
    public int SensorHubId { get; set; }

    public int? SensitivityLevel { get; set; }

    public int? SmokeDetectionLevel { get; set; }

    public int NotificationId { get; set; }
    public int NotificationUserId { get; set; }
    public int NotificationSecurityServiceId { get; set; }
    public int NotificationHubId { get; set; }
    public string NotificationMessage { get; set; }
}
