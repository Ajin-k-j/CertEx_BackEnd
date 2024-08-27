namespace CertExBackend.DTO
{
    public class AwsNominationDto
    {
        public int NominationId { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; } // Ensure this property exists
        public string CertificationName { get; set; }
        public string Provider { get; set; }
        public string Level { get; set; }
        public DateTime Date { get; set; }
        public string Criticality { get; set; }
    }
}
