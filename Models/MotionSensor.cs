public class MotionSensor : Sensor
{
    public int SensitivityLevel { get; set; }
    public float DetectionRange { get; set; }

    public bool DetectMotion() => true; // Заглушка
}
