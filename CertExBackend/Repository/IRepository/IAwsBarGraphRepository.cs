using CertExBackend.DTOs;

namespace CertExBackend.Repository.IRepository
{
    public interface IAwsBarGraphRepository
    {
        Task<IEnumerable<AwsBarGraphDto>> GetAwsBarGraphDataAsync();
        Task<MonthlyExamCompletionDTO> GetFilteredExamCompletionDataAsync(int financialYearId, int? departmentId);

    }
}

