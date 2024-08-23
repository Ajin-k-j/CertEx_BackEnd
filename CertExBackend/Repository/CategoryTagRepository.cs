using CertExBackend.Data;
using CertExBackend.Interfaces;
using CertExBackend.Model;

namespace CertExBackend.Repository
{
    public class CategoryTagRepository : ICategoryTagRepository
    {
        private readonly ApiDbContext _dbContext;

        public CategoryTagRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CategoryTag> GetAllCategoryTags()
        {
            return _dbContext.CategoryTags.ToList();
        }

        public CategoryTag GetCategoryTagById(int id)
        {
            return _dbContext.CategoryTags.Find(id);
        }

        public void AddCategoryTag(CategoryTag tag)
        {
            _dbContext.CategoryTags.Add(tag);
            _dbContext.SaveChanges();
        }

        public void UpdateCategoryTag(CategoryTag tag)
        {
            _dbContext.CategoryTags.Update(tag);
            _dbContext.SaveChanges();
        }

        public void DeleteCategoryTag(int id)
        {
            var tag = _dbContext.CategoryTags.Find(id);
            if (tag != null)
            {
                _dbContext.CategoryTags.Remove(tag);
                _dbContext.SaveChanges();
            }
        }
    }
}
