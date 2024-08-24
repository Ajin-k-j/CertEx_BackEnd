using System.ComponentModel.DataAnnotations;

namespace CertExBackend.DTOs
{
    public class AwsAdminDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int NominationId { get; set; }

        [Required]
        public string Credentials { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string UpdatedBy { get; set; }
    }
}
