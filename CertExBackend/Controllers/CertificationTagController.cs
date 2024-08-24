using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificationTagController : ControllerBase
    {
        private readonly ICertificationTagService _certificationTagService;

        public CertificationTagController(ICertificationTagService certificationTagService)
        {
            _certificationTagService = certificationTagService;
        }

        [HttpGet("allcertificationtags")]
        public async Task<ActionResult<IEnumerable<CertificationTagDto>>> AllCertificationTags()
        {
            var certificationTags = await _certificationTagService.GetAllCertificationTagsAsync();
            return Ok(certificationTags);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CertificationTagDto>> GetCertificationTagById(int id)
        {
            var certificationTag = await _certificationTagService.GetCertificationTagByIdAsync(id);
            if (certificationTag == null)
            {
                return NotFound(new { Message = $"CertificationTag with ID {id} not found." });
            }
            return Ok(certificationTag);
        }

        [HttpPost]
        public async Task<ActionResult> AddCertificationTag(CertificationTagDto certificationTagDto)
        {
            await _certificationTagService.AddCertificationTagAsync(certificationTagDto);
            return CreatedAtAction(nameof(GetCertificationTagById), new { id = certificationTagDto.Id }, certificationTagDto);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCertificationTag(CertificationTagDto certificationTagDto)
        {
            var existingTag = await _certificationTagService.GetCertificationTagByIdAsync(certificationTagDto.Id);
            if (existingTag == null)
            {
                return NotFound(new { Message = $"CertificationTag with ID {certificationTagDto.Id} not found." });
            }

            await _certificationTagService.UpdateCertificationTagAsync(certificationTagDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCertificationTag(int id)
        {
            var existingTag = await _certificationTagService.GetCertificationTagByIdAsync(id);
            if (existingTag == null)
            {
                return NotFound(new { Message = $"CertificationTag with ID {id} not found." });
            }

            await _certificationTagService.DeleteCertificationTagAsync(id);
            return NoContent();
        }
    }
}