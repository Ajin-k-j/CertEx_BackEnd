using CertExBackend.Interfaces;
using CertExBackend.Model;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificationTagController : ControllerBase
    {
        private readonly ICertificationTagRepository _certificationTagRepository;

        public CertificationTagController(ICertificationTagRepository certificationTagRepository)
        {
            _certificationTagRepository = certificationTagRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CertificationTag>> GetAllCertificationTags()
        {
            var tags = _certificationTagRepository.GetAllCertificationTags();
            return Ok(tags);
        }

        [HttpGet("{id}")]
        public ActionResult<CertificationTag> GetCertificationTagById(int id)
        {
            var tag = _certificationTagRepository.GetCertificationTagById(id);
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(tag);
        }

        [HttpPost]
        public ActionResult AddCertificationTag([FromBody] CertificationTag tag)
        {
            _certificationTagRepository.AddCertificationTag(tag);
            return CreatedAtAction(nameof(GetCertificationTagById), new { id = tag.Id }, tag);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCertificationTag(int id, [FromBody] CertificationTag tag)
        {
            var existingTag = _certificationTagRepository.GetCertificationTagById(id);

            if (existingTag == null)
            {
                return NotFound();
            }

            existingTag.CertificationId = tag.CertificationId;
            existingTag.CategoryTagId = tag.CategoryTagId;
            existingTag.UpdatedAt = DateTime.UtcNow;
            existingTag.UpdatedBy = tag.UpdatedBy;

            _certificationTagRepository.UpdateCertificationTag(existingTag);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCertificationTag(int id)
        {
            var tag = _certificationTagRepository.GetCertificationTagById(id);
            if (tag == null)
            {
                return NotFound();
            }

            _certificationTagRepository.DeleteCertificationTag(id);
            return NoContent();
        }
    }
}
