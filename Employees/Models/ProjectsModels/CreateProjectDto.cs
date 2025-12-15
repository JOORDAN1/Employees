using System.ComponentModel.DataAnnotations;

namespace Employees.Models.ProjectsModels;

public class CreateProjectDto
{
    [Required] [MaxLength(50)] 
    public string Name { get; set; }

    [MaxLength(200)] 
    public string Description { get; set; }
}