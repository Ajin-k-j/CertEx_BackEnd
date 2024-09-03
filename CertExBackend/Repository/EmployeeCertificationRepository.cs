using CertExBackend.Data;
using CertExBackend.Model;
using Microsoft.EntityFrameworkCore;

public class EmployeeCertificationRepository : IEmployeeCertificationRepository
{
    private readonly ApiDbContext _context;

    public EmployeeCertificationRepository(ApiDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Nomination>> GetPassedCertificationsByEmployeeIdAsync(int employeeId)
    {
        return await _context.Nominations
            .Where(n => n.EmployeeId == employeeId && n.ExamStatus == "Passed")
            .Include(n => n.CertificationExam)
                .ThenInclude(e => e.CertificationProvider)
            .Include(n => n.CertificationExam.CertificationTag)
                .ThenInclude(ct => ct.CategoryTag)
            .Include(n => n.ExamDetails)
                .ThenInclude(ed => ed.MyCertification)
            .ToListAsync();
        
    }


}
