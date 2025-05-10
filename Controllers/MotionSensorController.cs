using Microsoft.AspNetCore.Mvc;
using patern.Models;
using patern.Services.Interface;

namespace patern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotionSensorController : ControllerBase
    {
        private readonly IMotionSensorService _motionSensorService;

        public MotionSensorController(IMotionSensorService motionSensorService)
        {
            _motionSensorService = motionSensorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var motionSensors = _motionSensorService.GetMotionSensors();
            return Ok(motionSensors);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var motionSensor = _motionSensorService.GetMotionSensorById(id);
            if (motionSensor == null) return NotFound();
            return Ok(motionSensor);
        }

        [HttpPost]
        public IActionResult Create(MotionSensor motionSensor)
        {
            _motionSensorService.CreateMotionSensor(motionSensor);
            _motionSensorService.Save();
            return CreatedAtAction(nameof(GetById), new { id = motionSensor.Id }, motionSensor);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, MotionSensor motionSensor)
        {
            if (id != motionSensor.Id) return BadRequest();

            _motionSensorService.UpdateMotionSensor(motionSensor);
            _motionSensorService.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var motionSensor = _motionSensorService.GetMotionSensorById(id);
            if (motionSensor == null) return NotFound();

            _motionSensorService.DeleteMotionSensor(id);
            _motionSensorService.Save();
            return NoContent();
        }
    }
}
