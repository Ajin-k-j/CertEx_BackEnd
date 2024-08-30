using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;
using CertExBackend.Utilities;

namespace CertExBackend.Services
{
    public class NominationService : INominationService
    {
        private readonly INominationRepository _nominationRepository;
        private readonly IEmailService _emailService;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICertificationExamService _certificationExamService;
        private readonly IMapper _mapper;

        public NominationService(
            INominationRepository nominationRepository,
            IEmailService emailService,
            IEmployeeRepository employeeRepository,
            ICertificationExamService certificationExamService,
            IMapper mapper)
        {
            _nominationRepository = nominationRepository;
            _emailService = emailService;
            _employeeRepository = employeeRepository;
            _certificationExamService = certificationExamService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NominationDto>> GetAllNominationsAsync()
        {
            var nominations = await _nominationRepository.GetAllNominationsAsync();
            return _mapper.Map<IEnumerable<NominationDto>>(nominations);
        }

        public async Task<NominationDto> GetNominationByIdAsync(int id)
        {
            var nomination = await _nominationRepository.GetNominationByIdAsync(id);
            return _mapper.Map<NominationDto>(nomination);
        }

        public async Task AddNominationAsync(NominationCreateDto nominationCreateDto)
        {
            var nomination = _mapper.Map<Nomination>(nominationCreateDto);
            nomination.CreatedAt = nominationCreateDto.CreatedAt;
            nomination.CreatedBy = nominationCreateDto.CreatedBy;
            nomination.UpdatedAt = nominationCreateDto.UpdatedAt;
            nomination.UpdatedBy = nominationCreateDto.UpdatedBy;

            await _nominationRepository.AddNominationAsync(nomination);

            // Get certification exam details using the service
            var certificationExamDto = await _certificationExamService.GetCertificationExamByIdAsync(nomination.CertificationId);

            if (certificationExamDto == null)
            {
                throw new Exception("Certification exam not found.");
            }

            // Get employee details
            var employee = await _employeeRepository.GetEmployeeByIdAsync(nomination.EmployeeId);

            if (employee == null)
            {
                throw new Exception("Employee not found.");
            }

            // Send email to employee
            var employeeEmail = employee.Email;
            var employeeSubject = "Nomination Submitted";
            var employeeBody = EmailTemplates.CreateNominationSubmittedEmail(certificationExamDto.CertificationName, employee.FirstName);
            await _emailService.SendEmailAsync(employeeEmail, employeeSubject, employeeBody);

            // Send email to manager if applicable
            if (employee.ManagerId.HasValue)
            {
                var manager = await _employeeRepository.GetEmployeeByIdAsync(employee.ManagerId.Value);
                if (manager != null)
                {
                    var managerEmail = manager.Email;
                    var managerSubject = "Employee Nomination Submitted";
                    var managerBody = EmailTemplates.CreateManagerNotificationEmail(
                        $"{employee.FirstName} {employee.LastName}",
                        certificationExamDto.CertificationName,
                        manager.FirstName
                    );
                    await _emailService.SendEmailAsync(managerEmail, managerSubject, managerBody);
                }
            }

            // Send email to department head
            var departmentHeadEmail = "sahirnisar4388@gmail.com"; // Replace with actual email retrieval logic
            var departmentHeadSubject = "Nomination Awaiting Approval";
            var departmentHeadBody = EmailTemplates.CreateApprovalRequestEmail(
            certificationExamDto.CertificationName,
            $"{employee.FirstName} {employee.LastName}",
            nomination.PlannedExamMonth,
            nomination.MotivationDescription,
            "https://localhost:7209/api/Nomination/approve/department/" + nomination.Id,
            "https://localhost:7209/api/Nomination/reject/department/" + nomination.Id,
            "Department Head"
        );

            await _emailService.SendEmailAsync(departmentHeadEmail, departmentHeadSubject, departmentHeadBody);
        }

        public async Task UpdateNominationAsync(NominationDto nominationDto)
        {
            var nomination = await _nominationRepository.GetNominationByIdAsync(nominationDto.Id);
            if (nomination != null)
            {
                nomination = _mapper.Map(nominationDto, nomination);
                nomination.UpdatedAt = DateTime.UtcNow;
                nomination.UpdatedBy = "system"; // Should be replaced with the actual user context

                await _nominationRepository.UpdateNominationAsync(nomination);
            }
        }

        public async Task ApproveDepartmentAsync(int id)
        {
            var nomination = await _nominationRepository.GetNominationByIdAsync(id);
            if (nomination != null)
            {
                nomination.IsDepartmentApproved = true;
                nomination.UpdatedAt = DateTime.UtcNow;

                await _nominationRepository.UpdateNominationAsync(nomination);
                var employee = await _employeeRepository.GetEmployeeByIdAsync(nomination.EmployeeId);
                var certificationExamDto = await _certificationExamService.GetCertificationExamByIdAsync(nomination.CertificationId);

                if (employee == null || certificationExamDto == null)
                {
                    throw new Exception("Employee or Certification exam not found.");
                }

                var employeeEmail = employee.Email;
                var employeeSubject = "Nomination Approved by Department Head";
                var employeeBody = EmailTemplates.CreateStatusUpdateEmail(certificationExamDto.CertificationName, "approved by the Department Head", employee.FirstName);
                await _emailService.SendEmailAsync(employeeEmail, employeeSubject, employeeBody);

                var ldEmail = "sahirnisar4388@gmail.com"; // Replace with actual L&D email retrieval logic
                var ldSubject = "Nomination Awaiting L&D Approval";
                var ldBody = EmailTemplates.CreateApprovalRequestEmail(
                certificationExamDto.CertificationName,
                $"{employee.FirstName} {employee.LastName}",
                nomination.PlannedExamMonth,
                nomination.MotivationDescription,
                "https://localhost:7209/api/Nomination/approve/lnd/" + nomination.Id,
                "https://localhost:7209/api/Nomination/reject/lnd/" + nomination.Id,
                "L&D"
            );

                await _emailService.SendEmailAsync(ldEmail, ldSubject, ldBody);
            }
        }

            public async Task ApproveLndAsync(int id)
        {
            var nomination = await _nominationRepository.GetNominationByIdAsync(id);
            if (nomination != null)
            {
                nomination.IsLndApproved = true;
                nomination.UpdatedAt = DateTime.UtcNow;

                await _nominationRepository.UpdateNominationAsync(nomination);
                var employee = await _employeeRepository.GetEmployeeByIdAsync(nomination.EmployeeId);
                var certificationExamDto = await _certificationExamService.GetCertificationExamByIdAsync(nomination.CertificationId);

                if (employee == null || certificationExamDto == null)
                {
                    throw new Exception("Employee or Certification exam not found.");
                }

                var employeeEmail = employee.Email;
                var employeeSubject = "Nomination Approved by L&D";
                var employeeBody = EmailTemplates.CreateStatusUpdateEmail(certificationExamDto.CertificationName, "approved by L&D", employee.FirstName);
                await _emailService.SendEmailAsync(employeeEmail, employeeSubject, employeeBody);
            }

        }

        public async Task RejectDepartmentAsync(int id)
        {
            var nomination = await _nominationRepository.GetNominationByIdAsync(id);
            if (nomination != null)
            {
                nomination.IsDepartmentApproved = false; // Assuming rejecting sets this to false
                nomination.UpdatedAt = DateTime.UtcNow;

                await _nominationRepository.UpdateNominationAsync(nomination);
                var employee = await _employeeRepository.GetEmployeeByIdAsync(nomination.EmployeeId);
                var certificationExamDto = await _certificationExamService.GetCertificationExamByIdAsync(nomination.CertificationId);

                if (employee == null || certificationExamDto == null)
                {
                    throw new Exception("Employee or Certification exam not found.");
                }

                var employeeEmail = employee.Email;
                var employeeSubject = "Nomination Rejected by Department Head";
                var employeeBody = EmailTemplates.CreateStatusUpdateEmail(certificationExamDto.CertificationName, "rejected by the Department Head", employee.FirstName);
                await _emailService.SendEmailAsync(employeeEmail, employeeSubject, employeeBody);
            }
        }

        public async Task RejectLndAsync(int id)
        {
            var nomination = await _nominationRepository.GetNominationByIdAsync(id);
            if (nomination != null)
            {
                nomination.IsLndApproved = false; // Assuming rejecting sets this to false
                nomination.UpdatedAt = DateTime.UtcNow;

                await _nominationRepository.UpdateNominationAsync(nomination);
                var employee = await _employeeRepository.GetEmployeeByIdAsync(nomination.EmployeeId);
                var certificationExamDto = await _certificationExamService.GetCertificationExamByIdAsync(nomination.CertificationId);

                if (employee == null || certificationExamDto == null)
                {
                    throw new Exception("Employee or Certification exam not found.");
                }

                var employeeEmail = employee.Email;
                var employeeSubject = "Nomination Rejected by L&D";
                var employeeBody = EmailTemplates.CreateStatusUpdateEmail(certificationExamDto.CertificationName, "rejected by L&D", employee.FirstName);
                await _emailService.SendEmailAsync(employeeEmail, employeeSubject, employeeBody);
            }
        }


        public async Task<IEnumerable<PendingNominationDto>> GetPendingLndApprovalsAsync()
        {
            var nominations = await _nominationRepository.GetAllNominationsAsync();
            var pendingNominations = nominations
                .Where(n => !n.IsLndApproved)
                .ToList();

            return _mapper.Map<IEnumerable<PendingNominationDto>>(pendingNominations);
        }

        public async Task<IEnumerable<PendingNominationDto>> GetPendingDepartmentApprovalsAsync(int departmentId)
        {
            var nominations = await _nominationRepository.GetAllNominationsAsync();
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            var employeeIdsInDepartment = employees
                .Where(e => e.DepartmentId == departmentId)
                .Select(e => e.Id)
                .ToList();

            var pendingNominations = nominations
                .Where(n => !n.IsDepartmentApproved && employeeIdsInDepartment.Contains(n.EmployeeId))
                .ToList();

            return _mapper.Map<IEnumerable<PendingNominationDto>>(pendingNominations);
        }

        public async Task DeleteNominationAsync(int id)
        {
            await _nominationRepository.DeleteNominationAsync(id);
        }
    }
}
