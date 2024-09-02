using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;
using CertExBackend.Utilities;

namespace CertExBackend.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public EmployeeService(
        IEmployeeRepository employeeRepository,
        IEmailService emailService, // Inject IEmailService
        IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _emailService = emailService; // Initialize IEmailService
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task AddEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _employeeRepository.AddEmployeeAsync(employee);
        }

        public async Task<EmployeeDto> GetEmployeeByUsernameAsync(string username)
        {
            var employee = await _employeeRepository.GetEmployeeByUsernameAsync(username);
            return _mapper.Map<EmployeeDto>(employee);
        }


        public async Task UpdateAwsDetailsAsync(int employeeId, string awsCredentials, string awsAdminRemarks)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);
            if (employee != null)
            {
                /*employee.AwsAccountActive = true;*///after testing uncomment this.
                employee.AWSCredentials = awsCredentials;
                employee.AWSAdminRemarks = awsAdminRemarks;
                await _employeeRepository.UpdateEmployeeAsync(employee);

                // Prepare email
                var employeeEmail = employee.Email;
                var awsAdminEmail = "kalon2k23@gmail.com"; // Replace with actual AWS admin email retrieval logic
                var subject = "Your AWS Credentials and Access Details";
                var body = EmailTemplates.CreateAwsCredentialsEmail(
                    awsCredentials,
                    awsAdminRemarks
                );

                // Send email
                await _emailService.SendEmailWithCcAsync(employeeEmail, subject, body, awsAdminEmail);

            }
            else
            {
                throw new Exception("Employee not found.");
            }
        }


        public async Task UpdateEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _employeeRepository.UpdateEmployeeAsync(employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
        }
    }
}
