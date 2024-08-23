using CertExBackend.Interfaces;
using CertExBackend.Model;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CriticalCertificationController : ControllerBase
    {
        private readonly ICriticalCertificationRepository _criticalCertificationRepository;

        public CriticalCertificationController(ICriticalCertificationRepository criticalCertificationRepository)
        {
            _criticalCertificationRepository = criticalCertificationRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CriticalCertification>> GetAllCriticalCertifications()
        {
            var certifications = _criticalCertificationRepository.GetAllCriticalCertifications();
            return Ok(certifications);
        }

        [HttpGet("{id}")]
        public ActionResult<CriticalCertification> GetCriticalCertificationById(int id)
        {
            var certification = _criticalCertificationRepository.GetCriticalCertificationById(id);
            if (certification == null)
            {
                return NotFound();
            }
            return Ok(certification);
        }

        [HttpPost]
        public ActionResult AddCriticalCertification([FromBody] CriticalCertification certification)
        {
            _criticalCertificationRepository.AddCriticalCertification(certification);
            return CreatedAtAction(nameof(GetCriticalCertificationById), new { id = certification.Id }, certification);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCriticalCertification(int id, [FromBody] CriticalCertification certification)
        {
            var existingCertification = _criticalCertificationRepository.GetCriticalCertificationById(id);

            if (existingCertification == null)
            {
                return NotFound();
            }

            existingCertification.CertificationId = certification.CertificationId;
            existingCertification.FinancialYearId = certification.FinancialYearId;
            existingCertification.RequiredCount = certification.RequiredCount;
            existingCertification.UpdatedAt = DateTime.UtcNow;
            existingCertification.UpdatedBy = certification.UpdatedBy;

            _criticalCertificationRepository.UpdateCriticalCertification(existingCertification);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCriticalCertification(int id)
        {
            var certification = _criticalCertificationRepository.GetCriticalCertificationById(id);
            if (certification == null)
            {
                return NotFound();
            }

            _criticalCertificationRepository.DeleteCriticalCertification(id);
            return NoContent();
        }
    }
}
