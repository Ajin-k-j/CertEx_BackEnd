using CertExBackend.Data;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CertExBackend.Repository
{
    public class CategoryTagRepository : ICategoryTagRepository
    {
        private readonly ApiDbContext _dbContext;

        public CategoryTagRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CategoryTag>> GetAllCategoryTagsAsync()
        {
            return await _dbContext.CategoryTags.ToListAsync();
        }

        public async Task<CategoryTag> GetCategoryTagByIdAsync(int id)
        {
            return await _dbContext.CategoryTags.FindAsync(id);
        }

        public async Task AddCategoryTagAsync(CategoryTag categoryTag)
        {
            _dbContext.CategoryTags.Add(categoryTag);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCategoryTagAsync(CategoryTag categoryTag)
        {
            _dbContext.CategoryTags.Update(categoryTag);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCategoryTagAsync(int id)
        {
            var categoryTag = await _dbContext.CategoryTags.FindAsync(id);
            if (categoryTag != null)
            {
                _dbContext.CategoryTags.Remove(categoryTag);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
