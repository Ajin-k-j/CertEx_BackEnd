using CertExBackend.DTOs;

namespace CertExBackend.Services.IServices
{
    public interface IAwsBarGraphService
    {
        Task<IEnumerable<AwsBarGraphDto>> GetAwsBarGraphDataAsync();
        Task<MonthlyExamCompletionDTO> GetFilteredExamCompletionDataAsync(int financialYearId, int? departmentId);

    }
}


