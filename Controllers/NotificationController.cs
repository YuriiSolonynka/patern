using Microsoft.AspNetCore.Mvc;
using patern.Models;
using patern.Services.Interface;

namespace patern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var notifications = _notificationService.GetNotifications();
            return Ok(notifications);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var notification = _notificationService.GetNotificationById(id);
            if (notification == null) return NotFound();
            return Ok(notification);
        }

        [HttpPost]
        public IActionResult Create(Notification notification)
        {
            _notificationService.CreateNotification(notification);
            _notificationService.Save();
            return CreatedAtAction(nameof(GetById), new { id = notification.Id }, notification);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Notification notification)
        {
            if (id != notification.Id) return BadRequest();

            _notificationService.UpdateNotification(notification);
            _notificationService.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var notification = _notificationService.GetNotificationById(id);
            if (notification == null) return NotFound();

            _notificationService.DeleteNotification(id);
            _notificationService.Save();
            return NoContent();
        }
    }
}
