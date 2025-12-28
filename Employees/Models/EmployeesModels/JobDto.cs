using System.ComponentModel.DataAnnotations;

namespace Employees.Models;

public class JobDto
{
    [Required] [MaxLength(50)]
    public string Name { get; set; }
    
    [Required] [MaxLength(200)]
    public string Description { get; set; }
    
}