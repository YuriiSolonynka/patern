using Microsoft.EntityFrameworkCore;

public class User
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    public ICollection<Hub> Hubs { get; set; } = new List<Hub>();
}
