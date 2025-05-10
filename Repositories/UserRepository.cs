using System;
using System.Collections.Generic;
using System.Linq;
using patern.Models;
using patern.Repositories.Interface;
#pragma warning disable CS8603


namespace patern.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<object> GetUsers()
        {
            return _context.Users
            .Select(u => new{
                u.Id,
                u.Name,
                u.PhoneNumber,
                Notifications = u.Notifications.Select(s => s.Id).ToList(),
                Hubs = u.Hubs.Select(u => u.Id).ToList()
            })
            .ToList();
        }

        public object GetUserById(int id)
        {
            return _context.Users
            .Where(u => u.Id == id)
            .Select(u => new{
                u.Id,
                u.Name,
                u.PhoneNumber,
                Notifications = u.Notifications.Select(s => s.Id).ToList(),
                Hubs = u.Hubs.Select(u => u.Id).ToList()
            })
            .FirstOrDefault();
        }

        public void InsertUser(User user)
        {
            _context.Users.Add(user);
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
                _context.Users.Remove(user);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
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