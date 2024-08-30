namespace CertExBackend.DTOs
{
    public class EmployeeCertificationDto
    {
        public int CertificationId { get; set; }
        public string CertificationName { get; set; }
        public string ProviderName { get; set; }
        public string Level { get; set; }
        public string Category { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
