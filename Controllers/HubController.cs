using Microsoft.AspNetCore.Mvc;
using patern.Models;
using patern.Services.Interface;

namespace patern.Controllers
{
    public class HubController : Controller
    {

        private readonly IHubService _hubService;
        private readonly IUserService _userService;
        private readonly ISecurityServiceService _securityServiceService;

        public HubController(IHubService hubService)
        {
            _hubService = hubService;
        }

        public IActionResult Index()
        {
            var hubs = _hubService.GetHubs();
            return View(hubs);
        }

        public IActionResult Details(int id)
        {
            var hub = _hubService.GetHubById(id);
            if (hub == null) return NotFound();
            return View(hub);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Hub hub)
        {
            ModelState.Remove("User");
            ModelState.Remove("SecurityService");
            if (ModelState.IsValid)
            {
                _hubService.CreateHub(hub);
                _hubService.Save();
                Console.Write("controller\n");
                return RedirectToAction(nameof(Index));
            }
            return View(hub);
        }

        public IActionResult Edit(int id)
        {
            var hub = _hubService.GetHubById(id);
            if (hub == null) return NotFound();
            return View(hub);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Hub hub)
        {
            if (id != hub.Id) return NotFound();
            ModelState.Remove("User");
            ModelState.Remove("SecurityService");
            if (ModelState.IsValid)
            {
                _hubService.UpdateHub(hub);
                _hubService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(hub);
        }

        public IActionResult Delete(int id)
        {
            var hub = _hubService.GetHubById(id);
            if (hub == null) return NotFound();
            return View(hub);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _hubService.DeleteHub(id);
            _hubService.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
