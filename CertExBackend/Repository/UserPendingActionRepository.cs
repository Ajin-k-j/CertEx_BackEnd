using CertExBackend.Data;
using CertExBackend.DTOs;
using CertExBackend.Repository.IRepository;
using Microsoft.EntityFrameworkCore;


namespace CertExBackend.Repository
{
    public class UserPendingActionRepository : IUserPendingActionRepository
    {
        private readonly ApiDbContext _dbcontext;

        public UserPendingActionRepository(ApiDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<UserPendingActionDto>> GetUserPendingActionsAsync(int employeeId)
        {
            return await _dbcontext.Nominations
                .Where(n => n.EmployeeId == employeeId && n.NominationStatus == "Not Completed" && n.CertificationExam.NominationStatus == "Accepting")
                .Select(n => new UserPendingActionDto
                {
                    Id = n.Id,
                    EmployeeId = n.EmployeeId,
                    CertificationId = n.CertificationId,
                    NominationStatusFromNomination = n.NominationStatus,
                    NominationStatusFromCertificationExam = n.CertificationExam.NominationStatus,
                    CertificationName = n.CertificationExam.CertificationName
                })
                .ToListAsync();
        }
    }
}

