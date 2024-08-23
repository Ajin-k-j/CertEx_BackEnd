using CertExBackend.Interfaces;
using CertExBackend.Model;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificationProviderController : ControllerBase
    {
        private readonly ICertificationProviderRepository _certificationProviderRepository;

        public CertificationProviderController(ICertificationProviderRepository certificationProviderRepository)
        {
            _certificationProviderRepository = certificationProviderRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CertificationProvider>> GetAllCertificationProviders()
        {
            var providers = _certificationProviderRepository.GetAllCertificationProviders();
            return Ok(providers);
        }

        [HttpGet("{id}")]
        public ActionResult<CertificationProvider> GetCertificationProviderById(int id)
        {
            var provider = _certificationProviderRepository.GetCertificationProviderById(id);
            if (provider == null)
            {
                return NotFound();
            }
            return Ok(provider);
        }

        [HttpPost]
        public ActionResult AddCertificationProvider([FromBody] CertificationProvider provider)
        {
            _certificationProviderRepository.AddCertificationProvider(provider);
            return CreatedAtAction(nameof(GetCertificationProviderById), new { id = provider.Id }, provider);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCertificationProvider(int id, [FromBody] CertificationProvider provider)
        {
            var existingProvider = _certificationProviderRepository.GetCertificationProviderById(id);

            if (existingProvider == null)
            {
                return NotFound();
            }

            existingProvider.ProviderName = provider.ProviderName;
            existingProvider.UpdatedAt = DateTime.UtcNow;
            existingProvider.UpdatedBy = provider.UpdatedBy;

            _certificationProviderRepository.UpdateCertificationProvider(existingProvider);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCertificationProvider(int id)
        {
            var provider = _certificationProviderRepository.GetCertificationProviderById(id);
            if (provider == null)
            {
                return NotFound();
            }

            _certificationProviderRepository.DeleteCertificationProvider(id);
            return NoContent();
        }
    }
}
