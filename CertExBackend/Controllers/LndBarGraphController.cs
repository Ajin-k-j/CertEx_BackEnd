using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using CertExBackend.Repository.IRepository;
using System.Threading.Tasks;
namespace CertExBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LndBarGraphController : ControllerBase
    {
        private readonly ILndBarGraphService _lndBarGraphservice;

        public LndBarGraphController(ILndBarGraphService lndBarGraphservice)
        {
            _lndBarGraphservice = lndBarGraphservice;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LndBarGraphDTO>>> GetLndBarGraphData()
        {
            var data = await _lndBarGraphservice.GetLndBarGraphDataAsync();
            return Ok(data);
        }

        [HttpGet("filtered")]
        public async Task<ActionResult<MonthlyExamCompletionDTO>> GetFilteredExamCompletionData(
         [FromQuery] int financialYearId = 0,
         [FromQuery] int? departmentId = null,
         [FromQuery] int? providerId = null)
        {
            var data = await _lndBarGraphservice.GetFilteredExamCompletionDataAsync(financialYearId, departmentId, providerId);
            return Ok(data);
        }
    }
}

