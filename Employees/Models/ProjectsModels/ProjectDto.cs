using System.ComponentModel.DataAnnotations;
using Employees.Entities;

namespace Employees.Models.ProjectsModels;

public class ProjectDto
{
    [Key]
    public int Id { get; set; }
    
    [Required] [MaxLength(50)] 
    public string Name { get; set; }

    [MaxLength(200)] 
    public string Description { get; set; }

    public IEnumerable<ProjectEmployeeDto> Employees { get; set; }
}