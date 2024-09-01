namespace CertExBackend.DTOs
{
    public class ActionFlowExamDetailDto
    {
        public string InvoiceNumber { get; set; }
        public string InvoiceUrl { get; set; }
        public decimal CostInrWithoutTax { get; set; }
        public decimal CostInrWithTax { get; set; }
    }
}

