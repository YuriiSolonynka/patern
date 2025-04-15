using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patern.Repositories.Interface;
using patern.Models;
#pragma warning disable CS8603


namespace patern.Repositories
{
    public class NotificationRepository : INotificationRepository, IDisposable
    {  
       private readonly ApplicationContext _context;

        public NotificationRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<object> GetNotifications()
        {
            return _context.Notifications
            .Select(n => new {
                n.Id,
                n.Message,
                n.TimeStamp,
                n.UserId,
                n.SecurityServiceId,
                n.HubId
            })
            .ToList();
        }

        public object GetNotificationById(int id)
        {
            return _context.Notifications
            .Where(n => n.Id == id)
            .Select(n => new {
                n.Id,
                n.Message,
                n.TimeStamp,
                User = n.UserId,
                SecurityService = n.SecurityServiceId,
                Hub = n.HubId
            })
            .FirstOrDefault();
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