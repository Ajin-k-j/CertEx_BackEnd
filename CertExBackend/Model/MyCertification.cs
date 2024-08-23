using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CertExBackend.Model
{
    public class MyCertification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Filename { get; set; }

        [Required]
        [MaxLength(500)]
        public string Url { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public string Credentials { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        // Navigation property for ExamDetails
        [JsonIgnore]
        public ICollection<ExamDetail> ExamDetails { get; set; }
    }
}
