using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CertExBackend.Model
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string DepartmentName { get; set; }

        // New field for Department Head
        [ForeignKey("DepartmentHead")]
        public int? DepartmentHeadId { get; set; }

        // Navigation property for Department Head
        [JsonIgnore]
        public Employee DepartmentHead { get; set; }

        // Navigation property for Employees
        [JsonIgnore]
        public ICollection<Employee> Employees { get; set; }
    }
}
