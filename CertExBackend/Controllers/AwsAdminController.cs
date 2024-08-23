using CertExBackend.Interfaces;
using CertExBackend.Model;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AwsAdminController : ControllerBase
    {
        private readonly IAwsAdminRepository _awsAdminRepository;

        public AwsAdminController(IAwsAdminRepository awsAdminRepository)
        {
            _awsAdminRepository = awsAdminRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AwsAdmin>> GetAllAwsAdmins()
        {
            var awsAdmins = _awsAdminRepository.GetAllAwsAdmins();
            return Ok(awsAdmins);
        }

        [HttpGet("{id}")]
        public ActionResult<AwsAdmin> GetAwsAdminById(int id)
        {
            var awsAdmin = _awsAdminRepository.GetAwsAdminById(id);
            if (awsAdmin == null)
            {
                return NotFound();
            }
            return Ok(awsAdmin);
        }

        [HttpPost]
        public ActionResult AddAwsAdmin([FromBody] AwsAdmin awsAdmin)
        {
            if (awsAdmin == null)
            {
                return BadRequest();
            }

            _awsAdminRepository.AddAwsAdmin(awsAdmin);
            return CreatedAtAction(nameof(GetAwsAdminById), new { id = awsAdmin.Id }, awsAdmin);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAwsAdmin(int id, [FromBody] AwsAdmin awsAdmin)
        {
            var existingAwsAdmin = _awsAdminRepository.GetAwsAdminById(id);

            if (existingAwsAdmin == null)
            {
                return NotFound();
            }

            existingAwsAdmin.Credentials = awsAdmin.Credentials;
            existingAwsAdmin.Description = awsAdmin.Description;
            existingAwsAdmin.UpdatedAt = DateTime.UtcNow;
            existingAwsAdmin.UpdatedBy = awsAdmin.UpdatedBy;

            _awsAdminRepository.UpdateAwsAdmin(existingAwsAdmin);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteAwsAdmin(int id)
        {
            var awsAdmin = _awsAdminRepository.GetAwsAdminById(id);
            if (awsAdmin == null)
            {
                return NotFound();
            }

            _awsAdminRepository.DeleteAwsAdmin(id);
            return NoContent();
        }
    }
}
