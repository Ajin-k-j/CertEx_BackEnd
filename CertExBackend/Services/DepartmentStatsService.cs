using System.Threading.Tasks;
using CertExBackend.DTOs;
using CertExBackend.Repositories;

namespace CertExBackend.Services
{
    public class DepartmentStatsService : IDepartmentStatsService
    {
        private readonly IDepartmentStatsRepository _repository;

        public DepartmentStatsService(IDepartmentStatsRepository repository)
        {
            _repository = repository;
        }

        public Task<DepartmentStatsDto> GetDepartmentStatsAsync(int departmentId)
        {
            return _repository.GetDepartmentStatsAsync(departmentId);
        }
    }
}
