using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace CertExBackend.DTOs
{
    public class ActionFlowMyCertificationDto
    {
        public string Filename { get; set; }
        public string Url { get; set; }
        [NotMapped]
        [JsonIgnore]
        public IFormFile File { get; set; } // This will handle the file upload

        public DateTime FromDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Credentials { get; set; }
    }
}

