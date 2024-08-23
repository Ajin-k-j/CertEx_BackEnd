using CertExBackend.Model;

namespace CertExBackend.Interfaces
{
    public interface IExamDetailRepository
    {
        IEnumerable<ExamDetail> GetAllExamDetails();
        ExamDetail GetExamDetailById(int id);
        void AddExamDetail(ExamDetail examDetail);
        void UpdateExamDetail(ExamDetail examDetail);
        void DeleteExamDetail(int id);
    }
}
