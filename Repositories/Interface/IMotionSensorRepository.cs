using System.Collections.Generic;
using patern.Models;

namespace patern.Repositories.Interface
{
    public interface IMotionSensorRepository : IDisposable
    {
        IEnumerable<MotionSensor> GetMotionSensors();
        MotionSensor GetMotionSensorById(int id);
        void InsertMotionSensor(MotionSensor motionSensor);
        void UpdateMotionSernsor (MotionSensor motionSensor);
        void DeleteMotionSensor(int id);
        void Save();
    }
}