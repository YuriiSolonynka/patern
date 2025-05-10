using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patern.Models;

namespace patern.Services.Interface
{
    public interface IMotionSensorService
    {
        IEnumerable<object> GetMotionSensors();
        object GetMotionSensorById(int id);
        void CreateMotionSensor(MotionSensor motionSensor);
        void UpdateMotionSensor(MotionSensor motionSensor);
        void DeleteMotionSensor(int id);
        void Save();
    }
}