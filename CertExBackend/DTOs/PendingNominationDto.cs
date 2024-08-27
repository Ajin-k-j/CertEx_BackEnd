namespace CertExBackend.DTOs
{
    public class PendingNominationDto
    {
        public int Id { get; set; }
        public string CertificationName { get; set; }
        public string EmployeeName { get; set; }
        public string PlannedExamMonth { get; set; }
        public string MotivationDescription { get; set; }
        public string ProviderName { get; set; }
        public string DepartmentName { get; set; }
    }
}
