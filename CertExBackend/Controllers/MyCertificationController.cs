using CertExBackend.Interfaces;
using CertExBackend.Model;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyCertificationController : ControllerBase
    {
        private readonly IMyCertificationRepository _myCertificationRepository;

        public MyCertificationController(IMyCertificationRepository myCertificationRepository)
        {
            _myCertificationRepository = myCertificationRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MyCertification>> GetAllMyCertifications()
        {
            var certifications = _myCertificationRepository.GetAllMyCertifications();
            return Ok(certifications);
        }

        [HttpGet("{id}")]
        public ActionResult<MyCertification> GetMyCertificationById(int id)
        {
            var certification = _myCertificationRepository.GetMyCertificationById(id);
            if (certification == null)
            {
                return NotFound();
            }
            return Ok(certification);
        }

        [HttpPost]
        public ActionResult AddMyCertification([FromBody] MyCertification certification)
        {
            _myCertificationRepository.AddMyCertification(certification);
            return CreatedAtAction(nameof(GetMyCertificationById), new { id = certification.Id }, certification);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMyCertification(int id, [FromBody] MyCertification certification)
        {
            var existingCertification = _myCertificationRepository.GetMyCertificationById(id);

            if (existingCertification == null)
            {
                return NotFound();
            }

            existingCertification.Filename = certification.Filename;
            existingCertification.Url = certification.Url;
            existingCertification.FromDate = certification.FromDate;
            existingCertification.ExpiryDate = certification.ExpiryDate;
            existingCertification.Credentials = certification.Credentials;
            existingCertification.UpdatedAt = DateTime.UtcNow;
            existingCertification.UpdatedBy = certification.UpdatedBy;

            _myCertificationRepository.UpdateMyCertification(existingCertification);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteMyCertification(int id)
        {
            var certification = _myCertificationRepository.GetMyCertificationById(id);
            if (certification == null)
            {
                return NotFound();
            }

            _myCertificationRepository.DeleteMyCertification(id);
            return NoContent();
        }
    }
}
