using CertExBackend.Model;

namespace CertExBackend.Interfaces
{
    public interface ICertificationTagRepository
    {
        IEnumerable<CertificationTag> GetAllCertificationTags();
        CertificationTag GetCertificationTagById(int id);
        void AddCertificationTag(CertificationTag tag);
        void UpdateCertificationTag(CertificationTag tag);
        void DeleteCertificationTag(int id);
    }
}
