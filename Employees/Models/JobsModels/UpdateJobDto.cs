using System.ComponentModel.DataAnnotations;
using Employees.Models.ProjectsModels;

namespace Employees.Models.JobsModels;

public class UpdateJobDto
{
    [Required] [MaxLength(50)]
    public string Name { get; set; }
    
    [Required] [MaxLength(200)]
    public string Description { get; set; }
    
    public int? EmployeeId { get; set; }
}