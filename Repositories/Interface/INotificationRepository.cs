using System.Collections.Generic;
using patern.Models;

namespace patern.Repositories.Interface
{
    public interface INotificationRepository : IDisposable
    {
        IEnumerable<Notification> GetNotifications();
        Notification GetNotificationById(int id);
        void InsertNotification(Notification notification);
        void UpdateNotification(Notification notification);
        void DeleteNotification(int id);
        void Save();
    }
}