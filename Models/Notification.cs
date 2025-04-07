public class Notification
{
    public int Id { get; set; }
    public int SensorId { get; set; }
    public string Message { get; set; }
    public DateTime TimeStamp { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
    public int SecurityServiceId { get; set; }
    public SecurityService SecurityService { get; set; }
    public int HubId { get; set; }
    public Hub Hub { get; set; }
}
