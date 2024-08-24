using System.ComponentModel.DataAnnotations;
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

        // Navigation property for Employees
        [JsonIgnore]
        public ICollection<Employee> Employees { get; set; }
    }

}
