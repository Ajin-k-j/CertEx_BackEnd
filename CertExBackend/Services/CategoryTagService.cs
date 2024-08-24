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
            var categoryTag = _mapper.Map<CategoryTag>(categoryTagDto);
            await _categoryTagRepository.UpdateCategoryTagAsync(categoryTag);
        }

        public async Task DeleteCategoryTagAsync(int id)
        {
            await _categoryTagRepository.DeleteCategoryTagAsync(id);
        }
    }
}
