using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.Entities;

[Table("Employees")]
public class Employee : BaseEntity
{
    [Required] [MaxLength(20)]
    public string FirstName { get; set; }
    
    [Required] [MaxLength(30)]
    public string LastName { get; set; }
    
    [Required] [MaxLength(50)]
    public string Email { get; set; }
    
    public virtual IEnumerable<EmployeeProject> EmployeeProjects { get; set; }
    public virtual IEnumerable<Job> Jobs { get; set; }
}   