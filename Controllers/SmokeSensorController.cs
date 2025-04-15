using Microsoft.AspNetCore.Mvc;
using patern.Models;
using patern.Services.Interface;

namespace patern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SmokeSensorController : ControllerBase
    {
        private readonly ISmokeSensorService _smokeSensorService;

        public SmokeSensorController(ISmokeSensorService smokeSensorService)
        {
            _smokeSensorService = smokeSensorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var smokeSensors = _smokeSensorService.GetSmokeSensors();
            return Ok(smokeSensors);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var smokeSensor = _smokeSensorService.GetSmokeSensorById(id);
            if (smokeSensor == null) return NotFound();
            return Ok(smokeSensor);
        }

        [HttpPost]
        public IActionResult Create(SmokeSensor smokeSensor)
        {
            _smokeSensorService.CreateSmokeSensor(smokeSensor);
            _smokeSensorService.Save();
            return CreatedAtAction(nameof(GetById), new { id = smokeSensor.Id }, smokeSensor);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, SmokeSensor smokeSensor)
        {
            if (id != smokeSensor.Id) return BadRequest();

            _smokeSensorService.UpdateSmokeSensor(smokeSensor);
            _smokeSensorService.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var smokeSensor = _smokeSensorService.GetSmokeSensorById(id);
            if (smokeSensor == null) return NotFound();

            _smokeSensorService.DeleteSmokeSensor(id);
            _smokeSensorService.Save();
            return NoContent();
        }
    }
}
