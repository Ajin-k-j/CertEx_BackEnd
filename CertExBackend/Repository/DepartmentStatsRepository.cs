using AutoMapper;
using CertExBackend.Data;
using CertExBackend.DTOs;
using CertExBackend.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CertExBackend.Repositories
{
    public class DepartmentStatsRepository : IDepartmentStatsRepository
    {
        private readonly ApiDbContext _context;  // Use ApiDbContext here
        private readonly IMapper _mapper;

        public DepartmentStatsRepository(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DepartmentStatsDto> GetDepartmentStatsAsync(int departmentId)
        {
            var department = await _context.Departments
                .Include(d => d.Employees)
                .ThenInclude(e => e.Nominations) // If you need to include nominations or certifications
                .FirstOrDefaultAsync(d => d.Id == departmentId);

            if (department == null)
            {
                return null;
            }

            // Create a DTO to hold the department stats
            var departmentStats = new DepartmentStatsDto
            {
                Department = department.DepartmentName,
                Employees = department.Employees.Count,
                Certifications = department.Employees
                                    .SelectMany(e => e.Nominations)
                                    .Select(n => n.CertificationExam)
                                    .Distinct()
                                    .Count()
            };

            return departmentStats;
        }
    }
}
