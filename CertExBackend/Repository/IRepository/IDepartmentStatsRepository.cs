using System.Threading.Tasks;
using CertExBackend.DTOs;

namespace CertExBackend.Repositories
{
    public interface IDepartmentStatsRepository
    {
        Task<DepartmentStatsDto> GetDepartmentStatsAsync(int departmentId);
    }
}
