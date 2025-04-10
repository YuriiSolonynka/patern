using System.Collections.Generic;
using patern.Models;

namespace patern.Repositories.Interface
{
    public interface ISmokeSensorRepository : IDisposable
    {
        IEnumerable<SmokeSensor> GetSmokeSensors();
        SmokeSensor GetSmokeSensorById(int id);
        void InsertSmokeSensor(SmokeSensor smokeSensor);
        void UpdateSmokeSensor (SmokeSensor smokeSensor);
        void DeleteSmokeSensor(int id);
        void Save();
    }
}