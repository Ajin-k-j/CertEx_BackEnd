using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CertExBackend.Model
{
    public class AwsAdmin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Nomination")]
        public int NominationId { get; set; }

        [Required]
        public string Credentials { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; } = "system";
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string UpdatedBy { get; set; } = "system";

        // Navigation property
        [JsonIgnore]
        public Nomination Nomination { get; set; }
    }
}
