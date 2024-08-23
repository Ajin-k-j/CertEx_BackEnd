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

        [MaxLength(20)]
        public string DepartmentApproval { get; set; } // Approved, Pending, Rejected

        [MaxLength(20)]
        public string LndApproval { get; set; } // Approved, Pending, Rejected

        [MaxLength(20)]
        public string ExamStatus { get; set; } // Passed, Failed

        [MaxLength(20)]
        public string NominationStatus { get; set; } // Complete, Not Completed, Rejected

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        // Navigation properties
        [JsonIgnore]
        public CertificationExam CertificationExam { get; set; }

        [JsonIgnore]
        public Employee Employee { get; set; }

        // Navigation property for ExamDetails
        [JsonIgnore]
        public ICollection<ExamDetail> ExamDetails { get; set; }
    }
}
