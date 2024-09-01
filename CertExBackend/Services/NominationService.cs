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
            var employeeBody = EmailTemplates.CreateNominationSubmittedEmail(
                certificationExamDto.CertificationName,
                employee.FirstName
            );
            await _emailService.SendEmailAsync(employeeEmail, employeeSubject, employeeBody);

            // Send email to manager if applicable
            if (employee.ManagerId.HasValue)
            {
                var manager = await _employeeRepository.GetEmployeeByIdAsync(employee.ManagerId.Value);
                if (manager != null)
                {
                    var managerEmail = manager.Email;
                    var managerName = manager.FirstName;
                    var managerSubject = "Review Nomination";

                    // Generate the approval URL with query parameters
                    var queryParams = new Dictionary<string, string>
            {
                { "employeeName", $"{employee.FirstName} {employee.LastName}" },
                { "certificationName", certificationExamDto.CertificationName },
                { "plannedExamMonth", nomination.PlannedExamMonth },
                { "motivationDescription", Uri.EscapeDataString(nomination.MotivationDescription) }
            };

                    var queryString = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={kvp.Value}"));
                    var approvalUrl = $"http://localhost:5173/review-nomination/{nomination.Id}?{queryString}";

                    // Generate email body with updated template
                    var managerBody = EmailTemplates.CreateManagerApprovalEmail(
                        certificationExamDto.CertificationName,
                        $"{employee.FirstName} {employee.LastName}",
                        nomination.PlannedExamMonth,
                        nomination.MotivationDescription,
                        managerName,
                        approvalUrl
                    );

                    await _emailService.SendEmailAsync(managerEmail, managerSubject, managerBody);
                }
            }
        }



        public async Task<bool> ProcessManagerFeedbackAsync(ManagerFeedbackDto feedbackDto)
        {
            var nomination = await _nominationRepository.GetNominationByIdAsync(feedbackDto.NominationId);

            if (nomination == null)
            {
                return false;
            }

            // Update the nomination with the feedback data
            nomination.ManagerRecommendation = feedbackDto.Recommendation;
            nomination.ManagerRemarks = feedbackDto.Remarks;
            nomination.UpdatedAt = DateTime.UtcNow;

            await _nominationRepository.UpdateNominationAsync(nomination);

            // Get the employee and certification exam details
            var employee = await _employeeRepository.GetEmployeeByIdAsync(nomination.EmployeeId);
            var certificationExamDto = await _certificationExamService.GetCertificationExamByIdAsync(nomination.CertificationId);

            if (employee == null || certificationExamDto == null)
            {
                return false;
            }

            // Send email to department head
            var departmentHeadEmail = "ajinkjajin@gmail.com"; // Placeholder; Replace with actual retrieval logic
            /*var departmentHeadName = "Department Head";*/ // Placeholder; Replace with actual retrieval logic

            var approvalUrl = $"https://localhost:7209/api/Nomination/approve/department/{nomination.Id}";
            var rejectUrl = $"https://localhost:7209/api/Nomination/reject/department/{nomination.Id}";

            var emailBody = EmailTemplates.CreateDepartmentApprovalEmail(
                certificationExamDto.CertificationName,
                $"{employee.FirstName} {employee.LastName}",
                nomination.PlannedExamMonth,
                nomination.MotivationDescription,
                $"{employee.Manager.FirstName} {employee.Manager.LastName}",
                feedbackDto.Recommendation,
                feedbackDto.Remarks,
                approvalUrl,
                rejectUrl
            );

            var subject = "Nomination Awaiting Your Approval";
            await _emailService.SendEmailAsync(departmentHeadEmail, subject, emailBody);

            return true;
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

                // Send email to employee
                var employeeEmail = employee.Email;
                var employeeSubject = "Nomination Approved by Department Head";
                var employeeBody = EmailTemplates.CreateStatusUpdateEmail(
                    certificationExamDto.CertificationName,
                    "approved by the Department Head",
                    employee.FirstName
                );
                await _emailService.SendEmailAsync(employeeEmail, employeeSubject, employeeBody);

                // Send email to L&D team
                var ldEmail = "ajinkjajin@gmail.com"; // Replace with actual L&D email retrieval logic
                var ldSubject = "Nomination Awaiting Your Final Approval";
                var ldBody = EmailTemplates.CreateLndApprovalEmail(
                    certificationExamDto.CertificationName,
                    $"{employee.FirstName} {employee.LastName}",
                    nomination.PlannedExamMonth,
                    nomination.MotivationDescription,
                    $"{employee.Manager.FirstName} {employee.Manager.LastName}",
                    nomination.ManagerRecommendation,
                    nomination.ManagerRemarks,
                    nomination.IsDepartmentApproved,
                    "https://localhost:7209/api/Nomination/approve/lnd/" + nomination.Id,
                    "https://localhost:7209/api/Nomination/reject/lnd/" + nomination.Id
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

                // Send email to employee
                var employeeEmail = employee.Email;
                var employeeSubject = "Nomination Approved by L&D";
                var employeeBody = EmailTemplates.CreateStatusUpdateEmail(
                    certificationExamDto.CertificationName,
                    "approved by L&D",
                    employee.FirstName
                );
                await _emailService.SendEmailAsync(employeeEmail, employeeSubject, employeeBody);

                // Check if the certification provider is AWS and employee does not have an active AWS account
                if (certificationExamDto.ProviderName.Equals("AWS", StringComparison.OrdinalIgnoreCase) && !employee.AwsAccountActive)
                {
                    var awsAdminEmail = "ajinkjajin@gmail.com"; // Replace with actual AWS admin email retrieval logic
                    var awsAdminSubject = "AWS Certification: Action Required";

                    // Encode query parameters to be URL safe
                    var queryParams = new List<string>
            {
                $"employeeId={employee.Id}", // Pass employeeId instead of nominationId
                $"employeeName={Uri.EscapeDataString($"{employee.FirstName} {employee.LastName}")}",
                $"email={Uri.EscapeDataString(employee.Email)}",
                $"certificationName={Uri.EscapeDataString(certificationExamDto.CertificationName)}",
                $"plannedExamMonth={Uri.EscapeDataString(nomination.PlannedExamMonth)}"
            };

                    // Construct the URL with query parameters
                    var awsAdminUrl = $"http://localhost:5173/aws-admin-review/{employee.Id}?{string.Join("&", queryParams)}";

                    var awsAdminBody = EmailTemplates.CreateAwsAdminEmail(
                        certificationExamDto.CertificationName,
                        $"{employee.FirstName} {employee.LastName}",
                        employee.Email,
                        nomination.PlannedExamMonth,
                        awsAdminUrl // URL to the React component with all relevant info
                    );

                    await _emailService.SendEmailAsync(awsAdminEmail, awsAdminSubject, awsAdminBody);
                }
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
