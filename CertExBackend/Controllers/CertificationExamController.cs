using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificationExamController : ControllerBase
    {
        private readonly ICertificationExamService _certificationExamService;

        public CertificationExamController(ICertificationExamService certificationExamService)
        {
            _certificationExamService = certificationExamService;
        }

        [HttpGet("allcertificationexams")]
        public async Task<ActionResult<IEnumerable<CertificationExamDto>>> AllCertificationExams()
        {
            var certificationExams = await _certificationExamService.GetAllCertificationExamsAsync();
            return Ok(certificationExams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CertificationExamDto>> GetCertificationExamById(int id)
        {
            var certificationExam = await _certificationExamService.GetCertificationExamByIdAsync(id);
            if (certificationExam == null)
            {
                return NotFound(new { Message = $"CertificationExam with ID {id} not found." });
            }
            return Ok(certificationExam);
        }

        [HttpPost]
        public async Task<ActionResult> AddCertificationExam(CertificationExamDto certificationExamDto)
        {
            await _certificationExamService.AddCertificationExamAsync(certificationExamDto);
            return CreatedAtAction(nameof(GetCertificationExamById), new { id = certificationExamDto.Id }, certificationExamDto);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCertificationExam(CertificationExamDto certificationExamDto)
        {
            var existingExam = await _certificationExamService.GetCertificationExamByIdAsync(certificationExamDto.Id);
            if (existingExam == null)
            {
                return NotFound(new { Message = $"CertificationExam with ID {certificationExamDto.Id} not found." });
            }

            await _certificationExamService.UpdateCertificationExamAsync(certificationExamDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCertificationExam(int id)
        {
            var existingExam = await _certificationExamService.GetCertificationExamByIdAsync(id);
            if (existingExam == null)
            {
                return NotFound(new { Message = $"CertificationExam with ID {id} not found." });
            }

            await _certificationExamService.DeleteCertificationExamAsync(id);
            return NoContent();
        }
    }
}
