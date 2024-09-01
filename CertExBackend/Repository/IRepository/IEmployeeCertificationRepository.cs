using CertExBackend.Model;

public interface IEmployeeCertificationRepository
{
    Task<IEnumerable<Nomination>> GetPassedCertificationsByEmployeeIdAsync(int employeeId);
}
