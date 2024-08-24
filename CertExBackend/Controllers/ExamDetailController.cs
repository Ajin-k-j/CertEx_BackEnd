using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamDetailController : ControllerBase
    {
        private readonly IExamDetailService _examDetailService;

        public ExamDetailController(IExamDetailService examDetailService)
        {
            _examDetailService = examDetailService;
        }

        [HttpGet("allexamdetails")]
        public async Task<ActionResult<IEnumerable<ExamDetailDto>>> AllExamDetails()
        {
            var examDetails = await _examDetailService.GetAllExamDetailsAsync();
            return Ok(examDetails);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExamDetailDto>> GetExamDetailById(int id)
        {
            var examDetail = await _examDetailService.GetExamDetailByIdAsync(id);
            if (examDetail == null)
            {
                return NotFound(new { Message = $"ExamDetail with ID {id} not found." });
            }
            return Ok(examDetail);
        }

        [HttpPost]
        public async Task<ActionResult> AddExamDetail(ExamDetailDto examDetailDto)
        {
            await _examDetailService.AddExamDetailAsync(examDetailDto);
            return CreatedAtAction(nameof(GetExamDetailById), new { id = examDetailDto.Id }, examDetailDto);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateExamDetail(ExamDetailDto examDetailDto)
        {
            var existingExamDetail = await _examDetailService.GetExamDetailByIdAsync(examDetailDto.Id);
            if (existingExamDetail == null)
            {
                return NotFound(new { Message = $"ExamDetail with ID {examDetailDto.Id} not found." });
            }
            await _examDetailService.UpdateExamDetailAsync(examDetailDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExamDetail(int id)
        {
            var existingExamDetail = await _examDetailService.GetExamDetailByIdAsync(id);
            if (existingExamDetail == null)
            {
                return NotFound(new { Message = $"ExamDetail with ID {id} not found." });
            }
            await _examDetailService.DeleteExamDetailAsync(id);
            return NoContent();
        }
    }
}