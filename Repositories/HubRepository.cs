using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patern.Models;
using patern.Repositories.Interface;
namespace patern.Repositories
{
    public class HubRepository : IHubRepository, IDisposable
    {
        private readonly ApplicationContext _context;
        public HubRepository(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<Hub> GetHubs()
        {
            return _context.Hubs.ToList();
        }
        public Hub GetHubById(int id)
        {
            return _context.Hubs.Find(id);
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