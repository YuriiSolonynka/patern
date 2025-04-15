using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patern.Models;

namespace patern.Services.Interface
{
    public interface ISmokeSensorService
    {
        IEnumerable<object> GetSmokeSensors();
        object GetSmokeSensorById(int id);
        void CreateSmokeSensor(SmokeSensor smokeSensor);
        void UpdateSmokeSensor(SmokeSensor smokeSensor);
        void DeleteSmokeSensor(int id);
        void Save();
    }
}