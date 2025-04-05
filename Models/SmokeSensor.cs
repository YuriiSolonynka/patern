public class SmokeSensor : Sensor
{
    public int SmokeLevel { get; set; }
    public bool AlarmTriggered { get; set; }

    public bool DetectSmoke() => SmokeLevel > 50; // Заглушка
}
