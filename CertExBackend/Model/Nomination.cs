using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CertExBackend.Model
{
    public class Nomination
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("CertificationExam")]
        public int CertificationId { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string PlannedExamMonth { get; set; }

        [Required]
        public string MotivationDescription { get; set; }

        public DateTime? ExamDate { get; set; }

        // New fields
        public string ManagerRecommendation { get; set; } 
        public string ManagerRemarks { get; set; } 

        // Existing fields
        public bool IsDepartmentApproved { get; set; } = false; 
        public string DepartmentHeadRemarks { get; set; } 

        public bool IsLndApproved { get; set; } = false; 
        public string LndRemarks { get; set; } 

        [MaxLength(20)]
        public string ExamStatus { get; set; } = "Not Completed"; 

        [MaxLength(20)]
        public string NominationStatus { get; set; } = "Not Completed"; 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; } = "system";
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string UpdatedBy { get; set; } = "system";

        // Navigation properties
        [JsonIgnore]
        public CertificationExam CertificationExam { get; set; }

        [JsonIgnore]
        public Employee Employee { get; set; }

        [JsonIgnore]
        public ExamDetail ExamDetails { get; set; } 
    }
}
