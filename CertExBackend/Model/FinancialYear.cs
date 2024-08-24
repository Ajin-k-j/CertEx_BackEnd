using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CertExBackend.Model
{
    public class FinancialYear
    {
        [Key]
        public int Id { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } // Active, Inactive

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; } = "system";
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string UpdatedBy { get; set; } = "system";

        // Navigation property for CriticalCertifications
        [JsonIgnore]
        public ICollection<CriticalCertification> CriticalCertifications { get; set; }
    }
}
