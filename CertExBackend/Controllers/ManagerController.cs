using CertExBackend.DTOs;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly INominationService _nominationService;

        public ManagerController(INominationService nominationService)
        {
            _nominationService = nominationService;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitNomination([FromBody] ManagerFeedbackDto feedbackDto)
        {
            if (feedbackDto == null || feedbackDto.NominationId <= 0)
            {
                return BadRequest("Invalid nomination ID.");
            }

            // Process the feedback here, e.g., update the nomination record
            var result = await _nominationService.ProcessManagerFeedbackAsync(feedbackDto);

            if (result)
            {
                return Ok("Feedback submitted successfully.");
            }
            else
            {
                return StatusCode(500, "An error occurred while processing the feedback.");
            }
        }
    }
}
