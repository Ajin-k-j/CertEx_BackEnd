using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryTagController : ControllerBase
    {
        private readonly ICategoryTagService _categoryTagService;

        public CategoryTagController(ICategoryTagService categoryTagService)
        {
            _categoryTagService = categoryTagService;
        }

        [HttpGet("allcategorytags")]
        public async Task<ActionResult<IEnumerable<CategoryTagDto>>> AllCategoryTags()
        {
            var categoryTags = await _categoryTagService.GetAllCategoryTagsAsync();
            return Ok(categoryTags);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryTagDto>> GetCategoryTagById(int id)
        {
            var categoryTag = await _categoryTagService.GetCategoryTagByIdAsync(id);
            if (categoryTag == null)
            {
                return NotFound(new { Message = $"CategoryTag with ID {id} not found." });
            }
            return Ok(categoryTag);
        }

        [HttpPost]
        public async Task<ActionResult> AddCategoryTag(CategoryTagDto categoryTagDto)
        {
            await _categoryTagService.AddCategoryTagAsync(categoryTagDto);
            return Ok("Category tag created successfully.");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCategoryTag(CategoryTagDto categoryTagDto)
        {
            var existingTag = await _categoryTagService.GetCategoryTagByIdAsync(categoryTagDto.Id);
            if (existingTag == null)
            {
                return NotFound(new { Message = $"CategoryTag with ID {categoryTagDto.Id} not found." });
            }

            await _categoryTagService.UpdateCategoryTagAsync(categoryTagDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategoryTag(int id)
        {
            var existingTag = await _categoryTagService.GetCategoryTagByIdAsync(id);
            if (existingTag == null)
            {
                return NotFound(new { Message = $"CategoryTag with ID {id} not found." });
            }

            await _categoryTagService.DeleteCategoryTagAsync(id);
            return NoContent();
        }
    }
}
