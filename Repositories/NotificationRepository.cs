using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patern.Repositories.Interface;
using patern.Models;

namespace patern.Repositories
{
    public class NotificationRepository : INotificationRepository, IDisposable
    {  
       private readonly ApplicationContext _context;

        public NotificationRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Notification> GetNotifications()
        {
            return _context.Notifications.ToList();
        }

        public Notification GetNotificationById(int id)
        {
            return _context.Notifications.Find(id);
        }

        public void InsertNotification(Notification notification)
        {
            _context.Notifications.Add(notification);
        }

        public void DeleteNotification(int id)
        {
            var notification = _context.Notifications.Find(id);
            if (notification != null)
                _context.Notifications.Remove(notification);
        }

        public void UpdateNotification(Notification notification)
        {
            _context.Notifications.Update(notification);
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