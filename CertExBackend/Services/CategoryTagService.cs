using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;

namespace CertExBackend.Services
{
    public class CategoryTagService : ICategoryTagService
    {
        private readonly ICategoryTagRepository _categoryTagRepository;
        private readonly IMapper _mapper;

        public CategoryTagService(ICategoryTagRepository categoryTagRepository, IMapper mapper)
        {
            _categoryTagRepository = categoryTagRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryTagDto>> GetAllCategoryTagsAsync()
        {
            var categoryTags = await _categoryTagRepository.GetAllCategoryTagsAsync();
            return _mapper.Map<IEnumerable<CategoryTagDto>>(categoryTags);
        }

        public async Task<CategoryTagDto> GetCategoryTagByIdAsync(int id)
        {
            var categoryTag = await _categoryTagRepository.GetCategoryTagByIdAsync(id);
            return categoryTag == null ? null : _mapper.Map<CategoryTagDto>(categoryTag);
        }

        public async Task AddCategoryTagAsync(CategoryTagDto categoryTagDto)
        {
            var categoryTag = _mapper.Map<CategoryTag>(categoryTagDto);
            await _categoryTagRepository.AddCategoryTagAsync(categoryTag);
        }

        public async Task UpdateCategoryTagAsync(CategoryTagDto categoryTagDto)
        {
            // Retrieve the existing category tag from the database
            var existingCategoryTag = await _categoryTagRepository.GetCategoryTagByIdAsync(categoryTagDto.Id);

            // Check if the existing category tag was found
            if (existingCategoryTag == null)
            {
                throw new Exception($"CategoryTag with ID {categoryTagDto.Id} not found.");
            }

            // Map the updated values from the DTO to the existing entity
            _mapper.Map(categoryTagDto, existingCategoryTag);

            // Update the entity in the repository
            await _categoryTagRepository.UpdateCategoryTagAsync(existingCategoryTag);
        }


        public async Task DeleteCategoryTagAsync(int id)
        {
            await _categoryTagRepository.DeleteCategoryTagAsync(id);
        }
    }
}
