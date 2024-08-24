using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificationProviderController : ControllerBase
    {
        private readonly ICertificationProviderService _certificationProviderService;

        public CertificationProviderController(ICertificationProviderService certificationProviderService)
        {
            _certificationProviderService = certificationProviderService;
        }

        [HttpGet("allcertificationproviders")]
        public async Task<ActionResult<IEnumerable<CertificationProviderDto>>> AllCertificationProviders()
        {
            var certificationProviders = await _certificationProviderService.GetAllCertificationProvidersAsync();
            return Ok(certificationProviders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CertificationProviderDto>> GetCertificationProviderById(int id)
        {
            var certificationProvider = await _certificationProviderService.GetCertificationProviderByIdAsync(id);
            if (certificationProvider == null)
            {
                return NotFound(new { Message = $"CertificationProvider with ID {id} not found." });
            }
            return Ok(certificationProvider);
        }

        [HttpPost]
        public async Task<ActionResult> AddCertificationProvider(CertificationProviderDto certificationProviderDto)
        {
            await _certificationProviderService.AddCertificationProviderAsync(certificationProviderDto);
            return CreatedAtAction(nameof(GetCertificationProviderById), new { id = certificationProviderDto.Id }, certificationProviderDto);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCertificationProvider(CertificationProviderDto certificationProviderDto)
        {
            var existingProvider = await _certificationProviderService.GetCertificationProviderByIdAsync(certificationProviderDto.Id);
            if (existingProvider == null)
            {
                return NotFound(new { Message = $"CertificationProvider with ID {certificationProviderDto.Id} not found." });
            }

            await _certificationProviderService.UpdateCertificationProviderAsync(certificationProviderDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCertificationProvider(int id)
        {
            var existingProvider = await _certificationProviderService.GetCertificationProviderByIdAsync(id);
            if (existingProvider == null)
            {
                return NotFound(new { Message = $"CertificationProvider with ID {id} not found." });
            }

            await _certificationProviderService.DeleteCertificationProviderAsync(id);
            return NoContent();
        }
    }
}