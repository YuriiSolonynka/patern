using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patern.Repositories.Interface;
using patern.Models;
#pragma warning disable CS8603


namespace patern.Repositories
{
    public class SecurityServiceRepository : ISecurityServiceRepository, IDisposable
    {
        private readonly ApplicationContext _context;

        public SecurityServiceRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<object> GetSecurityServices()
        {
            return _context.SecurityServices
            .Select(s => new{
                s.Id,
                s.ServiceName,
                s.ContactNumber,
                Notifications = s.Notifications.Select(s => s.Id).ToList(),
                Hubs = s.Hubs.Select(s => s.Id).ToList()
            })
            .ToList();
        }

        public object GetSecurityServiceById(int id)
        {
            return _context.SecurityServices
            .Where(s => s.Id == id)
            .Select(s => new{
                s.Id,
                s.ServiceName,
                s.ContactNumber,
                Notifications = s.Notifications.Select(s => s.Id).ToList(),
                Hubs = s.Hubs.Select(s => s.Id).ToList()
            })
            .FirstOrDefault();
        }

        public void InsertSecurityService(SecurityService securityService)
        {
            _context.SecurityServices.Add(securityService);
        }

        public void DeleteSecurityService(int id)
        {
            var securityService = _context.SecurityServices.Find(id);
            if (securityService != null)
                _context.SecurityServices.Remove(securityService);
        }

        public void UpdateSecurityService(SecurityService securityService)
        {
            _context.SecurityServices.Update(securityService);
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