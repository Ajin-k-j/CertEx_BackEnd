using CertExBackend.Model;

namespace CertExBackend.Interfaces
{
    public interface ICategoryTagRepository
    {
        IEnumerable<CategoryTag> GetAllCategoryTags();
        CategoryTag GetCategoryTagById(int id);
        void AddCategoryTag(CategoryTag tag);
        void UpdateCategoryTag(CategoryTag tag);
        void DeleteCategoryTag(int id);
    }
}
