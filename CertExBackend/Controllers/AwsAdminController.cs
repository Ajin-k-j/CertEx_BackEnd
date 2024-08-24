using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwsAdminController : ControllerBase
    {
        private readonly IAwsAdminService _awsAdminService;

        public AwsAdminController(IAwsAdminService awsAdminService)
        {
            _awsAdminService = awsAdminService;
        }

        [HttpGet("allawsadmins")]
        public async Task<IActionResult> AllAwsAdmins()
        {
            var awsAdmins = await _awsAdminService.GetAllAwsAdminsAsync();
            return Ok(awsAdmins);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAwsAdminById(int id)
        {
            var awsAdmin = await _awsAdminService.GetAwsAdminByIdAsync(id);
            if (awsAdmin == null)
            {
                return NotFound(new { Message = "AwsAdmin not found" });
            }
            return Ok(awsAdmin);
        }

        [HttpPost]
        public async Task<IActionResult> AddAwsAdmin([FromBody] AwsAdminDto awsAdminDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _awsAdminService.AddAwsAdminAsync(awsAdminDto);
            return CreatedAtAction(nameof(GetAwsAdminById), new { id = awsAdminDto.Id }, awsAdminDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAwsAdmin(int id, [FromBody] AwsAdminDto awsAdminDto)
        {
            if (id != awsAdminDto.Id)
            {
                return BadRequest(new { Message = "Id mismatch" });
            }
            await _awsAdminService.UpdateAwsAdminAsync(awsAdminDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAwsAdmin(int id)
        {
            await _awsAdminService.DeleteAwsAdminAsync(id);
            return NoContent();
        }
    }
}