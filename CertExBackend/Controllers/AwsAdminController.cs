using Microsoft.AspNetCore.Mvc;
using CertExBackend.Services.IServices;
using System.Threading.Tasks;
using CertExBackend.DTOs;

namespace CertExBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwsAdminController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public AwsAdminController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitAwsDetails([FromBody] AwsAdminDetailsDto awsDetailsDto)
        {
            if (awsDetailsDto == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                await _employeeService.UpdateAwsDetailsAsync(
                    awsDetailsDto.EmployeeId,
                    awsDetailsDto.AWSCredentials,
                    awsDetailsDto.AWSAdminRemarks
                );

                return Ok("AWS credentials setup submitted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

    
}
