using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CertExBackend.Model
{
    public class CategoryTag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string CategoryTagName { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        // Navigation property for CertificationTags
        [JsonIgnore]
        public ICollection<CertificationTag> CertificationTags { get; set; }
    }
}
