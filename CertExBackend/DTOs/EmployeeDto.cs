namespace CertExBackend.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public int AppRoleId { get; set; }
        public bool AwsAccountActive { get; set; }
        public string Email { get; set; }
        public string SSOEmployeeId { get; set; }
        public int? ManagerId { get; set; }
        public bool IsManager { get; set; }
        public bool IsDepartmentHead { get; set; }
        public string Designation { get; set; }
    }
}
