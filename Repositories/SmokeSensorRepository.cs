using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patern.Repositories.Interface;
using patern.Models;

namespace patern.Repositories
{
    public class SmokeSensorRepository : ISmokeSensorRepository, IDisposable
    {
        private readonly ApplicationContext _context;

        public SmokeSensorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<SmokeSensor> GetSmokeSensors()
        {
            return _context.SmokeSensors.ToList();
        }

        public SmokeSensor GetSmokeSensorById(int id)
        {
            return _context.SmokeSensors.Find(id);
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