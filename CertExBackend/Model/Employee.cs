using CertExBackend.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

public class Employee
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    [ForeignKey("Department")]
    public int DepartmentId { get; set; }

    [Required]
    [ForeignKey("Role")]
    public int AppRoleId { get; set; }


    public bool AwsAccountActive { get; set; } = false; 

    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; set; }

    [MaxLength(100)]
    public string SSOEmployeeId { get; set; }

    // Self-Referencing Foreign Key
    public int? ManagerId { get; set; }

    public bool IsManager { get; set; } = false; 

    public bool IsDepartmentHead { get; set; } = false; 

    [MaxLength(50)]
    public string Designation { get; set; }

    // Navigation properties
    [JsonIgnore]
    public Department Department { get; set; }

    [JsonIgnore]
    public Role Role { get; set; }

    [JsonIgnore]
    public Employee Manager { get; set; }

    [JsonIgnore]
    public ICollection<Employee> Subordinates { get; set; }

    [JsonIgnore]
    public ICollection<Nomination> Nominations { get; set; }
}
