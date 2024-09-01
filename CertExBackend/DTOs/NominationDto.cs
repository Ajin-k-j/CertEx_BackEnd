namespace CertExBackend.DTOs
{
    public class NominationDto
    {
        public int Id { get; set; }
        public int CertificationId { get; set; }
        public int EmployeeId { get; set; }
        public string PlannedExamMonth { get; set; }
        public string MotivationDescription { get; set; }
        public DateTime? ExamDate { get; set; }
        public string ManagerRecommendation { get; set; }
        public string ManagerRemarks { get; set; }
        public bool IsDepartmentApproved { get; set; }
        public bool IsLndApproved { get; set; }
        public string ExamStatus { get; set; }
        public string NominationStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
