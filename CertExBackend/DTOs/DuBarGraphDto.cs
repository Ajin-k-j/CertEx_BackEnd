using System;
namespace CertExBackend.DTOs
{
    public class DuBarGraphDto
    {
        public string ExamStatus { get; set; }
        public DateTime? ExamDate { get; set; }
        public string DepartmentName { get; set; } = "DU1";
        public string ProviderName { get; set; }
    }
}
