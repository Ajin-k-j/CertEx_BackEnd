using System.Collections.Generic;
using System.Threading.Tasks;
using CertExBackend.Model;

namespace CertExBackend.Repository.IRepository
{
    public interface IEmployeeCertificationRepository
    {
        Task<IEnumerable<ExamDetail>> GetCertificationsByEmployeeIdAsync(int employeeId);
    }
}
