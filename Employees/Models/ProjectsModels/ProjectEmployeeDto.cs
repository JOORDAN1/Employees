using System.ComponentModel.DataAnnotations;

namespace Employees.Models.ProjectsModels;

public class ProjectEmployeeDto
{
    [Required] [MaxLength(20)]
    public string FirstName { get; set; }
    
    [Required] [MaxLength(30)]
    public string LastName { get; set; }
}