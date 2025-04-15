using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using patern.Services.Interface;

namespace patern.Controllers
{
    [ApiController]
    [Route("api/csv")]
    public class CsvImportController : ControllerBase
    {
        private readonly ICsvImportService _csvImportService;

        public CsvImportController(ICsvImportService csvImportService)
        {
            _csvImportService = csvImportService;
        }

        [HttpPost("writedata")]
        public IActionResult WriteData()
        {
            var success = _csvImportService.ImportData();
            if (!success)
                return BadRequest("Data has already been imported before.");
            
            return Ok("Data has been successfully imported.");
        }
    }
}
