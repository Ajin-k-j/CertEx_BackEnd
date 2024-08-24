namespace CertExBackend.DTOs
{
    public class MyCertificationDto
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public string Url { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Credentials { get; set; }
    }
}
