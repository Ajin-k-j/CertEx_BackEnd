using CertExBackend.Model;

namespace CertExBackend.Interfaces
{
    public interface ICertificationExamRepository
    {
        IEnumerable<CertificationExam> GetAllCertificationExams();
        CertificationExam GetCertificationExamById(int id);
        void AddCertificationExam(CertificationExam exam);
        void UpdateCertificationExam(CertificationExam exam);
        void DeleteCertificationExam(int id);
    }
}
