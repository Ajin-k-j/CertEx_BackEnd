using System.Collections.Generic;
using System.Threading.Tasks;
using CertExBackend.DTOs;

namespace CertExBackend.Services.IServices
{
    public interface IEmployeeCertificationService
    {
        Task<IEnumerable<EmployeeCertificationDto>> GetCertificationsByEmployeeIdAsync(int employeeId);
    }
}
