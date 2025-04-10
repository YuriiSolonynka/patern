using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patern.Repositories.Interface;
using patern.Models;

namespace patern.Repositories
{
    public class SecurityServiceRepository : ISecurityServiceRepository, IDisposable
    {
        private readonly ApplicationContext _context;

        public SecurityServiceRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<SecurityService> GetSecurityServices()
        {
            return _context.SecurityServices.ToList();
        }

        public SecurityService GetSecurityServiceById(int id)
        {
            return _context.SecurityServices.Find(id);
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