public class Notification
{
    public int Id { get; set; }
    public int SensorId { get; set; }
    public string Message { get; set; }
    public DateTime TimeStamp { get; set; }

    public Sensor Sensor { get; set; }
}
