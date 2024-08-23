using CertExBackend.Interfaces;
using CertExBackend.Model;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificationExamController : ControllerBase
    {
        private readonly ICertificationExamRepository _certificationExamRepository;

        public CertificationExamController(ICertificationExamRepository certificationExamRepository)
        {
            _certificationExamRepository = certificationExamRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CertificationExam>> GetAllCertificationExams()
        {
            var exams = _certificationExamRepository.GetAllCertificationExams();
            return Ok(exams);
        }

        [HttpGet("{id}")]
        public ActionResult<CertificationExam> GetCertificationExamById(int id)
        {
            var exam = _certificationExamRepository.GetCertificationExamById(id);
            if (exam == null)
            {
                return NotFound();
            }
            return Ok(exam);
        }

        [HttpPost]
        public ActionResult AddCertificationExam([FromBody] CertificationExam exam)
        {
            _certificationExamRepository.AddCertificationExam(exam);
            return CreatedAtAction(nameof(GetCertificationExamById), new { id = exam.Id }, exam);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCertificationExam(int id, [FromBody] CertificationExam exam)
        {

            var existingExam = _certificationExamRepository.GetCertificationExamById(id);
            if (existingExam == null)
            {
                return NotFound();
            }

            // Update properties of the existing exam with the values from the request body
            existingExam.ProviderId = exam.ProviderId;
            existingExam.CertificationName = exam.CertificationName;
            existingExam.NominationStatus = exam.NominationStatus;
            existingExam.Level = exam.Level;
            existingExam.Description = exam.Description;
            existingExam.OfficialLink = exam.OfficialLink;
            existingExam.CostUsd = exam.CostUsd;
            existingExam.CostInr = exam.CostInr;
            existingExam.UpdatedAt = DateTime.UtcNow;
            existingExam.UpdatedBy = exam.UpdatedBy;

            _certificationExamRepository.UpdateCertificationExam(existingExam);
            return Ok("Updated Success");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCertificationExam(int id)
        {
            var exam = _certificationExamRepository.GetCertificationExamById(id);
            if (exam == null)
            {
                return NotFound();
            }

            _certificationExamRepository.DeleteCertificationExam(id);
            return NoContent();
        }
    }
}
