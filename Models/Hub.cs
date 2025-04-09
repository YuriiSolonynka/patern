using Microsoft.Net.Http.Headers;

public class Hub
{
    public int Id { get; set; }
    public string Location { get; set; }

    public int UserId{ get; set; }
    public User User { get; set; }
    public int SecurityServiceId{ get; set; }
    public SecurityService SecurityService { get; set; }
    public ICollection<Sensor> Sensors { get; set; } = new List<Sensor>();
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
