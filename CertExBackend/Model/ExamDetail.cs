using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CertExBackend.Model
{
    public class ExamDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Nomination")]
        public int NominationId { get; set; }

        [Required]
        [ForeignKey("MyCertification")]
        public int MyCertificationId { get; set; }

        public decimal CostInrWithoutTax { get; set; }
        public decimal CostInrWithTax { get; set; }
        [MaxLength(100)]
        public string InvoiceNumber { get; set; }
        [MaxLength(200)]
        public string InvoiceUrl { get; set; }

        [MaxLength(20)]
        public string UploadCertificateStatus { get; set; } // Uploaded, Not Uploaded

        [MaxLength(20)]
        public string SkillMatrixStatus { get; set; } // Updated, Not Updated

        [MaxLength(20)]
        public string ReimbursementStatus { get; set; } // Complete, Not Complete

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        // Navigation properties
        [JsonIgnore]
        public Nomination Nomination { get; set; }

        [JsonIgnore]
        public MyCertification MyCertification { get; set; }
    }
}
