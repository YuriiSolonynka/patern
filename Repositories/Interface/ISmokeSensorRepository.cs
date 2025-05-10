using System.Collections.Generic;
using patern.Models;

namespace patern.Repositories.Interface
{
    public interface ISmokeSensorRepository : IDisposable
    {
        IEnumerable<object> GetSmokeSensors();
        object GetSmokeSensorById(int id);
        void InsertSmokeSensor(SmokeSensor smokeSensor);
        void UpdateSmokeSensor (SmokeSensor smokeSensor);
        void DeleteSmokeSensor(int id);
        void Save();
    }
}