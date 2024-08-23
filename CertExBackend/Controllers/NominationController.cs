using CertExBackend.Interfaces;
using CertExBackend.Model;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NominationController : ControllerBase
    {
        private readonly INominationRepository _nominationRepository;

        public NominationController(INominationRepository nominationRepository)
        {
            _nominationRepository = nominationRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Nomination>> GetAllNominations()
        {
            var nominations = _nominationRepository.GetAllNominations();
            return Ok(nominations);
        }

        [HttpGet("{id}")]
        public ActionResult<Nomination> GetNominationById(int id)
        {
            var nomination = _nominationRepository.GetNominationById(id);
            if (nomination == null)
            {
                return NotFound();
            }
            return Ok(nomination);
        }

        [HttpPost]
        public ActionResult AddNomination([FromBody] Nomination nomination)
        {
            if (nomination == null)
            {
                return BadRequest();
            }

            _nominationRepository.AddNomination(nomination);
            return CreatedAtAction(nameof(GetNominationById), new { id = nomination.Id }, nomination);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateNomination(int id, [FromBody] Nomination nomination)
        {
            var existingNomination = _nominationRepository.GetNominationById(id);

            if (existingNomination == null)
            {
                return NotFound();
            }

            existingNomination.CertificationId = nomination.CertificationId;
            existingNomination.EmployeeId = nomination.EmployeeId;
            existingNomination.PlannedExamMonth = nomination.PlannedExamMonth;
            existingNomination.MotivationDescription = nomination.MotivationDescription;
            existingNomination.ExamDate = nomination.ExamDate;
            existingNomination.DepartmentApproval = nomination.DepartmentApproval;
            existingNomination.LndApproval = nomination.LndApproval;
            existingNomination.ExamStatus = nomination.ExamStatus;
            existingNomination.NominationStatus = nomination.NominationStatus;
            existingNomination.UpdatedAt = DateTime.UtcNow;
            existingNomination.UpdatedBy = nomination.UpdatedBy;

            _nominationRepository.UpdateNomination(existingNomination);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteNomination(int id)
        {
            var nomination = _nominationRepository.GetNominationById(id);
            if (nomination == null)
            {
                return NotFound();
            }

            _nominationRepository.DeleteNomination(id);
            return NoContent();
        }
    }
}
