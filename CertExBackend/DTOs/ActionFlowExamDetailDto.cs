namespace CertExBackend.DTOs
{
    public class ActionFlowExamDetailDto
    {
        public int Id { get; set; } // Primary Key
        public int NominationId { get; set; } // To map with ExamDetail
        public int MyCertificationId { get; set; } // To map with ExamDetail
        public string InvoiceNumber { get; set; }
        public IFormFile InvoiceFile { get; set; } // To accept file input
        public string Url { get; set; } // To store the file URL in the DB
        public decimal CostInrWithoutTax { get; set; }
        public decimal CostInrWithTax { get; set; }
  
    }
}
