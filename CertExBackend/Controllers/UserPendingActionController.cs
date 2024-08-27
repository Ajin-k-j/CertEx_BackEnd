using CertExBackend.DTOs;
using CertExBackend.Services;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserPendingActionController : ControllerBase
    {
        private readonly IUserPendingActionService _userPendingActionService;

        public UserPendingActionController(IUserPendingActionService userPendingActionService)
        {
            _userPendingActionService = userPendingActionService;
        }

        [HttpGet("pending-actions")]
        public async Task<ActionResult<IEnumerable<UserPendingActionDto>>> GetUserPendingActions()
        {
            try
            {
                var pendingActions = await _userPendingActionService.GetUserPendingActionsAsync();
                return Ok(pendingActions);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
