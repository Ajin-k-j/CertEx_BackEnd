using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CertExBackend.Services;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentStatsController : ControllerBase
    {
        private readonly IDepartmentStatsService _service;

        public DepartmentStatsController(IDepartmentStatsService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentStats(int id)
        {
            var stats = await _service.GetDepartmentStatsAsync(id);
            if (stats == null)
            {
                return NotFound();
            }
            return Ok(stats);
        }
    }
}
