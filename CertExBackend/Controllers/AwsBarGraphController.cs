using CertExBackend.DTOs;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;


namespace CertExBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwsBarGraphController : ControllerBase
    {
        private readonly IAwsBarGraphService _awsBarGraphService;

        public AwsBarGraphController(IAwsBarGraphService awsBarGraphService)
        {
            _awsBarGraphService = awsBarGraphService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<AwsBarGraphDto>>> GetAll()
        {
            var data = await _awsBarGraphService.GetAwsBarGraphDataAsync();
            return Ok(data);
        }

        [HttpGet("filtered")]
        public async Task<ActionResult<MonthlyExamCompletionDTO>> GetFiltered(int financialYearId, int? departmentId)
        {
            var data = await _awsBarGraphService.GetFilteredExamCompletionDataAsync(financialYearId, departmentId);
            return Ok(data);
        }
    }
}
