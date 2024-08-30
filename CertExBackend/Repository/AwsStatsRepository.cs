using CertExBackend.Data;
using CertExBackend.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CertExBackend.Repositories
{
    public class AwsStatsRepository : IAwsStatsRepository
    {
        private readonly ApiDbContext _context;
        private const int AwsProviderId = 3; // AWS ProviderId
        private const string PendingStatus = "Not Completed"; // Pending Exam Status
        private const string NominationStatus = "Not Completed"; // Pending Nomination Status

        public AwsStatsRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalAwsNominationsAsync()
        {
            return await _context.Nominations
                .Include(n => n.CertificationExam)
                .Where(n => n.CertificationExam.ProviderId == AwsProviderId)
                .CountAsync();
        }

        public async Task<int> GetPendingNominationsAsync()
        {
            return await _context.Nominations
                .Include(n => n.CertificationExam)
                .Where(n => n.CertificationExam.ProviderId == AwsProviderId
                            && n.ExamStatus == PendingStatus
                            && n.NominationStatus == NominationStatus)
                .CountAsync();
        }
    }
}
