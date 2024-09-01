namespace CertExBackend.DTOs
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public int? DepartmentHeadId { get; set; } // Nullable to account for departments without a head
    }
}
