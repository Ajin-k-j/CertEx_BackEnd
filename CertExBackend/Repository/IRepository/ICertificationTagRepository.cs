using CertExBackend.Model;

namespace CertExBackend.Repository.IRepository
{
    public interface ICertificationTagRepository
    {
        Task<IEnumerable<CertificationTag>> GetAllCertificationTagsAsync();
        Task<CertificationTag> GetCertificationTagByIdAsync(int id);
        Task AddCertificationTagAsync(CertificationTag certificationTag);
        Task UpdateCertificationTagAsync(CertificationTag certificationTag);
        Task DeleteCertificationTagAsync(int id);
    }
}
