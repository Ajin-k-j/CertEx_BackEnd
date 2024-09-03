// Repositories/LDNominationRepository.cs
using CertExBackend.Data;
using CertExBackend.Model;
using CertExBackend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertExBackend.Repositories
{
    public class LDNominationRepository : ILDNominationRepository
    {
        private readonly ApiDbContext _context;

        public LDNominationRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Nomination> GetNominationByIdAsync(int id)
        {
            return await _context.Nominations
                .Include(n => n.Employee)
                .Include(n => n.CertificationExam)
                .Include(n => n.ExamDetails)
                .FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<IEnumerable<Nomination>> GetAllNominationsAsync()
        {
            return await _context.Nominations
                .Include(n => n.Employee)
                .ThenInclude(n => n.Department)
                .Include(n => n.CertificationExam)
                .ThenInclude(ce => ce.CertificationProvider)
                .Include(n => n.ExamDetails)
                .ToListAsync();
        }
    }
}
