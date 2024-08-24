namespace CertExBackend.DTOs
{
    public class CertificationExamDto
    {
        public int Id { get; set; }
        public string CertificationName { get; set; }
        public string NominationStatus { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public int Views { get; set; }
        public string OfficialLink { get; set; }
        public decimal CostUsd { get; set; }
        public decimal CostInr { get; set; }
        public DateTime? NominationOpenDate { get; set; }
        public DateTime? NominationCloseDate { get; set; }
        public string ProviderName { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
