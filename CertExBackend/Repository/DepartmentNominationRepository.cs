using AutoMapper;
using CertExBackend.Data;
using CertExBackend.Model;
using Microsoft.EntityFrameworkCore;

public class DepartmentNominationRepository : IDepartmentNominationRepository
{
    private readonly ApiDbContext _context;
    private readonly IMapper _mapper;

    public DepartmentNominationRepository(ApiDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DepartmentNominationDto>> GetNominationsByDepartmentAsync(int departmentId)
    {
        var nominations = await _context.Nominations
            .Include(n => n.Employee)
            .Include(n => n.CertificationExam)
                .ThenInclude(e => e.CertificationProvider)
            .Include(n => n.ExamDetail)
            .Where(n => n.Employee.DepartmentId == departmentId)
            .ToListAsync();

        return _mapper.Map<IEnumerable<DepartmentNominationDto>>(nominations);
    }
}
