using Microsoft.AspNetCore.Mvc;
using patern.Models;
using patern.Services.Interface;

namespace patern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HubController : ControllerBase
    {
        private readonly IHubService _hubService;

        public HubController(IHubService hubService)
        {
            _hubService = hubService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var hubs = _hubService.GetHubs();
            return Ok(hubs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var hub = _hubService.GetHubById(id);
            if (hub == null) return NotFound();
            return Ok(hub);
        }

        [HttpPost]
        public IActionResult Create(Hub hub)
        {
            _hubService.CreateHub(hub);
            _hubService.Save();
            return CreatedAtAction(nameof(GetById), new { id = hub.Id }, hub);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Hub hub)
        {
            if (id != hub.Id) return BadRequest();

            _hubService.UpdateHub(hub);
            _hubService.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var hub = _hubService.GetHubById(id);
            if (hub == null) return NotFound();

            _hubService.DeleteHub(id);
            _hubService.Save();
            return NoContent();
        }
    }
}
