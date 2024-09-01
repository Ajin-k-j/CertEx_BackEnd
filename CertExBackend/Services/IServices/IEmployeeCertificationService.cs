public interface IEmployeeCertificationService
{
    Task<IEnumerable<EmployeeCertificationDto>> GetCertificationsByEmployeeIdAsync(int employeeId);
}
