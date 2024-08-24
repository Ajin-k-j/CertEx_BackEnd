using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyCertificationController : ControllerBase
    {
        private readonly IMyCertificationService _myCertificationService;

        public MyCertificationController(IMyCertificationService myCertificationService)
        {
            _myCertificationService = myCertificationService;
        }

        [HttpGet("allmycertifications")]
        public async Task<ActionResult<IEnumerable<MyCertificationDto>>> AllMyCertifications()
        {
            var myCertifications = await _myCertificationService.GetAllMyCertificationsAsync();
            return Ok(myCertifications);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MyCertificationDto>> GetMyCertificationById(int id)
        {
            var myCertification = await _myCertificationService.GetMyCertificationByIdAsync(id);
            if (myCertification == null)
            {
                return NotFound(new { Message = $"MyCertification with ID {id} not found." });
            }
            return Ok(myCertification);
        }

        [HttpPost]
        public async Task<ActionResult> AddMyCertification(MyCertificationDto myCertificationDto)
        {
            await _myCertificationService.AddMyCertificationAsync(myCertificationDto);
            return CreatedAtAction(nameof(GetMyCertificationById), new { id = myCertificationDto.Id }, myCertificationDto);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateMyCertification(MyCertificationDto myCertificationDto)
        {
            var existingMyCertification = await _myCertificationService.GetMyCertificationByIdAsync(myCertificationDto.Id);
            if (existingMyCertification == null)
            {
                return NotFound(new { Message = $"MyCertification with ID {myCertificationDto.Id} not found." });
            }
            await _myCertificationService.UpdateMyCertificationAsync(myCertificationDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMyCertification(int id)
        {
            var existingMyCertification = await _myCertificationService.GetMyCertificationByIdAsync(id);
            if (existingMyCertification == null)
            {
                return NotFound(new { Message = $"MyCertification with ID {id} not found." });
            }
            await _myCertificationService.DeleteMyCertificationAsync(id);
            return NoContent();
        }
    }
}