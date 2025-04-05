public class Hub
{
    public int Id { get; set; }
    public string Location { get; set; }

    public ICollection<Sensor> ConnectedSensors { get; set; } = new List<Sensor>();
}
