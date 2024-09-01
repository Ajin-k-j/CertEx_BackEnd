using CertExBackend.DTOs;

namespace CertExBackend.Services.IServices
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(EmployeeDto employeeDto);
        Task UpdateEmployeeAsync(EmployeeDto employeeDto);
        Task DeleteEmployeeAsync(int id);

        // New method for updating AWS credentials and admin remarks
        Task UpdateAwsDetailsAsync(int employeeId, string awsCredentials, string awsAdminRemarks);
    }
}
