using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patern.Repositories.Interface;
using patern.Models;
#pragma warning disable CS8603

namespace patern.Repositories
{
    public class SmokeSensorRepository : ISmokeSensorRepository, IDisposable
    {
        private readonly ApplicationContext _context;

        public IEnumerable<object> GetSmokeSensors()
        {
            return _context.Sensors
                .OfType<SmokeSensor>()
                .Select(s => new
                {
                    s.Id,
                    s.HubId,
                    s.SmokeLevel,
                    SensorType = "Smoke"
                })
                .ToList();
        }

        public object GetSmokeSensorById(int id)
        {
            return _context.Sensors
                .OfType<SmokeSensor>()
                .Where(s => s.Id == id)
                .Select(s => new
                {
                    s.Id,
                    s.HubId,
                    s.SmokeLevel,
                    SensorType = "Smoke"
                })
                .FirstOrDefault();
        }

        public void InsertSmokeSensor(SmokeSensor smokeSensor)
        {
            _context.SmokeSensors.Add(smokeSensor);
        }

        public void DeleteSmokeSensor(int id)
        {
            var smokeSensor = _context.SmokeSensors.Find(id);
            if (smokeSensor != null)
                _context.SmokeSensors.Remove(smokeSensor);
        }

        public void UpdateSmokeSensor(SmokeSensor smokeSensor)
        {
            _context.SmokeSensors.Update(smokeSensor);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }   
    }
}