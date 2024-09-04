using CertExBackend.DTOs;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NominationController : ControllerBase
    {
        private readonly INominationService _nominationService;
        private readonly ILogger<NominationController> _logger;

        public NominationController(INominationService nominationService, ILogger<NominationController> logger)
        {
            _nominationService = nominationService;
            _logger = logger;
        }

        [HttpGet("allnominations")]
        public async Task<ActionResult<IEnumerable<NominationDto>>> AllNominations()
        {
            try
            {
                var nominations = await _nominationService.GetAllNominationsAsync();
                return Ok(nominations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all nominations.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NominationDto>> GetNominationById(int id)
        {
            try
            {
                var nomination = await _nominationService.GetNominationByIdAsync(id);
                if (nomination == null)
                {
                    _logger.LogWarning("Nomination with ID {Id} not found.", id);
                    return NotFound(new { Message = $"Nomination with ID {id} not found." });
                }
                return Ok(nomination);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching nomination by ID {Id}.", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddNomination(NominationCreateDto nominationCreateDto)
        {
            if (nominationCreateDto == null)
            {
                _logger.LogWarning("Nomination data is required.");
                return BadRequest("Nomination data is required.");
            }

            try
            {
                await _nominationService.AddNominationAsync(nominationCreateDto);
                return CreatedAtAction(nameof(GetNominationById), new { id = nominationCreateDto.Id }, nominationCreateDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding nomination.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateNomination(NominationDto nominationDto)
        {
            if (nominationDto == null)
            {
                _logger.LogWarning("Nomination data is required.");
                return BadRequest("Nomination data is required.");
            }

            var existingNomination = await _nominationService.GetNominationByIdAsync(nominationDto.Id);
            if (existingNomination == null)
            {
                _logger.LogWarning("Nomination with ID {Id} not found.", nominationDto.Id);
                return NotFound(new { Message = $"Nomination with ID {nominationDto.Id} not found." });
            }

            try
            {
                await _nominationService.UpdateNominationAsync(nominationDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating nomination with ID {Id}.", nominationDto.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("approve/department/{id}")]
        public async Task<ActionResult> ApproveDepartment(int id)
        {
            try
            {
                await _nominationService.ApproveDepartmentAsync(id);
                return Redirect($"http://localhost:5173/message?message=Nomination_approved.&success=true");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while approving department nomination with ID {Id}.", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("approve/lnd/{id}")]
        public async Task<ActionResult> ApproveLnd(int id)
        {
            try
            {
                await _nominationService.ApproveLndAsync(id);
                return Redirect($"http://localhost:5173/message?message=Nomination_approved.&success=true");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while approving L&D nomination with ID {Id}.", id);
                return StatusCode(500, "Internal server error");
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
                _logger.LogError(ex, "Error occurred while rejecting department nomination with ID {Id}.", id);
                return StatusCode(500, "Internal server error");
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
                _logger.LogError(ex, "Error occurred while rejecting L&D nomination with ID {Id}.", id);
                return StatusCode(500, "Internal server error");
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
                _logger.LogError(ex, "Error occurred while fetching pending L&D approvals.");
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
                _logger.LogError(ex, "Error occurred while fetching pending department approvals for department ID {DepartmentId}.", departmentId);
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
                    _logger.LogWarning("Nomination with ID {Id} not found.", id);
                    return NotFound(new { Message = $"Nomination with ID {id} not found." });
                }

                await _nominationService.DeleteNominationAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting nomination with ID {Id}.", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
