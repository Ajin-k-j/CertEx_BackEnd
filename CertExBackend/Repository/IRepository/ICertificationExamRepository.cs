using CertExBackend.Model;

namespace CertExBackend.Repository.IRepository
{
    public interface ICertificationExamRepository
    {
        Task<IEnumerable<CertificationExam>> GetAllCertificationExamsAsync();
        Task<CertificationExam> GetCertificationExamByIdAsync(int id);
        Task AddCertificationExamAsync(CertificationExam certificationExam);
        Task UpdateCertificationExamAsync(CertificationExam certificationExam);
        Task DeleteCertificationExamAsync(int id);
    }
}
