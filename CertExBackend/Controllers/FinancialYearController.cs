using CertExBackend.Interfaces;
using CertExBackend.Model;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancialYearController : ControllerBase
    {
        private readonly IFinancialYearRepository _financialYearRepository;

        public FinancialYearController(IFinancialYearRepository financialYearRepository)
        {
            _financialYearRepository = financialYearRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FinancialYear>> GetAllFinancialYears()
        {
            var financialYears = _financialYearRepository.GetAllFinancialYears();
            return Ok(financialYears);
        }

        [HttpGet("{id}")]
        public ActionResult<FinancialYear> GetFinancialYearById(int id)
        {
            var financialYear = _financialYearRepository.GetFinancialYearById(id);
            if (financialYear == null)
            {
                return NotFound();
            }
            return Ok(financialYear);
        }

        [HttpPost]
        public ActionResult AddFinancialYear([FromBody] FinancialYear financialYear)
        {
            _financialYearRepository.AddFinancialYear(financialYear);
            return CreatedAtAction(nameof(GetFinancialYearById), new { id = financialYear.Id }, financialYear);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFinancialYear(int id, [FromBody] FinancialYear financialYear)
        {
            var existingFinancialYear = _financialYearRepository.GetFinancialYearById(id);

            if (existingFinancialYear == null)
            {
                return NotFound();
            }

            existingFinancialYear.FromDate = financialYear.FromDate;
            existingFinancialYear.ToDate = financialYear.ToDate;
            existingFinancialYear.Status = financialYear.Status;
            existingFinancialYear.UpdatedAt = DateTime.UtcNow;
            existingFinancialYear.UpdatedBy = financialYear.UpdatedBy;

            _financialYearRepository.UpdateFinancialYear(existingFinancialYear);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteFinancialYear(int id)
        {
            var financialYear = _financialYearRepository.GetFinancialYearById(id);
            if (financialYear == null)
            {
                return NotFound();
            }

            _financialYearRepository.DeleteFinancialYear(id);
            return NoContent();
        }
    }
}
