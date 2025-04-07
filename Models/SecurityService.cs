public class SecurityService
{
    public int Id { get; set; }
    public string ServiceName { get; set; }
    public string ContactNumber { get; set; }
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    public ICollection<Hub> Hubs { get; set; } = new List<Hub>();
}
