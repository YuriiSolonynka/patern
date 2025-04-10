namespace patern.Models;
public abstract class Sensor
{
    public int Id { get; set; }
    public string Type { get; set; }
    public bool Status { get; set; }
    public int BatteryLevel { get; set; }

    public int HubId { get; set; }
    public Hub Hub { get; set; }

    public bool LowBattery() => BatteryLevel < 20;
}
