using CertExBackend.Data;
using CertExBackend.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CertExBackend.Repositories
{
    public class AwsNominationRepository : IAwsNominationRepository
    {
        private readonly ApiDbContext _context;

        public AwsNominationRepository(ApiDbContext context)
        {
            _context = context;
        }

        public Nomination GetNomination(int nominationId)
        {
            return _context.Nominations
                .Include(n => n.Employee)
                .ThenInclude(e => e.Department) // Ensure Department is included
                .Include(n => n.CertificationExam)
                .ThenInclude(ce => ce.CertificationProvider)
                .SingleOrDefault(n => n.Id == nominationId);
        }

        public bool IsCertificationCritical(int certificationId)
        {
            return _context.CriticalCertifications
                .Any(cc => cc.CertificationId == certificationId);
        }

        public IEnumerable<Nomination> GetAllAwsNominations()
        {
            return _context.Nominations
                .Include(n => n.Employee)
                .ThenInclude(e => e.Department) // Ensure Department is included
                .Include(n => n.CertificationExam)
                .ThenInclude(ce => ce.CertificationProvider)
                .Where(n => n.CertificationExam.CertificationProvider.ProviderName == "AWS")
                .ToList();
        }
    }
}
