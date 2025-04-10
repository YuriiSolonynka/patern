using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patern.Models;
using patern.Services.Interface;
using patern.Repositories.Interface;

namespace patern.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public IEnumerable<Notification> GetNotifications()
        {
            return _notificationRepository.GetNotifications();
        }

        public Notification GetNotificationById(int id)
        {
            return _notificationRepository.GetNotificationById(id);
        }

        public void CreateNotification(Notification notification)
        {
            _notificationRepository.InsertNotification(notification);
            _notificationRepository.Save();
        }

        public void UpdateNotification(Notification notification)
        {
            _notificationRepository.UpdateNotification(notification);
            _notificationRepository.Save();
        }

        public void DeleteNotification(int id)
        {
            _notificationRepository.DeleteNotification(id);
            _notificationRepository.Save();
        }

        public void Save()
        {
            _notificationRepository.Save();
        }
    }
}