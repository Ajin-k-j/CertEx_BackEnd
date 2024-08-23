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

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        // Navigation properties
        [JsonIgnore]
        public CertificationExam CertificationExam { get; set; }

        [JsonIgnore]
        public FinancialYear FinancialYear { get; set; }
    }
}
