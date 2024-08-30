using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CertExBackend.Data;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

public class EmployeeCertificationRepository : IEmployeeCertificationRepository
{
    private readonly ApiDbContext _dbContext;

    public EmployeeCertificationRepository(ApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<ExamDetail>> GetCertificationsByEmployeeIdAsync(int employeeId)
    {
        return await _dbContext.ExamDetails
            .Include(ed => ed.MyCertification)
            .Where(ed => ed.Nomination.EmployeeId == employeeId)
            .ToListAsync();
    }
}
