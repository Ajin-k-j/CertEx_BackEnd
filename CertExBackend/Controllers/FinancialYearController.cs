using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancialYearController : ControllerBase
    {
        private readonly IFinancialYearService _financialYearService;

        public FinancialYearController(IFinancialYearService financialYearService)
        {
            _financialYearService = financialYearService;
        }

        [HttpGet("allfinancialyears")]
        public async Task<ActionResult<IEnumerable<FinancialYearDto>>> AllFinancialYears()
        {
            var financialYears = await _financialYearService.GetAllFinancialYearsAsync();
            return Ok(financialYears);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FinancialYearDto>> GetFinancialYearById(int id)
        {
            var financialYear = await _financialYearService.GetFinancialYearByIdAsync(id);
            if (financialYear == null)
            {
                return NotFound(new { Message = $"FinancialYear with ID {id} not found." });
            }
            return Ok(financialYear);
        }

        [HttpPost]
        public async Task<ActionResult> AddFinancialYear(FinancialYearDto financialYearDto)
        {
            await _financialYearService.AddFinancialYearAsync(financialYearDto);
            return CreatedAtAction(nameof(GetFinancialYearById), new { id = financialYearDto.Id }, financialYearDto);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateFinancialYear(FinancialYearDto financialYearDto)
        {
            var existingFinancialYear = await _financialYearService.GetFinancialYearByIdAsync(financialYearDto.Id);
            if (existingFinancialYear == null)
            {
                return NotFound(new { Message = $"FinancialYear with ID {financialYearDto.Id} not found." });
            }
            await _financialYearService.UpdateFinancialYearAsync(financialYearDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFinancialYear(int id)
        {
            var existingFinancialYear = await _financialYearService.GetFinancialYearByIdAsync(id);
            if (existingFinancialYear == null)
            {
                return NotFound(new { Message = $"FinancialYear with ID {id} not found." });
            }
            await _financialYearService.DeleteFinancialYearAsync(id);
            return NoContent();
        }
    }
}