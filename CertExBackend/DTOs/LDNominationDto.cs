// DTOs/LDNominationDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace CertExBackend.DTOs
{
    public class LDNominationDto
    {
        public int NominationId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string EmployeeName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Department { get; set; }

        [Required]
        [MaxLength(100)]
        public string Provider { get; set; }

        [Required]
        [MaxLength(100)]
        public string CertificationName { get; set; }

        [Required]
        [MaxLength(20)]
        public string Criticality { get; set; }

        [Required]
        public DateTime NominationDate { get; set; }

        [MaxLength(50)]
        public string PlannedExamMonth { get; set; }

        [Required]
        public string MotivationDescription { get; set; }

        public string ManagerRecommendation { get; set; }

        public string ManagerRemarks { get; set; }

        public bool IsDepartmentApproved { get; set; }

        /*public string DepartmentHeadRemarks { get; set; }*/

        public bool IsLndApproved { get; set; }

        /* public string LndRemarks { get; set; }*/

        public DateTime? ExamDate { get; set; }

        [MaxLength(20)]
        public string ExamStatus { get; set; }

        [MaxLength(20)]
        public string UploadCertificateStatus { get; set; }

        [MaxLength(20)]
        public string SkillMatrixStatus { get; set; }

        [MaxLength(20)]
        public string ReimbursementStatus { get; set; }

        [MaxLength(20)]
        public string NominationStatus { get; set; }

        [MaxLength(10)]
        public string FinancialYear { get; set; }

        [Range(0, double.MaxValue)]
        public decimal CostOfCertification { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string CreatedBy { get; set; } = "system";

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public string UpdatedBy { get; set; } = "system";
    }
}