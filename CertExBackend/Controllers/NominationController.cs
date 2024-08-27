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
        public async Task<ActionResult> AddNomination(NominationCreateDto nominationCreateDto)
        {
            if (nominationCreateDto == null)
            {
                return BadRequest("Nomination data is required.");
            }

            try
            {
                await _nominationService.AddNominationAsync(nominationCreateDto);
                return CreatedAtAction(nameof(GetNominationById), new { id = nominationCreateDto.Id }, nominationCreateDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateNomination(NominationDto nominationDto)
        {
            if (nominationDto == null)
            {
                return BadRequest("Nomination data is required.");
            }

            var existingNomination = await _nominationService.GetNominationByIdAsync(nominationDto.Id);
            if (existingNomination == null)
            {
                return NotFound(new { Message = $"Nomination with ID {nominationDto.Id} not found." });
            }

            try
            {
                await _nominationService.UpdateNominationAsync(nominationDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("approve/department/{id}")]
        public async Task<ActionResult> ApproveDepartment(int id)
        {
            try
            {
                await _nominationService.ApproveDepartmentAsync(id);
                /*return Ok("Nomination Approved by Department");*/
                return Redirect($"http://localhost:5173/message?message=Nomination_approved.&success=true");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("approve/lnd/{id}")]
        public async Task<ActionResult> ApproveLnd(int id)
        {
            try
            {
                await _nominationService.ApproveLndAsync(id);
                /*return Ok("Nomination Approved by L&D");*/
                return Redirect($"http://localhost:5173/message?message=Nomination_approved.&success=true");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("reject/department/{id}")]
        public async Task<ActionResult> RejectDepartment(int id)
        {
            try
            {
                await _nominationService.RejectDepartmentAsync(id);
                return Redirect($"http://localhost:5173/message?message=Nomination_rejected.&success=true");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("reject/lnd/{id}")]
        public async Task<ActionResult> RejectLnd(int id)
        {
            try
            {
                await _nominationService.RejectLndAsync(id);
                return Redirect($"http://localhost:5173/message?message=Nomination_rejected.&success=true");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("pendingActions/Lnd")]
        public async Task<IActionResult> GetPendingLndApprovals()
        {
            try
            {
                var pendingNominations = await _nominationService.GetPendingLndApprovalsAsync();
                return Ok(pendingNominations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("pendingActions/Department/{departmentId}")]
        public async Task<IActionResult> GetPendingDepartmentApprovals(int departmentId)
        {
            try
            {
                var pendingNominations = await _nominationService.GetPendingDepartmentApprovalsAsync(departmentId);
                return Ok(pendingNominations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNomination(int id)
        {
            try
            {
                var existingNomination = await _nominationService.GetNominationByIdAsync(id);
                if (existingNomination == null)
                {
                    return NotFound(new { Message = $"Nomination with ID {id} not found." });
                }

                await _nominationService.DeleteNominationAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}