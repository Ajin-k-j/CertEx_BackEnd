using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CertExBackend.Model
{
    public class CriticalCertification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("CertificationExam")]
        public int CertificationId { get; set; }

        [Required]
        [ForeignKey("FinancialYear")]
        public int FinancialYearId { get; set; }

        [Required]
        public int RequiredCount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; } = "system";
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string UpdatedBy { get; set; } = "system";

        // Navigation properties
        [JsonIgnore]
        public CertificationExam CertificationExam { get; set; }

        [JsonIgnore]
        public FinancialYear FinancialYear { get; set; }
    }
}
