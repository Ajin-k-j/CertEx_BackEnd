using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CertExBackend.Model
{
    public class CertificationProvider
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProviderName { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        // Navigation property for CertificationExams
        [JsonIgnore]
        public ICollection<CertificationExam> CertificationExams { get; set; }
    }
}
