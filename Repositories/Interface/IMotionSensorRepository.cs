using System.Collections.Generic;
using patern.Models;

namespace patern.Repositories.Interface
{
    public interface IMotionSensorRepository : IDisposable
    {
        IEnumerable<object> GetMotionSensors();
        object GetMotionSensorById(int id);
        void InsertMotionSensor(MotionSensor motionSensor);
        void UpdateMotionSensor (MotionSensor motionSensor);
        void DeleteMotionSensor(int id);
        void Save();
    }
}