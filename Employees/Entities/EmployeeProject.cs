using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.Entities;

[Table("EmployeeProjects")]
public class EmployeeProject : BaseEntity
{
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }

    public int ProjectId { get; set; }
    public Project Project { get; set; }
}