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

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        // Navigation property for CriticalCertifications
        [JsonIgnore]
        public ICollection<CriticalCertification> CriticalCertifications { get; set; }
    }
}
