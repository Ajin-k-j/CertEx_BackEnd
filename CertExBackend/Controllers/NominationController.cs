using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NominationController : ControllerBase
    {
        private readonly INominationService _nominationService;

        public NominationController(INominationService nominationService)
        {
            _nominationService = nominationService;
        }

        [HttpGet("allnominations")]
        public async Task<ActionResult<IEnumerable<NominationDto>>> AllNominations()
        {
            var nominations = await _nominationService.GetAllNominationsAsync();
            return Ok(nominations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NominationDto>> GetNominationById(int id)
        {
            var nomination = await _nominationService.GetNominationByIdAsync(id);
            if (nomination == null)
            {
                return NotFound(new { Message = $"Nomination with ID {id} not found." });
            }
            return Ok(nomination);
        }

        [HttpPost]
        public async Task<ActionResult> AddNomination(NominationDto nominationDto)
        {
            await _nominationService.AddNominationAsync(nominationDto);
            return CreatedAtAction(nameof(GetNominationById), new { id = nominationDto.Id }, nominationDto);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateNomination(NominationDto nominationDto)
        {
            var existingNomination = await _nominationService.GetNominationByIdAsync(nominationDto.Id);
            if (existingNomination == null)
            {
                return NotFound(new { Message = $"Nomination with ID {nominationDto.Id} not found." });
            }
            await _nominationService.UpdateNominationAsync(nominationDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNomination(int id)
        {
            var existingNomination = await _nominationService.GetNominationByIdAsync(id);
            if (existingNomination == null)
            {
                return NotFound(new { Message = $"Nomination with ID {id} not found." });
            }
            await _nominationService.DeleteNominationAsync(id);
            return NoContent();
        }
    }
}