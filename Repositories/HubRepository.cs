using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patern.Models;
using patern.Repositories.Interface;
namespace patern.Repositories
#pragma warning disable CS8603

{
    public class HubRepository : IHubRepository, IDisposable
    {
        private readonly ApplicationContext _context;
        public HubRepository(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<object> GetHubs()
        {
            return _context.Hubs
                .Select(h => new
                {
                    h.Id,
                    h.Location,
                    h.UserId,
                    h.SecurityServiceId,
                    Sensors = h.Sensors.Select(s => s.Id).ToList(),
                    Notifications = h.Notifications.Select(n => n.Id).ToList()
                })
                .ToList();
        }
        public object GetHubById(int id)
        {
            return _context.Hubs
                .Where(h => h.Id == id)
                .Select(h => new
                {
                    h.Id,
                    h.Location,
                    User = h.UserId,
                    SecurityService = h.SecurityServiceId,
                    Sensors = h.Sensors.Select(s => s.Id).ToList(),
                    Notifications = h.Notifications.Select(n => n.Id).ToList()
                })
                .FirstOrDefault();
        }
        public void InsertHub(Hub hub)
        {
            _context.Hubs.Add(hub);
        }
        public void DeleteHub(int id)
        {
            var hub = _context.Hubs.Find(id);
            if (hub != null)
                _context.Hubs.Remove(hub);
        }
        public void UpdateHub(Hub hub)
        {
            _context.Hubs.Update(hub);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if(!_disposed)
            {
                if(disposing)
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