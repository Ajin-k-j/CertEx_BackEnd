using System;
namespace CertExBackend.DTOs
{
    public class LndBarGraphDTO
    {
        public string ExamStatus { get; set; }
        public DateTime? ExamDate { get; set; }
        public string DepartmentName { get; set; }
        public string ProviderName { get; set; }
    }
}
