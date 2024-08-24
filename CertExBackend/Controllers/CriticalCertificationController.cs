using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CriticalCertificationController : ControllerBase
    {
        private readonly ICriticalCertificationService _criticalCertificationService;

        public CriticalCertificationController(ICriticalCertificationService criticalCertificationService)
        {
            _criticalCertificationService = criticalCertificationService;
        }

        [HttpGet("allcriticalcertifications")]
        public async Task<ActionResult<IEnumerable<CriticalCertificationDto>>> AllCriticalCertifications()
        {
            var criticalCertifications = await _criticalCertificationService.GetAllCriticalCertificationsAsync();
            return Ok(criticalCertifications);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CriticalCertificationDto>> GetCriticalCertificationById(int id)
        {
            var criticalCertification = await _criticalCertificationService.GetCriticalCertificationByIdAsync(id);
            if (criticalCertification == null)
            {
                return NotFound(new { Message = $"CriticalCertification with ID {id} not found." });
            }
            return Ok(criticalCertification);
        }

        [HttpPost]
        public async Task<ActionResult> AddCriticalCertification(CriticalCertificationDto criticalCertificationDto)
        {
            await _criticalCertificationService.AddCriticalCertificationAsync(criticalCertificationDto);
            return CreatedAtAction(nameof(GetCriticalCertificationById), new { id = criticalCertificationDto.Id }, criticalCertificationDto);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCriticalCertification(CriticalCertificationDto criticalCertificationDto)
        {
            var existingCertification = await _criticalCertificationService.GetCriticalCertificationByIdAsync(criticalCertificationDto.Id);
            if (existingCertification == null)
            {
                return NotFound(new { Message = $"CriticalCertification with ID {criticalCertificationDto.Id} not found." });
            }

            await _criticalCertificationService.UpdateCriticalCertificationAsync(criticalCertificationDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCriticalCertification(int id)
        {
            var existingCertification = await _criticalCertificationService.GetCriticalCertificationByIdAsync(id);
            if (existingCertification == null)
            {
                return NotFound(new { Message = $"CriticalCertification with ID {id} not found." });
            }

            await _criticalCertificationService.DeleteCriticalCertificationAsync(id);
            return NoContent();
        }
    }
}