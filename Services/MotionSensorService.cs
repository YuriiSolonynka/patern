using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patern.Models;
using patern.Services.Interface;
using patern.Repositories.Interface;

namespace patern.Services
{
    public class MotionSensorService : IMotionSensorService
    {
        private readonly IMotionSensorRepository _motionSensorRepository;

        public MotionSensorService(IMotionSensorRepository motionSensorRepository)
        {
            _motionSensorRepository = motionSensorRepository;
        }

        public IEnumerable<object> GetMotionSensors()
        {
            return _motionSensorRepository.GetMotionSensors();
        }

        public object GetMotionSensorById(int id)
        {
            return _motionSensorRepository.GetMotionSensorById(id);
        }

        public void CreateMotionSensor(MotionSensor motionSensor)
        {
            _motionSensorRepository.InsertMotionSensor(motionSensor);
            _motionSensorRepository.Save();
        }

        public void UpdateMotionSensor(MotionSensor motionSensor)
        {
            _motionSensorRepository.UpdateMotionSensor(motionSensor);
            _motionSensorRepository.Save();
        }

        public void DeleteMotionSensor(int id)
        {
            _motionSensorRepository.DeleteMotionSensor(id);
            _motionSensorRepository.Save();
        }

        public void Save()
        {
            _motionSensorRepository.Save();
        }
    }
}