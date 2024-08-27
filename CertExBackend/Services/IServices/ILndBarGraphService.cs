using CertExBackend.DTOs;

namespace CertExBackend.Services.IServices
{
    public interface ILndBarGraphService
    {
        Task<IEnumerable<LndBarGraphDTO>> GetLndBarGraphDataAsync();
        Task<MonthlyExamCompletionDTO> GetFilteredExamCompletionDataAsync(int financialYearId, int? departmentId, int? providerId);



    }
}

