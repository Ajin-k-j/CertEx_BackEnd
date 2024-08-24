using CertExBackend.DTOs;

namespace CertExBackend.Services.IServices
{
    public interface ICategoryTagService
    {
        Task<IEnumerable<CategoryTagDto>> GetAllCategoryTagsAsync();
        Task<CategoryTagDto> GetCategoryTagByIdAsync(int id);
        Task AddCategoryTagAsync(CategoryTagDto categoryTagDto);
        Task UpdateCategoryTagAsync(CategoryTagDto categoryTagDto);
        Task DeleteCategoryTagAsync(int id);
    }
}
