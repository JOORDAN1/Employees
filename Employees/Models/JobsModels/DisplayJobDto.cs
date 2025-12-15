using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.Models.JobsModels;

public class DisplayJobDto
{
    [Key]
    public int Id { get; set; }
    
    [Required] [MaxLength(50)]
    public string Name { get; set; }
    
    [Required] [MaxLength(200)]
    public string Description { get; set; }
}