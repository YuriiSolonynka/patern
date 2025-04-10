using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patern.Repositories.Interface;
using patern.Models;

namespace patern.Repositories
{
    public class MotionSensorRepository : IMotionSensorRepository, IDisposable
    {
        private readonly ApplicationContext _context;

        public MotionSensorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<MotionSensor> GetMotionSensors()
        {
            return _context.MotionSensors.ToList();
        }

        public MotionSensor GetMotionSensorById(int id)
        {
            return _context.MotionSensors.Find(id);
        }

        public void InsertMotionSensor(MotionSensor motionSensor)
        {
            _context.MotionSensors.Add(motionSensor);
        }

        public void DeleteMotionSensor(int id)
        {
            var motionSensor = _context.MotionSensors.Find(id);
            if (motionSensor != null)
                _context.MotionSensors.Remove(motionSensor);
        }

        public void UpdateMotionSensor(MotionSensor motionSensor)
        {
            _context.MotionSensors.Update(motionSensor);
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