using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.Entities;

[Table("Projects")]
public class Project : BaseEntity
{
    [Required] [MaxLength(50)] 
    public string Name { get; set; }

    [MaxLength(200)] 
    public string Description { get; set; }

    
    public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
}