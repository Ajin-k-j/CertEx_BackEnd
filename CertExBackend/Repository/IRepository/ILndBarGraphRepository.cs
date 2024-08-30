using CertExBackend.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CertExBackend.Repository.IRepository
{
    public interface ILndBarGraphRepository
    {
        Task<IEnumerable<LndBarGraphDTO>> GetLndBarGraphDataAsync();
        Task<MonthlyExamCompletionDTO> GetFilteredExamCompletionDataAsync(int financialYearId, int? departmentId, int? providerId);


    }
}

