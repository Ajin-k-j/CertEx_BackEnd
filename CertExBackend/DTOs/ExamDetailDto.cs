namespace CertExBackend.DTOs
{
    public class ExamDetailDto
    {
        public int Id { get; set; }
        public int NominationId { get; set; }
        public int MyCertificationId { get; set; }
        public decimal CostInrWithoutTax { get; set; }
        public decimal CostInrWithTax { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceUrl { get; set; }
        public string UploadCertificateStatus { get; set; }
        public string SkillMatrixStatus { get; set; }
        public string ReimbursementStatus { get; set; }
    }
}
