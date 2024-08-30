using System.Threading.Tasks;
using CertExBackend.DTOs;

namespace CertExBackend.Services
{
    public interface IDepartmentStatsService
    {
        Task<DepartmentStatsDto> GetDepartmentStatsAsync(int departmentId);
    }
}
