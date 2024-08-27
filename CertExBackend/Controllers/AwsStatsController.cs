using CertExBackend.DTOs;
using CertExBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AwsStatsController : ControllerBase
    {
        private readonly IAwsStatsService _awsStatsService;

        public AwsStatsController(IAwsStatsService awsStatsService)
        {
            _awsStatsService = awsStatsService;
        }

        [HttpGet]
        public async Task<ActionResult<AwsStatsDto>> GetAwsStats()
        {
            var stats = await _awsStatsService.GetAwsStatsAsync();
            return Ok(stats);
        }
    }
}
