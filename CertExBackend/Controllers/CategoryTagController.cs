using CertExBackend.Interfaces;
using CertExBackend.Model;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryTagController : ControllerBase
    {
        private readonly ICategoryTagRepository _categoryTagRepository;

        public CategoryTagController(ICategoryTagRepository categoryTagRepository)
        {
            _categoryTagRepository = categoryTagRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryTag>> GetAllCategoryTags()
        {
            var tags = _categoryTagRepository.GetAllCategoryTags();
            return Ok(tags);
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryTag> GetCategoryTagById(int id)
        {
            var tag = _categoryTagRepository.GetCategoryTagById(id);
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(tag);
        }

        [HttpPost]
        public ActionResult AddCategoryTag([FromBody] CategoryTag tag)
        {
            _categoryTagRepository.AddCategoryTag(tag);
            return CreatedAtAction(nameof(GetCategoryTagById), new { id = tag.Id }, tag);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategoryTag(int id, [FromBody] CategoryTag tag)
        {
            var existingTag = _categoryTagRepository.GetCategoryTagById(id);

            if (existingTag == null)
            {
                return NotFound();
            }

            existingTag.CategoryTagName = tag.CategoryTagName;
            existingTag.UpdatedAt = DateTime.UtcNow;
            existingTag.UpdatedBy = tag.UpdatedBy;

            _categoryTagRepository.UpdateCategoryTag(existingTag);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCategoryTag(int id)
        {
            var tag = _categoryTagRepository.GetCategoryTagById(id);
            if (tag == null)
            {
                return NotFound();
            }

            _categoryTagRepository.DeleteCategoryTag(id);
            return NoContent();
        }
    }
}
