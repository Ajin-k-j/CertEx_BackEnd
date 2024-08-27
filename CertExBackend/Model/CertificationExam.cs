using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CertExBackend.Model
{
    public class CertificationExam
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("CertificationProvider")]
        public int ProviderId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CertificationName { get; set; }

        [Required]
        [MaxLength(20)]
        public string NominationStatus { get; set; } // Accepting, NotAccepting

        [Required]
        [MaxLength(20)]
        public string Level { get; set; } // Beginner, Intermediate, Expert

        public string Description { get; set; }
        public int Views { get; set; }
        [MaxLength(200)]
        public string OfficialLink { get; set; }
        public decimal CostUsd { get; set; }
        public decimal CostInr { get; set; }
        public DateTime? NominationOpenDate { get; set; }
        public DateTime? NominationCloseDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; } = "system";
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string UpdatedBy { get; set; } = "system";

        // Navigation property for CertificationTags
        [JsonIgnore]
        public ICollection<CertificationTag> CertificationTags { get; set; }

        [JsonIgnore]
        public CertificationProvider CertificationProvider { get; set; }

    }
}