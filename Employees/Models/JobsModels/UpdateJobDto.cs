using System.ComponentModel.DataAnnotations;

namespace Employees.Models.JobsModels;

public class UpdateJobDto
{
    [Required] [MaxLength(50)]
    public string Name { get; set; }
    
    [Required] [MaxLength(200)]
    public string Description { get; set; }
}