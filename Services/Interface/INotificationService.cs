using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patern.Models;

namespace patern.Services.Interface
{
    public interface INotificationService
    {
        IEnumerable<object> GetNotifications();
        object GetNotificationById(int id);
        void CreateNotification(Notification notification);
        void UpdateNotification(Notification notification);
        void DeleteNotification(int id);
        void Save();
    }
}