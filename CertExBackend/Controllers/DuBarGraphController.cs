using CertExBackend.DTOs;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuBarGraphController : ControllerBase
    {
        private readonly IDuBarGraphService _duBarGraphService;

        public DuBarGraphController(IDuBarGraphService duBarGraphService)
        {
            _duBarGraphService = duBarGraphService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<DuBarGraphDto>>> GetAll()
        {
            var data = await _duBarGraphService.GetDuBarGraphDataAsync();
            return Ok(data);
        }

        [HttpGet("filtered")]
        public async Task<ActionResult<MonthlyExamCompletionDTO>> GetFiltered(int financialYearId, int? providerId)
        {
            var data = await _duBarGraphService.GetFilteredExamCompletionDataAsync(financialYearId, providerId);
            return Ok(data);
        }
    }
}