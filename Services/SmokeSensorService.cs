using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patern.Models;
using patern.Services.Interface;
using patern.Repositories.Interface;

namespace patern.Services
{
    public class SmokeSensorService : ISmokeSensorService
    {
        private readonly ISmokeSensorRepository _smokeSensorRepository;

        public SmokeSensorService(ISmokeSensorRepository smokeSensorRepository)
        {
            _smokeSensorRepository = smokeSensorRepository;
        }

        public IEnumerable<SmokeSensor> GetSmokeSensors()
        {
            return _smokeSensorRepository.GetSmokeSensors();
        }

        public SmokeSensor GetSmokeSensorById(int id)
        {
            return _smokeSensorRepository.GetSmokeSensorById(id);
        }

        public void CreateSmokeSensor(SmokeSensor smokeSensor)
        {
            _smokeSensorRepository.InsertSmokeSensor(smokeSensor);
            _smokeSensorRepository.Save();
        }

        public void UpdateSmokeSensor(SmokeSensor smokeSensor)
        {
            _smokeSensorRepository.UpdateSmokeSensor(smokeSensor);
            _smokeSensorRepository.Save();
        }

        public void DeleteSmokeSensor(int id)
        {
            _smokeSensorRepository.DeleteSmokeSensor(id);
            _smokeSensorRepository.Save();
        }

        public void Save()
        {
            _smokeSensorRepository.Save();
        }
    }
}