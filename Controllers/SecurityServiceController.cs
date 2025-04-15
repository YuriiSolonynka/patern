using Microsoft.AspNetCore.Mvc;
using patern.Models;
using patern.Services.Interface;

namespace patern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecurityServiceController : ControllerBase
    {
        private readonly ISecurityServiceService _securityServiceService;

        public SecurityServiceController(ISecurityServiceService securityServiceService)
        {
            _securityServiceService = securityServiceService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var securityServices = _securityServiceService.GetSecurityServices();
            return Ok(securityServices);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var securityService = _securityServiceService.GetSecurityServiceById(id);
            if (securityService == null) return NotFound();
            return Ok(securityService);
        }

        [HttpPost]
        public IActionResult Create(SecurityService securityService)
        {
            _securityServiceService.CreateSecurityService(securityService);
            _securityServiceService.Save();
            return CreatedAtAction(nameof(GetById), new { id = securityService.Id }, securityService);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, SecurityService securityService)
        {
            if (id != securityService.Id) return BadRequest();

            _securityServiceService.UpdateSecurityService(securityService);
            _securityServiceService.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var securityService = _securityServiceService.GetSecurityServiceById(id);
            if (securityService == null) return NotFound();

            _securityServiceService.DeleteSecurityService(id);
            _securityServiceService.Save();
            return NoContent();
        }
    }
}
