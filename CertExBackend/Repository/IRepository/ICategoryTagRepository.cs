using CertExBackend.Model;

namespace CertExBackend.Repository.IRepository
{
    public interface ICategoryTagRepository
    {
        Task<IEnumerable<CategoryTag>> GetAllCategoryTagsAsync();
        Task<CategoryTag> GetCategoryTagByIdAsync(int id);
        Task AddCategoryTagAsync(CategoryTag categoryTag);
        Task UpdateCategoryTagAsync(CategoryTag categoryTag);
        Task DeleteCategoryTagAsync(int id);
    }
}
