namespace CertExBackend.DTOs
{
    public class FinancialYearDto
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Status { get; set; } // Active, Inactive
    }
}
