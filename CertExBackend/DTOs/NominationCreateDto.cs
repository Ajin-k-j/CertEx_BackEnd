namespace CertExBackend.DTOs
{
    public class NominationCreateDto
    {
        public int Id { get; set; }
        public int CertificationId { get; set; }
        public int EmployeeId { get; set; }
        public string PlannedExamMonth { get; set; }
        public string MotivationDescription { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; } = "system"; 
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string UpdatedBy { get; set; } = "system"; 
    }
}
