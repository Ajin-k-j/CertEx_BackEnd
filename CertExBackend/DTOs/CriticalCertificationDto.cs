namespace CertExBackend.DTOs
{
    public class CriticalCertificationDto
    {
        public int Id { get; set; }
        public int CertificationId { get; set; }
        public int FinancialYearId { get; set; }
        public int RequiredCount { get; set; }
    }
}
